using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
using System.Data.Common;
namespace WebLineNotify.DAL
{
    /// <summary>`linemachine`表数据访问类
    /// 作者:alonso(line:menshin7)
    /// 创建时间:2019-07-13 22:29:53
    /// </summary>
    public partial class LinemachineDAL
    {
        public LinemachineDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(WebLineNotify.Model.Linemachine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into `linemachine`(");
            strSql.Append("MachineNo, AlertNo, AlertName, CreateTime, CreateUser, UpdateTime, UpdateUser, IsDelete  )");
            strSql.Append(" values (");
            strSql.Append("@MachineNo, @AlertNo, @AlertName, @CreateTime, @CreateUser, @UpdateTime, @UpdateUser, @IsDelete  )");
            strSql.Append(";select @@IDENTITY");
 
    using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int i = connection.Query<int>(strSql.ToString(), model).SingleOrDefault();
                return i;
            }
        }

        /// <summary>更新一条数据
        /// 
        /// </summary>
        public bool Update(WebLineNotify.Model.Linemachine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update `linemachine` set ");
            strSql.Append("MachineNo=@MachineNo, AlertNo=@AlertNo, AlertName=@AlertName, CreateTime=@CreateTime, CreateUser=@CreateUser, UpdateTime=@UpdateTime, UpdateUser=@UpdateUser, IsDelete=@IsDelete  ");
            strSql.Append(" where id=@id ");
       using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int i = connection.Execute(strSql.ToString(), model);
                return i > 0;
            }
        }

        /// <summary>按条件更新数据
        /// 
        /// </summary>
        public bool UpdateByCond(string str_set, string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update `linemachine` set "+str_set +" "); 
            strSql.Append(" where "+cond);
               using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int i = connection.Execute(strSql.ToString());
                return i > 0;
            }
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from `linemachine` ");
            strSql.Append(" where id=@id ");
         using (var connection = ConnectionFactory.GetOpenConnection())
            {

                int i = connection.Execute(strSql.ToString(), new { id = id });
                return i > 0;
            }
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from `linemachine` ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
                 using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int i = connection.Execute(strSql.ToString());
                return i > 0;
            }
        }
		
        /// <summary>取一个字段的值
        /// 
        /// </summary>
        /// <param name="filed">字段，如sum(je)</param>
        /// <param name="cond">条件，如userid=2</param>
        /// <returns></returns>
        public string GetOneFiled(string filed, string cond)
        {
            string sql = "select " + filed + " from `linemachine`";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
			
             using (var connection = ConnectionFactory.GetOpenConnection())
            {
                string tmp = connection.ExecuteScalar<string>(sql);
                return tmp;
            }
        }


        /// <summary>取一个字段的值
        /// 
        /// </summary>
        /// <param name="filed">字段，如sum(je)</param>
        /// <param name="cond">条件，如userid=2</param>
        /// <returns></returns>
        public List<string> GetOneFiledArray(string filed, string cond)
        {
            List<string> reuslt = new List<string>();
            string sql = "select " + filed + " from `linemachine`";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }

            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                reuslt  = connection.Query<string>(sql).ToList();
                return reuslt;
            }
        }

        /// <summary>取一个字段的值
        /// 
        /// </summary>
        /// <param name="filed">字段，如sum(je)</param>
        /// <param name="cond">条件，如userid=2</param>
        /// <returns></returns>
        public double GetOneFiledDouble(string filed, string cond)
        {
            string tmp = GetOneFiled(filed, cond);
            return string.IsNullOrEmpty(tmp) ? 0 : double.Parse(tmp);
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public WebLineNotify.Model.Linemachine GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from `linemachine` ");
            strSql.Append(" where id=@id ");
             WebLineNotify.Model.Linemachine model = null;
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                model = connection.Query<WebLineNotify.Model.Linemachine>(strSql.ToString(), new { id=id }).SingleOrDefault();

            }
            return model;
        }

        /// <summary>根据条件得到一个对象实体
        /// 
        /// </summary>
        public WebLineNotify.Model.Linemachine GetModelByCond(string cond )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from `linemachine` ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            } 
            strSql.Append(" limit 1;");
        WebLineNotify.Model.Linemachine model = null;
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                model = connection.Query<WebLineNotify.Model.Linemachine>(strSql.ToString()).SingleOrDefault();

            }
            return model;
        }

 

 
 

        /// <summary>获得数据列表
        /// 
        /// </summary>
        public List<WebLineNotify.Model.Linemachine> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM `linemachine` ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WebLineNotify.Model.Linemachine> list = new List<WebLineNotify.Model.Linemachine>();
                  using (var connection = ConnectionFactory.GetOpenConnection())
            {
                list = connection.Query<WebLineNotify.Model.Linemachine>(strSql.ToString()).ToList();

            }
            return list;
        }

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public List<WebLineNotify.Model.Linemachine> GetListArray(string fileds, string orderstr, int PageSize, int PageIndex, string strWhere )
        { 

            string cond = string.IsNullOrEmpty(strWhere) ? "" : string.Format(" where {0}",strWhere);
 
			    string sql = string.Format("select {0} from `linemachine` {1} order by {2} limit {3},{4}", fileds, cond, orderstr, (PageIndex - 1) * PageSize, PageSize);
          

            List<WebLineNotify.Model.Linemachine> list = new List<WebLineNotify.Model.Linemachine>(); 
                  using (var connection = ConnectionFactory.GetOpenConnection())
            {
                list = connection.Query<WebLineNotify.Model.Linemachine>(sql).ToList();

            }
            return list;
        }

 

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond )
        {
            string sql = "select count(1) from `linemachine`";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
         using (var connection = ConnectionFactory.GetOpenConnection())
            {
                int i = connection.Query<int>(sql).SingleOrDefault();
                return i;

            }
        }

		
 
    }
}

