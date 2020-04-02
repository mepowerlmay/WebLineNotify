using ClosedXML.Excel;
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
using WinLineNotifyTCP.Helper;

namespace WinLineNotifyTCP
{
    public partial class FormLog : Form
    {

        private LinenotifymsgDAL linenotifymsgDAL;

        public FormLog()
        {
            InitializeComponent();
            linenotifymsgDAL = new LinenotifymsgDAL();
            this.Text = "訊息紀錄查詢";
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

        private void FormLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            //   Log.Info("程式關閉");
            Environment.Exit(0);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtReuslt = new DataTable();
            string folderPath = "";
            string sFileName =  DateTime.Now.ToString("yyyyMMddhhmmss")+ "訊息紀錄.xlsx";

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dtReuslt.Columns.Add(column.HeaderText, column.ValueType);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dtReuslt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dtReuslt.Rows[dtReuslt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            //Exporting to Excel
      
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    folderPath = fbd.SelectedPath + "\\";               
                }
            }

            if ( string.IsNullOrEmpty( folderPath))
            {
                MessageBox.Show("請選擇匯出資料夾");
                return;
            }


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dtReuslt, "訊息紀錄");
                wb.SaveAs(folderPath + sFileName);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string where = " 1= 1";


            WhereClausesBuilder whereClausesBuilder = new WhereClausesBuilder();

            whereClausesBuilder.appendCriteriaDate(dtpStart.Value.ToShortDateString(), dtpEnd.Value.ToShortDateString(), " CreateTime  ", ref where);


            var result = linenotifymsgDAL.GetListArray(where);


            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = result;

            dataGridView1.AutoResizeColumns();



        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            this.dtpStart.Value = DateTime.Now.AddDays(-14);
            this.dtpEnd.Value = DateTime.Now;
        }

     
    }
}
