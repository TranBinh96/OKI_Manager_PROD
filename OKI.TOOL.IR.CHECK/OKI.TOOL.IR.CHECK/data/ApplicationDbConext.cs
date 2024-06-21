using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.ClipboardSource.SpreadsheetML;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace OKI.TOOL.IR.CHECK.data
{
    public class ApplicationDbConext
    {
        private static string datasource = "10.17.156.235\\SQLEXPRESS";
        private static string database = "Oki_product";
        private static string username = "okipe";
        private static string password = "oki2024$";
        private static SqlConnection cnn ;
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            try
            {
                string connString = @"Data Source=" + datasource
                       + ";Initial Catalog=" + database
                       + ";User ID=" + username
                       + ";Password=" + password;
                SqlConnection conn = new SqlConnection(connString);
                return conn;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);  
                return null;
            }
        }
        public  SqlConnection OpenDb()
        {
            cnn = GetDBConnection(datasource, database, username, password);
            cnn.Open();
            return cnn;

        }

        public void CloseDb()
        {
            cnn.Close();

        }

    }
}
