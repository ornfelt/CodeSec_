using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeSec.Models;

namespace CodeSec.Components
{
    public class PictureColumnViewComponent : ViewComponent
    {
        private ICodeSecRepository repository;

        public PictureColumnViewComponent(ICodeSecRepository repo)
        {
            repository = repo;
        }

        /*
        * VC that is called from cshtml showing the aside column with pictures 
        */
        public IViewComponentResult Invoke()
        {
            return View("PictureColumn");
        }
    }
}
