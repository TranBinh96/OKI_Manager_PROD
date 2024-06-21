using OKI.TOOL.IR.CHECK.data;
using OKI.TOOL.IR.CHECK.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
namespace OKI.TOOL.IR.CHECK.services
{
    public class QuantityServices
    {
        static ApplicationDbConext dbConext = new ApplicationDbConext();
        static QuantityServices quantityServices = new QuantityServices();
        static SqlConnection conn;

        public Quantity GetQuantity()
        {
            Quantity quantity = new Quantity();
            string[]  host  = quantityServices.GetHostEntry();

            conn = dbConext.OpenDb();
            string queryStringDay = "EXEC P_GET_SUM_DAY @pcline = '" + host[0] +"';";
            string queryStringMonth = "EXEC P_GET_SUM_MONTH @pcline = '" + host[0] + "';";
            // Tạo đối tượng Command
            using (SqlCommand command = new SqlCommand(queryStringDay, conn))
            {
                // Thực thi truy vấn và đọc dữ liệu
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        quantity.ok = reader["ok"].ToString() ==""? 0 : int.Parse(reader["ok"].ToString());
                        quantity.ng = reader["ng"].ToString() == "" ? 0 : int.Parse(reader["ng"].ToString());                       
                    }
                }
            }
            using (SqlCommand command = new SqlCommand(queryStringMonth, conn))
            {
                // Thực thi truy vấn và đọc dữ liệu
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        quantity.month = int.Parse(reader["Total_OK"].ToString());                       
                        
                    }
                }
            }
            DateTime now = DateTime.Now;
            quantity.time_update = now.ToString("yyyy-MM-dd HH:mm:ss");
            dbConext.CloseDb();
            return quantity;
        }

        public string[] GetHostEntry()
        {
            string[] host = new string[2];  
            string hostName = Dns.GetHostName(); // Lấy tên máy
            IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
            IPAddress[] ipAddresses = hostEntry.AddressList;

            host[0] = hostName;
            
            foreach (IPAddress ipAddress in ipAddresses)
            {
                host[1] = ipAddress.ToString();
            }
            return host;
        }

    }
}
