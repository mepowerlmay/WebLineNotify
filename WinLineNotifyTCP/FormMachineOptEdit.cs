using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebLineNotify.DAL;
using WebLineNotify.Model;
using WinLineNotifyTCP.Helper;
using WinLineNotifyTCP.Ext;

namespace WinLineNotifyTCP
{
    public partial class FormMachineOptEdit : Form
    {
        /// <summary>
        /// 編輯的異常代號
        /// </summary>
        public string sAlertNo;

        /// <summary>
        /// 機器代號
        /// </summary>
        public string sMachineNo;

        /// <summary>
        /// 機台相關參數 設定黨
        /// </summary>
        private string linemachineFile = @"linemachine.csv";

        /// <summary>
        /// 設定資訊
        /// </summary>
        private List<Linemachine> LinemachineResult { get; set; }

        public FormMachineOptEdit()
        {

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackToFormMachineOpt();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("請確認是否儲存資料", "資料確認視窗", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Linemachine model = null;
                if (string.IsNullOrEmpty(sAlertNo) && string.IsNullOrEmpty(sMachineNo) )
                {
                    model = new Linemachine();

                    //檢核數字
                    int iMachineNo = TypeChange.StringToInt(txtMachineNo.Text);
                    if (iMachineNo == 0)
                    {
                        MessageBox.Show("機台代號請輸入數字!!");
                        return;
                    }

                    int iAlertNo = TypeChange.StringToInt(txtAlertNo.Text);
                    if (iAlertNo == 0)
                    {
                        MessageBox.Show("異常項目代碼請輸入數字!!");
                        return;
                    }
                    string where = "  1=1 ";
                    where += string.Format("  and   MachineNo = {0} and  AlertNo={1} ", iMachineNo, iAlertNo);



                    int iCount = LinemachineResult.Where(i => i.MachineNo == iMachineNo.ToString()
                            && i.AlertNo == iAlertNo.ToString()).Count();
                    if (iCount > 0)
                    {
                        MessageBox.Show("異常項目代碼&與機台代碼已存在，請使用編輯方式修改");
                        return;
                    }

                    model.MachineNo = iMachineNo.ToString();
                    model.AlertNo = iAlertNo.ToString();
                    model.AlertName = txtAlertName.Text;
                    model.CreateTime = DateTime.Now;
                    model.CreateUser = "User";
                    model.UpdateTime = DateTime.Now;
                    model.UpdateUser = "User";
                    model.IsDelete = "0";

                    LinemachineResult.Add(model);


                DataTable tempDT =    LinemachineResult.ToDataTable();

                    

                    CommonHelper.SaveCSV(tempDT, Application.StartupPath);

                   // int reuslt = linemachineDAL.Add(model);


                    //if (reuslt > 0)
                    //{
                    //    MessageBox.Show("新增成功");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("新增異常，請通知系統工程師");
                    //}
                }
                else
                {

                    //model = linemachineDAL.GetModel(PKId);
                    ////檢核數字
                    //int iMachineNo = TypeChange.StringToInt(txtMachineNo.Text);
                    //if (iMachineNo == 0)
                    //{
                    //    MessageBox.Show("機台代號請輸入數字!!");
                    //    return;
                    //}

                    //int iAlertNo = TypeChange.StringToInt(txtAlertNo.Text);
                    //if (iAlertNo == 0)
                    //{
                    //    MessageBox.Show("異常項目代碼請輸入數字!!");
                    //    return;
                    //}



                    //model.MachineNo = iMachineNo.ToString();
                    //model.AlertNo = iAlertNo.ToString();
                    //model.AlertName = txtAlertName.Text;

                    //model.UpdateTime = DateTime.Now;
                    //model.UpdateUser = "User";
                    //model.IsDelete = "0";

                    //bool reuslt = linemachineDAL.Update(model);
                    //if (reuslt)
                    //{
                    //    MessageBox.Show("更新成功");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("更新異常，請通知系統工程師");
                    //}
                }

            }
            else
            {
                return;

            }

            BackToFormMachineOpt();
        }

        private void FormMachineOptEdit_FormClosing(object sender, FormClosingEventArgs e)
        {

            BackToFormMachineOpt();
        }

        /// <summary>
        /// 返回編輯畫面
        /// </summary>
        private void BackToFormMachineOpt()
        {
            Hide();
            System.Threading.Thread.Sleep(200);

            FormMachineOpt f = null;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == "FormMachineOpt")
                {
                    f = (FormMachineOpt)item;
                    break;
                }
            }
            if (f != null)
            {
                System.Threading.Thread.Sleep(200);


                f.GetCSVData();
                f.GetOptionData();
                f.Show();
                return;
            }

            System.Threading.Thread.Sleep(200);
            f = new FormMachineOpt();      
            f.Show();
        }

        private void FormMachineOptEdit_Activated(object sender, EventArgs e)
        {

        }

        private void FormMachineOptEdit_Load(object sender, EventArgs e)
        {

            GetCSVData();


            if (string.IsNullOrEmpty(sAlertNo) && string.IsNullOrEmpty(sMachineNo))
            {
                labTitle.Text = "機台訊息維護/新增";
                this.Text = "機台訊息維護/新增";

                txtAlertName.Text = "";
                txtAlertNo.Text = "";
                txtMachineNo.Text = "";
            }
            else
            {
                var temp = LinemachineResult.Where(i => i.AlertNo == sAlertNo
                  && i.AlertName == sMachineNo).FirstOrDefault();
                if (temp != null)
                {
                    txtAlertName.Text = temp.AlertName;
                    txtAlertNo.Text = temp.AlertNo;
                    txtMachineNo.Text = temp.MachineNo;

                    labTitle.Text = "機台訊息維護/編輯";
                    this.Text = "機台訊息維護/編輯";
                }

            }

        }


        /// <summary>
        /// 取得ini資料
        /// </summary>
        public void GetCSVData()
        {

            DataTable dtresult = CommonHelper.OpenCSV(linemachineFile);

            //   string[] arrayValues = System.IO.File.ReadAllLines(linemachineFile);
            LinemachineResult = new List<Linemachine>();
            foreach (DataRow row in dtresult.Rows)
            {
                Linemachine tempModel = new Linemachine();
                tempModel.MachineNo = row[0].ToString();
                tempModel.AlertNo = row[1].ToString();
                tempModel.AlertName = row[2].ToString();
                LinemachineResult.Add(tempModel);
            }

        }



    }
}