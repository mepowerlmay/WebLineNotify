using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLineNotify.DAL;
using WebLineNotify.Model;

namespace WebLineNotify
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private LinenotifymsgDAL linenotifymsgDAL;

        public WebForm1() {
            linenotifymsgDAL = new LinenotifymsgDAL();
          
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                anp.RecordCount = linenotifymsgDAL.CalcCount(GetCond());
                BindRep();

             
            }
        }

        private void BindRep()
        {
            GridView1.DataSource = linenotifymsgDAL.GetListArray(GetCond());
            GridView1.DataBind();
        }

        private string GetCond()
        {
            string where = "";

            return where;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {


        

            string strToken = txtToken.Text;
            string Url = "https://notify-api.line.me/api/notify";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.KeepAlive = true; //是否保持連線
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Set("Authorization", "Bearer " + strToken);
            string content = "";
            content += "message=\r\n" + txtmsg.Text;//發送的文字訊息內容



            //model.ChannelName = txtChannel.Text;
            //model.ChannelToken = strToken;
            //model.Message = txtmsg.Text;
            //model.SendTime = DateTime.Now;

         //   linenotifymsgDAL.Add(model);
            #region 傳送圖片(選擇性)
            //imgurl = tbxURL.Text.ToString();
            //content += "&imageThumbnail=" + imgurl;
            //content += "&imageFullsize=" + imgurl;
            #endregion

            byte[] bytes = Encoding.UTF8.GetBytes(content);
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            if (txtmsg.Text == "")
            {
                lblStatus.Text = "訊息內容為必填或是網路異常!!";
            }
            else
            {
                var response = (HttpWebResponse)request.GetResponse();
                txtmsg.Text = "";
                lblStatus.Text = "訊息傳送成功!!";
            }


            anp.RecordCount = linenotifymsgDAL.CalcCount(GetCond());
            BindRep();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Linenotifymsg model = new Linenotifymsg();
            //model.lineToken = txtToken.Text;
            //model.lineTokenName = txtChannel.Text;

            model.Title = "訊息通知";
            model.LineMsg = txtmsg.Text;

            model.SendTime = DateTime.Now;
            model.CreateTime = DateTime.Now;
            model.IsDelete = "0";
            model.Statu = "0";
            linenotifymsgDAL.Add(model);

        }
    }
}