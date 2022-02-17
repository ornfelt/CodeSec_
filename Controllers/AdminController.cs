using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeSec.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using CodeSec.common;
using System.Collections;
using Microsoft.AspNetCore.DataProtection;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeSec.Controllers
{
  //only the roles Admin can access Admin views - in accordance with checklist: 6
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private ICodeSecRepository repository;
        private IHttpContextAccessor contextAcc;
        IDataProtector protector;

    //Razor views are used for checklist: 7
    public AdminController(ICodeSecRepository repo, IHttpContextAccessor cont, IDataProtectionProvider provider)
        {
            repository = repo;
            contextAcc = cont;
            protector = provider.CreateProtector("Contoso.CodeSec.v1");
    }
        // GET: /<controller>/

        public ViewResult SickAdmin(int id)
        {
            ViewBag.ID = id;
            var userName = contextAcc.HttpContext.User.Identity.Name;
            var mgrInfo = repository.Employees.Where(em => em.EmployeeId == userName).FirstOrDefault().DepartmentId; //gets Admins department id
      ViewBag.ListOfEmployees = repository.Employees;

            return View();
        }

        public ViewResult StartAdmin()
        {
            var userName = contextAcc.HttpContext.User.Identity.Name;
            var mgrInfo = repository.Employees.Where(em => em.EmployeeId == userName).FirstOrDefault().DepartmentId; //gets Admins department id

            ViewBag.ListOfStatuses = repository.SickNoteStatuses;
            ViewBag.ListOfEmployees = repository.Employees.Where(e => e.DepartmentId == mgrInfo);
            ViewBag.ListOfDepartments = repository.Departments;

      var SickNoteList =
                from err in repository.SickNotes
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

        [HttpPost]
    [ValidateAntiForgeryToken] 
    public IActionResult SaveRegularEmployee(int id, string RegularEmployee, string reason, bool noAction) //ValidateAntiForgeryToken used for forms (checklist: 7)
        {
            repository.UpdateRegularEmployee(id, RegularEmployee, reason, noAction);
            return RedirectToAction("StartAdmin");
        }

        

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SortAdmin(string submit, string status, string department, string casenumber)
    {
      ViewBag.ListOfStatuses = repository.SickNoteStatuses;
      ViewBag.ListOfDepartments = repository.Departments;

      if (submit == "Sök" && casenumber != null && casenumber != "")
      {
        var SickNoteList =
        from err in repository.SickNotes.Where(er => er.RefNumber == casenumber)
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

        return View("StartAdmin");
      }
      else if (submit == "Hämta lista" && department != null && department != "Välj alla" && status != null && status != "Välj alla")
      {
        var SickNoteList =
        from err in repository.SickNotes.Where(ed => ed.DepartmentId.Equals(department)).Where(er => er.StatusId == status)
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
        return View("StartAdmin");

      }
      else if (submit == "Hämta lista" && department != null && department != "Välj alla")
      {
        var SickNoteList =
        from err in repository.SickNotes.Where(ed => ed.DepartmentId.Equals(department))
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
        return View("StartAdmin");

      }
      else if (submit == "Hämta lista" && status != null && status != "Välj alla")
      {

        var SickNoteList =
        from err in repository.SickNotes.Where(er => er.StatusId == status)
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
        return View("StartAdmin");
      }
      else
      {
        return RedirectToAction("StartAdmin");
      }
    }

    public ViewResult AdminLogs()
    {
      IO io = new IO(protector);
      String logText = io.PrintText();

      
      ViewBag.LogInfo = logText;
      return View();
    }
  }
}
