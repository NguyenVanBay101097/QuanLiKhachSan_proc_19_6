using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLiKhachSan.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        

        public static DataProvider Instance {
            get
            {
                if (instance == null) instance = new DataProvider(); return DataProvider.instance;
            }
            private set
            {
                DataProvider.instance = value;
            }
        }

        private DataProvider() {
        }

        public DataTable ExecuteQuery(string query,object[] parameter=null)
        {
           
                string sever = fLogin.Laytenserver;
            string id = fLogin.TaiKhoan;
            string matkhau = fLogin.MatKhau;
            string ConnectSTR = @"Server="+@sever+ ";Database=QuanLiKhachSan;User Id=" + id+";Password ="+matkhau;
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectSTR))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (var item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                   
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                    connection.Close();

            }
            return dataTable;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            string sever = fLogin.Laytenserver;
            string ConnectSTR = @"Server=" + @sever + ";Database=QuanLiKhachSan;Trusted_Connection=True";
            int data = 0;
            using (SqlConnection connection = new SqlConnection(ConnectSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            string sever = fLogin.Laytenserver;
            string ConnectSTR = @"Server=" + @sever + ";Database=QuanLiKhachSan;Trusted_Connection=True";
            object data = 0;
            using (SqlConnection connection = new SqlConnection(ConnectSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (var item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
