using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WinLineNotifyTCP.DAL
{
    /// <summary>linetoken表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2019-07-28 00:38:49
    /// </summary>
    public partial class LinetokenDAL
    {
        public LinetokenDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(WinLineNotifyTCP.Model.Linetoken model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into linetoken(");
            strSql.Append("ChannelName, TokenKey, CreateTime, CreateUser, UpdateTime, IsDelete )");
            strSql.Append(" values (");
            strSql.Append("@ChannelName, @TokenKey, @CreateTime, @CreateUser, @UpdateTime, @IsDelete )");
            SQLiteHelper h = new SQLiteHelper();

            h.CreateCommand(strSql.ToString());
            if (model.ChannelName == null)
            {
                h.AddParameter("@ChannelName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ChannelName", model.ChannelName);
            }
            if (model.TokenKey == null)
            {
                h.AddParameter("@TokenKey", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TokenKey", model.TokenKey);
            }
            if (model.CreateTime == null)
            {
                h.AddParameter("@CreateTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateTime", model.CreateTime);
            }
            if (model.CreateUser == null)
            {
                h.AddParameter("@CreateUser", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateUser", model.CreateUser);
            }
            if (model.UpdateTime == null)
            {
                h.AddParameter("@UpdateTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@UpdateTime", model.UpdateTime);
            }
            if (model.IsDelete == null)
            {
                h.AddParameter("@IsDelete", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsDelete", model.IsDelete);
            }


            h.ExecuteNonQuery();
            string sql2 = "select max(id) from linetoken";
            h.CreateCommand(sql2);
            int result;
            string obj = h.ExecuteScalar();
            if (!int.TryParse(obj, out result))
            {
                return 0;
            }
            return result;
        }

        /// <summary>更新一条数据
        /// 
        /// </summary>
        public bool Update(WinLineNotifyTCP.Model.Linetoken model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update linetoken set ");
            strSql.Append("ChannelName=@ChannelName, TokenKey=@TokenKey, CreateTime=@CreateTime, CreateUser=@CreateUser, UpdateTime=@UpdateTime, IsDelete=@IsDelete  ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            if (model.ChannelName == null)
            {
                h.AddParameter("@ChannelName", DBNull.Value);
            }
            else
            {
                h.AddParameter("@ChannelName", model.ChannelName);
            }
            if (model.TokenKey == null)
            {
                h.AddParameter("@TokenKey", DBNull.Value);
            }
            else
            {
                h.AddParameter("@TokenKey", model.TokenKey);
            }
            if (model.CreateTime == null)
            {
                h.AddParameter("@CreateTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateTime", model.CreateTime);
            }
            if (model.CreateUser == null)
            {
                h.AddParameter("@CreateUser", DBNull.Value);
            }
            else
            {
                h.AddParameter("@CreateUser", model.CreateUser);
            }
            if (model.UpdateTime == null)
            {
                h.AddParameter("@UpdateTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@UpdateTime", model.UpdateTime);
            }
            if (model.IsDelete == null)
            {
                h.AddParameter("@IsDelete", DBNull.Value);
            }
            else
            {
                h.AddParameter("@IsDelete", model.IsDelete);
            }
            h.AddParameter("@id", model.Id);

            return h.ExecuteNonQuery();
        }

        /// <summary>删除一条数据
        /// 
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from linetoken ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            return h.ExecuteNonQuery();
        }

        /// <summary>根据条件删除数据
        /// 
        /// </summary>
        public bool DeleteByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from linetoken ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }

        /// <summary>得到一个对象实体
        /// 
        /// </summary>
        public WinLineNotifyTCP.Model.Linetoken GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from linetoken ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            WinLineNotifyTCP.Model.Linetoken model = null;
            DataTable dt = h.ExecuteQuery();


            model = ReaderBind(dt);
            return model;
        }

        /// <summary>根据条件得到一个对象实体
        /// 
        /// </summary>
        public WinLineNotifyTCP.Model.Linetoken GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from linetoken ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            strSql.Append(" limit 1");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            WinLineNotifyTCP.Model.Linetoken model = null;
            DataTable dt = h.ExecuteQuery();


            model = ReaderBind(dt);
            return model;
        }

        /// <summary>获得数据列表
        /// 
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM linetoken  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public DataSet GetList(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            SQLiteHelper h = new SQLiteHelper();
            DataTable dt = h.FengYe("linetoken", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        public List<WinLineNotifyTCP.Model.Linetoken> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM linetoken ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WinLineNotifyTCP.Model.Linetoken> list = new List<WinLineNotifyTCP.Model.Linetoken>();
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Model.Linetoken()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    ChannelName = row["ChannelName"].ToString(),
                    TokenKey = row["TokenKey"].ToString(),
                    CreateTime = row["CreateTime"].ToString(),
                    CreateUser = row["CreateUser"].ToString(),
                    UpdateTime = row["UpdateTime"].ToString(),
                    IsDelete = row["IsDelete"].ToString(),
                });
            }
            return list;
        }

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public List<WinLineNotifyTCP.Model.Linetoken> GetListArray(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            SQLiteHelper h = new SQLiteHelper();
            DataTable dt = h.FengYe("linetoken", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            List<WinLineNotifyTCP.Model.Linetoken> list = new List<WinLineNotifyTCP.Model.Linetoken>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Model.Linetoken()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    ChannelName = row["ChannelName"].ToString(),
                    TokenKey = row["TokenKey"].ToString(),
                    CreateTime = row["CreateTime"].ToString(),
                    CreateUser = row["CreateUser"].ToString(),
                    UpdateTime = row["UpdateTime"].ToString(),
                    IsDelete = row["IsDelete"].ToString(),
                });
            }
            return list;
        }

        /// <summary>对象实体绑定数据
        /// 
        /// </summary>
        public WinLineNotifyTCP.Model.Linetoken ReaderBind(DataTable dt)
        {
            WinLineNotifyTCP.Model.Linetoken model = new WinLineNotifyTCP.Model.Linetoken();


            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                model.Id = Convert.ToInt32(row["Id"]);
                model.ChannelName = row["ChannelName"].ToString();
                model.TokenKey = row["TokenKey"].ToString();
                model.CreateTime = row["CreateTime"].ToString();
                model.CreateUser = row["CreateUser"].ToString();
                model.UpdateTime = row["UpdateTime"].ToString();
                model.IsDelete = row["IsDelete"].ToString();
            }



            return model;
        }

        /// <summary>计算记录数
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int CalcCount(string cond)
        {
            string sql = "select count(1) from linetoken";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(sql);
            return int.Parse(h.ExecuteScalar());
        }

        /// <summary>取一个字段的值
        /// 
        /// </summary>
        /// <param name="filed">字段，如sum(je)</param>
        /// <param name="cond">条件，如userid=2</param>
        /// <returns></returns>
        public string GetOneFiled(string filed, string cond)
        {
            string sql = "select " + filed + " from linetoken";
            if (!string.IsNullOrEmpty(cond))
            {
                sql += " where " + cond;
            }
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(sql);
            return h.ExecuteScalar();
        }

        /// <summary>按条件更新数据
        /// 
        /// </summary>
        public bool UpdateByCond(string str_set, string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update linetoken set " + str_set + " ");
            strSql.Append(" where " + cond);
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }
    }
}

