using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OKI.TOOL.IR.CHECK.data;
using OKI.TOOL.IR.CHECK.models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OKI.TOOL.IR.CHECK.services
{
    public class InfraredRadiationServices 
    {
        static ApplicationDbConext dbConext = new ApplicationDbConext();
        static QuantityServices quantityServices = new QuantityServices();
        static string[] host = quantityServices.GetHostEntry();
        public SqlConnection conn;

        public DataTable Onmit()
        {
            DataTable dataInfraredRadiation = new DataTable("DBInfraredRadiation");
            DataColumn noColumn = new DataColumn("No", typeof(int));
            DataColumn unitnoColumn = new DataColumn("UnitNo", typeof(string));
            DataColumn starttimeColumn = new DataColumn("StartTime", typeof(string));
            DataColumn finishtimeColumn = new DataColumn("FinishTime", typeof(string));
            DataColumn remarksColumn = new DataColumn("Remarks", typeof(string));
            DataColumn timeaccessColumn = new DataColumn("TimeAccess", typeof(string));

            dataInfraredRadiation.Columns.Add(noColumn);
            dataInfraredRadiation.Columns.Add(unitnoColumn);
            dataInfraredRadiation.Columns.Add(starttimeColumn);
            dataInfraredRadiation.Columns.Add(finishtimeColumn);
            dataInfraredRadiation.Columns.Add(remarksColumn);
            dataInfraredRadiation.Columns.Add(timeaccessColumn);
            return dataInfraredRadiation;
        }


        // check -> search xem seri finsh hay NG
        public InfraredRadiation GetByIdInfraredRadiation(string seri_number)
        {
            InfraredRadiation infrared = new InfraredRadiation();
            conn = dbConext.OpenDb();
            string queryString = "exec Get_Infrared_Radiation @seri_number = '"+ seri_number + "' ";
            // Tạo đối tượng Command
            using (SqlCommand command = new SqlCommand(queryString, conn))
            {
                // Thực thi truy vấn và đọc dữ liệu
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        infrared = new InfraredRadiation()
                        {
                            no = int.Parse(reader["no"].ToString()),
                            job_no = (int.Parse(reader["job_no"].ToString())),
                            kotei_filename = (string)reader["kotei_filename"].ToString(),
                            unit_no = (string)reader["unit_no"].ToString(),
                            st_no = reader["st_no"].ToString(),
                            start_time = reader["start_time"].ToString(),
                            finish_time = reader["finish_time"].ToString(),
                            remarks = (string)reader["remarks"].ToString(),
                            time_access = reader["time_access"].ToString(),
                        };
                    }
                }
            }
            dbConext.CloseDb(); 
            return infrared;
        }

        public List<InfraredRadiation> GetAllInfraredRadiation(string seri_number)
        {
            List<InfraredRadiation> infrareds = new List<InfraredRadiation>();
            conn = dbConext.OpenDb();
            string queryString = " select  * from  t_IR_Search_result where pcline = '" + seri_number+"' order by  time_access desc";
            // Tạo đối tượng Command
            using (SqlCommand command = new SqlCommand(queryString, conn))
            {
                // Thực thi truy vấn và đọc dữ liệu
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        InfraredRadiation  infrared = new InfraredRadiation()
                        {
                            no = int.Parse(reader["no"].ToString()),
                            job_no = (int.Parse(reader["job_no"].ToString())),
                            kotei_filename = (string)reader["kotei_filename"].ToString(),
                            unit_no = (string)reader["unit_no"].ToString(),
                            st_no = reader["st_no"].ToString(),
                            start_time = reader["start_time"].ToString(),
                            finish_time = reader["finish_time"].ToString(),
                            remarks = (string)reader["remarks"].ToString(),
                            time_access = reader["time_access"].ToString(),
                            
                        };
                        infrared.remarks = infrared.remarks.Replace(" ", "");
                        infrareds.Add(infrared);
                    }
                }
            }
            dbConext.CloseDb();
            return infrareds;
        }


        public List<InfraredRadiation> GetByPcLineDateInfraredRadiation(string data)
        {
            string queryString = "";
            if (data.Equals("line"))
            {
                queryString = "  select  * from  t_IR_Search_result where  pcline = '" + host[0] + "'  and   " +
                "CONVERT(DATE, time_access) = CONVERT(DATE, GETDATE()) order by  time_access desc";
            }
            else if (data.Equals("all"))
            {
                queryString = "select * from  t_IR_Search_result  order by  time_access desc";
            }
            else if (data.LastIndexOf(",") != -1)
            {
                string[] time = data.Split(',');

                queryString = "select * from  t_IR_Search_result" +
                    " WHERE CONVERT(DATE, time_access)  >= '" + time[0] +"' " +
                    "AND CONVERT(DATE, time_access)  <= '" + time[1] +"' order by  time_access desc";
            }

            List <InfraredRadiation> infrareds = new List<InfraredRadiation>();
            conn = dbConext.OpenDb();
             
            // Tạo đối tượng Command
            using (SqlCommand command = new SqlCommand(queryString, conn))
            {
                // Thực thi truy vấn và đọc dữ liệu
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        InfraredRadiation infrared = new InfraredRadiation()
                        {
                            no = int.Parse(reader["no"].ToString()),
                            job_no = (int.Parse(reader["job_no"].ToString())),
                            kotei_filename = (string)reader["kotei_filename"].ToString(),
                            unit_no = (string)reader["unit_no"].ToString(),
                            st_no = reader["st_no"].ToString(),
                            start_time = reader["start_time"].ToString(),
                            finish_time = reader["finish_time"].ToString(),
                            remarks = (string)reader["remarks"].ToString(),
                            time_access = reader["time_access"].ToString(),

                        };
                        infrareds.Add(infrared);
                    }
                }
            }
            dbConext.CloseDb();
            return infrareds;
        }


        // Hàm Xử Lý Chung

        public List<InfraredRadiation> EX(String seriNumber)
        {
            List<InfraredRadiation> infraredRadiations = new List<InfraredRadiation>() ; 
            InfraredRadiation infrared = GetByIdInfraredRadiation(seriNumber);
            if(infrared.job_no != 0 )
            {
                string remark = infrared.remarks.Replace(" ", "");
                if (!remark.Equals("FINISH"))
                {
                    if (CheckNGInfraredRadiation(infrared.unit_no))
                    {
                        infrared.remarks = "NG";
                        SetInfraredRadiationById(infrared);                        
                    }
                    infraredRadiations = GetByPcLineDateInfraredRadiation("line");
                }
                else if (remark.Equals("FINISH"))
                {
                    infrared.remarks = "FINISH";
                    if (SetInfraredRadiationById(infrared))
                        infraredRadiations = GetByPcLineDateInfraredRadiation("line");
                }
            }            
            return infraredRadiations;  
        }

        public List<InfraredRadiation> CheckIR(String seriNumber)
        {
            List<InfraredRadiation> infraredRadiations = new List<InfraredRadiation>();
            DbWrapperDataContext _db = new DbWrapperDataContext();
            t_IR_result t_IR_Results = _db.t_IR_results
                                    .Where(x => x.unit_no == seriNumber && x.remarks.IndexOf("FINISH") != -1)
                                    .FirstOrDefault();


            InfraredRadiation infrared = new InfraredRadiation();
            if (t_IR_Results != null)
            {
                infrared.job_no = t_IR_Results.job_no;
                infrared.kotei_filename = t_IR_Results.kotei_filename.ToString();
                infrared.unit_no = t_IR_Results.unit_no;
                infrared.st_no = t_IR_Results.st_no;
                infrared.start_time = t_IR_Results.start_time.ToString();
                infrared.finish_time = t_IR_Results.finish_time.ToString();
                infrared.remarks = t_IR_Results.remarks.ToString();
                infrared.time_access = DateTime.Now.ToString();   
            };
            if (infrared.job_no != 0)
            {
                string remark = infrared.remarks.Replace(" ", "");
                if (!remark.Equals("FINISH"))
                {
                    if (CheckNGInfraredRadiation(infrared.unit_no))
                    {
                        infrared.remarks = "NG";
                        SetInfraredRadiationById(infrared);
                    }
                    infraredRadiations = GetByPcLineDateInfraredRadiation("line");
                }
                else if (remark.Equals("FINISH"))
                {
                    infrared.remarks = "FINISH";
                    if (SetInfraredRadiationById(infrared))
                        infraredRadiations = GetByPcLineDateInfraredRadiation("line");
                }
            }
            return infraredRadiations;
        }

        //Get Data Set
        public DataTable getDataSetInfraredRadiation(string seri_number)
        {
            DataTable dataInfraredRadiation = new DataTable("DBInfraredRadiation");
            List<InfraredRadiation> radiations = new List<InfraredRadiation>();
            int i = 1;
            if (seri_number.Equals("line"))
            {
                radiations = GetByPcLineDateInfraredRadiation("line").ToList(); 
            }            
            else if (seri_number.Equals("all"))
            {
                radiations = GetByPcLineDateInfraredRadiation("all").ToList();
            }
            else if (seri_number.LastIndexOf(",")!=-1)
            {
                radiations = GetByPcLineDateInfraredRadiation(seri_number).ToList();
            }
            else if (seri_number.Length > 5 && (seri_number.LastIndexOf(",") != 1))
            {
                radiations = CheckIR(seri_number.Trim()).ToList()
               .Where(x => x.unit_no.Trim() == seri_number.Trim()).ToList();
            }

            if (radiations.Count == 0)
            {
                return dataInfraredRadiation;
            }
            else
            {
                List<InfraredRadiationReponse> radiationReponses = new List<InfraredRadiationReponse>();
                foreach (var radiation in radiations)
                {
                    InfraredRadiationReponse infraredRadiationReponse = new InfraredRadiationReponse()
                    {
                        no = i,
                        unit_no = radiation.unit_no,
                        finish_time = radiation.finish_time,
                        start_time = radiation.start_time,
                        remarks = radiation.remarks,
                        time_access = radiation.time_access,
                    };
                    radiationReponses.Add(infraredRadiationReponse);
                    i++;
                }
                // Tạo các cột cho DataTable
                DataColumn noColumn = new DataColumn("No", typeof(int));
                DataColumn unitnoColumn = new DataColumn("UnitNo", typeof(string));
                DataColumn starttimeColumn = new DataColumn("StartTime", typeof(string));
                DataColumn finishtimeColumn = new DataColumn("FinishTime", typeof(string));
                DataColumn remarksColumn = new DataColumn("Remarks", typeof(string));
                DataColumn timeaccessColumn = new DataColumn("TimeAccess", typeof(string));

                dataInfraredRadiation.Columns.Add(noColumn);
                dataInfraredRadiation.Columns.Add(unitnoColumn);
                dataInfraredRadiation.Columns.Add(starttimeColumn);
                dataInfraredRadiation.Columns.Add(finishtimeColumn);
                dataInfraredRadiation.Columns.Add(remarksColumn);
                dataInfraredRadiation.Columns.Add(timeaccessColumn);
                foreach (InfraredRadiationReponse infrared in radiationReponses)
                {
                    DataRow row = dataInfraredRadiation.NewRow();
                    row["no"] = infrared.no;
                    row["unitno"] = infrared.unit_no;
                    row["starttime"] = infrared.start_time;
                    row["finishtime"] = infrared.finish_time;
                    row["remarks"] = infrared.remarks;
                    row["timeaccess"] = infrared.time_access;
                    dataInfraredRadiation.Rows.Add(row);
                }
                return dataInfraredRadiation;
            }          
                    
           
        }        

        //Insert InfraredRadiation in database
        public bool SetInfraredRadiationById(InfraredRadiation infrared)
        {
            bool status = false;
            if (!infrared.Equals("FINISH"))
            {              
                conn.Open();
                string insertQuery = 
                    "EXEC Insert_Infrared_Radiations " +
                    "@job_no = '" + infrared.job_no + "'," +
                    "@kotei_filename = '" + infrared.kotei_filename + "'," +
                    "@unit_no = '" + infrared.unit_no + "'," +
                    "@st_no = '" +infrared.st_no+"'," +
                    "@start_time = '"+infrared.start_time+"'," +
                    "@finish_time = '"+infrared.finish_time+"'," +
                    "@remarks = '"+infrared.remarks+"',"+
                    "@pcline = '"+ host[0] + "'";
                // Tạo đối tượng SqlCommand để thực thi truy vấn INSERT
                using (SqlCommand command = new SqlCommand(insertQuery, conn))
                {
                    // Thực thi truy vấn INSERT
                    int rowsAffected = command.ExecuteNonQuery();
                    status = rowsAffected > 0 ? true : false;      
                }
                conn.Close();              
            }
            return status;
        }

        //check InfraredRadiation Đã tồn tại Finsh

        public Boolean CheckInfraredRadiation(string seri_number)
        {
           bool status = false;
            string remarks = "";
            conn = dbConext.OpenDb();
            string queryString = " select top 1 unit_no,remarks from t_IR_Search_result where t_IR_Search_result.unit_no  =  '" + seri_number+ "' order by  time_access desc";
            // Tạo đối tượng Command
            using (SqlCommand command = new SqlCommand(queryString, conn))
            {
                // Thực thi truy vấn và đọc dữ liệu
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        remarks = (string)reader["remarks"].ToString();
                    }
                }
            }
            status = !remarks.Equals("FINISH") || remarks.Length ==0   ? false : true;    
            dbConext.CloseDb();
            
            return status;
        }


        //check InfraredRadiation Đã tồn tại NG

        public Boolean CheckNGInfraredRadiation(string seri_number)
        {
            bool status = false;
            string remarks = "";
            conn = dbConext.OpenDb();
            string queryString = " select top 1 unit_no,remarks from t_IR_Search_result where t_IR_Search_result.unit_no  =  '" + seri_number + "' order by  time_access desc";
            // Tạo đối tượng Command
            using (SqlCommand command = new SqlCommand(queryString, conn))
            {
                // Thực thi truy vấn và đọc dữ liệu
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        remarks = (string)reader["remarks"].ToString();
                    }
                }
            }
            status = !remarks.Equals("FINISH") || remarks.Length == 0 ? true : false;
            dbConext.CloseDb();

            return status;
        }



    }
    public class CustomText
    {
        public string Text { get; set; }
        public Font Font { get; set; }

        // Constructor để khởi tạo đối tượng CustomText
        public CustomText(string text, Font font)
        {
            Text = text;
            Font = font;
        }
    }

}
