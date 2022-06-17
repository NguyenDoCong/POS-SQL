using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236
{
    public class DoUong
    {
        public DoUong(string id, string ten, string loai, float gia)
        {
            this.ID = id;
            this.Ten = ten;
            this.Loai = loai;
            this.Gia = gia;
        }

        public DoUong(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.Ten = row["TenDoUong"].ToString();
            this.Loai = row["Loai"].ToString();
            this.Gia = (float)Convert.ToDouble(row["Gia"].ToString());
        }

        private float gia;

        public float Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        private string loai;

        public string Loai
        {
            get { return loai; }
            set { loai = value; }
        }

        private string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        private string iD;

        public string ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
