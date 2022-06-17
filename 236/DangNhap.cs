using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace _236
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        public static SqlConnection connect()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=236;Integrated Security=True");
            return con;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        string s;

        private void dn()
        {
            this.Hide();
            SqlConnection con = DangNhap.connect();
            con.Open();
            string sql = "select * from DSNV where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";
            SqlCommand cm = new SqlCommand(sql, con);
            cm.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            ComboBox cb = new ComboBox();
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataGridView dg = new DataGridView();
            dg.DataSource = dt;


            foreach (DataRow row in dt.Rows)
            {
                s = row["loaitk"].ToString();

            }
            con.Close();

            if (s.Contains("Admin"))
            {
                QL ql = new QL();
                ql.ShowDialog();
            }
            else if (s.Contains("NV"))
            {
                Order ql = new Order();
                ql.ShowDialog();
            }
            else if (s.Contains("Thu kho"))
            {
                //NhapXuat ql = new NhapXuat();
                //ql.ShowDialog();
            }
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dn();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down
                dn();
            }
        }
    }
}
