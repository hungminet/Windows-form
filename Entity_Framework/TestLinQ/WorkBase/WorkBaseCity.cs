using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLinQ.WorkBase
{
    class WorkBaseCity
    {
        public DataTable GetCities()
        {
            QuanLyBanHangEntities quanLyBanHangEntities = new QuanLyBanHangEntities();

            var tps = from p in quanLyBanHangEntities.ThanhPhoes
                      select p;
            DataTable data = new DataTable();
            data.Columns.Add("Mã thành phố");
            data.Columns.Add("Tên thành phố");
            foreach (var p in tps)
            {
                data.Rows.Add(p.ThanhPho1, p.TenThanhPho);
            }
            return data;
        }
        public bool AddCity(string cityID, string cityName, ref string err)
        {
            QuanLyBanHangEntities qLBH = new QuanLyBanHangEntities();
            ThanhPho city = new ThanhPho();
            city.ThanhPho1 = cityID.Trim();
            city.TenThanhPho = cityName.Trim();
            qLBH.ThanhPhoes.Add(city);
            qLBH.SaveChanges();
            return true;
        }
        public bool RemoveCity(string cityID, ref string err)
        {
            QuanLyBanHangEntities qLBH = new QuanLyBanHangEntities();

            ThanhPho tp = new ThanhPho();
            tp.ThanhPho1 = cityID;
            qLBH.ThanhPhoes.Attach(tp);
            qLBH.ThanhPhoes.Remove(tp);
            qLBH.SaveChanges();
            return true;
        }

        public bool UpdateCity(string cityID, string cityName, ref string err)
        {
            QuanLyBanHangEntities qLBH = new QuanLyBanHangEntities();
            var TP = (from tp in qLBH.ThanhPhoes
                           where tp.ThanhPho1 == cityID
                           select tp).SingleOrDefault();
            if (TP != null)
            {
                TP.TenThanhPho = cityName;
                qLBH.SaveChanges();
            }
            return true;
        }
    }
}
