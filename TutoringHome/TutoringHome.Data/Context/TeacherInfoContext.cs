using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringHome.Data.Model;

namespace TutoringHome.Data.Context
{
    public class TeacherInfoContext : DbContext
    {
        public TeacherInfoContext(string connectionName)
            : base(connectionName)
        {
        }
        public DbSet<TeacherInfo> TeacherInfo
        {
            get;
            set;
        }
    }

    public class TutoringContextFactory : IDbContextFactory<TeacherInfoContext>
    {
        public TeacherInfoContext Create()
        {
            return new TeacherInfoContext("TutoringHome");
        }
    }
}
