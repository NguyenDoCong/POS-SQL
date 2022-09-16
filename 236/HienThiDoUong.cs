using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _236
{
    public class HienThiDoUong
    {
        //private static HienThiDoUong instance;

        //public static HienThiDoUong Instance
        //{
        //    get { if (instance == null) instance = new HienThiDoUong(); return HienThiDoUong.instance; }
        //    private set { HienThiDoUong.instance = value; }
        //}

        public static int ChieuRong = 100;
        public static int ChieuCao = 50;

        private HienThiDoUong() { }

        public static List<DoUong> HienThiDSDoUong(string sql)
        {
            //var kn = new KetNoiDuLieu();

            List<DoUong> DSDoUong = new List<DoUong>();

            DataTable data = KetNoiDuLieu.ExecuteQuery(sql);

            //DataTable data = kn.taobang("SELECT * FROM Ban");

            foreach (DataRow item in data.Rows)
            {
                DoUong du = new DoUong(item);
                DSDoUong.Add(du);
            }

            return DSDoUong;
        }

        

    }
}
