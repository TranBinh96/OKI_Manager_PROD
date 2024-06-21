using DevExpress.Export;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using OKI.TOOL.IR.CHECK.models;
using OKI.TOOL.IR.CHECK.services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace OKI.TOOL.IR.CHECK
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        static InfraredRadiationServices radiationServices = new InfraredRadiationServices();
        static QuantityServices quantityServices = new QuantityServices();
        static string seri = "";
        static System.Data.DataTable dbInfraredRadiation = new System.Data.DataTable();
        private int currentPosition = 0;
        private string Logo = "DEVELOP BY OKI_PE";
        private const int Speed = 100; // Tốc độ chạy chữ (ms)
        public frmMain()
        {
            InitializeComponent();
            lblStatusCheck.Visible = false;
            lblStatus.Visible = false;
            lblSeriCheck.Text = "";
            gridData.DataSource = radiationServices.Onmit();
            LoadDataForm();

        }
        private void timerRunLogo_Tick(object sender, EventArgs e)
        {
            if (txtSeriNumber.Text.Length > 9)
            {

                string input = txtVersion.Text.ToUpper().Substring(0,24);
                string[] parts = input.Split('\"');

                lblSeriCheck.Text = "SN : " + parts[0].Replace("'", "") + "****" + txtSeriNumber.Text.Trim();
                // open trạng thái chờ get data
                splashLoadDataset.ShowWaitForm();
                seri = parts[0].Replace("'", "") + "****" + txtSeriNumber.Text.Trim();
                txtVersion.Text = parts[0].Replace("'", "");

                txtSeriNumber.Text = "";
                txtVersion.Text = "";
                bool status = radiationServices.CheckInfraredRadiation(seri.Trim()) == true;
                if (!status)
                {
                    dbInfraredRadiation = radiationServices.getDataSetInfraredRadiation(seri);
                    if (dbInfraredRadiation.Rows.Count != 0)
                    {
                        DataRow firstRow = dbInfraredRadiation.Rows[0];
                        string name = firstRow["Remarks"].ToString();
                        if (!name.Equals("NG"))
                        {
                            gridData.DataSource = dbInfraredRadiation;
                            lblrow.Text = "ROW  : " + dbInfraredRadiation.Rows.Count;
                            CustomLabel("OK");
                        }
                        else
                        {
                            gridData.DataSource = dbInfraredRadiation;
                            lblrow.Text = "ROW  : " + dbInfraredRadiation.Rows.Count;
                            CustomLabel("NG");

                        }
                    }
                    if (dbInfraredRadiation.Rows.Count == 0)
                        CustomLabel("NotSR");
                }
                else if (status)
                    CustomLabel("PASS1");
                else if (seri.Length == 0)
                    CustomLabel("NOTNULL");
                // Ngăn không cho ký tự Enter hiển thị trong TextBox

                // close trạng thái chờ get data
                /*             splashCheckStatus.CloseWaitForm();*/
                splashLoadDataset.CloseWaitForm();
                LoadDataForm();

            }


        }

        public void LoadDataForm()
        {
            string[] hostpc = quantityServices.GetHostEntry();
            Quantity quantity = quantityServices.GetQuantity();
            lblUpdateSL.Text = "Sản lượng được cập nhật lúc : " + quantity.time_update;
            lblOKDay.Text = quantity.ok.ToString();
            lblNGDay.Text = quantity.ng.ToString();
            lblOKMonth.Text = quantity.month.ToString();
            lblpc.Text = " PC Name : " + hostpc[0];
            lblhostIP.Text = " Address IP : " + hostpc[1];
            LoadDataByPCDay();
            var targetPage = (TabNavigationPage)tableAdmin.Pages.First(x => x.Name == "SLDAY");
            tableAdmin.SelectedPage = targetPage;
            timerRunLogo.Interval = 1;
            timerRunLogo.Tick += new EventHandler(timerRunLogo_Tick);
            timerRunLogo.Start();

        }


     /*   private void txtSeriNumber_KeyPress(object sender, KeyPressEventArgs e)
        {           

            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    string input = txtVersion.Text.ToUpper();
                    string[] parts = input.Split('\"');

                    lblSeriCheck.Text = "SN : " + parts[0].Replace("'","") + "****" + txtSeriNumber.Text.Trim();
                    // open trạng thái chờ get data
                    splashLoadDataset.ShowWaitForm();
                    seri = parts[0].Replace("'", "") + "****" + txtSeriNumber.Text.Trim();
                    txtVersion.Text = parts[0].Replace("'", ""); 

                    txtSeriNumber.Text = "";
                    bool status = radiationServices.CheckInfraredRadiation(seri.Trim()) == true;
                    if (!status)
                    {
                        dbInfraredRadiation = radiationServices.getDataSetInfraredRadiation(seri);
                        if (dbInfraredRadiation.Rows.Count != 0)
                        {
                            DataRow firstRow = dbInfraredRadiation.Rows[0];
                            string name = firstRow["Remarks"].ToString();
                            if (!name.Equals("NG"))
                            {
                                gridData.DataSource = dbInfraredRadiation;
                                lblrow.Text = "ROW  : " + dbInfraredRadiation.Rows.Count;
                                CustomLabel("OK");
                            }
                            else
                            {
                                gridData.DataSource = dbInfraredRadiation;
                                lblrow.Text = "ROW  : " + dbInfraredRadiation.Rows.Count;
                                CustomLabel("NG");

                            }
                        }
                        if (dbInfraredRadiation.Rows.Count == 0)
                            CustomLabel("NotSR");
                    }
                    else if (status)
                        CustomLabel("PASS1");
                    else if (seri.Length == 0)
                        CustomLabel("NOTNULL");
                    // Ngăn không cho ký tự Enter hiển thị trong TextBox
                    e.Handled = true;
                    // close trạng thái chờ get data
                    *//*             splashCheckStatus.CloseWaitForm();*//*
                    splashLoadDataset.CloseWaitForm();
                    LoadDataForm();
                }
            }
            catch (Exception ex)
            {
                splashLoadDataset.CloseWaitForm();
                XtraMessageBox.Show("Vui lòng liên hệ admin binh337@oki.com ?" 
                  , "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

*/
        public void CustomLabel(string text)
        {
            if (text.CompareTo("OK") == 0)
            {
                lblStatus.Text = "OK";
                lblStatus.ForeColor = Color.Green;
                lblStatus.BackColor = Color.FromArgb(192, 255, 192);
                lblStatus.Visible = true;
                lblStatusCheck.Visible = false;
            }
            else if (text.CompareTo("NG") == 0)
            {
                lblStatus.Text = "NG";
                lblStatus.ForeColor = Color.Maroon;
                lblStatus.BackColor = Color.FromArgb(255, 192, 192);
                lblStatus.Visible = true;
                lblStatusCheck.Visible = false;

            }
            else if (text.CompareTo("PASS0") == 0)
            {
                lblStatusCheck.Visible = false;
                lblStatus.Visible = true;

            }
            else if (text.CompareTo("PASS1") == 0)
            {
                lblStatus.Visible = false;
                lblStatusCheck.Visible = true;
                lblStatusCheck.Text = "SN : " + seri + " ĐÃ CHECK";
                lblStatusCheck.ForeColor = Color.Red;
                lblStatusCheck.BackColor = Color.Beige;
            }
            else if (text.CompareTo("NotSR") == 0)
            {
                lblStatus.Visible = false;
                lblStatusCheck.Visible = true;
                lblStatusCheck.Text = "SN : " + seri + " NOT FOUND";
                lblStatusCheck.ForeColor = Color.Red;
                lblStatusCheck.BackColor = Color.Beige;
            }
            else if (text.CompareTo("NOTNULL") == 0)
            {
                lblStatus.Visible = false;
                lblStatusCheck.Visible = true;
                lblStatusCheck.Text = "Seri Number Không Được Bỏ Trống";
                lblStatusCheck.ForeColor = Color.Red;
                lblStatusCheck.BackColor = Color.Beige;
            }
        }
        public void LoadDataByPCDay()
        {
            dbInfraredRadiation = radiationServices.getDataSetInfraredRadiation("line");
            gridData.DataSource = dbInfraredRadiation;
            lblrow.Text = "ROW  : " + dbInfraredRadiation.Rows.Count;
        }


        private void gridViewData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == view.FocusedRowHandle) return;
            if (e.Column.FieldName != "Remarks") return;
            if (Convert.ToString(e.CellValue) == "NG")
            {               
                e.Appearance.BackColor = Color.FromArgb(60, Color.Red);
            }
            else
            {
                e.Appearance.BackColor = Color.FromArgb(60, Color.Green);
            }
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {
            string date = dateTo.DateTime.ToString("yyyy-MM-dd") + "," + dateFrom.DateTime.ToString("yyyy-MM-dd");
            dbInfraredRadiation = radiationServices.getDataSetInfraredRadiation(date);
            gridDataAll.DataSource = dbInfraredRadiation;
            lblrow.Text = "ROW  : " + dbInfraredRadiation.Rows.Count;
        }

        private void btnExlse_Click(object sender, EventArgs e)
        {
            
            if (dbInfraredRadiation.Rows.Count != 0)
            {
                string path = "test" + ".xlsx";
                string tempPath = Environment.GetEnvironmentVariable("TEMP") + "\\" + path;
                DataTable dt = (gridDataAll.MainView as GridView).DataSource as DataTable;
                XlsxExportOptionsEx options = new XlsxExportOptionsEx();
                options.ExportType = ExportType.DataAware;
                gridDataAll.ExportToXlsx(tempPath, options);
                Process.Start(tempPath);
            }
            else
            {
                XtraMessageBox.Show("Không Có Dữ Liệu Vui Lòng Kiểm Trai Lại" +
                   "\n", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tableAdmin_MouseClick(object sender, MouseEventArgs e)
        {
            string nameCurrentPage = tableAdmin.SelectedPage.Name.Trim();

            switch (nameCurrentPage)
            {
                case "Admin":
                    ManagerAdmin();
                    break;
                case "SLDAY":
                    SlFolowDay();
                    break;
                case "SLAll":
                    SlFolowMonth();
                    break;

            }
        }

        private void ManagerAdmin()
        {
            var userLogin = new XtraLogin();
            panelControlManeger.Controls.Add(userLogin);
            panelControlManeger.Show();

        }

        private void SlFolowDay()
        {
            try
            {
                splashLoadDataset.ShowWaitForm();
                dbInfraredRadiation = radiationServices.getDataSetInfraredRadiation("line");
                gridDataAll.DataSource = dbInfraredRadiation;
                lblrow.Text = "ROW  : " + dbInfraredRadiation.Rows.Count;
                splashLoadDataset.CloseWaitForm();
            }
            catch (Exception ex)
            {
                splashLoadDataset.CloseWaitForm();
                XtraMessageBox.Show("Không Có Dữ Liệu Vui Lòng Kiểm Trai Lại" +
                   "\n", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void SlFolowMonth()
        {
            try
            {
                splashLoadDataset.ShowWaitForm();  
                dbInfraredRadiation = radiationServices.getDataSetInfraredRadiation("all");
                gridDataAll.DataSource = dbInfraredRadiation;
                lblrow.Text = "ROW  : " + dbInfraredRadiation.Rows.Count;
                splashLoadDataset.CloseWaitForm();
            }
            catch (Exception ex) {
                splashLoadDataset.CloseWaitForm();
                XtraMessageBox.Show("Không Có Dữ Liệu Vui Lòng Kiểm Trai Lại" +
                   "\n", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        public DataTable ConvertToDataTable<T>(List<T> list)
        {
            DataTable table = new DataTable();
            // Tạo các cột dựa trên các thuộc tính của kiểu T
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                table.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Thêm dữ liệu từ danh sách vào DataTable
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyInfo property in properties)
                {
                    object value = property.GetValue(item);
                    row[property.Name] = value ?? DBNull.Value; // Thay thế giá trị null bằng DBNull.Value
                }
                table.Rows.Add(row);
            }

            return table;
        }

    }
}