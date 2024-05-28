using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QL_XeMay
{
    public partial class form_menu : Form
    {
        public form_menu()
        {
            InitializeComponent();
        }

        private void form_menu_Load(object sender, EventArgs e)
        {
            dataGridView_khohang.DataSource = GetAllKhoHang().Tables[0];
            dataGridView_khachhang.DataSource = GetAllKhachHang().Tables[0];
            dataGridView_nhanvien.DataSource = GetAllNhanVien().Tables[0];
            dataGridView_ChiTietHoaDon.DataSource = GetAllChiTietHoaDon().Tables[0];
            dataGridView_tknam.DataSource = tknam().Tables[0];
            dataGridView_tkthang.DataSource = tkthang().Tables[0];
            dataGridView1.DataSource = tktheosoluongban().Tables[0];
        }
        // lấy dữ liệu trong data base
        DataSet GetAllKhachHang()
        {
            DataSet data = new DataSet();
            //Sqlconnection
            string query = "select MaKh,TenKh,SDT,DiaChi from KhachHang";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(data);
                conn.Close();
            }
            return data;
        }
        DataSet GetAllKhoHang()
        {
            DataSet data = new DataSet();
            //Sqlconnection
            string query = "select MaSp,TenSp,Nsx,Soluong,Gianhap from KhoHang";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(data);
                conn.Close();
            }
            return data;
        }
        DataSet GetAllNhanVien()
        {
            DataSet data = new DataSet();
            //Sqlconnection
            string query = "select MaNv,TenNv,SDT,NgaySinh,DiaChi,luong from NhanVien";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(data);
                conn.Close();
            }
            return data;
        }
        DataSet GetAllChiTietHoaDon()
        {
            DataSet data = new DataSet();
            string query = "select MaHd,MaKh,MaNv,NgayBan from HoaDon";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(data);
                conn.Close();
            }
            return data;
        }
        // events click datagridView
        private void dataGridView_khachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView_khachhang.CurrentRow.Index;
            textBox2.Text = dataGridView_khachhang.Rows[i].Cells[0].Value.ToString();
            Tenkh.Text = dataGridView_khachhang.Rows[i].Cells[1].Value.ToString();
            Sdt.Text = dataGridView_khachhang.Rows[i].Cells[2].Value.ToString();
            diachi.Text = dataGridView_khachhang.Rows[i].Cells[3].Value.ToString();
        }

        private void dataGridView_khohang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView_khohang.CurrentRow.Index;
            textBox3.Text = dataGridView_khohang.Rows[i].Cells[0].Value.ToString();
            TebSp.Text = dataGridView_khohang.Rows[i].Cells[1].Value.ToString();
            Nsx.Text = dataGridView_khohang.Rows[i].Cells[2].Value.ToString();
            SoLuong.Text = dataGridView_khohang.Rows[i].Cells[3].Value.ToString();
            GiaNhap.Text = dataGridView_khohang.Rows[i].Cells[4].Value.ToString();
        }

        private void dataGridView_nhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView_nhanvien.CurrentRow.Index;
            textBox4.Text = dataGridView_nhanvien.Rows[i].Cells[0].Value.ToString();
            TenNv.Text = dataGridView_nhanvien.Rows[i].Cells[1].Value.ToString();
            sdt1.Text = dataGridView_nhanvien.Rows[i].Cells[2].Value.ToString();
            NgaySinh.Text = dataGridView_nhanvien.Rows[i].Cells[3].Value.ToString();
            luong.Text = dataGridView_nhanvien.Rows[i].Cells[5].Value.ToString();
            diachi1.Text = dataGridView_nhanvien.Rows[i].Cells[4].Value.ToString();
        }
        //them kho hang
        private void btn_them2_Click(object sender, EventArgs e)
        {
            string sqlInSert = "insert into KhoHang values(@TenSp,@Nsx,@Soluong,@Gianhap)";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlInSert, conn);
                cmd.Parameters.AddWithValue("TenSp", TebSp.Text);
                cmd.Parameters.AddWithValue("Nsx", Nsx.Text);
                cmd.Parameters.AddWithValue("Soluong", SoLuong.Text);
                cmd.Parameters.AddWithValue("Gianhap", GiaNhap.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            TebSp.Text = Nsx.Text = SoLuong.Text = GiaNhap.Text = "";
            TebSp.Focus();
            dataGridView_khohang.DataSource = GetAllKhoHang().Tables[0];
            //MessageBox.Show("Thêm thành công ");
        }
        //them khach hang
        private void btn_them_Click(object sender, EventArgs e)
        {
            string sqlinsert = "insert into KhachHang values(@TenKh,@SDT,@DiaChi)";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlinsert, conn);
                cmd.Parameters.AddWithValue("TenKh", Tenkh.Text);
                cmd.Parameters.AddWithValue("SDT", Sdt.Text);
                cmd.Parameters.AddWithValue("DiaChi", diachi.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            Tenkh.Text = Sdt.Text = diachi.Text = "";
            Tenkh.Focus();
            dataGridView_khachhang.DataSource = GetAllKhachHang().Tables[0];
        }
        //sua kho hang
        private void btn_sua2_Click(object sender, EventArgs e)
        {
            string sqledit = "update KhoHang set TenSp=@TenSp,Nsx=@Nsx,Soluong=@Soluong,Gianhap=@Gianhap where MaSp=@MaSp";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqledit, conn);
                cmd.Parameters.AddWithValue("MaSp", textBox3.Text);
                cmd.Parameters.AddWithValue("TenSp", TebSp.Text);
                cmd.Parameters.AddWithValue("Nsx", Nsx.Text);
                cmd.Parameters.AddWithValue("Soluong", SoLuong.Text);
                cmd.Parameters.AddWithValue("Gianhap", GiaNhap.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            TebSp.Text = Nsx.Text = SoLuong.Text = GiaNhap.Text = textBox3.Text = "";
            TebSp.Focus();
            dataGridView_khohang.DataSource = GetAllKhoHang().Tables[0];
        }
        //xoa kho hang
        private void btn_xoa2_Click(object sender, EventArgs e)
        {
            string sqldelete = "delete from KhoHang where MaSp=@MaSp";
            DialogResult dl = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqldelete, conn);
                    cmd.Parameters.AddWithValue("MaSp", textBox3.Text);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            TebSp.Text = Nsx.Text = SoLuong.Text = GiaNhap.Text = textBox3.Text = "";
            TebSp.Focus();
            dataGridView_khohang.DataSource = GetAllKhoHang().Tables[0];
        }
        //sua khach hang
        private void btn_sua_Click(object sender, EventArgs e)
        {
            string sqledit = "update KhachHang set TenKh=@TenKh,SDT=@SDT,DiaChi=@DiaChi where MaKh=@MaKh";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqledit, conn);
                cmd.Parameters.AddWithValue("MaKh", textBox2.Text);
                cmd.Parameters.AddWithValue("TenKh", Tenkh.Text);
                cmd.Parameters.AddWithValue("SDT", Sdt.Text);
                cmd.Parameters.AddWithValue("DiaChi", diachi.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            Tenkh.Text = Sdt.Text = diachi.Text = textBox2.Text = "";
            Tenkh.Focus();
            dataGridView_khachhang.DataSource = GetAllKhachHang().Tables[0];
        }
        //xoa khach hang
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string sqldelete = "delete from KhachHang where MaKh=@MaKh";
            DialogResult dl = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqldelete, conn);
                    cmd.Parameters.AddWithValue("MaKh", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            Tenkh.Text = Sdt.Text = diachi.Text = textBox2.Text = "";
            Tenkh.Focus();
            dataGridView_khachhang.DataSource = GetAllKhachHang().Tables[0];
        }
        //them nhan vien 
        private void them1btn__Click(object sender, EventArgs e)
        {
            string insert = "insert into NhanVien values(@TenNv,@SDT,@DiaChi,@NgaySinh,@luong)";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("TenNv", TenNv.Text);
                cmd.Parameters.AddWithValue("SDT", sdt1.Text);
                cmd.Parameters.AddWithValue("DiaChi", diachi1.Text);
                cmd.Parameters.AddWithValue("NgaySinh", Convert.ToDateTime(NgaySinh.Text));
                cmd.Parameters.AddWithValue("luong", luong.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            TenNv.Text = sdt1.Text = diachi1.Text = NgaySinh.Text = luong.Text = "";
            TenNv.Focus();
            dataGridView_nhanvien.DataSource = GetAllNhanVien().Tables[0];
        }
        //sua nhan vien
        private void btn_sua1_Click(object sender, EventArgs e)
        {
            string sqledit = "update NhanVien set TenNv=@TenNv,SDT=@SDT,NgaySinh=@NgaySinh,luong=@luong where MaNv=@MaNv";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqledit, conn);
                cmd.Parameters.AddWithValue("TenNv", textBox4.Text);
                cmd.Parameters.AddWithValue("SDT", sdt1.Text);
                cmd.Parameters.AddWithValue("DiaChi", diachi1.Text);
                cmd.Parameters.AddWithValue("NgaySinh", Convert.ToDateTime(NgaySinh.Text));
                cmd.Parameters.AddWithValue("luong", luong.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            TenNv.Text = sdt1.Text = diachi1.Text = NgaySinh.Text = luong.Text = textBox4.Text = "";
            TenNv.Focus();
            dataGridView_nhanvien.DataSource = GetAllNhanVien().Tables[0];
        }
        //xoa nhan vien
        private void btn_xoa1_Click(object sender, EventArgs e)
        {
            string sqldelete = "delete from NhanVien where MaNv=@MaNV";
            DialogResult dl = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqldelete, conn);
                    cmd.Parameters.AddWithValue("TenNv", textBox4.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            TenNv.Text = sdt1.Text = diachi1.Text = NgaySinh.Text = luong.Text = textBox4.Text = "";
            TenNv.Focus();
            dataGridView_nhanvien.DataSource = GetAllNhanVien().Tables[0];
        }

        //them hoa don
        private void btn_themhd_Click(object sender, EventArgs e)
        {
            string sqlinsert = "insert into HoaDon(MaNv,MaKh,NgayBan) values(@MaNv,@MaKh,@NgayBan)";


            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlinsert, conn);
                cmd.Parameters.AddWithValue("MaNv", textBox3_Manv.Text);
                cmd.Parameters.AddWithValue("MaKh", textBox4_Makh.Text);
                cmd.Parameters.AddWithValue("NgayBan", Convert.ToDateTime(nb.Text));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            textBox3_Manv.Text = textBox4_Makh.Text = "";
            textBox3_Manv.Focus();
            dataGridView_ChiTietHoaDon.DataSource = GetAllChiTietHoaDon().Tables[0];
            var myform = new ChiTietHoaDon();
            myform.Show();
        }
        //xoa hoa don
        private void btn_xoahd_Click(object sender, EventArgs e)
        {
            string sqldelete = "delete from HoaDon where MaHd=@MaHd";
            DialogResult dl = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqldelete, conn);
                    cmd.Parameters.AddWithValue("MaHd", textBox1.Text);


                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            textBox1.Text = "";
            textBox1.Focus();
            dataGridView_ChiTietHoaDon.DataSource = GetAllChiTietHoaDon().Tables[0];
        }
        private void dataGridView_ChiTietHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var myform = new ChiTietHoaDon();
            myform.Show();


        }
        //thong ke

        DataSet tknam()
        {
            DataSet data = new DataSet();
            string sqlselct = "select b.TenSp,a.Soluongdat  from dbo.ChiTietHoaDon as a ,dbo.KhoHang as b,dbo.HoaDon as c\r\nwhere a.MaSp=b.MaSp  and  a.Mahd1=c.MaHd and YEAR(c.NgayBan)=YEAR(GETDATE())";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlselct, conn);
                adapter.Fill(data);
                conn.Close();
            }
            return data;
        }
        DataSet tkthang()
        {
            DataSet data = new DataSet();
            string sqlselct = "select b.TenSp,a.Soluongdat  from dbo.ChiTietHoaDon as a ,dbo.KhoHang as b,dbo.HoaDon as c\r\nwhere a.MaSp=b.MaSp  and  a.Mahd1=c.MaHd and Month(c.NgayBan)=Month(GETDATE())";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlselct, conn);
                adapter.Fill(data);
                conn.Close();
            }
            return data;
        }
        DataSet tktheosoluongban()
        {
            DataSet data = new DataSet();
            string sqlselct = "select b.TenSp,a.Soluongdat,c.NgayBan from ChiTietHoaDon as a ,KhoHang as b,HoaDon as c \r\nwhere a.MaSp=(select top 1 MaSp from ChiTietHoaDon group by MaSp order by SUM(Soluongdat) desc) and a.MaSp=b.MaSp  and  a.Mahd1=c.MaHd ;";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlselct, conn);
                adapter.Fill(data);
                conn.Close();
            }
            return data;
        }



        //tim kiem khach hang 
        public void serchkhachahng(string valuestofind)
        {
            string query = "select TenKh,SDT,DiaChi from KhachHang where TenKh like'%" + valuestofind + "%'";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView_khachhang.DataSource = table;
                conn.Close();
            }
        }
        private void textBox1_tkkh_TextChanged(object sender, EventArgs e)
        {
            serchkhachahng(textBox1_tkkh.Text);
        }
        //tim kiem san pham
        public void serchkhohang(string valuestofind)
        {
            string query = "select TenSp,Nsx,Soluong,Gianhap from KhoHang where TenSp like N'%" + valuestofind + "%'";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView_khohang.DataSource = table;
                conn.Close();
            }
        }
        private void textBox1_tksp_TextChanged(object sender, EventArgs e)
        {
            serchkhohang(textBox1_tksp.Text);
        }
        //tim kiem nhan vien 
        public void serchnhanvien(string valuestofind)
        {
            string query = "select TenNv,SDT,NgaySinh,DiaChi,luong from NhanVien where TenNv like N'%" + valuestofind + "%'";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView_nhanvien.DataSource = table;
                conn.Close();
            }
        }

        private void textBox1_tknv_TextChanged(object sender, EventArgs e)
        {
            serchnhanvien(textBox1_tknv.Text);
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }
    }
}
