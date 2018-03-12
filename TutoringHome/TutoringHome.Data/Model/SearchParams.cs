using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutoringHome.Data.Model
{
    public class SearchParams
    {
        public string ClassName { get; set; }
        public List<string> SubjectName { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页数据条数       
        /// </summary>
        public int PageSize { get; set; }
    }
}
