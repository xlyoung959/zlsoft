﻿using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public static class OracleHelper
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["test"].ConnectionString;


        //封装ExecuteNonQuery方法    insert  update  delete
        public static int ExecuteNonQuery(string sql, CommandType cmdType, params OracleParameter[] prms)
        {
            using (OracleConnection con = new OracleConnection(conStr))
            {
                using (OracleCommand cmd = new OracleCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (prms != null)
                    {
                        cmd.Parameters.AddRange(prms);
                    }
                    con.Open();
                    try
                    {
                        return cmd.ExecuteNonQuery();

                    }
                    catch
                    {
                        return -1;
                    }
                }
            }
        }


        //返回单个值
        public static object ExecuteScalar(string sql, CommandType cmdType, params OracleParameter[] prms)
        {
            using (OracleConnection con = new OracleConnection(conStr))
            {

                using (OracleCommand cmd = new OracleCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (prms != null)
                    {
                        cmd.Parameters.AddRange(prms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        //执行返回datareader
        public static OracleDataReader ExecuteReader(string sql, CommandType cmdType, params OracleParameter[] prms)
        {
            OracleConnection con = new OracleConnection(conStr);
            using (OracleCommand cmd = new OracleCommand(sql, con))
            {
                cmd.CommandType = cmdType;
                if (prms != null)
                {
                    cmd.Parameters.AddRange(prms);
                }
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }


        public static DataTable ExecuteDataTable(string sql, CommandType cmdType, params OracleParameter[] prms)
        {
            DataTable dt = new DataTable();
            using (OracleDataAdapter adapter = new OracleDataAdapter(sql, conStr))
            {
                adapter.SelectCommand.CommandType = cmdType;
                if (prms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(prms);
                }
                adapter.Fill(dt);

            }
            return dt;
        }

    }
}