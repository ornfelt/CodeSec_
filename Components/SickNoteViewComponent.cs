using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeSec.Models;

namespace CodeSec.Components
{
    public class SickNoteViewComponent:ViewComponent //inherits from base class
    {
        private ICodeSecRepository repository;

        public SickNoteViewComponent(ICodeSecRepository repo)
        {
            repository = repo;
        }
    /*
     * Task that is called from cshtml that shows deatails for the SickNote clicked on
     */
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
      string departmentName = null;
      string employeeName = null;
            var objectOfSickNote = await repository.GetSickNoteDetail(id);
            var statusName = repository.SickNoteStatuses.Where(es => es.StatusId == objectOfSickNote.StatusId).FirstOrDefault().StatusName; //gets statusname for SickNote
      if (objectOfSickNote.DepartmentId != null)
      {
        var depName = repository.Departments.Where(de => de.DepartmentId == objectOfSickNote.DepartmentId).FirstOrDefault().DepartmentName; //gets departmentname for SickNote
        departmentName = depName;
      }
      if(objectOfSickNote.EmployeeId != null && objectOfSickNote.EmployeeId != "ej tillsatt")
      {
        //gets employeename for SickNote
        var empName = repository.Employees.Where(em => em.EmployeeId == objectOfSickNote.EmployeeId).FirstOrDefault().EmployeeName;
        employeeName = empName;
      }

            ViewBag.SickNoteConnecter = new SickNoteConnect
            {
                DateOfSickness = objectOfSickNote.DateOfSickness,
                SickNoteId = objectOfSickNote.SickNoteID,
                RefNumber = objectOfSickNote.RefNumber,
                TypeOfSickness = objectOfSickNote.TypeOfSickness,
                StatusName = statusName,
                DepartmentName =
                        (objectOfSickNote.DepartmentId == null ? "ej tillsatt" : departmentName),
                EmployeeName =
                        (objectOfSickNote.EmployeeId == null ? "ej tillsatt" : employeeName)
            };

            if (repository.SamplePath(id) == ""){
                ViewBag.SampleName = "";
            }
            else
            {
                ViewBag.SampleName = repository.SamplePath(id);
            }

            if (repository.PicturePath(id) == "")
            {
                ViewBag.PictureName = "";
            }
            else
            {
                ViewBag.PictureName = repository.PicturePath(id);
            }

            return View(objectOfSickNote);
        }
    }
}
