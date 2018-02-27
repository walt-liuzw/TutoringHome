using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using TutoringHome.Web.CommonEnum;

namespace TutoringHome.Web.Models
{
    [DataContract]
    public class TeacherInfoModel
    {
        [DataMember]
        [Required(ErrorMessage = "请输入姓名")]
        public string Name { get; set; }
        [DataMember]
        [Required(ErrorMessage = "请选择性别")]
        public SexEnum Sex { get; set; }
        [DataMember]
        [Required(ErrorMessage = "请输入年龄")]
        public int Age { get; set; }
        [DataMember]
        [Required(ErrorMessage = "请输入毕业院校")]
        public string Graduate { get; set; }
        [DataMember]
        [Required(ErrorMessage = "请输入专业")]
        public string Major { get; set; }
        [DataMember]
        [Required(ErrorMessage = "请输入擅长年级与科目")]
        public string Subject { get; set; }
        [DataMember]
        [Required(ErrorMessage = "请输入教育经验")]
        public string Experience { get; set; }
        [DataMember]
        [Required(ErrorMessage = "请输入自我评价")]
        public string Evaluation { get; set; }
        [DataMember]
        [Required(ErrorMessage = "请输入现在居住地")]
        public string Domicile { get; set; }
        [DataMember]
        [Required(ErrorMessage = "请输入联系电话")]
        public string Mobile { get; set; }
    }
}