using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using TutoringHome.Data;
using TutoringHome.Data.Model;
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
            ViewBag.WorkTimeList = EnumHelper.GetSelectList<WorkTimeEnum>();
            return View();
        }
        [HttpPost]
        public ActionResult Save(TeacherInfoModel teacherInfo)
        {
            string redirectUrl = "";
            try
            {
                if (string.IsNullOrEmpty(teacherInfo.Name) || (int)teacherInfo.Sex == 0 || (teacherInfo.Age < 15 && teacherInfo.Age >= 70) || string.IsNullOrEmpty(teacherInfo.Graduate) || string.IsNullOrEmpty(teacherInfo.Subject)
                || string.IsNullOrEmpty(teacherInfo.Major) || string.IsNullOrEmpty(teacherInfo.Mobile) || string.IsNullOrEmpty(teacherInfo.Domicile) || string.IsNullOrEmpty(teacherInfo.Experience))
                {
                    return Content("<script>alert('存在必填项为空')</Script>");
                }
                TeacherInfo info = new TeacherInfo()
                {
                    Name = teacherInfo.Name,
                    Sex = (int)teacherInfo.Sex,
                    Age = teacherInfo.Age,
                    Graduate = teacherInfo.Graduate,
                    Major = teacherInfo.Major,
                    WorkTime = (int)teacherInfo.WorkTime,
                    Mobile = teacherInfo.Mobile,
                    Domicile = teacherInfo.Domicile,
                    Evaluation = teacherInfo.Evaluation,
                    Experience = teacherInfo.Experience,
                    Subject = teacherInfo.Subject
                };
                var teacherInfoId = TeacherRepository.Instance.Insert(info);
                if (teacherInfoId <= 0)
                {
                    Content("<script>alert('保存数据失败')</script>");
                }
                redirectUrl = string.Format("http://tutoringhome.163vps.cn/TutorCandidates/Detail?teacherInfoId={0}", teacherInfoId);
            }
            catch (Exception)
            {
                Content("<script>alert('保存失败')</script>");
            }
            
            return Content("<script>alert('保存成功');window.location.href='" + redirectUrl + "'</script>");
        }
        [HttpPost]
        public ActionResult Update(TeacherInfoModel teacherInfo,int id)
        {
            string redirectUrl = "";
            try
            {
                if (string.IsNullOrEmpty(teacherInfo.Name) || (int)teacherInfo.Sex == 0 || (teacherInfo.Age < 15 && teacherInfo.Age >= 70) || string.IsNullOrEmpty(teacherInfo.Graduate) || string.IsNullOrEmpty(teacherInfo.Subject)
                || string.IsNullOrEmpty(teacherInfo.Major) || string.IsNullOrEmpty(teacherInfo.Mobile) || string.IsNullOrEmpty(teacherInfo.Domicile) || string.IsNullOrEmpty(teacherInfo.Experience))
                {
                    return Content("<script>alert('存在必填项为空')</Script>");
                }
                TeacherInfo oldTeacherInfo = TeacherRepository.Instance.Get(Convert.ToString(id));
                TeacherInfo info = new TeacherInfo()
                {
                    Name = teacherInfo.Name,
                    Sex = (int)teacherInfo.Sex,
                    Age = teacherInfo.Age,
                    Graduate = teacherInfo.Graduate,
                    Major = teacherInfo.Major,
                    WorkTime = (int)teacherInfo.WorkTime,
                    Mobile = teacherInfo.Mobile,
                    Domicile = teacherInfo.Domicile,
                    Evaluation = teacherInfo.Evaluation,
                    Experience = teacherInfo.Experience,
                    Subject = teacherInfo.Subject,
                    CreateDateTime = oldTeacherInfo.CreateDateTime,
                    ModifyDateTime = oldTeacherInfo.ModifyDateTime,
                    ID = id
                };
                var teacherInfoId = TeacherRepository.Instance.Update(info,id);
                if (teacherInfoId <= 0)
                {
                    Content("<script>alert('更新数据失败')</script>");
                }
                redirectUrl = string.Format("http://tutoringhome.163vps.cn/TutorCandidates/Detail?teacherInfoId={0}", teacherInfoId);
            }
            catch (Exception)
            {
                Content("<script>alert('更新失败')</script>");
            }

            return Content("<script>alert('更新成功');window.location.href='" + redirectUrl + "'</script>");
        }
        [HttpGet]
        public ActionResult Detail(string teacherInfoId)
        {
            ViewBag.TimeStamp = Guid.NewGuid().ToString();
            ViewBag.TeacherInfoId = teacherInfoId;
            TeacherInfo teacherInfo = TeacherRepository.Instance.Get(teacherInfoId);
            TeacherInfoModel teacherInfoModel = new TeacherInfoModel();
            if (teacherInfo != null)
            {
                teacherInfoModel.Domicile = teacherInfo.Domicile;
                teacherInfoModel.Evaluation = teacherInfo.Evaluation;
                teacherInfoModel.Experience = teacherInfo.Experience;
                teacherInfoModel.Graduate = teacherInfo.Graduate;
                teacherInfoModel.Major = teacherInfo.Major;
                teacherInfoModel.Mobile = teacherInfo.Mobile;
                teacherInfoModel.Sex = (SexEnum)teacherInfo.Sex;
                teacherInfoModel.Subject = teacherInfo.Subject;
                teacherInfoModel.Age = teacherInfo.Age;
                teacherInfoModel.Name = teacherInfo.Name;
                teacherInfoModel.WorkTime = (WorkTimeEnum)teacherInfo.WorkTime;
                teacherInfoModel.CreateDateTime = teacherInfo.CreateDateTime;
                teacherInfoModel.ModifyDateTime = teacherInfo.ModifyDateTime;
            }
            return View(teacherInfoModel);
        }
    }
}