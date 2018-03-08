using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutoringHome.Data;
using TutoringHome.Data.Model;
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
            var pager = new Pager();
            List<TeacherInfo> rst = new List<TeacherInfo>();
            SearchParams sp = new SearchParams();
            sp.ClassName = className;
            sp.SubjectName = subjectName;
            sp.PageIndex = pageIndex + 1;
            sp.PageSize = pager.PageSize;
            ViewBag.SubjectNameList = EnumHelper.GetSelectList<SubjectEnum>();
            ViewBag.ClassNameList = EnumHelper.GetSelectList<ClassNameEnum>();

            pager.Count = TeacherRepository.Instance.GetCount(className, subjectName);
            rst = TeacherRepository.Instance.GetList(className, subjectName, pageIndex);
            
            pager.PageIndex = pageIndex;

            ViewBag.ClassName = className;
            ViewBag.SubjectName = subjectName;
            ViewBag.PagerRecord = pager;
            ViewBag.ListData = rst;
            return View();
        }
    }
}