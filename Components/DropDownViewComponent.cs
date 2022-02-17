using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeSec.Models;

namespace CodeSec.Components {
  public class DropDownViewComponent : ViewComponent {
    private ICodeSecRepository repository;

    public DropDownViewComponent(ICodeSecRepository repo)
    {
      repository = repo;
    }

    /*
    * VC that is called from cshtml - the VC shows the dropdown list for SickNotestatuses
    */
    public IViewComponentResult Invoke()
    {
      ViewBag.ListOfStatuses = repository.SickNoteStatuses;
      return View("DropDown");
    }
  }
}
