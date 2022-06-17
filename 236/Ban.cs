using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236
{
    public class Ban
    {
        public Ban(int id, string ten, string trangthai)
        {
            this.ID = id;
            this.Ten = ten;
            this.TrangThai = trangthai;
        }

        public Ban(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Ten = row["TenBan"].ToString();
            this.TrangThai = row["TrangThai"].ToString();
        }

        private string trangThai;

        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        private string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
