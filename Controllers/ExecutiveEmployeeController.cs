using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeSec.Models;
using CodeSec.Infrastructure;
using CodeSec.common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Logging;
using NLog;
using Microsoft.AspNetCore.DataProtection;
using System.Collections;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeSec.Controllers
{
    [Authorize(Roles = "ExecutiveEmployee")] //only the ExecutiveEmployee role can access the ExecutiveEmployee views in accordance with checklist: 6
  public class ExecutiveEmployeeController : Controller
    {

        private ICodeSecRepository repository;
        private IHttpContextAccessor contextAcc;
        private readonly ILogger<ExecutiveEmployeeController> logger;
        IDataProtector protector;

    public ExecutiveEmployeeController(ICodeSecRepository repo, IHttpContextAccessor cont, ILogger<ExecutiveEmployeeController> logger, IDataProtectionProvider provider)
        {
            repository = repo;
            contextAcc = cont;
            this.logger = logger;
            protector = provider.CreateProtector("Contoso.CodeSec.v1");
        }

    //shows view with all the sicknotes selected - Razor views are used for checklist: 7
    public ViewResult SickExecutiveEmployee(int id)
        {
            ViewBag.ID = id;
            return View(repository.Departments);
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

    //shows view with all SickNotes
        public ViewResult StartExecutiveEmployee()
        {
            var userName = contextAcc.HttpContext.User.Identity.Name;
            var mgrInfo = repository.Employees.Where(em => em.EmployeeId == userName).FirstOrDefault().DepartmentId; //gets EE department id

            ViewBag.ListOfStatuses = repository.SickNoteStatuses;
            ViewBag.ListOfDepartments = repository.Departments;

            var SickNoteList =
                from err in repository.SickNotes.Where(ed => ed.DepartmentId.Equals(mgrInfo))
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

            return View();
        }

    //shows view thanks, that shows the SickNote reported
        public ViewResult Thanks(SickNote sickNote)
        {
            sickNote = HttpContext.Session.GetJson<SickNote>("NewSickNote");
            ViewBag.refNo = repository.SaveSickNote(sickNote);
      //before the session is removed it's encrypted and saved in a log file according to checklist: 10 & partly 1,2,3 & 8
      NLog.GlobalDiagnosticsContext.Set("IpAddress", HttpContext.Connection.RemoteIpAddress);

      string logInfo = ($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} Anmälan skapad av: {sickNote.EmployeeName.ToString()}, Typ av sjukdom: {sickNote.TypeOfSickness}, IP: {HttpContext.Connection.RemoteIpAddress.ToString()} ");

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

    [ValidateAntiForgeryToken]
    public IActionResult SaveDepartment(int id, string department) //ValidateAntiForgeryToken used for forms (checklist: 7)
    {
            repository.UpdateSickNoteDepartment(id, department);
            return RedirectToAction("StartExecutiveEmployee");
        }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SortExecutiveEmployee(string submit, string status, string RegularEmployee, string empnumber) //ValidateAntiForgeryToken used for forms (checklist: 7)
    {
      var userName = contextAcc.HttpContext.User.Identity.Name;
      var mgrInfo = repository.Employees.Where(em => em.EmployeeId == userName).FirstOrDefault().DepartmentId; //gets EE department id

      ViewBag.ListOfStatuses = repository.SickNoteStatuses;
      ViewBag.ListOfEmployees = repository.Employees.Where(e => e.DepartmentId == mgrInfo);

      if (submit == "Sök" && empnumber != null && empnumber != "")
      {
        var SickNoteList =
        from err in repository.SickNotes.Where(er => er.EmployeeId == empnumber).Where( er => er.DepartmentId.Equals(mgrInfo))
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

        return View("StartExecutiveEmployee");
      }
      else if (submit == "Hämta lista" && RegularEmployee != null && RegularEmployee != "Välj alla" && status != null && status != "Välj alla")
      {
        var SickNoteList =
        from err in repository.SickNotes.Where(st => st.StatusId == status).Where(em => em.EmployeeId == RegularEmployee)
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
        return View("StartExecutiveEmployee");

      }
      else if (submit == "Hämta lista" && RegularEmployee != null && RegularEmployee != "Välj alla")
      {

        var SickNoteList =
        from err in repository.SickNotes.Where(ed => ed.DepartmentId.Equals(mgrInfo)).Where(ed => ed.EmployeeId == RegularEmployee)
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
        return View("StartExecutiveEmployee");

      }
      else if (submit == "Hämta lista" && status != null && status != "Välj alla")
      {
        var SickNoteList =
        from err in repository.SickNotes.Where(ed => ed.DepartmentId.Equals(mgrInfo)).Where(er => er.StatusId == status)
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
        return View("StartExecutiveEmployee");
      }
      else
      {
        return RedirectToAction("StartExecutiveEmployee");
      }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SaveInfoEntered(int id, string events, string information, string status) //ValidateAntiForgeryToken used for forms (checklist: 7)
    {
      var SickNote = repository.GetSickNoteInfo(id);
      if (status != "" && status != "Välj")
      {
        repository.UpdateSickNoteStatus(id, status);
      }

      if (events != "")
      {
        repository.UpdateRegularEmployeeAction(id, events);
      }

      if (information != "")
      {
        repository.UpdateRegularEmployeeInfo(id, information);
      }

      return RedirectToAction("StartExecutiveEmployee");
    }
  }
}
