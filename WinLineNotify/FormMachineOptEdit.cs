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
using WinLineNotify.Helper;

namespace WinLineNotify
{
    public partial class FormMachineOptEdit : Form
    {
        private LinemachineDAL linemachineDAL;

        public int PKId = 0;

        public FormMachineOptEdit(int Id)
        {         

            InitializeComponent();

            //linemachineDAL = new LinemachineDAL();
            //PKId = Id;

            //txtAlertName.Text = "";
            //txtAlertNo.Text = "";
            //txtMachineNo.Text = "";

            //if (Id == 0)
            //{
                
            //    labTitle.Text = "機台訊息維護/新增";
            //    this.Text = "機台訊息維護/新增";
            //}
            //else
            //{
            //    Linemachine model =   linemachineDAL.GetModel(PKId);

            //    txtAlertName.Text =     model.AlertName;
            //    txtAlertNo.Text = model.AlertNo;
            //    txtMachineNo.Text = model.MachineNo;

            //    labTitle.Text = "機台訊息維護/編輯";
            //    this.Text = "機台訊息維護/編輯";
            //}
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackToFormMachineOpt();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("請確認是否儲存資料","資料確認視窗",MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Linemachine model = null;
                if (PKId ==0)
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
                     where += string.Format("  and   MachineNo = {0} and  AlertNo={1} " , iMachineNo, iAlertNo);
                 int iCount =   linemachineDAL.CalcCount(where);
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

                    int reuslt =       linemachineDAL.Add(model);
                    if (reuslt >0)
                    {
                        MessageBox.Show("新增成功");
                    }
                    else
                    {
                        MessageBox.Show("新增異常，請通知系統工程師");
                    }
                }
                else
                {

                     model = linemachineDAL.GetModel(PKId);
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



                    model.MachineNo = iMachineNo.ToString();
                    model.AlertNo = iAlertNo.ToString();
                    model.AlertName = txtAlertName.Text;

                    model.UpdateTime = DateTime.Now;
                    model.UpdateUser = "User";
                    model.IsDelete = "0";

                    bool reuslt = linemachineDAL.Update(model);
                    if (reuslt)
                    {
                        MessageBox.Show("更新成功");
                    }
                    else
                    {
                        MessageBox.Show("更新異常，請通知系統工程師");
                    }
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
        private void BackToFormMachineOpt() {
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
                FormMachineOpt tempF = (FormMachineOpt)f;
                    tempF.GetDropDownItem();
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
            linemachineDAL = new LinemachineDAL();
            var temp = linemachineDAL.GetModel(PKId);


            if (temp == null)
            {

                labTitle.Text = "機台訊息維護/新增";
                this.Text = "機台訊息維護/新增";

                txtAlertName.Text = "";
                txtAlertNo.Text = "";
                txtMachineNo.Text = "";
            }
            else
            {


                txtAlertName.Text = temp.AlertName;
                txtAlertNo.Text = temp.AlertNo;
                txtMachineNo.Text = temp.MachineNo;

                labTitle.Text = "機台訊息維護/編輯";
                this.Text = "機台訊息維護/編輯";
            }
        }
    }
}
