﻿using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Text;

namespace SnnuWebService.DAL
{
    public class Message
    {
        private SqlHelper sqlhelper = new SqlHelper(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MySqlDataReader AllDep()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct Department from Message");
            return sqlhelper.ExecuteReader(strSql.ToString());
        }
        
        public MySqlDataReader QueryByDate(DateTime start,DateTime end,string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Message");
            strSql.Append(" where Type='" + type + "' ");
            strSql.Append("and Date between '"+start.ToString("yyyy-MM-dd") +"' and '");
            strSql.Append(end.ToString("yyyy-MM-dd") + "'");
            return sqlhelper.ExecuteReader(strSql.ToString());
        }
        public MySqlDataReader QueryByDateAndDep(DateTime start, DateTime end, string dep,string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Message");
            strSql.Append(" where Type='" + type + "' ");
            strSql.Append("and " + "Department='" + dep + "' ");
            strSql.Append("and Date between '" + start.ToString("yyyy-MM-dd") + "' and '");
            strSql.Append(end.ToString("yyyy-MM-dd") + "'");
            return sqlhelper.ExecuteReader(strSql.ToString());
        }
        public MySqlDataReader QueryByLikeTitle(string keyworld,string type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Message");
            strSql.Append(" where Type='" + type + "' ");
            strSql.Append("and title like '%" + keyworld + "%'");
            return sqlhelper.ExecuteReader(strSql.ToString());
        }
        public MySqlDataReader QueryByDepartment(string dep,string type)
        {
            DateTime d = DateTime.Now;
            DateTime start = d.AddDays(-7);
            DateTime end = d.AddDays(7);
            return QueryByDateAndDep(start, end, dep, type);
        }
    }
}