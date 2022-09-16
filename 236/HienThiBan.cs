using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236
{
    
        public class HienThiBan
    {
        //private static HienThiBan instance;

        //public static HienThiBan Instance
        //{
        //    get { if (instance == null) instance = new HienThiBan(); return HienThiBan.instance; }
        //    private set { HienThiBan.instance = value; }
        //}

        public static int ChieuRong = 90;
        public static int ChieuCao = 90;

        private HienThiBan() { }

        public static List<Ban> HienThiDSBan()
        {
            //var kn = new KetNoiDuLieu();

            List<Ban> dsBan = new List<Ban>();

            DataTable data = KetNoiDuLieu.ExecuteQuery("USP_DanhSachBan");

            //DataTable data = kn.taobang("SELECT * FROM Ban");

            foreach (DataRow item in data.Rows)
            {
                Ban b = new Ban(item);
                dsBan.Add(b);
            }

            return dsBan;
        }
    }
}
