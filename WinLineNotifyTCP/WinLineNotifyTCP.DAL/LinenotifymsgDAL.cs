using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WinLineNotifyTCP.DAL
{
    /// <summary>linenotifymsg表数据访问类
    /// 作者:牛腩(QQ:164423073)
    /// 创建时间:2019-07-28 00:38:33
    /// </summary>
    public partial class LinenotifymsgDAL
    {
        public LinenotifymsgDAL()
        { }
        /// <summary>增加一条数据
        /// 
        /// </summary>
        public int Add(WinLineNotifyTCP.Model.Linenotifymsg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into linenotifymsg(");
            strSql.Append("Title, PLCMsg, LineMsg, Statu, SendTime, CreateTime, CreateUser, UpdateTime, UpdateUser, IsDelete )");
            strSql.Append(" values (");
            strSql.Append("@Title, @PLCMsg, @LineMsg, @Statu, @SendTime, @CreateTime, @CreateUser, @UpdateTime, @UpdateUser, @IsDelete )");
            SQLiteHelper h = new SQLiteHelper();

            h.CreateCommand(strSql.ToString());
            if (model.Title == null)
            {
                h.AddParameter("@Title", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Title", model.Title);
            }
            if (model.PLCMsg == null)
            {
                h.AddParameter("@PLCMsg", DBNull.Value);
            }
            else
            {
                h.AddParameter("@PLCMsg", model.PLCMsg);
            }
            if (model.LineMsg == null)
            {
                h.AddParameter("@LineMsg", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LineMsg", model.LineMsg);
            }
            if (model.Statu == null)
            {
                h.AddParameter("@Statu", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Statu", model.Statu);
            }
            if (model.SendTime == null)
            {
                h.AddParameter("@SendTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SendTime", model.SendTime);
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
            if (model.UpdateUser == null)
            {
                h.AddParameter("@UpdateUser", DBNull.Value);
            }
            else
            {
                h.AddParameter("@UpdateUser", model.UpdateUser);
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
            string sql2 = "select max(id) from linenotifymsg";
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
        public bool Update(WinLineNotifyTCP.Model.Linenotifymsg model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update linenotifymsg set ");
            strSql.Append("Title=@Title, PLCMsg=@PLCMsg, LineMsg=@LineMsg, Statu=@Statu, SendTime=@SendTime, CreateTime=@CreateTime, CreateUser=@CreateUser, UpdateTime=@UpdateTime, UpdateUser=@UpdateUser, IsDelete=@IsDelete  ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            if (model.Title == null)
            {
                h.AddParameter("@Title", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Title", model.Title);
            }
            if (model.PLCMsg == null)
            {
                h.AddParameter("@PLCMsg", DBNull.Value);
            }
            else
            {
                h.AddParameter("@PLCMsg", model.PLCMsg);
            }
            if (model.LineMsg == null)
            {
                h.AddParameter("@LineMsg", DBNull.Value);
            }
            else
            {
                h.AddParameter("@LineMsg", model.LineMsg);
            }
            if (model.Statu == null)
            {
                h.AddParameter("@Statu", DBNull.Value);
            }
            else
            {
                h.AddParameter("@Statu", model.Statu);
            }
            if (model.SendTime == null)
            {
                h.AddParameter("@SendTime", DBNull.Value);
            }
            else
            {
                h.AddParameter("@SendTime", model.SendTime);
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
            if (model.UpdateUser == null)
            {
                h.AddParameter("@UpdateUser", DBNull.Value);
            }
            else
            {
                h.AddParameter("@UpdateUser", model.UpdateUser);
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
            strSql.Append("delete from linenotifymsg ");
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
            strSql.Append("delete from linenotifymsg ");
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
        public WinLineNotifyTCP.Model.Linenotifymsg GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from linenotifymsg ");
            strSql.Append(" where id=@id ");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            h.AddParameter("@id", id);
            WinLineNotifyTCP.Model.Linenotifymsg model = null;
            DataTable dt = h.ExecuteQuery();


            model = ReaderBind(dt);
            return model;
        }

        /// <summary>根据条件得到一个对象实体
        /// 
        /// </summary>
        public WinLineNotifyTCP.Model.Linenotifymsg GetModelByCond(string cond)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from linenotifymsg ");
            if (!string.IsNullOrEmpty(cond))
            {
                strSql.Append(" where " + cond);
            }
            strSql.Append(" limit 1");
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            WinLineNotifyTCP.Model.Linenotifymsg model = null;
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
            strSql.Append(" FROM linenotifymsg  ");
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
            DataTable dt = h.FengYe("linenotifymsg", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        /// <summary>获得数据列表（比DataSet效率高，推荐使用）
        /// 
        /// </summary>
        public List<WinLineNotifyTCP.Model.Linenotifymsg> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM linenotifymsg ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<WinLineNotifyTCP.Model.Linenotifymsg> list = new List<WinLineNotifyTCP.Model.Linenotifymsg>();
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            DataTable dt = h.ExecuteQuery();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Model.Linenotifymsg()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Title = row["Title"].ToString(),
                    PLCMsg = row["PLCMsg"].ToString(),
                    LineMsg = row["LineMsg"].ToString(),
                    Statu = row["Statu"].ToString(),
                    SendTime = row["SendTime"].ToString(),
                    CreateTime = row["CreateTime"].ToString(),
                    CreateUser = row["CreateUser"].ToString(),
                    UpdateTime = row["UpdateTime"].ToString(),
                    UpdateUser = row["UpdateUser"].ToString(),
                    IsDelete = row["IsDelete"].ToString(),
                });
            }
            return list;
        }

        /// <summary>分页获取数据列表
        /// 
        /// </summary>
        public List<WinLineNotifyTCP.Model.Linenotifymsg> GetListArray(string fileds, string order, string ordertype, int PageSize, int PageIndex, string strWhere)
        {
            SQLiteHelper h = new SQLiteHelper();
            DataTable dt = h.FengYe("linenotifymsg", fileds, order, ordertype, strWhere, PageSize, PageIndex);
            List<WinLineNotifyTCP.Model.Linenotifymsg> list = new List<WinLineNotifyTCP.Model.Linenotifymsg>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Model.Linenotifymsg()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Title = row["Title"].ToString(),
                    PLCMsg = row["PLCMsg"].ToString(),
                    LineMsg = row["LineMsg"].ToString(),
                    Statu = row["Statu"].ToString(),
                    SendTime = row["SendTime"].ToString(),
                    CreateTime = row["CreateTime"].ToString(),
                    CreateUser = row["CreateUser"].ToString(),
                    UpdateTime = row["UpdateTime"].ToString(),
                    UpdateUser = row["UpdateUser"].ToString(),
                    IsDelete = row["IsDelete"].ToString(),
                });
            }
            return list;
        }

        /// <summary>对象实体绑定数据
        /// 
        /// </summary>
        public WinLineNotifyTCP.Model.Linenotifymsg ReaderBind(DataTable dt)
        {
            WinLineNotifyTCP.Model.Linenotifymsg model = new WinLineNotifyTCP.Model.Linenotifymsg();
         
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                model.Id = Convert.ToInt32( row["Id"]);
                model.Title = row["Title"].ToString();
                model.PLCMsg = row["PLCMsg"].ToString();
                model.LineMsg = row["LineMsg"].ToString();
                model.Statu = row["Statu"].ToString();
                model.SendTime = row["SendTime"].ToString();
                model.CreateTime = row["CreateTime"].ToString();
                model.CreateUser = row["CreateUser"].ToString();
                model.UpdateTime = row["UpdateTime"].ToString();
                model.UpdateUser = row["UpdateUser"].ToString();
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
            string sql = "select count(1) from linenotifymsg";
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
            string sql = "select " + filed + " from linenotifymsg";
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
            strSql.Append("update linenotifymsg set " + str_set + " ");
            strSql.Append(" where " + cond);
            SQLiteHelper h = new SQLiteHelper();
            h.CreateCommand(strSql.ToString());
            return h.ExecuteNonQuery();
        }
    }
}

