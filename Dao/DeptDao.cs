﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

using Oracle.DataAccess.Client;
using System.Data;

namespace Dao
{
  
    public class DeptDao
    {


    
        /// <summary>
        /// 新增组织
        /// </summary>
        /// <param name="dept">部门类</param>
        /// <returns>int操作的行数</returns>
        public int insertDept(Dept dept)
        {
            string sql = "insert into 部门表(ID,上级ID,编码,名称,简码,位置,末级,建档时间,站点,环境类别) values(deptid_seq.nextval,:parentId,:code,:name,:simCode,:location,:finalNode,to_date(:createTime,'YYYY-MM-DD'),:site,:envCat)";
            //insert into(ID,上级ID,编码,名称,简码,位置,末级,建档时间,撤档时间,站点,环境类别,部门负责人,最后修改时间,顺序,别名) 部门表 
           // values(deptid_seq.nextval,:parentId,:code,:name,:simCode,:location,:finalNode, to_date(:createTime, 'YYYY-MM-DD'), to_date(:deleteTime, 'YYYY-MM-DD'),:site,:envCat,:deptId, to_date(:lastTime, 'YYYY-MM-DD'),:sort,:otherName)
            if (dept.parentId == 0)
            {
                dept.parentId = null;
            }
            OracleParameter[] prms = new OracleParameter[]
            {
             new OracleParameter("parentId",OracleDbType.Int32,10) { Value=dept.parentId},
             new OracleParameter("code",OracleDbType.Varchar2,10) { Value=dept.code},
             new OracleParameter("name",OracleDbType.Varchar2,100) { Value=dept.name},
             new OracleParameter("simCode",OracleDbType.Varchar2,100) { Value=dept.simCode},
             new OracleParameter("location",OracleDbType.Varchar2,50) { Value=dept.location},
             new OracleParameter("finalNode",OracleDbType.Int32,1) { Value=dept.finalNode},
             new OracleParameter("createTime",OracleDbType.Varchar2,50) { Value=dept.createTime},
            //new OracleParameter("deleteTime",OracleDbType.Date) { Value=null},
             new OracleParameter("site",OracleDbType.Varchar2,1) { Value=dept.site},
             new OracleParameter("envCat",OracleDbType.Varchar2,10) { Value=dept.envCat},
            // new OracleParameter("deptId",OracleDbType.Int32,10) { Value=0},
           // new OracleParameter("lastTime",OracleDbType.Date) { Value=null},
             //new OracleParameter("sort",OracleDbType.Int32,10) { Value=null},
             //new OracleParameter("otherName",OracleDbType.Varchar2,10) { Value=null}
            };
            int r =  OracleHelper.ExecuteNonQuery(sql, CommandType.Text, prms);
            return r;
        }



        /// <summary>
        /// 修改组织
        /// </summary>
        /// <param name="dept">部门类</param>
        /// <returns>操作的行数</returns>
        public int updateDept(Dept dept)
        {
            string sql = "update 部门表 set 上级ID=:parentId,编码=:code,名称=:name,简码=:simCode,位置=:location,末级=:finalNode,站点=:site,环境类别=:entCat,最后修改时间=sysdate where ID=:Id";
            if (dept.parentId == 0)
            {
                dept.parentId =null;
            }
            OracleParameter[] prms = new OracleParameter[]
                {
                 new OracleParameter("parentId",OracleDbType.Int32,10) { Value=dept.parentId},
                 new OracleParameter("code",OracleDbType.Varchar2,10) { Value=dept.code},
                 new OracleParameter("name",OracleDbType.Varchar2,100) { Value=dept.name},
                 new OracleParameter("simCode",OracleDbType.Varchar2,100) { Value=dept.simCode},
                 new OracleParameter("location",OracleDbType.Varchar2,50) { Value=dept.location},
                 new OracleParameter("finalNode",OracleDbType.Int32,1) { Value=dept.finalNode},
                 new OracleParameter("site",OracleDbType.Varchar2,1) { Value=dept.site},
                 new OracleParameter("envCat",OracleDbType.Varchar2,10) { Value=dept.envCat},
                 
                 new OracleParameter("Id",OracleDbType.Int32,10) { Value=dept.Id}
                };
            int r = OracleHelper.ExecuteNonQuery(sql, CommandType.Text, prms);
            return r;
        }



        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int deleteDept(int id)
        {
            string sql = "delete from 部门表 where ID=:ID";
            OracleParameter[] prms = new OracleParameter[]
               {
                 new OracleParameter("ID",OracleDbType.Int32,10) { Value=id}
               };
            int r = OracleHelper.ExecuteNonQuery(sql, CommandType.Text, prms);
            return r;
        }



        /// <summary>
        /// 查询所有组织的名称，ID，上级ID
        /// </summary>
        /// <returns></returns>
        public DataTable selectDeptTree()
        {
            string sql = "select 名称 as name,ID,上级ID as parentId from 部门表";
          return  OracleHelper.ExecuteDataTable(sql, CommandType.Text, null);
        }


        /// <summary>
        /// 根据id查询组织的详细信息
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>这个组织的详细信息</returns>
        public DataTable selectDeptById(int id)
        {
            string sql = "select ID , 名称 as name,上级ID as parentId,编码 as code,简码 as simCode,位置 as location,末级 as finalNode,建档时间 as createTime,撤档时间 as deleteTime,站点 as site,环境类别 as entCat,最后修改时间 as lastTime,别名 as otherName from 部门表 where ID=:id";
            OracleParameter[] prms = new OracleParameter[]
              {
                 new OracleParameter("id",OracleDbType.Int32,10) { Value=id}
              };
            return OracleHelper.ExecuteDataTable(sql, CommandType.Text, prms);
        }
        /// <summary>
        /// 查出这个部门下的子部门有多少，如果有不能删除
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public DataTable selectDeptIdByPid(int pid)
        {
            string sql = "select ID from 部门表 where 上级ID=:pid";
            OracleParameter[] prms = new OracleParameter[]
              {
                 new OracleParameter("pid",OracleDbType.Varchar2,10) { Value=pid}
              };
            return OracleHelper.ExecuteDataTable(sql, CommandType.Text, prms);
        }

       
    }
}
