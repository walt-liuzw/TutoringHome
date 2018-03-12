using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringHome.Data.Model;

namespace TutoringHome.Data
{
    public interface ITeacherRepository
    {
        int Insert(TeacherInfo teacherInfo);
        TeacherInfo Get(string teacherInfoId);
        int Update(TeacherInfo teacherInfo,int id);
        List<TeacherInfo> GetList(SearchParams sp);
        int GetCount(SearchParams sp);
    }
}
