using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPSocketCSNET4;

namespace WinLineNotifyTCP
{
    public partial class FormTCP2PLC : Form
    {
        private AppState appState = AppState.Stoped;

        private delegate void ShowMsg(string msg);
        private ShowMsg AddMsgDelegate;

        private delegate void SendLineMsgHandler(string msg);

        HPSocketCSNET4.TcpServer server = new HPSocketCSNET4.TcpServer();

        HPSocketCSNET4.Extra<ClientInfo> extra = new HPSocketCSNET4.Extra<ClientInfo>();

        private string title = "TCP/IP訊息接收";
        private static Object thisLock = new Object();     

        public FormTCP2PLC()
        {
            InitializeComponent();

      

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

        private void FormTCP2PLC_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Log.Info("程式關閉");
            Environment.Exit(0);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {


                String ip = this.cboIP.Text;
                ushort port = ushort.Parse(this.txtPort.Text.Trim());

                // 写在这个位置是上面可能会异常
                SetAppState(AppState.Starting);
                server.IpAddress = ip;
                server.Port = port;
                // 启动服务
                if (server.Start())
                {
                    this.Text = string.Format("{2} - ({0}:{1})", ip, port, title);
                    SetAppState(AppState.Started);
                    AddMsg(string.Format("$Server Start OK -> ({0}:{1})", ip, port));
                }
                else
                {
                    SetAppState(AppState.Stoped);
                    throw new Exception(string.Format("$Server Start Error -> {0}({1})", server.ErrorMessage, server.ErrorCode));
                }
            }
            catch (Exception ex)
            {
                AddMsg(ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SetAppState(AppState.Stoping);

            // 停止服务
            AddMsg("$Server Stop");
            if (server.Stop())
            {
                this.Text = title;
                SetAppState(AppState.Stoped);
            }
            else
            {
                AddMsg(string.Format("$Stop Error -> {0}({1})", server.ErrorMessage, server.ErrorCode));
            }
        }

        /// <summary>
        /// 设置程序状态
        /// </summary>
        /// <param name="state"></param>
       private  void SetAppState(AppState state)
        {
            appState = state;
            this.btnStart.Enabled = (appState == AppState.Stoped);
            this.btnStop.Enabled = (appState == AppState.Started);

            
           this.cboIP.Enabled = (appState == AppState.Stoped);
            this.txtPort.Enabled = (appState == AppState.Stoped);
            this.txtDisConn.Enabled = (appState == AppState.Started);
            this.btnDisconn.Enabled = (appState == AppState.Started && this.txtDisConn.Text.Length > 0);
        }


        public enum AppState
        {
            Starting, Started, Stoping, Stoped, Error
        }

        [StructLayout(LayoutKind.Sequential)]
        public class ClientInfo
        {
            public IntPtr ConnId { get; set; }
            public string IpAddress { get; set; }
            public ushort Port { get; set; }
        }

        private void btnDisconn_Click(object sender, EventArgs e)
        {
            try
            {
                IntPtr connId = (IntPtr)Convert.ToInt32(this.txtDisConn.Text.Trim());
                // 断开指定客户
                if (server.Disconnect(connId, true))
                {
                    AddMsg(string.Format("$({0}) Disconnect OK", connId));
                }
                else
                {
                    throw new Exception(string.Format("Disconnect({0}) Error", connId));
                }
            }
            catch (Exception ex)
            {
                AddMsg(ex.Message);
            }
        }

        /// <summary>
        /// 往listbox加一条项目
        /// </summary>
        /// <param name="msg"></param>
        private void AddMsg(string msg)
        {
            if (this.lbxMsg.InvokeRequired)
            {
                // 很帅的调自己
                this.lbxMsg.Invoke(AddMsgDelegate, msg);
            }
            else
            {
                if (this.lbxMsg.Items.Count > 100)
                {
                    this.lbxMsg.Items.RemoveAt(0);
                }
                this.lbxMsg.Items.Add(msg);
                this.lbxMsg.TopIndex = this.lbxMsg.Items.Count - (int)(this.lbxMsg.Height / this.lbxMsg.ItemHeight);
            }
        }

        private void FormTCP2PLC_Load(object sender, EventArgs e)
        {
            try
            {

                this.Text = title;

                //取IP{清單



                GetHostIPAddress();
                // 本机测试没必要改地址,有需求请注释或删除
                //  this.txtIpAddress.ReadOnly = true;

                // 加个委托显示msg,因为on系列都是在工作线程中调用的,ui不允许直接操作
                AddMsgDelegate = new ShowMsg(AddMsg);
                // 设置服务器事件
                server.OnPrepareListen += new ServerEvent.OnPrepareListenEventHandler(OnPrepareListen);
                server.OnAccept += new ServerEvent.OnAcceptEventHandler(OnAccept);
                server.OnSend += new ServerEvent.OnSendEventHandler(OnSend);
                // 两个数据到达事件的一种
                server.OnPointerDataReceive += new ServerEvent.OnPointerDataReceiveEventHandler(OnPointerDataReceive);
                // 两个数据到达事件的一种
                //server.OnReceive += new ServerEvent.OnReceiveEventHandler(OnReceive);

                server.OnClose += new ServerEvent.OnCloseEventHandler(OnClose);
                server.OnShutdown += new ServerEvent.OnShutdownEventHandler(OnShutdown);

                SetAppState(AppState.Stoped);

                AddMsg(string.Format("HP-Socket Version: {0}", server.Version));
            }
            catch (Exception ex)
            {
                SetAppState(AppState.Error);
                AddMsg(ex.Message);
            }
        }


        HandleResult OnPrepareListen(IServer sender, IntPtr soListen)
        {
            // 监听事件到达了,一般没什么用吧?

            return HandleResult.Ok;
        }

        HandleResult OnAccept(IServer sender, IntPtr connId, IntPtr pClient)
        {
            // 客户进入了


            // 获取客户端ip和端口
            string ip = string.Empty;
            ushort port = 0;
            if (server.GetRemoteAddress(connId, ref ip, ref port))
            {
                AddMsg(string.Format(" > [{0},OnAccept] -> PASS({1}:{2})", connId, ip.ToString(), port));
            }
            else
            {
                AddMsg(string.Format(" > [{0},OnAccept] -> Server_GetClientAddress() Error", connId));
            }


            // 设置附加数据
            ClientInfo clientInfo = new ClientInfo();
            clientInfo.ConnId = connId;
            clientInfo.IpAddress = ip;
            clientInfo.Port = port;
            if (extra.Set(connId, clientInfo) == false)
            {
                AddMsg(string.Format(" > [{0},OnAccept] -> SetConnectionExtra fail", connId));
            }

            return HandleResult.Ok;
        }

        HandleResult OnSend(IServer sender, IntPtr connId, byte[] bytes)
        {
            // 服务器发数据了


            AddMsg(string.Format(" > [{0},OnSend] -> ({1} bytes)", connId, bytes.Length));

            return HandleResult.Ok;
        }


        HandleResult OnPointerDataReceive(IServer sender, IntPtr connId, IntPtr pData, int length)
        {
            // 数据到达了
            try
            {

                lock (thisLock)
                {
                    // 可以通过下面的方法转换到byte[]
                    byte[] bytes = new byte[length];
                    Marshal.Copy(pData, bytes, 0, length);

                    // 获取附加数据
                    ClientInfo clientInfo = extra.Get(connId);
                    if (clientInfo != null)
                    {

                        // clientInfo 就是accept里传入的附加数据了
                        AddMsg(string.Format(" > [{0},OnReceive] -> {1}:{2} ({3} bytes)", clientInfo.ConnId, clientInfo.IpAddress, clientInfo.Port, length));

                        string Getstring = Encoding.Default.GetString(bytes);
                        AddMsg(Getstring);


                        SendLineMsgHandler d = new SendLineMsgHandler(SendLineMsg);

                        this.Invoke(d, Getstring);




                    }
                    else
                    {
                        AddMsg(string.Format(" > [{0},OnReceive] -> ({1} bytes)", connId, length));
                    }

                    if (server.Send(connId, pData, length))
                    {
                        return HandleResult.Ok;
                    }

                    return HandleResult.Error;
                }
            }
            catch (Exception)
            {

                return HandleResult.Ignore;
            }
        }
        HandleResult OnReceive(IServer sender, IntPtr connId, byte[] bytes)
        {
            // 数据到达了
            try
            {
                // 获取附加数据
                ClientInfo clientInfo = extra.Get(connId);
                if (clientInfo != null)
                {
                    // clientInfo 就是accept里传入的附加数据了
                    AddMsg(string.Format(" > [{0},OnReceive] -> {1}:{2} ({3} bytes)", clientInfo.ConnId, clientInfo.IpAddress, clientInfo.Port, bytes.Length));


                }
                else
                {
                    AddMsg(string.Format(" > [{0},OnReceive] -> ({1} bytes)", connId, bytes.Length));
                }

                if (server.Send(connId, bytes, bytes.Length))
                {
                    return HandleResult.Ok;
                }

                return HandleResult.Error;
            }
            catch (Exception)
            {

                return HandleResult.Ignore;
            }
        }

        HandleResult OnClose(IServer sender, IntPtr connId, SocketOperation enOperation, int errorCode)
        {
            if (errorCode == 0)
                AddMsg(string.Format(" > [{0},OnClose]", connId));
            else
                AddMsg(string.Format(" > [{0},OnError] -> OP:{1},CODE:{2}", connId, enOperation, errorCode));

            if (extra.Remove(connId) == false)
            {
                AddMsg(string.Format(" > [{0},OnClose] -> SetConnectionExtra({0}, null) fail", connId));
            }

            return HandleResult.Ok;
        }

        HandleResult OnShutdown(IServer sender)
        {
            // 服务关闭了


            AddMsg(" > [OnShutdown]");
            return HandleResult.Ok;
        }

        private void SendLineMsg(string msg)
        {
            string resultMsg = "";

            //    1,2,100,101  PLC傳入代碼順序 機台編號, 異常代碼, 設定值, 機台值
            string[] arrayMsg =   msg.Split(',');
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

          

            string strToken = txtKey.Text;
            string Url = "https://notify-api.line.me/api/notify";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
          request.KeepAlive = true; //是否保持連線
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Set("Authorization", "Bearer " + strToken);
            string content = "";
            content += "message=\r\n" + resultMsg;   //發送的文字訊息內容

            #region 傳送圖片(選擇性)
            //imgurl = tbxURL.Text.ToString();
            //content += "&imageThumbnail=" + imgurl;
            //content += "&imageFullsize=" + imgurl;
            #endregion

            // System.Threading.Thread.Sleep(200);

            byte[] bytescontent = Encoding.UTF8.GetBytes(content);
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytescontent, 0, bytescontent.Length);
            }
            var response = request.GetResponse();
            request.Abort();
        }

