using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace _236
{
    public partial class QL : Form
    {
        public QL()
        {
            InitializeComponent();
        }

        #region "Ket Noi"
        public static SqlConnection connect()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=236;Integrated Security=True");
            return con;
        }

        public DataTable hienthiDoUong()
        {
            SqlConnection con = QL.connect();
            con.Open();
            SqlCommand cm = new SqlCommand("select ID, TenDoUong as 'Tên Đồ Uống', Gia as Giá, Loai as Loại from DSDoUong order by Loai", con);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable hienthiNguyenLieu()
        {
            SqlConnection con = QL.connect();
            con.Open();
            SqlCommand cm = new SqlCommand("select ID, Ten as Tên, GiaNL as 'Giá NL', SLNL from DSNguyenLieu", con);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable hienthiCongThuc()
        {
            SqlConnection con = QL.connect();
            con.Open();
            SqlCommand cm = new SqlCommand("select ID, TenDoUong as 'Tên Đồ Uống', NguyenLieu as 'Nguyên liệu', SoLuong as 'Số lượng' from CongThuc", con);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable hienthiTTB()
        {
            SqlConnection con = QL.connect();
            con.Open();
            SqlCommand cm = new SqlCommand("select ID, Ten as Tên, SoLuong as 'Số Lượng' from DSTrangThietBi", con);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable hienthiNV()
        {
            SqlConnection con = QL.connect();
            con.Open();
            SqlCommand cm = new SqlCommand("select ID, Username, Password, LoaiTK as 'Loại TK' from DSNV", con);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable hienthiTheoNgay()
        {
            SqlConnection con = QL.connect();
            con.Open();
            SqlCommand cm = new SqlCommand("USP_ThongKeTheoNgay", con);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable hienthiTheoDoUong()
        {
            DataTable data = KetNoiDuLieu.Instance.ExecuteQuery("USP_ThongKeTheoLoaiDoUong");
            return data;
        }
        public DataTable hienthiMuaVao()
        {
            SqlConnection con = QL.connect();
            con.Open();
            SqlCommand cm = new SqlCommand("USP_MuaVao", con);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable ThuChi()
        {
            DataTable data = KetNoiDuLieu.Instance.ExecuteQuery("USP_ThongKeTheoThang");
            return data;
        }

        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            QL ql = new QL();
            dataGridView2.DataSource = ql.hienthiDoUong();
            dataGridView3.DataSource = ql.hienthiNguyenLieu();
            dataGridView4.DataSource = ql.hienthiTTB();
            dataGridView1.DataSource = ql.hienthiNV();
            dataGridView5.DataSource = ql.hienthiTheoNgay();
            dataGridView6.DataSource = ql.hienthiMuaVao();
            dataGridView7.DataSource = ql.ThuChi();
            dataGridView8.DataSource = ql.hienthiCongThuc();


            //Do Uong
            textBox4.Clear();
            textBox7.Clear();
            textBox10.Clear();
            textBox10.Enabled = false;
            //Nguyen Lieu
            textBox5.Clear();
            textBox8.Clear();
            textBox11.Clear();
            textBox5.Enabled = false;
            //TTB
            textBox6.Clear();
            textBox9.Clear();
            textBox12.Clear();
            textBox6.Enabled = false;
            //NV
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox13.Enabled = false;
            //CT
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox14.Enabled = false;

            ThongKeTheoNgay();
            BieuDoThuChi();
            BieuDoMuaVao();
        }

        #region "Bieu Do"
        private void BieuDoThuChi()
        {
            SqlConnection con = QL.connect();
            con.Open();
            SqlCommand cm = new SqlCommand("USP_ThongKeTheoThang", con);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            chart2.DataSource = ds;
            //chart2.Series.Add("Thu Chi");
            chart2.Series["Lợi Nhuận"].ChartType = SeriesChartType.Line;
            chart2.Series["Lợi Nhuận"].XValueMember = "Tháng";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chart2.Series["Lợi Nhuận"].YValueMembers = "Lợi Nhuận";
            chart2.Titles.Add("Lợi Nhuận");
            con.Close();
        }

        private void BieuDoMuaVao()
        {
            SqlConnection con = QL.connect();
            con.Open();
            SqlCommand cm = new SqlCommand("USP_MuaVao", con);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            chart3.DataSource = ds;
            //chart2.Series.Add("Thu Chi");
            chart3.Series["Mua Vào"].ChartType = SeriesChartType.Bar;
            chart3.Series["Mua Vào"].XValueMember = "Tên";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chart3.Series["Mua Vào"].YValueMembers = "Tổng số lượng";
            chart3.Titles.Add("Mua Vào");
            con.Close();
        }
        private void ThongKeTheoLoaiDoUong()
        {
            SqlConnection con = QL.connect();
            con.Open();
            SqlCommand cm = new SqlCommand("USP_ThongKeTheoLoaiDoUong", con);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //chart1.Series.Clear();
            chart1.DataSource = ds;
            chart1.Series["Bán Ra"].ChartType = SeriesChartType.Bar;
            chart1.Series["Bán Ra"].XValueMember = "Tên Đồ Uống";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chart1.Series["Bán Ra"].YValueMembers = "Tổng Thu";

            //chart1.Titles.Add("Ban ra");
            con.Close();
        }

        private void ThongKeTheoNgay()
        {
            SqlConnection con = QL.connect();
            con.Open();
            SqlCommand cm = new SqlCommand("USP_ThongKeTheoNgay", con);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //chart1.Series.Clear();
            chart1.DataSource = ds;
            chart1.Series["Bán Ra"].ChartType = SeriesChartType.Column;
            chart1.Series["Bán Ra"].XValueMember = "Ngày";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chart1.Series["Bán Ra"].YValueMembers = "Tổng Thu";
            //chart1.Series.
            //chart1.Titles.Clear();
            //chart1.Titles.Add("Ban ra");
            con.Close();
        }

        #endregion
        private void bind_data()
        {
            //Do uong
            textBox4.DataBindings.Clear();
            textBox7.DataBindings.Clear();
            textBox10.DataBindings.Clear();
            textBox18.DataBindings.Clear();

            //
            textBox10.DataBindings.Add("Text", dataGridView2.DataSource, "ID");
            textBox7.DataBindings.Add("Text", dataGridView2.DataSource, "Tên Đồ Uống");
            textBox4.DataBindings.Add("Text", dataGridView2.DataSource, "Giá");
            textBox18.DataBindings.Add("Text", dataGridView2.DataSource, "Loại");


            //Nguyen Lieu
            textBox5.DataBindings.Clear();
            textBox8.DataBindings.Clear();
            textBox11.DataBindings.Clear();
            //
            textBox5.DataBindings.Add("Text", dataGridView3.DataSource, "ID");
            textBox8.DataBindings.Add("Text", dataGridView3.DataSource, "Tên");
            textBox11.DataBindings.Add("Text", dataGridView3.DataSource, "Giá NL");

            //TTB
            textBox6.DataBindings.Clear();
            textBox9.DataBindings.Clear();
            textBox12.DataBindings.Clear();
            //
            textBox6.DataBindings.Add("Text", dataGridView4.DataSource, "ID");
            textBox9.DataBindings.Add("Text", dataGridView4.DataSource, "Tên");
            textBox12.DataBindings.Add("Text", dataGridView4.DataSource, "Số lượng");

            //NV
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox13.DataBindings.Clear();
            //
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "Username");
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "Password");
            textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "Loại TK");
            textBox13.DataBindings.Add("Text", dataGridView1.DataSource, "ID");

            //CT
            textBox14.DataBindings.Clear();
            textBox15.DataBindings.Clear();
            textBox16.DataBindings.Clear();
            textBox17.DataBindings.Clear();
            //
            textBox14.DataBindings.Add("Text", dataGridView8.DataSource, "ID");
            textBox15.DataBindings.Add("Text", dataGridView8.DataSource, "Tên đồ uống");
            textBox16.DataBindings.Add("Text", dataGridView8.DataSource, "Nguyên liệu");
            textBox17.DataBindings.Add("Text", dataGridView8.DataSource, "Số lượng");


        }

        #region "Su kien"
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bind_data();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2_CellClick(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //them
            SqlConnection con = QL.connect();
            string sql = "insert into DSDoUong (TenDoUong,Gia,Loai) values(N'" + textBox7.Text + "','" + textBox4.Text + "','" + textBox18.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            QL ql = new QL();
            dataGridView2.DataSource = ql.hienthiDoUong();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = QL.connect();
            string sql2 = "update DSDoUong set TenDoUong='" + textBox7.Text + "',Gia='" + textBox4.Text + "',Loai='" + textBox18.Text + "' where ID='" + textBox10.Text + "'";
            SqlCommand cmd = new SqlCommand(sql2, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            QL ql = new QL();
            dataGridView2.DataSource = ql.hienthiDoUong();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc không?", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = QL.connect();
                string sql = "delete from DSDoUong where ID='" + textBox10.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                QL ql = new QL();
                dataGridView2.DataSource = ql.hienthiDoUong();
                textBox4.Clear();
                textBox7.Clear();
                textBox10.Clear();
                textBox18.Clear();
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bind_data();
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3_CellClick(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //them
            SqlConnection con = QL.connect();
            string sql = "insert into DSNguyenLieu (Ten,GiaNL,SLNL) values(N'" + textBox8.Text + "','" + textBox11.Text + "','" + textBox19.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            QL ql = new QL();
            dataGridView3.DataSource = ql.hienthiNguyenLieu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = QL.connect();
            string sql = "update DSNguyenLieu set Ten='" + textBox8.Text + "',Gia='" + textBox11.Text + "' where ID='" + textBox5.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            QL ql = new QL();
            dataGridView3.DataSource = ql.hienthiNguyenLieu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc không?", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = QL.connect();
                string sql = "delete from DSNguyenLieu where ID='" + textBox5.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                QL ql = new QL();
                dataGridView3.DataSource = ql.hienthiNguyenLieu();
                textBox5.Clear();
                textBox8.Clear();
                textBox11.Clear();
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bind_data();
        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView4_CellClick(sender, e);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //them
            SqlConnection con = QL.connect();
            string sql = "insert into DSTrangThietBi (Ten,SoLuong) values(N'" + textBox9.Text + "','" + textBox12.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            QL ql = new QL();
            dataGridView4.DataSource = ql.hienthiTTB();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection con = QL.connect();
            string sql = "update DSTrangThietBi set Ten='" + textBox9.Text + "',SoLuong='" + textBox12.Text + "' where ID='" + textBox6.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            QL ql = new QL();
            dataGridView4.DataSource = ql.hienthiTTB();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc không?", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = QL.connect();
                string sql = "delete from DSTrangThietBi where ID='" + textBox6.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                QL ql = new QL();
                dataGridView4.DataSource = ql.hienthiTTB();
                textBox6.Clear();
                textBox9.Clear();
                textBox12.Clear();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bind_data();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView8_CellClick(sender, e);

        }

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //throw new NotImplementedException();
            bind_data();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //them
            SqlConnection con = QL.connect();
            string sql = "insert into DSNV (Username,Password,LoaiTK) values(N'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            QL ql = new QL();
            dataGridView1.DataSource = ql.hienthiNV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = QL.connect();
            string sql = "update DSNV set Username='" + textBox1.Text + "',Password='" + textBox2.Text + "',LoaiTK='" + textBox3.Text + "' where ID='" + textBox13.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            QL ql = new QL();
            dataGridView1.DataSource = ql.hienthiNV();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc không?", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = QL.connect();
                string sql = "delete from DSNV where ID='" + textBox13.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                QL ql = new QL();
                dataGridView1.DataSource = ql.hienthiNV();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            QL ql = new QL();
            dataGridView5.DataSource = ql.hienthiTheoNgay();

            ThongKeTheoNgay();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            QL ql = new QL();
            dataGridView5.DataSource = ql.hienthiTheoDoUong();
            ThongKeTheoLoaiDoUong();

        }



        #endregion

        private void button17_Click(object sender, EventArgs e)
        {
            SqlConnection con = QL.connect();
            string sql = "insert into CongThuc (TenDoUong,NguyenLieu,SoLuong) values(N'" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            QL ql = new QL();
            dataGridView8.DataSource = ql.hienthiCongThuc();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SqlConnection con = QL.connect();
            string sql = "update CongThuc set TenDoUong=N'" + textBox15.Text + "',NguyenLieu=N'" + textBox16.Text + "',SoLuong='" + textBox17.Text + "' where ID='" + textBox14.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            QL ql = new QL();
            dataGridView8.DataSource = ql.hienthiCongThuc();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc không?", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection con = QL.connect();
                string sql = "delete from CongThuc where ID='" + textBox14.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                QL ql = new QL();
                dataGridView8.DataSource = ql.hienthiCongThuc();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();

            }
        }
    }
}
