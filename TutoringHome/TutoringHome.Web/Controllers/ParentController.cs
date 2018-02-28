using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutoringHome.Web.CommonEnum;
using TutoringHome.Web.Models;

namespace TutoringHome.Web.Controllers
{
    public class ParentController : Controller
    {
        // GET: Parent
        public ActionResult GetInfoList(string className,string subjectName,int pageIndex = 0)
        {
            className = (string.IsNullOrEmpty(className)) ? string.Empty : className;
            subjectName = (string.IsNullOrEmpty(subjectName)) ? string.Empty : subjectName;
            List<TeacherInfoModel> rst = new List<TeacherInfoModel>();
            var pager = new Pager();
            SearchParams sp = new SearchParams();
            sp.ClassName = className;
            sp.SubjectName = subjectName;
            sp.PageIndex = pageIndex + 1;
            sp.PageSize = pager.PageSize;
            ViewBag.SubjectNameList = EnumHelper.GetSelectList<SubjectEnum>();
            ViewBag.ClassNameList = EnumHelper.GetSelectList<ClassNameEnum>();

            ViewData["PagerRecord"] = pager;
            ViewData["ListData"] = rst;
            return View();
        }
    }
}