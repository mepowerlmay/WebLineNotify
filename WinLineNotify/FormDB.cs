using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebLineNotify.DAL;
using WebLineNotify.Model;
using WinLineNotify.Helper;

namespace WinLineNotify
{
    public partial class FormDB : Form
    {

        #region field

        /// <summary>
        /// line 通知 key
        /// </summary>
        private string LineToken;

        /// <summary>
        /// 是否停止
        /// </summary>
        private bool IsStop = false;

        /// <summary>
        /// 自動或手動 AT= 自動 MT = 手動
        /// </summary>
        private string TransMode = "AT";


        private string TransModeTxt { get { return TransMode == "AT" ? "自動" : "手動"; } }

        private LinenotifymsgDAL linenotifymsgDAL;
      private   LinetokenDAL linetokenDAL ;
        #endregion


        public FormDB()
        {

            linenotifymsgDAL = new LinenotifymsgDAL();
            linetokenDAL = new LinetokenDAL();

            //取的line token
            List<WebLineNotify.Model.Linetoken> result =    linetokenDAL.GetListArray("");
            LineToken = result.FirstOrDefault().TokenKey;

            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            timerPre.Stop();
            IsStop = true;
            Log.Info("程式關閉");

            this.Close();
            Application.Exit();
            Application.ExitThread();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            labTransStatu.Text = "停止";
            Log.Info("轉檔程式停止");

            timerPre.Stop();
            IsStop = true;
            btnAutoTrans.Enabled = btnExit.Enabled = btnMTrans.Enabled = true;
            txtCountTimer.Enabled = true;
        }

        private void btnAutoTrans_Click(object sender, EventArgs e)
        {
            labTransStatu.Text = "定時轉檔";
            TransMode = "AT";
            TransModelLog();

            int iSyncDays = TypeChange.StringToInt(txtCountTimer.Text);
            if (iSyncDays < 30)
            {
                txtCountTimer.Text = "30";
            }

            txtCountTimer.Enabled = false;
            IsStop = false;
            timerPre.Start();


        }

        private void btnMTrans_Click(object sender, EventArgs e)
        {
            labTransStatu.Text = "手動轉檔";
            TransMode = "MT";
            TransModelLog();

            btnAutoTrans.Enabled = btnExit.Enabled = btnMTrans.Enabled = false;
            StartdateTimePicker.Enabled = EnddateTimePicker.Enabled = false;

            timerPre.Stop();
            IsStop = false;

            TransLineMsg();
            labTransStatu.Text = "停止";

            btnAutoTrans.Enabled = btnExit.Enabled = btnMTrans.Enabled = true;
            StartdateTimePicker.Enabled = EnddateTimePicker.Enabled = true;

            txtCountTimer.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtCountTimer.Text = "30";
            txtCountTimer.Enabled = false;
            timerPre.Interval = 1000;
            timerPre.Start();

            labTransStatu.Text = "定時轉檔";      
         
            StartdateTimePicker.Value = DateTime.Now.AddDays(7 * -1);
            EnddateTimePicker.Value = DateTime.Now;

            Log.Info("程式啟動");
            TransModelLog();
        }


        /// <summary>
        /// 轉換模式紀錄
        /// </summary>
        private void TransModelLog()
        {
            string txt = "";
            if (TransMode == "MT")
            {
                txt = "手動";
            }
            else
            {
                txt = "定時";
            }
            Log.Info("轉檔程式，" + txt);
        }

        private void timerPre_Tick(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(txtCountTimer.Text);
            count--;

            txtCountTimer.Text = (count).ToString();

            if (txtCountTimer.Text == "0")
            {
                btnAutoTrans.Enabled = btnExit.Enabled = btnMTrans.Enabled = false;
                timerPre.Stop();

                TransLineMsg();

                txtCountTimer.Text = "5";
                
                labTransStatu.Text = "閒置....";

                timerPre.Start();
                btnAutoTrans.Enabled = btnExit.Enabled = btnMTrans.Enabled = true;
            }
        }


        private void TransLineMsg() {

            string where = " 1=1 ";

            var whereClausesBuilder = new WhereClausesBuilder();


            whereClausesBuilder.appendCriteriaText("0", "  Statu = '{0}' ", ref where);
            whereClausesBuilder.appendCriteriaDateText(StartdateTimePicker.Value.ToShortDateString(), EnddateTimePicker.Value.ToShortDateString(), " CreateTime  ", ref where);


            List<Linenotifymsg> result = linenotifymsgDAL.GetListArray(where);

            string resultMsg = "";

            foreach (var item in result)
            {
                resultMsg = "";

                //1,2,100,101  PLC傳入代碼順序 機台編號, 異常代碼, 設定值, 機台值

                if (string.IsNullOrEmpty(item.PLCMsg)) continue;

                string[] arrayMsg = item.PLCMsg.Split(',');
                if (arrayMsg.Length == 4)
                {
                    resultMsg = string.Format(" 機台編號:{0}, 異常代碼:{1}, 設定值:{2}, 機台值:{3}",
                        arrayMsg[0],
                        arrayMsg[1],
                        arrayMsg[2],
                        arrayMsg[3]);
                }
                else
                {
                    resultMsg = "訊息代號傳入錯誤";
                }

                item.LineMsg = resultMsg;


                string Url = "https://notify-api.line.me/api/notify";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.KeepAlive = true; //是否保持連線
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Set("Authorization", "Bearer " + LineToken);
                string content = "";
                content += "message=\r\n" + resultMsg;//發送的文字訊息內容
                                
                #region 傳送圖片(選擇性)
                //imgurl = tbxURL.Text.ToString();
                //content += "&imageThumbnail=" + imgurl;
                //content += "&imageFullsize=" + imgurl;
                #endregion

                try
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(content);
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }
                        var response = (HttpWebResponse)request.GetResponse();
                        string tempresult =
                        txtResult.Text += string.Concat(DateTime.Now.ToString(), "訊息傳送成功", Environment.NewLine);

                    item.UpdateTime = DateTime.Now;
                    item.SendTime = DateTime.Now;
                    item.UpdateUser = "User";
                    item.Statu = "1";
                    linenotifymsgDAL.Update(item);


                }
                catch (Exception ex)
                {
                    Log.Info("轉檔程式，發生錯誤" + ex.Message);

                }
            }
        }

     

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Info("程式關閉");
            Environment.Exit(0);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);

            Form f = null;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == "FormLog")
                {
                    f = item;
                    break;
                }
            }
            if (f != null)
            {
                System.Threading.Thread.Sleep(200);
                f.Show();
                return;
            }
            System.Threading.Thread.Sleep(200);
            f = new FormLog();
            f.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);

            Form f = null;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == "FormMachineOpt")
                {
                    f = item;
                    break;
                }
            }
            if (f != null)
            {
                System.Threading.Thread.Sleep(200);
                f.Show();
                return;
            }
            System.Threading.Thread.Sleep(200);
            f = new FormMachineOpt();
            f.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);

            Form f = null;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == "Form1")
                {
                    f = item;
                    break;
                }
            }
            if (f != null)
            {
                System.Threading.Thread.Sleep(200);
                f.Show();
                return;
            }
            System.Threading.Thread.Sleep(200);
            f = new FormDB();
            f.Show();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);

            Form f = null;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == "FormTCP2PLC")
                {
                    f = item;
                    break;
                }
            }
            if (f != null)
            {
                System.Threading.Thread.Sleep(200);
                f.Show();
                return;
            }
            System.Threading.Thread.Sleep(200);
            f = new FormTCP2PLC();
            f.Show();

        }
    }
}
