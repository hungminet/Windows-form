using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DB_layer
{
    class DB_Layer
    {
        string ConnectStr = "Data Source = (local)" +
        ";Initial Catalog = QUANLIBANHANG;" +
        "Integrated Security = True";
        SqlConnection sqlConnection = null;
        SqlCommand sqlCommand = null;
        SqlDataAdapter sqlAdapter = null;

        public DB_Layer()
        {
            sqlConnection = new SqlConnection(ConnectStr);
            sqlCommand = sqlConnection.CreateCommand();
        }

        public DataSet ExeQueryDataSet(string strSQL, CommandType commandtype)
        {
            if (sqlConnection.State == ConnectionState.Open)
                sqlConnection.Close();
            sqlConnection.Open();
            sqlCommand.CommandText = strSQL;
            sqlCommand.CommandType = commandtype;
            sqlAdapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds);
            return ds;
        }



        public bool ExeNonQuery(string strSQL, CommandType commandType, ref string error)
        {
            bool f = false;
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            sqlConnection.Open();
            sqlCommand.CommandText = strSQL;
            sqlCommand.CommandType = commandType;
            try
            {
                sqlCommand.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                sqlConnection.Close();
            }
            return f;
        }


    }
}
