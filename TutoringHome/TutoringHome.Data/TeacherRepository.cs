﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringHome.Data.Context;
using TutoringHome.Data.Model;

namespace TutoringHome.Data
{
    public class TeacherRepository: ITeacherRepository
    {
        #region 单例

        private static readonly ITeacherRepository _instance = new TeacherRepository();
        public static ITeacherRepository Instance
        {
            get { return _instance; }
        }

        private TeacherRepository()
        {
        }
        #endregion       
        public int Insert(TeacherInfo teacherInfo)
        {
            try
            {
                teacherInfo.CreateDateTime = DateTime.Now;
                teacherInfo.ModifyDateTime = DateTime.Now;
                using (var ctx = new TeacherInfoContext("DataConnection"))
                {
                    ctx.TeacherInfo.Add(teacherInfo);
                    ctx.SaveChanges();
                    //获取这个数据，得到Id
                    return teacherInfo.ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(TeacherInfo teacherInfo,int id)
        {
            try
            {
                teacherInfo.ModifyDateTime = DateTime.Now;
                using (var ctx = new TeacherInfoContext("DataConnection"))
                {
                    ctx.Entry(teacherInfo).State = EntityState.Modified;
                    ctx.SaveChanges();
                    return id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TeacherInfo Get(string teacherInfoId)
        {
            try
            {
                using (var ctx = new TeacherInfoContext("DataConnection"))
                {
                    var result = ctx.Database.SqlQuery<TeacherInfo>("SELECT * FROM  [TeacherInfoes] WHERE ID =" + teacherInfoId);
                    return result?.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TeacherInfo> GetList(SearchParams sp)
        {
            List<TeacherInfo> list = new List<TeacherInfo>();
            try
            {
                string sqlStr = string.Empty;
                string className = "一年级";
                if (!string.IsNullOrEmpty(sp.ClassName))
                {
                    className = sp.ClassName;
                }
                List<string> addParamsList = new List<string>();
                foreach (var item in sp.SubjectName)
                {
                    addParamsList.Add(string.Format(" [Subject] like '%{0}-{1}%' ", className, item));
                }
                if (addParamsList.Count > 0)
                {
                    sqlStr = "SELECT *  FROM  [TutoringHome].[dbo].[TeacherInfoes] WHERE " + string.Join(" OR ", addParamsList);
                }
                else
                {
                    sqlStr = string.Format("SELECT *  FROM  [TutoringHome].[dbo].[TeacherInfoes] WHERE [Subject] like '%{0}%'", className);
                }
                using (var ctx = new TeacherInfoContext("DataConnection"))
                {
                    var result = ctx.Database.SqlQuery<TeacherInfo>(sqlStr);
                    foreach (var item in result)
                    {
                        TeacherInfo info = new TeacherInfo
                        {
                            ID = item.ID,
                            Name = item.Name,
                            Sex = item.Sex,
                            Age = item.Age,
                            Graduate = item.Graduate,
                            Major=item.Major,
                            Subject=item.Subject,
                            Experience = item.Experience,
                            Evaluation=item.Evaluation,
                            Domicile=item.Domicile,
                            Mobile=item.Mobile,
                            WorkTime=item.WorkTime,
                            CreateDateTime=item.CreateDateTime,
                            ModifyDateTime=item.ModifyDateTime
                        };
                        list.Add(info);
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetCount(SearchParams sp)
        {
            try
            {
                string sqlStr = string.Empty;
                string className = "一年级";
                if (!string.IsNullOrEmpty(sp.ClassName))
                {
                    className = sp.ClassName;
                }
                List<string> addParamsList = new List<string>();
                
                foreach (var item in sp.SubjectName)
                {
                    addParamsList.Add(string.Format(" [Subject] like '%{0}-{1}%' ", className, item));
                }
                if (addParamsList.Count > 0)
                {
                    sqlStr = "SELECT COUNT(*) FROM  [TutoringHome].[dbo].[TeacherInfoes] WHERE " + string.Join(" OR ", addParamsList);
                }
                else
                {
                    sqlStr = string.Format("SELECT COUNT(*) FROM  [TutoringHome].[dbo].[TeacherInfoes] WHERE [Subject] like '%{0}%'", className);
                }
                using (var ctx = new TeacherInfoContext("DataConnection"))
                {
                    var result = ctx.Database.SqlQuery<int>(sqlStr);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
