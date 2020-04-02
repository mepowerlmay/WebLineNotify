using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dapper;
namespace WebLineNotify.DAL
{
    /// <summary>[AlonsoLineNotify]表数据访问类
    /// 作者:alonso(line:menshin7)
    /// 创建时间:2019-06-23 23:23:28
    /// </summary>
    public partial class AlonsoLineNotifyDAL
    {
        public AlonsoLineNotifyDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public void Add(WebLineNotify.Model.AlonsoLineNotify model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [AlonsoLineNotify](");
            strSql.Append("[ChannelToken], [ChannelName], [Message], [SendTime]  )");
            strSql.Append(" values (");
            strSql.Append("@ChannelToken, @ChannelName, @Message, @SendTime  );select @@identity;"); 
 
    using (var connection = ConnectionFactory.GetOpenConnection())
            {
                connection.Query(strSql.ToString(), model).SingleOrDefault();;
                
            }
        }

        /// <summary>更新一条数据
        /// 
        /// </summary>
        public bool Update(WebLineNotify.Model.AlonsoLineNotify model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [AlonsoLineNotify] set ");
            strSql.Append("[ChannelToken]=@ChannelToken, [ChannelName]=@ChannelName, [Message]=@Message, [SendTime]=@SendTime  ");
            strSql.Append(" where Id=@Id ");
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
            strSql.Append("update [AlonsoLineNotify] set "+str_set +" "); 
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
        public bool Delete(Guid Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [AlonsoLineNotify] ");
            strSql.Append(" where Id=@Id ");
         using (var connection = ConnectionFactory.GetOpenConnection())
            {

                int i = connection.Execute(strSql.ToString(), new { Id = Id });
                return i > 0;
            }
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [AlonsoLineNotify] ");
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
            string sql = "select " + filed + " from [AlonsoLineNotify]";
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
        public double GetOneFiledDouble(string filed, string cond)
        {
            string tmp = GetOneFiled(filed, cond);
            return string.IsNullOrEmpty(tmp) ? 0 : double.Parse(tmp);
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public WebLineNotify.Model.AlonsoLineNotify GetModel(Guid Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from [AlonsoLineNotify] ");
            strSql.Append(" where Id=@Id ");
             WebLineNotify.Model.AlonsoLineNotify model = null;
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                model = connection.Query<WebLineNotify.Model.AlonsoLineNotify>(strSql.ToString(), new { Id=Id }).SingleOrDefault();

            }
            return model;
        }

        /// <summary>根据条件得到一个对象实体
        /// 
        /// </summary>
        public WebLineNotify.Model.AlonsoLineNotify GetModelByCond(string cond )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from [AlonsoLineNotify] ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            } 
        WebLineNotify.Model.AlonsoLineNotify model = null;
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                model = connection.Query<WebLineNotify.Model.AlonsoLineNotify>(strSql.ToString()).SingleOrDefault();

            }
            return model;
        }

 

 
 

        /// <summary>获得数据列表
        /// 
        /// </summary>
        public List<WebLineNotify.Model.AlonsoLineNotify> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [AlonsoLineNotify] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WebLineNotify.Model.AlonsoLineNotify> list = new List<WebLineNotify.Model.AlonsoLineNotify>();
                  using (var connection = ConnectionFactory.GetOpenConnection())
            {
                list = connection.Query<WebLineNotify.Model.AlonsoLineNotify>(strSql.ToString()).ToList();

            }
            return list;
        }

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public List<WebLineNotify.Model.AlonsoLineNotify> GetListArray(string fileds, string orderstr, int PageSize, int PageIndex, string strWhere )
        { 
   string order = orderstr.Split(' ')[0];
            string ordertype= orderstr.Split(' ')[1];
            string cond = string.IsNullOrEmpty(strWhere) ? "" : string.Format(" where {0}",strWhere);
          string sql = string.Format("SELECT * FROM ( SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) AS pos, {2} FROM  [AlonsoLineNotify] {3}  ) AS sp WHERE pos BETWEEN {4} AND {5}",order,ordertype,fileds,cond, (((PageIndex - 1) * PageSize) + 1), PageSize * PageIndex);

		 // 	    string sql = string.Format("select {0} from [AlonsoLineNotify] {1} order by {2} offset {3} rows fetch next {4} rows only", fileds, cond, orderstr, (PageIndex - 1) * PageSize, PageSize);
          

            List<WebLineNotify.Model.AlonsoLineNotify> list = new List<WebLineNotify.Model.AlonsoLineNotify>(); 
                  using (var connection = ConnectionFactory.GetOpenConnection())
            {
                list = connection.Query<WebLineNotify.Model.AlonsoLineNotify>(sql).ToList();

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
            string sql = "select count(1) from [AlonsoLineNotify]";
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
		
		//1234
 
    }
}

