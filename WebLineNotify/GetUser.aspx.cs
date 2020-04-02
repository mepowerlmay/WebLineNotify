using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebLineNotify
{
    public partial class GetUser : System.Web.UI.Page
    {
        #region 申請LINE Notify給的資料
        private string _clientid = "NVDM7jNrJyDvSrPr3fOJVK";
        private string _redirecturi = "http://localhost:60964/GetUser.aspx";
        private string _clientsecret = "O4msxOOefrjHE5BevPtLHpmmC9Ji71f0HtUujuKLxAx";
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            //取出使用者code執行轉換


            if (!IsPostBack)
            {
                string userCode = Request.QueryString["code"];
                if (userCode != null)
                {
                    string msg = GetTokenFromCode(userCode).ToString();
                    lblMessage.Text = msg;
                }
            }
            else
            {
                //string userCode = Request.QueryString["code"];
                //if (userCode != null)
                //{
                //    string msg = GetTokenFromCode(userCode).ToString();
                //    lblMessage.Text = msg;
                //}
            }

            


             
          
        }

        #region 取得使用者code
        protected void BtnAgree_Click(object sender, EventArgs e)
        {
            var URL = "https://notify-bot.line.me/oauth/authorize?";
            URL += "response_type=code";
            URL += "&client_id=" + _clientid;
            URL += "&redirect_uri=" + _redirecturi;
            URL += "&scope=notify";
            URL += "&state=abcde";
            Response.Redirect(URL); //導回網頁


       


        }
        #endregion

        #region Code取得Token
        private object GetTokenFromCode(string Code)
        {
            string Url = "https://notify-bot.line.me/oauth/token";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);

            request.Method = "POST";
            request.KeepAlive = true; //是否保持連線
            request.ContentType = "application/x-www-form-urlencoded";
            string posturi = "";
            posturi += "grant_type=authorization_code";
            posturi += "&code=" + Code; //Authorize code
            posturi += "&redirect_uri=" + _redirecturi;
            posturi += "&client_id=" + _clientid;
            posturi += "&client_secret=" + _clientsecret;

            byte[] bytes = Encoding.UTF8.GetBytes(posturi);//轉byte[]

            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();//回傳JSON
            responseString = "[" + responseString + "]";
            response.Close();

            var token = JsonConvert.DeserializeObject<JArray>(responseString)[0]["access_token"].ToString();
            try
            {
                Session["LineOption"] = false;
                return "連結成功,token:" +"<br />"+ token;

              
            }
            catch (Exception ex)
            {
                return "連結失敗:" + ex.ToString();
            }
        }
        #endregion
    }
}