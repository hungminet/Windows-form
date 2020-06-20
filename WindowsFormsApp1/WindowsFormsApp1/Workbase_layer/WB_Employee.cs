using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DB_layer;

namespace WindowsFormsApp1.Workbase_layer
{
    class WB_Employee
    {
        DB_Layer _dB_Layer = null;
        public WB_Employee()
        {
            _dB_Layer = new DB_Layer();
        }

        public DataSet GetEmployee()
        {
            return _dB_Layer.ExeQueryDataSet("SELECT * FROM NHANVIEN", CommandType.Text);
        }
        public bool AddEmployee(string EmID, string em_Name, int sex,
            int cmnd, int sdt, int tt, ref string err)
        {
            string sqlSting = "INSERT INTO NHANVIEN VALUES ("
                + "'" + EmID + "'"
                + ",'" + em_Name + "'"
                + "," + sex
                + "," + cmnd
                + ",N'" + sdt + "'"
                + ",N'" + tt + "'"
                + ",'" + Hinh + "')";
            return _dB_Layer.ExeNonQuery(sqlSting, CommandType.Text, ref err);
        }

        public bool DelEmployee(string Employee_ID, ref string err)
        {
            string sqlString = "UPDATE NHANVIEN SET TT_LamViec = 0 + WHERE MaNV = '" + Employee_ID + "'";
            return _dB_Layer.ExeNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool EditEmployee(string Employee_ID, string City_name_edited, ref string err)
        {
            string sqlString = "UPDATE ThanhPho SET TenThanhPho =N'" + City_name_edited + "'" + "WHERE ThanhPho = '" + City_ID + "'";
            return _dB_Layer.ExeNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
