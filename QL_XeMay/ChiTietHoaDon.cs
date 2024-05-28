using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_XeMay
{
    public partial class ChiTietHoaDon : Form
    {
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetAllChiTietHoaDon().Tables[0];
        }
        DataSet GetAllChiTietHoaDon()
        {
            DataSet data = new DataSet();
            string query = "select b.MaHd as stt, b.Mahd1,a.TenSp,a.Nsx,b.Soluongdat,a.Gianhap+(a.Gianhap*0.1) AS dongia ,b.Soluongdat*a.Gianhap+(a.Gianhap*0.1) AS thanhtien from dbo.KhoHang AS a,dbo.ChiTietHoaDon as b,dbo.HoaDon as c\r\nwhere a.MaSp=b.MaSp and  b.Mahd1=c.MaHd  ";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(data);
                conn.Close();
            }
            return data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert ChiTietHoaDon(Mahd1,MaSp,Soluongdat) values(@Mahd1,@MaSp,@Soluongdat)";
            using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("Mahd1", textBox3.Text);
                cmd.Parameters.AddWithValue("MaSp", textBox1.Text);
                cmd.Parameters.AddWithValue("Soluongdat", textBox2.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            textBox3.Text = textBox1.Text = textBox2.Text = "";
            textBox3.Focus();
            dataGridView1.DataSource = GetAllChiTietHoaDon().Tables[0];
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "delete from ChiTietHoaDon where MaHd=@MaHd";
            DialogResult dl = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionDatabase.connection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("MaHd",textBox4.Text);
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                textBox4.Text = "";
                textBox4.Focus();
            }
            dataGridView1.DataSource = GetAllChiTietHoaDon().Tables[0];
        }
    }
}
