using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeSec.Models;
using Microsoft.AspNetCore.Http;
using System.Net;
using CodeSec.Infrastructure;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeSec.Controllers
{
    public class CitizenController : Controller
    {
        private ICodeSecRepository repository;

    //Razor views are used for checklist: 7
    public CitizenController(ICodeSecRepository repo)
        {
            repository = repo;
        }

        // GET: /<controller>/
        public IActionResult Contact()
        {
            return View();
        }

        public ViewResult Faq()
        {
            return View();
        }

        public ViewResult Services()
        {
            return View();
        }

      //shows thanks view, the SickNote is sent with the view, and the session is removed
        public ViewResult Thanks(SickNote SickNote)
        {
            SickNote = HttpContext.Session.GetJson<SickNote>("NewSickNote");
            ViewBag.refNo = repository.SaveSickNote(SickNote);

            HttpContext.Session.Remove("NewSickNote");
            return View(SickNote);
        }

    //shows validate view, a new session is created if the modelstate is valid
        public ViewResult Validate(SickNote SickNote)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetJson("NewSickNote", SickNote);
                return View(SickNote);
            }
            else
            {
                return View();
            }
        }
    }
}
