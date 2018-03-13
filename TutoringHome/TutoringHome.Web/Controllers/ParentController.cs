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
            sp.ClassName = EnumHelper.GetTextByValue<ClassNameEnum>(className);
            sp.SubjectName = BuildSubjectName(subjectName.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList());
            sp.PageIndex = pageIndex + 1;
            sp.PageSize = pager.PageSize;
            ViewBag.SubjectNameList = EnumHelper.GetSelectList<SubjectEnum>();
            ViewBag.ClassNameList = EnumHelper.GetSelectList<ClassNameEnum>();

            pager.Count = TeacherRepository.Instance.GetCount(sp);
            rst = TeacherRepository.Instance.GetList(sp);
            
            pager.PageIndex = pageIndex;

            ViewBag.DDSelectValue = string.IsNullOrEmpty(className) ? "Class1" : className;
            ViewBag.SelectValue = subjectName;
            ViewBag.PagerRecord = pager;
            ViewBag.ListData = rst;
            return View();
        }
        public ActionResult Detail(string id)
        {
            var item = TeacherRepository.Instance.Get(id);
            TeacherInfoModel result = new TeacherInfoModel
            {
                ID = item.ID,
                Name = item.Name,
                Sex = (SexEnum)item.Sex,
                Age = item.Age,
                Graduate = item.Graduate,
                Major = item.Major,
                Subject = item.Subject,
                Experience = item.Experience,
                Evaluation = item.Evaluation,
                Domicile = item.Domicile,
                Mobile = item.Mobile,
                WorkTime = (WorkTimeEnum)item.WorkTime,
                CreateDateTime = item.CreateDateTime,
                ModifyDateTime = item.ModifyDateTime
            };
            return View(result);
        }
        private List<string> BuildSubjectName(List<string> list)
        {
            List<string> result = new List<string>();
            foreach (var item in list)
            {
                result.Add(EnumHelper.GetTextByValue<SubjectEnum>(item));
            }
            return result;
        }
    }
}