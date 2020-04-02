using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
    public partial class FormMachineOpt : Form
    {


        /// <summary>
        /// 機台相關參數 設定黨
        /// </summary>
        private string linemachineFile = @"linemachine.csv";

        /// <summary>
        /// 設定資訊
        /// </summary>
        private List<Linemachine> LinemachineResult { get; set; }

        public FormMachineOpt()
        {
            
            InitializeComponent();      
        }


        private void FormMachineOpt_Load(object sender, EventArgs e)
        {

            GetCSVData();
            GetOptionData();       

            btnQuery_Click(null, null);
        }

        /// <summary>
        /// 取得下拉選單資料
        /// </summary>
        public void GetOptionData()
        {
            //開始取下拉選單資料
            var result1 = LinemachineResult.DistinctBy(i => i.MachineNo);
            List<ListItem> Items1 = new List<ListItem>();

            foreach (var item in result1)
            {
                Items1.Add(new ListItem { Text = item.MachineNo, Value = item.MachineNo });
            }
            cboMachineNo.DataSource = Items1;
            cboMachineNo.DisplayMember = "Text";
            cboMachineNo.ValueMember = "Value";


            var result2 = LinemachineResult.DistinctBy(i => i.AlertNo);
            List<ListItem> Items2 = new List<ListItem>();
            foreach (var item in result2)
            {
                Items2.Add(new ListItem { Text = item.AlertNo, Value = item.AlertNo });
            }

            cboAlertNo.DisplayMember = "Text";
            cboAlertNo.ValueMember = "Value";
            cboAlertNo.DataSource = Items2;

            var result3 = LinemachineResult.DistinctBy(i => i.AlertName);
            List<ListItem> Items3 = new List<ListItem>();
            foreach (var item in result3)
            {
                Items3.Add(new ListItem { Text = item.AlertName, Value = item.AlertName });
            }
            cboAlertName.DisplayMember = "Text";
            cboAlertName.ValueMember = "Value";
            cboAlertName.DataSource = Items3;
        }

        /// <summary>
        /// 取得ini資料
        /// </summary>
        public void GetCSVData()
        {

        DataTable dtresult = CommonHelper.  OpenCSV(linemachineFile);

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

        private void FormMachineOpt_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  Log.Info("程式關閉");
            Environment.Exit(0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);

            Form f = null;
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == "FormMachineOptEdit")
                {
                    f = item;
                    break;
                }
            }
            if (f != null)
            {
                System.Threading.Thread.Sleep(200);
                f.ShowDialog();
                return;
            }
            System.Threading.Thread.Sleep(200);
            f = new FormMachineOptEdit();
            f.ShowDialog();

            
        }

        private void btnQuery_Click(object sender, EventArgs e)
        { 
            GetData();        
        }

        private void GetData()
        {
            var result = new List<Linemachine>();
            result = LinemachineResult;
            if (!string.IsNullOrEmpty(cboAlertName.Text))
                result = LinemachineResult.Where( i => i.AlertName.Contains( cboAlertName.Text)).ToList();
            if (!string.IsNullOrEmpty(cboAlertNo.Text))
                result = LinemachineResult.Where(i => i.AlertNo.Contains(cboAlertNo.Text)).ToList();
            if (!string.IsNullOrEmpty(cboMachineNo.Text))
                result = LinemachineResult.Where(i => i.MachineNo.Contains(cboMachineNo.Text)).ToList();

             
            
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = result;
            dataGridView1.Refresh();
        }

        private void FormMachineOpt_Activated(object sender, EventArgs e)
        {
         

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Id = TypeChange.StringToInt(  dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString() );
            //edit column 


            //8 = 編輯
            if (e.ColumnIndex == 8)
            {

                Hide();
                System.Threading.Thread.Sleep(200);

                FormMachineOptEdit f = null;
                foreach (Form item in Application.OpenForms)
                {
                    if (item.Name == "FormMachineOptEdit")
                    {
                         f = (FormMachineOptEdit)item;
                   //     f.PKId = Id;


                        break;
                    }
                }
                if (f != null)
                {
                    System.Threading.Thread.Sleep(200);
                    f.ShowDialog();
                    return;
                }
                System.Threading.Thread.Sleep(200);
                //f = new FormMachineOptEdit(0);
                //f.PKId = Id;
                //f.ShowDialog();

                //Form2 frm2 = new Form3(this);
                //fm2.a = id;
                //fm2.Show();
                //dataGridView1.Refresh();
                ////delete column
                //if (e.ColumnIndex == 6)
                //{
                //    id = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                //    MySqlDataAdapter da = new MySqlDataAdapter("delete from student where id = '" + id + "'", conn);
                //    DataSet ds = new DataSet();
                //    da.Fill(ds);
                //    dataGridView1.Refresh();
                //}
            }

            //9 刪除
            if (e.ColumnIndex == 9)
            {
                //var confirmResult = MessageBox.Show("請確認是否刪除資料", "資料確認視窗", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //if (confirmResult == DialogResult.Yes) {
                // var temp =     linemachineDAL.GetModel(Id);
                //    temp.IsDelete = "1";
                //    temp.UpdateTime = DateTime.Now;
                //    temp.UpdateUser = "User";
                //    linemachineDAL.Update(temp);

                //}
                //GetData();


            }


        }

     

 
    }


}
