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
using WinLineNotify.Helper;

namespace WinLineNotify
{
    public partial class FormMachineOpt : Form
    {
        private LinemachineDAL linemachineDAL;

        public FormMachineOpt()
        {
            linemachineDAL = new LinemachineDAL();
            InitializeComponent();

      
        }


        private void FormMachineOpt_Load(object sender, EventArgs e)
        {
            GetDropDownItem();


        }

        /// <summary>
        /// 取得下拉選單
        /// </summary>
        public void GetDropDownItem() {
            //開始取下拉選單資料
            var result1 = linemachineDAL.GetOneFiledArray(" distinct  MachineNo  ", " IsDelete = '0' ");
            List<ListItem> Items1 = new List<ListItem>();

            foreach (var item in result1)
            {
                Items1.Add(new ListItem { Text = item, Value = item });
            }
            cboMachineNo.DataSource = Items1;
            cboMachineNo.DisplayMember = "Text";
            cboMachineNo.ValueMember = "Value";


            var result2 = linemachineDAL.GetOneFiledArray(" distinct  AlertNo  ", "   IsDelete = '0' ");
            List<ListItem> Items2 = new List<ListItem>();
            foreach (var item in result2)
            {
                Items2.Add(new ListItem { Text = item, Value = item });
            }

            cboAlertNo.DisplayMember = "Text";
            cboAlertNo.ValueMember = "Value";
            cboAlertNo.DataSource = Items2;

            var result3 = linemachineDAL.GetOneFiledArray(" distinct  AlertName  ", "  IsDelete = '0'  ");
            List<ListItem> Items3 = new List<ListItem>();
            foreach (var item in result3)
            {
                Items3.Add(new ListItem { Text = item, Value = item });
            }
            cboAlertName.DisplayMember = "Text";
            cboAlertName.ValueMember = "Value";
            cboAlertName.DataSource = Items3;

            btnQuery_Click(null, null);
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
            f = new FormMachineOptEdit(0);
            f.ShowDialog();

            
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

            //cboAlertName.Text

            //            cboAlertNo.Text

            //cboMachineNo.Text

            GetData();

        
        }

        private void GetData()
        {
            string where = " 1=1 ";

            if (!string.IsNullOrEmpty(cboAlertName.Text))
                where += "  and  AlertName like '%" + cboAlertName.Text + "%'";
            if (!string.IsNullOrEmpty(cboAlertNo.Text))
                where += "  and  AlertNo like '%" + cboAlertNo.Text + "%'";
            if (!string.IsNullOrEmpty(cboMachineNo.Text))
                where += "  and  MachineNo like '%" + cboMachineNo.Text + "%'";

            where +=  " and IsDelete = '0' ";

            var result = linemachineDAL.GetListArray(where);
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
                        f.PKId = Id;


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
                f = new FormMachineOptEdit(0);
                f.PKId = Id;
                f.ShowDialog();

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
                var confirmResult = MessageBox.Show("請確認是否刪除資料", "資料確認視窗", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes) {
                 var temp =     linemachineDAL.GetModel(Id);
                    temp.IsDelete = "1";
                    temp.UpdateTime = DateTime.Now;
                    temp.UpdateUser = "User";
                    linemachineDAL.Update(temp);

                }
                GetData();


            }


        }
    }
}
