using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutoringHome.Web.CommonEnum;
using TutoringHome.Web.Models;

namespace TutoringHome.Web.Controllers
{
    public class TutorCandidatesController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.SexList = EnumHelper.GetSelectList<SexEnum>();
            return View();
        }
        [HttpPost]
        public ContentResult Save()
        {
            var result = new Result();
            return Content("");
        }
        public ActionResult Update()
        {
            return View();
        }
    }
}