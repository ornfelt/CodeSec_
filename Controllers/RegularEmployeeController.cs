using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeSec.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using CodeSec.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.DataProtection;
using CodeSec.common;
using System.Collections;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeSec.Controllers
{
  //only the role RegularEmployee can access RegularEmployee views - in accordance with checklist: 6
    [Authorize(Roles = "RegularEmployee")]
    public class RegularEmployeeController : Controller
    {

        private ICodeSecRepository repository;
        private IHostingEnvironment environment;
        private IHttpContextAccessor contextAcc;
    private readonly ILogger<ExecutiveEmployeeController> logger;
    IDataProtector protector;

    //Razor views are used for checklist: 7
    public RegularEmployeeController(ICodeSecRepository repo, IHostingEnvironment env, IHttpContextAccessor cont, ILogger<ExecutiveEmployeeController> logger, IDataProtectionProvider provider)
        {
            repository = repo;
            environment = env;
            contextAcc = cont;
      this.logger = logger;
      protector = provider.CreateProtector("Contoso.CodeSec.v1");

    }

        // GET: /<controller>/
        public ViewResult SickRegularEmployee(int id)
        {
            ViewBag.ID = id;
            ViewBag.ListOfStatuses = repository.SickNoteStatuses;
            return View();
        }

        public ViewResult StartRegularEmployee()
        {
            var userName = contextAcc.HttpContext.User.Identity.Name;
            ViewBag.ListOfStatuses = repository.SickNoteStatuses;

            var SickNoteList =
                from err in repository.SickNotes.Where(ed => ed.EmployeeId.Equals(userName))
                join stat in repository.SickNoteStatuses on err.StatusId equals stat.StatusId
                join dep in repository.Departments on err.DepartmentId equals dep.DepartmentId
                    into departmentSickNote
                from deptE in departmentSickNote.DefaultIfEmpty()
                join em in repository.Employees on err.EmployeeId equals em.EmployeeId
                    into employeeSickNote
                from empE in employeeSickNote.DefaultIfEmpty()
                orderby err.RefNumber descending
                select new SickNoteConnect
                {
                    DateOfSickness = err.DateOfSickness,
                    SickNoteId = err.SickNoteID,
                    RefNumber = err.RefNumber,
                    TypeOfSickness = err.TypeOfSickness,
                    StatusName = stat.StatusName,
                    DepartmentName =
                        (err.DepartmentId == null ? "ej tillsatt" : deptE.DepartmentName),
                    EmployeeName =
                        (err.EmployeeId == null ? "ej tillsatt" : empE.EmployeeName)
                };
            ViewBag.ListOfSickNotes = SickNoteList;

            return View(repository);
        }

        

        [HttpPost]
    [ValidateAntiForgeryToken] //connected to taghelper to protect app login from cross site request forgery via hidden field where a value is added that later needs validation in our action (checklist: 7)
    public IActionResult SortRegularEmployee(string submit, string status, string casenumber)
        {
            var userName = contextAcc.HttpContext.User.Identity.Name;
            ViewBag.ListOfStatuses = repository.SickNoteStatuses;

            if (submit == "Sök" && casenumber != null && casenumber != "")
            {
                var SickNoteList =
                from err in repository.SickNotes.Where(er => er.RefNumber == casenumber).Where(ed => ed.EmployeeId.Equals(userName))
                join stat in repository.SickNoteStatuses on err.StatusId equals stat.StatusId
                join dep in repository.Departments on err.DepartmentId equals dep.DepartmentId
                    into departmentSickNote
                from deptE in departmentSickNote.DefaultIfEmpty()
                join em in repository.Employees on err.EmployeeId equals em.EmployeeId
                    into employeeSickNote
                from empE in employeeSickNote.DefaultIfEmpty()
                orderby err.RefNumber descending
                select new SickNoteConnect
                {
                    DateOfSickness = err.DateOfSickness,
                    SickNoteId = err.SickNoteID,
                    RefNumber = err.RefNumber,
                    TypeOfSickness = err.TypeOfSickness,
                    StatusName = stat.StatusName,
                    DepartmentName =
                        (err.DepartmentId == null ? "ej tillsatt" : deptE.DepartmentName),
                    EmployeeName =
                        (err.EmployeeId == null ? "ej tillsatt" : empE.EmployeeName)
                };

                ViewBag.ListOfSickNotes = SickNoteList;

                return View("StartRegularEmployee");
            }
            else if (submit == "Hämta lista" && status != null && status != "Välj alla")
            {

                var SickNoteList =
                from err in repository.SickNotes.Where(ed => ed.EmployeeId.Equals(userName)).Where(er => er.StatusId == status)
                join stat in repository.SickNoteStatuses on err.StatusId equals stat.StatusId
                join dep in repository.Departments on err.DepartmentId equals dep.DepartmentId
                    into departmentSickNote
                from deptE in departmentSickNote.DefaultIfEmpty()
                join em in repository.Employees on err.EmployeeId equals em.EmployeeId
                    into employeeSickNote
                from empE in employeeSickNote.DefaultIfEmpty()
                orderby err.RefNumber descending
                select new SickNoteConnect
                {
                    DateOfSickness = err.DateOfSickness,
                    SickNoteId = err.SickNoteID,
                    RefNumber = err.RefNumber,
                    TypeOfSickness = err.TypeOfSickness,
                    StatusName = stat.StatusName,
                    DepartmentName =
                        (err.DepartmentId == null ? "ej tillsatt" : deptE.DepartmentName),
                    EmployeeName =
                        (err.EmployeeId == null ? "ej tillsatt" : empE.EmployeeName)
                };

                ViewBag.ListOfSickNotes = SickNoteList;
                return View("StartRegularEmployee");
            }
            else
            {
                return RedirectToAction("StartRegularEmployee");
            }
        }

    //shows view where the user can report the new sicknote
    public ViewResult ReportSickNote()
    {
      var mySickNote = HttpContext.Session.GetJson<SickNote>("NewSickNote");

      if (mySickNote == null)
      {
        return View();
      }
      else
      {
        return View(mySickNote);
      }
    }
    //shows view thanks, that shows the SickNote reported
    public ViewResult Thanks(SickNote sickNote)
    {
      sickNote = HttpContext.Session.GetJson<SickNote>("NewSickNote");
      ViewBag.refNo = repository.SaveSickNote(sickNote);
      //before the session is removed it's encrypted and saved in a log file according to checklist: 10 & partly 1,2,3 & 8
      NLog.GlobalDiagnosticsContext.Set("IpAddress", HttpContext.Connection.RemoteIpAddress);

      string logInfo = ($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} Anmälan skapad av användare: {sickNote.EmployeeName.ToString()}, Typ av sjukdom: {sickNote.TypeOfSickness}, IP: {HttpContext.Connection.RemoteIpAddress.ToString()} ");

      string protectedInfo = protector.Protect(logInfo);
      logger.LogInformation("Ny anmälan skapad: " + protectedInfo);
      IO io = new IO(protector);
      io.SaveText(logInfo);

      HttpContext.Session.Remove("NewSickNote");
      return View(sickNote);
    }

    //shows view validate and creates new session if modelstate is correct
    public ViewResult Validate(SickNote sickNote)
    {
      if (ModelState.IsValid)
      {
        HttpContext.Session.SetJson("NewSickNote", sickNote);
        return View(sickNote);
      }
      else
      {
        return View();
      }
    }
  }
}