        /// <summary>
        /// 取得本機 IP Address
        /// </summary>
        /// <returns></returns>
        private  void GetHostIPAddress()
        {
            List<string> lstIPAddress = new List<string>();
            IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ipa in IpEntry.AddressList)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                    lstIPAddress.Add(ipa.ToString());
            }
            // return lstIPAddress; // result: 192.168.1.17 ......

            cboIP.Items.Clear();
            foreach (var item in lstIPAddress)
            {
                cboIP.Items.Add(item);
            }
        

        }

        private void 建立資料庫ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + @"\myData.db"))
            {
                SQLiteConnection.CreateFile("myData.db");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //HPSocketCSNET4.UdpClient udpclient = new HPSocketCSNET4.UdpClient();

            //bool connected = udpclient.Connect("192.168.1.1", 666);
            byte[] temp = HexString2Bytes("30 01 00 01 00 64 00 00");

            byte[] bytes = new byte[] { 0x02, 0x00, 0x05, 0xff };
        }

        private  byte[] HexString2Bytes(string hexString)
        {
            //check for null
            if (hexString == null) return null;
            //get length
            int len = hexString.Length;
            if (len % 2 == 1) return null;
            int len_half = len / 2;
            //create a byte array
            byte[] bs = new byte[len_half];
            try
            {
                //convert the hexstring to bytes
                for (int i = 0; i != len_half; i++)
                {
                    bs[i] = (byte)Int32.Parse(hexString.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
                }
            }
            catch (Exception ex)
            {

            }
            //return the byte array
            return bs;
        }
    }
}
