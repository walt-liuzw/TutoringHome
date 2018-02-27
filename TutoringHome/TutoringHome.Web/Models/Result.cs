using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TutoringHome.Web.Models
{
    [DataContract]
    public class Result
    {
        [DataMember(Name ="code")]
        public int Code { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}