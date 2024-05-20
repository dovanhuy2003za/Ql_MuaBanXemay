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
            string query = "select*from KhachHang";
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
            string query = "select*from Khohang";
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
            string query = "select*from NhanVien";
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
            string query = "select * from ChiTietHoaDon";
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
            Makh.Text = dataGridView_khachhang.Rows[i].Cells[0].Value.ToString();
            Tenkh.Text = dataGridView_khachhang.Rows[i].Cells[1].Value.ToString();
            Sdt.Text = dataGridView_khachhang.Rows[i].Cells[2].Value.ToString();
            diachi.Text = dataGridView_khachhang.Rows[i].Cells[3].Value.ToString();
        }

        private void dataGridView_khohang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView_khohang.CurrentRow.Index;
            MaSp.Text = dataGridView_khohang.Rows[i].Cells[0].Value.ToString();
            TebSp.Text = dataGridView_khohang.Rows[i].Cells[1].Value.ToString();
            Nsx.Text = dataGridView_khohang.Rows[i].Cells[2].Value.ToString();
            SoLuong.Text = dataGridView_khohang.Rows[i].Cells[3].Value.ToString();
            GiaNhap.Text = dataGridView_khohang.Rows[i].Cells[4].Value.ToString();
        }

        private void dataGridView_nhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView_nhanvien.CurrentRow.Index;
            Manv.Text = dataGridView_nhanvien.Rows[i].Cells[0].Value.ToString();
            TenNv.Text = dataGridView_nhanvien.Rows[i].Cells[1].Value.ToString();
            sdt1.Text = dataGridView_nhanvien.Rows[i].Cells[2].Value.ToString();
            NgaySinh.Text = dataGridView_nhanvien.Rows[i].Cells[4].Value.ToString();
            luong.Text = dataGridView_nhanvien.Rows[i].Cells[5].Value.ToString();
            diachi1.Text = dataGridView_nhanvien.Rows[i].Cells[3].Value.ToString();
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
                cmd.Parameters.AddWithValue("MaSp", MaSp.Text);
                cmd.Parameters.AddWithValue("TenSp", TebSp.Text);
                cmd.Parameters.AddWithValue("Nsx", Nsx.Text);
                cmd.Parameters.AddWithValue("Soluong", SoLuong.Text);
                cmd.Parameters.AddWithValue("Gianhap", GiaNhap.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            MaSp.Text = TebSp.Text = Nsx.Text = SoLuong.Text = GiaNhap.Text = "";
            MaSp.Focus();
            dataGridView_khohang.DataSource = GetAllKhoHang().Tables[0];
        }
        //xoa kho hang
        private void btn_xoa2_Click(object sender, EventArgs e)
        {
            string sqldelete = "delete from KhoHang where MaSp=@MaSp";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqldelete, conn);
                cmd.Parameters.AddWithValue("MaSp", MaSp.Text);
                cmd.Parameters.AddWithValue("TenSp", TebSp.Text);
                cmd.Parameters.AddWithValue("Nsx", Nsx.Text);
                cmd.Parameters.AddWithValue("Soluong", SoLuong.Text);
                cmd.Parameters.AddWithValue("Gianhap", GiaNhap.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            MaSp.Text = TebSp.Text = Nsx.Text = SoLuong.Text = GiaNhap.Text = "";
            MaSp.Focus();
            dataGridView_khohang.DataSource = GetAllKhoHang().Tables[0];
        }
        //sua khach hang
        private void btn_sua_Click(object sender, EventArgs e)
        {
            string sqledit = "update KhachHang set TenKh=@TenKh,SDT=@SDT,DiaChi=@DiaChi where MaSp=@MaSp";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqledit, conn);
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
        //xoa khach hang
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string sqldelete = "delete from KhachHang where MaSp=@MaSp";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqldelete, conn);
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
        //xoa nhan vien
        private void btn_xoa1_Click(object sender, EventArgs e)
        {
            string sqldelete = "delete from NhanVien where MaNv=@MaNV";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqldelete, conn);
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

        //them hoa don
        private void btn_themhd_Click(object sender, EventArgs e)
        {
            string sqlinsert = "insert into ChiTietHoaDon(TenHd,MaNv,MaKh,MaSp,TenSp,Soluongdat,dongia,NgayBan) values(@TenHd,@MaNv,@MaKh,@MaSp,@TenSp,@Soluongdat,@dongia,@NgayBan)";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlinsert, conn);
                cmd.Parameters.AddWithValue("TenHd", TenHd.Text);
                cmd.Parameters.AddWithValue("MaNv", textBox3_Manv.Text);
                cmd.Parameters.AddWithValue("MaKh", textBox4_Makh.Text);
                cmd.Parameters.AddWithValue("MaSp", textBox5_Masp.Text);
                cmd.Parameters.AddWithValue("TenSp", textBox6_Tensp.Text);
                cmd.Parameters.AddWithValue("Soluongdat", textBox7_sldat.Text);
                cmd.Parameters.AddWithValue("dongia", textBox8_dongia.Text);
                cmd.Parameters.AddWithValue("NgayBan", Convert.ToDateTime(nb.Text));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            TenHd.Text = textBox3_Manv.Text = textBox4_Makh.Text = textBox5_Masp.Text = textBox6_Tensp.Text = textBox7_sldat.Text = textBox8_dongia.Text = "";
            TenHd.Focus();
            dataGridView_ChiTietHoaDon.DataSource = GetAllChiTietHoaDon().Tables[0];
        }
        //xoa hoa don
        private void btn_xoahd_Click(object sender, EventArgs e)
        {
            string sqldelete = "delete from ChiTietHoaDon where MaHd=@MaHd";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqldelete, conn);
                cmd.Parameters.AddWithValue("MaHd", MaHd.Text);
                cmd.Parameters.AddWithValue("TenHd", TenHd.Text);
                cmd.Parameters.AddWithValue("MaNv", textBox3_Manv.Text);
                cmd.Parameters.AddWithValue("MaKh", textBox4_Makh.Text);
                cmd.Parameters.AddWithValue("MaSp", textBox5_Masp.Text);
                cmd.Parameters.AddWithValue("TenSp", textBox6_Tensp.Text);
                cmd.Parameters.AddWithValue("Soluongdat", textBox7_sldat.Text);
                cmd.Parameters.AddWithValue("dongia", textBox8_dongia.Text);
                cmd.Parameters.AddWithValue("NgayBan", Convert.ToDateTime(nb.Text));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            MaHd.Text = TenHd.Text = textBox3_Manv.Text = textBox4_Makh.Text = textBox5_Masp.Text = textBox6_Tensp.Text = textBox7_sldat.Text = textBox8_dongia.Text = "";
            TenHd.Focus();
            dataGridView_ChiTietHoaDon.DataSource = GetAllChiTietHoaDon().Tables[0];
        }
        private void dataGridView_ChiTietHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView_ChiTietHoaDon.CurrentRow.Index;
            MaHd.Text = dataGridView_ChiTietHoaDon.Rows[i].Cells[0].Value.ToString();
            TenHd.Text = dataGridView_ChiTietHoaDon.Rows[i].Cells[1].Value.ToString();
            textBox3_Manv.Text = dataGridView_ChiTietHoaDon.Rows[i].Cells[2].Value.ToString();
            textBox4_Makh.Text = dataGridView_ChiTietHoaDon.Rows[i].Cells[4].Value.ToString();
            textBox5_Masp.Text = dataGridView_ChiTietHoaDon.Rows[i].Cells[5].Value.ToString();
            textBox6_Tensp.Text = dataGridView_ChiTietHoaDon.Rows[i].Cells[6].Value.ToString();
            textBox7_sldat.Text = dataGridView_ChiTietHoaDon.Rows[i].Cells[7].Value.ToString();
            textBox8_dongia.Text = dataGridView_ChiTietHoaDon.Rows[i].Cells[8].Value.ToString();
            nb.Text = dataGridView_ChiTietHoaDon.Rows[i].Cells[9].Value.ToString();
        }
        //thong ke
        DataSet tknam()
        {
            DataSet data = new DataSet();
            string sqlselct = "select * from ChiTietHoaDon where (select YEAR(NgayBan))=(select YEAR(GetDate()));";
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
            string sqlselct = "select * from ChiTietHoaDon where (select Month(NgayBan))=(select Month(GetDate()));";
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
            string sqlselct = "select MaSp,TenSp,Soluongdat from ChiTietHoaDon where MaSp=(select top 1 MaSp from ChiTietHoaDon group by MaSp order by SUM(Soluongdat) desc);";
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
            string query = "select* from KhachHang where TenKh like'%" + valuestofind + "%'";
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
            string query = "select* from KhoHang where TenSp like N'%" + valuestofind + "%'";
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
            string query = "select* from NhanVien where TenNv like N'%" + valuestofind + "%'";
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
        //tim kiem hoa don
        public void serchhoadon(string valuestofind)
        {
            string query = "select* from ChiTietHoaDon where TenHd like N'%" + valuestofind + "%'";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView_ChiTietHoaDon.DataSource = table;
                conn.Close();
            }
        }

        private void textBox1_tkhd_TextChanged(object sender, EventArgs e)
        {
            serchhoadon(textBox1_tkhd.Text);
        }
    }
}
