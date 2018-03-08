using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringHome.Data.Model
{
    public class TeacherInfo
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public string Graduate { get; set; }
        public string Major { get; set; }
        public string Subject { get; set; }
        public string Experience { get; set; }
        public string Evaluation { get; set; }
        public string Domicile { get; set; }
        public string Mobile { get; set; }
        public int WorkTime { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
    }
}
