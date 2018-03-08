using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutoringHome.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringHome.Data;
using TutoringHome.Data.Model;

namespace TutoringHome.Web.Controllers.Tests
{
    [TestClass()]
    public class TutorCandidatesControllerTests
    {
        [TestMethod()]
        public void SaveTest()
        {
            TeacherInfo info = new TeacherInfo();
            info.Domicile = "sdsfs";
            info.Evaluation = "ssdffdf";
            info.Experience = "sfdgffdhfgj";
            info.Graduate = "shshsllcn";
            info.Major = "软件工程";
            info.Mobile = "1224434546";
            info.Sex = 1;
            info.Subject = "gaiti;yui-hsdjdjn;jsjdkksd-";
            info.Age = 1;
            info.Name = "liuzhiwei";
            info.WorkTime = 1;
            TeacherRepository.Instance.Insert(info);
        }
    }
}