using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL_QuanLy
{
    public class DBConnect
    {
        protected SqlConnection _conn = new SqlConnection("Data Source=.;Initial Catalog=QLPHONGTRO;Integrated Security=True;TrustServerCertificate=True");

        // 1. Hàm thực thi câu lệnh SELECT
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable data = new DataTable();
            try
            {
                if (_conn.State == ConnectionState.Closed) _conn.Open();

                using (SqlCommand command = new SqlCommand(query, _conn))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(data);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi ExecuteQuery: " + ex.Message);
            }
            finally
            {
                if (_conn.State == ConnectionState.Open) _conn.Close();
            }
            return data;
        }

        // 2. Hàm thực thi lệnh INSERT, UPDATE, DELETE
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int acceptedRows = 0;
            try
            {
                if (_conn.State == ConnectionState.Closed) _conn.Open();

                using (SqlCommand command = new SqlCommand(query, _conn))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    acceptedRows = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi ExecuteNonQuery: " + ex.Message);
            }
            finally
            {
                if (_conn.State == ConnectionState.Open) _conn.Close();
            }
            return acceptedRows;
        }

        // 3. Hàm trả về 1 giá trị duy nhất
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object data = null;
            try
            {
                if (_conn.State == ConnectionState.Closed) _conn.Open();

                using (SqlCommand command = new SqlCommand(query, _conn))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    data = command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi ExecuteScalar: " + ex.Message);
            }
            finally
            {
                if (_conn.State == ConnectionState.Open) _conn.Close();
            }
            return data;
        }
    }
}