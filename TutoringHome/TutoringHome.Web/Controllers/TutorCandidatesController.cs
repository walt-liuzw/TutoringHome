using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using TutoringHome.Web.CommonEnum;
using TutoringHome.Web.CommonHelper;
using TutoringHome.Web.Models;

namespace TutoringHome.Web.Controllers
{
    public class TutorCandidatesController : Controller
    {
        public static readonly string AppId = WebConfigurationManager.AppSettings["WeixinAppId"];
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TimeStamp = Guid.NewGuid().ToString();
            ViewBag.SexList = EnumHelper.GetSelectList<SexEnum>();
            
            return View();
        }
        [HttpPost]
        public ActionResult Save(TeacherInfoModel teacherInfo)
        {
            var result = new Result();
            return Json(result);
        }
        public ActionResult Update()
        {
            return View();
        }
    }
}