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
        public System.Data.Linq.Table<ThanhPho> LayThanhPho()
        {
            //DataSet ds = new DataSet();
            QLBHDataContext qlBH = new QLBHDataContext();
            return qlBH.ThanhPhos;
        }
        public bool AddCity(string cityID, string cityName, ref string err)
        {
            QLBHDataContext qLBH = new QLBHDataContext();
            ThanhPho city = new ThanhPho();
            city.ThanhPho1 = cityID.Trim();
            city.TenThanhPho = cityName.Trim();
            qLBH.ThanhPhos.InsertOnSubmit(city);
            qLBH.ThanhPhos.Context.SubmitChanges();
            return true;
        }
        public bool RemoveCity(string cityID, ref string err)
        {
            QLBHDataContext qLBH = new QLBHDataContext();
            var TP = from tp in qLBH.ThanhPhos
                     where tp.ThanhPho1 == cityID
                     select tp;
            qLBH.ThanhPhos.DeleteAllOnSubmit(TP);
            qLBH.SubmitChanges();
            return true;
        }

        public bool UpdateCity(string cityID, string cityName, ref string err)
        {
            QLBHDataContext qLBH = new QLBHDataContext();
            var TP = (from tp in qLBH.ThanhPhos
                           where tp.ThanhPho1 == cityID
                           select tp).SingleOrDefault();
            if (TP != null)
            {
                TP.TenThanhPho = cityID;
                qLBH.SubmitChanges();
            }
            return true;
        }
    }
}
