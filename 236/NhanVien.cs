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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
            NapDSBan();
            napDSNuocEp();
            napDSCaPhe();
            napDSSuaChua();
            napDSSinhTo();
            napDSTra();
            napDSBia();

        }


        #region "Ket Noi"
        //KetNoiDuLieu kn = new KetNoiDuLieu();
        public static SqlConnection connect()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=236;Integrated Security=True");
            return con;
        }

        public static DataTable hienthi()
        {
            //SqlConnection con = NhanVien.connect();
            //con.Open();
            //SqlCommand cm = new SqlCommand("select ID,TenDoUong as 'Tên Đồ Uống', SoLuong as 'Số Lượng', Ngay as Ngày, TrangThai as 'Trạng Thái', Ban as Bàn from dsgoido order by Ngay desc", con);
            //SqlDataAdapter da = new SqlDataAdapter(cm);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //con.Close();
            DataTable data = KetNoiDuLieu.ExecuteQuery("select ID,TenDoUong as 'Tên Đồ Uống', SoLuong as 'Số Lượng', Ngay as Ngày, TrangThai as 'Trạng Thái', Ban as Bàn from dsgoido order by Ngay desc");
            return data;
        }
        public DataTable hienthiNhap()
        {
            //SqlConnection con = NhanVien.connect();
            //con.Open();
            //SqlCommand cm = new SqlCommand("select * from DSNhap order by Ngay desc", con);
            //SqlDataAdapter da = new SqlDataAdapter(cm);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //con.Close();
            DataTable data = KetNoiDuLieu.ExecuteQuery("select * from DSNhap order by Ngay desc");
            return data;
        }

        public DataTable hienthiOrder()
        {
            DataTable data = KetNoiDuLieu.ExecuteQuery("USP_HienThiOrder");
            return data;
        }

        public DataTable hienthiBan()
        {
            DataTable data = KetNoiDuLieu.ExecuteQuery("USP_HienThiBan");
            return data;
        }


        //public DataTable chon()
        //{
        //    SqlConnection con = Order.connect();
        //    con.Open();
        //    SqlCommand cm = new SqlCommand("select TenDoUong from DSDoUong", con);
        //    SqlDataAdapter da = new SqlDataAdapter(cm);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}

        public DataTable chonNguyenLieu()
        {
            //SqlConnection con = NhanVien.connect();
            //con.Open();
            //SqlCommand cm = new SqlCommand("select * from DSNguyenLieu", con);
            //SqlDataAdapter da = new SqlDataAdapter(cm);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //con.Close();
            DataTable data = KetNoiDuLieu.ExecuteQuery("select * from DSNguyenLieu");
            return data;
        }

        #endregion
        private void Order_Load(object sender, EventArgs e)
        {
            //NhanVien ql = new NhanVien();
            dataGridView1.DataSource = hienthi();
            //dataGridView2.DataSource = ql.hienthiOrder();
            textBox2.Enabled = false;
            textBox5.Enabled = false;
            textBox5.Clear();
            textBox2.Clear();
            dataGridView2.DataSource = hienthiOrder();
            comboBox1.DataSource = chonNguyenLieu();
            comboBox1.DisplayMember = "Ten";
            /*dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-mm-dd";*/
            //this.IsMdiContainer = true;
            dataGridView3.DataSource = hienthiNhap();

        }
        #region ql don hang
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);
        }

        private void bind_data()
        {
            //binding
            //textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            numericUpDown5.DataBindings.Clear();
            numericUpDown6.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "ID");
            textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "Tên đồ uống");
            numericUpDown5.DataBindings.Add("Value", dataGridView1.DataSource, "Số lượng");
            numericUpDown6.DataBindings.Add("Value", dataGridView1.DataSource, "Bàn");
            //textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "SoLuong");

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bind_data();

            dataGridView1.CurrentRow.Selected = true;
            bind_data();

            //textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Tên đồ uống"].Value.ToString();
            //numericUpDown5.Value = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Số lượng"].Value;
            //numericUpDown5.Value = (int)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Bàn"].Value;

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellClick(sender, e);

        }


        private void button2_Click(object sender, EventArgs e)
        {
            //SqlConnection con = NhanVien.connect();
            //string sql = "update dsgoido set TenDoUong=N'" + textBox4.Text + "',SoLuong='" + numericUpDown5.Text + "',Ban='" + numericUpDown6.Text + "' where ID='" + textBox2.Text + "'";
            //SqlCommand cmd = new SqlCommand(sql, con);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            //NhanVien ql = new NhanVien();
            KetNoiDuLieu.ExecuteNonQuery("update dsgoido set TenDoUong=N'" + textBox4.Text + "',SoLuong='" + numericUpDown5.Text + "',Ban='" + numericUpDown6.Text + "' where ID='" + textBox2.Text + "'");
            dataGridView1.DataSource = hienthi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn không?", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                //SqlConnection con = NhanVien.connect();
                //string sql = "delete from dsgoido where ID='" + textBox2.Text + "'";
                //SqlCommand cmd = new SqlCommand(sql, con);
                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();
                //NhanVien ql = new NhanVien();
                KetNoiDuLieu.ExecuteNonQuery("delete from dsgoido where ID='" + textBox2.Text + "'");
                dataGridView1.DataSource = hienthi();
            }
        }

        #endregion 

        #region nhap hang
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3_CellClick(sender, e);

        }

        private void bind_data2()
        {
            //binding
            //textBox2.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            //textBox6.DataBindings.Clear();
            textBox6.DataBindings.Clear();
            textBox5.DataBindings.Add("Text", dataGridView3.DataSource, "ID");
            //textBox6.DataBindings.Add("Text", dataGridView2.DataSource, "Ten");
            textBox6.DataBindings.Add("Text", dataGridView3.DataSource, "SoLuong");
            //textBox2.DataBindings.Add("Text", dataGridView2.DataSource, "Ngay");
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //throw new NotImplementedException();
            bind_data2();
            dataGridView3.CurrentRow.Selected = true;
            comboBox1.Text = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells["Ten"].Value.ToString();
            //dateTimePicker1.Value = DateTime.Parse(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells["Ngay"].Value.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //thêm hàng nhập
            //SqlConnection con = NhanVien.connect();
            DateTime dt = DateTime.Now;
            string s = dt.ToString();
            //string sql = "insert into DSNhap values(N'" + comboBox1.Text + "','" + textBox6.Text + "','" + s + "')";
            //SqlCommand cmd = new SqlCommand(sql, con);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            KetNoiDuLieu.ExecuteNonQuery("insert into DSNhap values(N'" + comboBox1.Text + "','" + textBox6.Text + "','" + s + "')");
            //NhanVien ql = new NhanVien();
            dataGridView3.DataSource = hienthiNhap();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //sửa DS hàng nhập
            //SqlConnection con = NhanVien.connect();
            DateTime dt = DateTime.Now;
            string s = dt.ToString();
            string t = comboBox1.Text;
            //string sql = "update DSNhap set Ten=N'" + t + "',SoLuong='" + textBox6.Text + "',Ngay='" + s + "' where ID='" + textBox5.Text + "'";
            //SqlCommand cmd = new SqlCommand(sql, con);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();

            KetNoiDuLieu.ExecuteNonQuery("update DSNhap set Ten=N'" + t + "',SoLuong='" + textBox6.Text + "',Ngay='" + s + "' where ID='" + textBox5.Text + "'");
            //NhanVien ql = new NhanVien();
            dataGridView3.DataSource = hienthiNhap();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //xóa hàng nhập
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn không?", "Tiêu đề", MessageBoxButtons.YesNo);
            if (kq == System.Windows.Forms.DialogResult.Yes)
            {
                //SqlConnection con = NhanVien.connect();
                //string sql = "delete from DSNhap where ID='" + textBox5.Text + "'";
                //SqlCommand cmd = new SqlCommand(sql, con);
                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();
                KetNoiDuLieu.ExecuteNonQuery("delete from DSNhap where ID='" + textBox5.Text + "'");
                //NhanVien ql = new NhanVien();
                dataGridView3.DataSource = hienthiNhap();
            }
        }
        #endregion

        #region goi do
        public void ThemDoUong(string TenDoUong, int SoLuong)
        {
            KetNoiDuLieu.ExecuteNonQuery("USP_ThemDoUong @TenDoUong , @SoLuong", new object[] { TenDoUong, SoLuong });
        }

        public bool ktbantrong(int b)
        {
            DataTable data = KetNoiDuLieu.ExecuteQuery("SELECT * FROM Ban WHERE ID = " + b + " AND TrangThai=N'Trống'");
            if (data.Rows.Count > 0)
                return true;
            return false;
        }

        public bool ktdouong(int b)
        {
            DataTable data = KetNoiDuLieu.ExecuteQuery("SELECT * FROM DSGoiDo WHERE TenDoUong = N'" + textBox3.Text + "' AND Ban=" + b + " AND TrangThai!=N'Đã thanh toán'");
            if (data.Rows.Count > 0)
                return true;
            return false;
        }

        //string TenDoUong;
        //int SoLuong;
        //int Ban;
        private void button1_Click(object sender, EventArgs e)
        {
            //them
            //Đang gọi đồ
            NhanVien ql = new NhanVien();
            int a = System.Int32.Parse(numericUpDown1.Text);
            int b = System.Int32.Parse(numericUpDown2.Text);
            string s = textBox3.Text;
            if (ktbantrong(b))
            {
                if (!ktdouong(b))
                {
                    //SqlConnection con = NhanVien.connect();
                    ////string sql = "insert into DSban values(N'" + comboBox1.Text + "','" + textBox1.Text + "','" + dateTimePicker1.Value + "')";
                    //string sql = "USP_ThemDoUong @TenDoUong , @SoLuong, @Ban";
                    //SqlCommand cmd = new SqlCommand(sql, con);
                    //cmd.Parameters.AddWithValue("@TenDoUong", textBox3.Text);
                    //cmd.Parameters.AddWithValue("@SoLuong", numericUpDown1.Text);
                    //cmd.Parameters.AddWithValue("@Ban", numericUpDown2.Text);
                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();

                    KetNoiDuLieu.ExecuteNonQuery("USP_ThemDoUong @TenDoUong , @SoLuong , @Ban", new object[] { s, a, b });
                    //object tdu = textBox3.Text;
                    //int t = System.Int32.Parse(textBox1.Text);
                    //string s = textBox3.ToString();
                    //string item1 = textBox3.Text;
                    //ql.ThemDoUong(comboBox1.Text, t);
                    textBox1.Text = KetNoiDuLieu.ExecuteScalar("USP_HienThiTongTien").ToString();

                    //dataGridView1.DataSource = ql.hienthi();
                    dataGridView2.DataSource = hienthiOrder();
                    return;
                }
                if (ktdouong(b))
                {
                    //SqlConnection con = NhanVien.connect();
                    //string sql = "USP_CapNhatDoUong @TenDoUong , @SoLuong, @Ban";
                    //SqlCommand cmd = new SqlCommand(sql, con);
                    //cmd.Parameters.AddWithValue("@TenDoUong", textBox3.Text);
                    //cmd.Parameters.AddWithValue("@SoLuong", numericUpDown1.Text);
                    //cmd.Parameters.AddWithValue("@Ban", numericUpDown2.Text);
                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();

                    KetNoiDuLieu.ExecuteNonQuery("USP_CapNhatDoUong @TenDoUong , @SoLuong , @Ban", new object[] { s, a, b });
                    textBox1.Text = KetNoiDuLieu.ExecuteScalar("USP_HienThiTongTien").ToString();

                    //dataGridView1.DataSource = ql.hienthi();
                    dataGridView2.DataSource = hienthiOrder();
                    return;

                }
            }
            else if (!ktbantrong(b))
            {
                if (!ktdouong(b))
                {
                    //SqlConnection con = NhanVien.connect();
                    //string sql = "USP_ThemDoUong @TenDoUong , @SoLuong, @Ban";
                    //SqlCommand cmd = new SqlCommand(sql, con);
                    //cmd.Parameters.AddWithValue("@TenDoUong", textBox3.Text);
                    //cmd.Parameters.AddWithValue("@SoLuong", numericUpDown1.Text);
                    //cmd.Parameters.AddWithValue("@Ban", numericUpDown2.Text);
                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();
                    KetNoiDuLieu.ExecuteNonQuery("USP_ThemDoUong @TenDoUong , @SoLuong , @Ban", new object[] { s, a, b });
                    DataTable data = KetNoiDuLieu.ExecuteQuery("USP_XemBan @idban", new object[] { idban = b });
                    dataGridView2.DataSource = data;
                    return;

                }
                else if (ktdouong(b))
                {
                    //SqlConnection con = NhanVien.connect();
                    //string sql = "USP_CapNhatDoUong @TenDoUong , @SoLuong, @Ban";
                    //SqlCommand cmd = new SqlCommand(sql, con);
                    //cmd.Parameters.AddWithValue("@TenDoUong", textBox3.Text);
                    //cmd.Parameters.AddWithValue("@SoLuong", numericUpDown1.Text);
                    //cmd.Parameters.AddWithValue("@Ban", numericUpDown2.Text);
                    //con.Open();
                    //cmd.ExecuteNonQuery();
                    //con.Close();

                    KetNoiDuLieu.ExecuteNonQuery("USP_CapNhatDoUong @TenDoUong , @SoLuong , @Ban", new object[] { s, a, b });
                    DataTable data = KetNoiDuLieu.ExecuteQuery("USP_XemBan @idban", new object[] { idban = b });
                    dataGridView2.DataSource = data;
                    return;

                }
            }
            textBox3.Text = "";
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;

        }




        //static void HienThiLoaiDoUong(FlowLayoutPanel p, string sql)
        //{
        //    p.Controls.Clear();

        //    NhanVien nv = new NhanVien();

        //    List<DoUong> DSDoUong = HienThiDoUong.HienThiDSDoUong(sql);

        //    foreach (DoUong item in DSDoUong)
        //    {
        //        Button btn = new Button()
        //        {
        //            Width = HienThiDoUong.ChieuRong,
        //            Height = HienThiDoUong.ChieuCao
        //        };
        //        btn.Text = item.Ten + Environment.NewLine + item.Gia;
        //        btn.Click += nv.DoUong_Click;
        //        btn.Tag = item;

        //        p.Controls.Add(btn);
        //    }

        //}

        //static void bDU(DoUong du, Button b)
        //{
        //    NhanVien n = new NhanVien();
        //    b.Width = HienThiDoUong.ChieuRong;
        //    b.Height = HienThiDoUong.ChieuCao;
        //    b.Text = du.Ten + Environment.NewLine + du.Gia;
        //    //b.Click += n.DoUong_Click;
        //    b.Tag = du;
        //}
        //public NhanVien nv = new NhanVien();
        class bDU : Button
        {
            private NhanVien nv;

            public void set(DoUong du)
            {
                Width = HienThiDoUong.ChieuRong;
                Height = HienThiDoUong.ChieuCao;
                this.Text = du.Ten + Environment.NewLine + du.Gia;
                //this.Click += nv.DoUong_Click;            
                this.Tag = du;
            }
        }
        void napDSNuocEp()
        {
            //NhanVien.HienThiLoaiDoUong(flowLayoutPanel1, "USP_DanhSachNuocEp");
            flowLayoutPanel1.Controls.Clear();

            List<DoUong> DSDoUong = HienThiDoUong.HienThiDSDoUong("USP_DanhSachNuocEp");

            foreach (DoUong item in DSDoUong)
            {
                bDU bne = new bDU();
                bne.set(item);
                //Button btn = new Button()
                //{
                //    Width = HienThiDoUong.ChieuRong,
                //    Height = HienThiDoUong.ChieuCao
                //};

                //btn.Text = item.Ten + Environment.NewLine + item.Gia;
                //btn.Click += DoUong_Click;
                //btn.Tag = item;
                //bDU(item, btn);
                bne.Click += DoUong_Click;

                flowLayoutPanel1.Controls.Add(bne);
            }
        }

        void napDSCaPhe()
        {
            fLPCaPhe.Controls.Clear();

            List<DoUong> DSDoUong = HienThiDoUong.HienThiDSDoUong("USP_DanhSachCaPhe");

            foreach (DoUong item in DSDoUong)
            {
                bDU bcf = new bDU();
                bcf.set(item);
                bcf.Click += DoUong_Click;
                //Button btn = new Button()
                //{
                //    Width = HienThiDoUong.ChieuRong,
                //    Height = HienThiDoUong.ChieuCao
                //};
                //btn.Text = item.Ten + Environment.NewLine + item.Gia;
                //btn.Click += DoUong_Click;
                //btn.Tag = item;

                fLPCaPhe.Controls.Add(bcf);
            }
        }

        void napDSSuaChua()
        {
            fLPSuaChua.Controls.Clear();

            List<DoUong> DSDoUong = HienThiDoUong.HienThiDSDoUong("USP_DanhSachSuaChua");

            foreach (DoUong item in DSDoUong)
            {
                bDU bsc = new bDU();
                bsc.set(item);
                bsc.Click += DoUong_Click;
                //Button btn = new Button()
                //{
                //    Width = HienThiDoUong.ChieuRong,
                //    Height = HienThiDoUong.ChieuCao
                //};
                //btn.Text = item.Ten + Environment.NewLine + item.Gia;
                //btn.Click += DoUong_Click;
                //btn.Tag = item;

                fLPSuaChua.Controls.Add(bsc);
            }
        }

        void napDSSinhTo()
        {
            fLPSinhTo.Controls.Clear();

            List<DoUong> DSDoUong = HienThiDoUong.HienThiDSDoUong("USP_DanhSachSinhTo");

            foreach (DoUong item in DSDoUong)
            {
                bDU bst = new bDU();
                bst.set(item);
                bst.Click += DoUong_Click;
                //Button btn = new Button()
                //{
                //    Width = HienThiDoUong.ChieuRong,
                //    Height = HienThiDoUong.ChieuCao
                //};
                //btn.Text = item.Ten + Environment.NewLine + item.Gia;
                //btn.Click += DoUong_Click;
                //btn.Tag = item;

                fLPSinhTo.Controls.Add(bst);
            }
        }

        void napDSTra()
        {
            fLPTra.Controls.Clear();

            List<DoUong> DSDoUong = HienThiDoUong.HienThiDSDoUong("USP_DanhSachTra");

            foreach (DoUong item in DSDoUong)
            {
                bDU bt = new bDU();
                bt.set(item);
                bt.Click += DoUong_Click;
                //Button btn = new Button()
                //{
                //    Width = HienThiDoUong.ChieuRong,
                //    Height = HienThiDoUong.ChieuCao
                //};
                //btn.Text = item.Ten + Environment.NewLine + item.Gia;
                //btn.Click += DoUong_Click;
                //btn.Tag = item;

                fLPTra.Controls.Add(bt);
            }
        }

        void napDSBia()
        {
            fLPBia.Controls.Clear();

            List<DoUong> DSDoUong = HienThiDoUong.HienThiDSDoUong("USP_DanhSachBia");

            foreach (DoUong item in DSDoUong)
            {
                bDU bb = new bDU();
                bb.set(item);
                bb.Click += DoUong_Click;
                //Button btn = new Button()
                //{
                //    Width = HienThiDoUong.ChieuRong,
                //    Height = HienThiDoUong.ChieuCao
                //};
                //btn.Text = item.Ten + Environment.NewLine + item.Gia;
                //btn.Click += DoUong_Click;
                //btn.Tag = item;

                fLPBia.Controls.Add(bb);
            }
        }

        void DoUong_Click(object sender, EventArgs e)
        {
            string tenDoUong = ((sender as Button).Tag as DoUong).Ten;
            textBox3.Text = tenDoUong;
            //NhanVien ql = new NhanVien();
            dataGridView2.DataSource = hienthiOrder();
        }

        int idban;
        void Ban_Click(object sender, EventArgs e)
        {
            idban = ((sender as Button).Tag as Ban).ID;
            numericUpDown3.Value = idban;
            DataTable data = KetNoiDuLieu.ExecuteQuery("USP_XemBan @idban", new object[] { idban });
            //NhanVien ql = new NhanVien();
            dataGridView2.DataSource = data;
        }
        void NapDSBan()
        {
            flowLayoutPanel2.Controls.Clear();

            //var htb = new HienThiBan();

            //List<Ban> tableList = htb.HienThiDSBan();

            List<Ban> dsBan = HienThiBan.HienThiDSBan();

            foreach (Ban item in dsBan)
            {
                Button btn = new Button()
                {
                    Width = HienThiBan.ChieuRong,
                    Height = HienThiBan.ChieuCao
                };
                btn.Text = item.Ten + Environment.NewLine + item.TrangThai;
                btn.Click += Ban_Click;
                btn.Tag = item;

                switch (item.TrangThai)
                {
                    case "Trống":
                        btn.BackColor = Color.LimeGreen;
                        btn.ForeColor = Color.White;
                        break;
                    default:
                        btn.BackColor = Color.Orange;
                        btn.ForeColor = Color.White;
                        break;
                }

                flowLayoutPanel2.Controls.Add(btn);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //hoàn thành order
            int n = System.Int32.Parse(numericUpDown2.Text);
            KetNoiDuLieu.ExecuteNonQuery("USP_TruNguyenLieu");
            KetNoiDuLieu.ExecuteNonQuery("USP_HoanThanhOrder");
            //string sql = "USP_DatBan @idban";
            //SqlConnection con = NhanVien.connect();
            //SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@idban", numericUpDown2.Text);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            KetNoiDuLieu.ExecuteNonQuery("USP_DatBan @idban", new object[] { n });
            NapDSBan();
            //int idban = System.Int32.Parse(numericUpDown2.Text);
            //KetNoiDuLieu.Instance.ExecuteNonQuery("USP_DatBan @idban", new object[] { idban });
            //NhanVien ql = new NhanVien();
            dataGridView1.DataSource = hienthi();
            dataGridView2.DataSource = hienthiOrder();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Thanh toán
            int idban = System.Int32.Parse(numericUpDown3.Text);
            KetNoiDuLieu.ExecuteNonQuery("USP_ThanhToan @idban", new object[] { idban });
            KetNoiDuLieu.ExecuteNonQuery("USP_ThanhToanBan @idban", new object[] { idban });
            //NhanVien ql = new NhanVien();
            DataTable dt = KetNoiDuLieu.ExecuteQuery("USP_XemBan @idban", new object[] { idban });
            dataGridView1.DataSource = hienthi();
            dataGridView2.DataSource = dt;
            NapDSBan();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //chuyển bàn
            int bantruoc = (int)numericUpDown3.Value;
            int bansau = (int)numericUpDown4.Value;
            KetNoiDuLieu.ExecuteNonQuery("USP_ThanhToanBan @bantruoc", new object[] { bantruoc });
            KetNoiDuLieu.ExecuteNonQuery("USP_DatBan @bansau", new object[] { bansau });
            //string sql = "USP_DoiBan @bantruoc, @bansau";
            //SqlConnection con = NhanVien.connect();
            //SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@bantruoc", numericUpDown3.Value);
            //cmd.Parameters.AddWithValue("@bansau", numericUpDown4.Value);
            //con.Open();

            //cmd.ExecuteNonQuery();

            //con.Close();
            KetNoiDuLieu.ExecuteNonQuery("USP_DoiBan @bantruoc , @bansau", new object[] { bantruoc, bansau });
            DataTable data = KetNoiDuLieu.ExecuteQuery("USP_XemBan @bansau", new object[] { bansau });
            dataGridView2.DataSource = data;
            NapDSBan();
            numericUpDown3.Value = numericUpDown4.Value;
            numericUpDown4.Value = 0;
        }



        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region QL TK

        private void doimatkhau()
        {
            //SqlConnection con = DangNhap.connect();
            //con.Open();
            //string sql = "select * from DSNV where Username='" + textBox7.Text + "' and Password='" + textBox8.Text + "'";
            //SqlCommand cm = new SqlCommand(sql, con);
            //cm.ExecuteNonQuery();
            //SqlDataAdapter da = new SqlDataAdapter(cm);
            ////ComboBox cb = new ComboBox();
            //DataTable dt = new DataTable();
            //da.Fill(dt);

            ///*            DataGridView dg = new DataGridView();
            //            dg.DataSource = dt;*/

            //foreach (DataRow row in dt.Rows)
            //{
            //    string id = row["id"].ToString();
            //}
            int t = 0;
            if (textBox9.Text.Equals(textBox10.Text))
            {
                //string sql2 = "update DSNV set Password='" + textBox9.Text + "' where Username='" + textBox7.Text + "'";
                //SqlCommand cm2 = new SqlCommand(sql2, con);
                //con.Open();

                //t = (Int32)cm2.ExecuteNonQuery();
                //con.Close();
                t = KetNoiDuLieu.ExecuteNonQuery("update DSNV set Password='" + textBox9.Text + "' where Username='" + textBox7.Text + "'");
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
            }

            if (t > 0)
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else MessageBox.Show("Nhập sai, vui lòng nhập lại");



            //con.Close();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            doimatkhau();
        }
        #endregion
    }

}
