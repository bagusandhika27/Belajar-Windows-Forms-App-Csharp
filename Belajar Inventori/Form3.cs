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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Belajar_Inventori
{
    public partial class Form3 : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        Koneksi Konn = new Koneksi();

        private const int CB_SETCUEBANNER = 0x1703;

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lParam);

        void autoID()
        {
            SqlConnection conn = Konn.GetConn();

            try
            {
                cmd = new SqlCommand("SELECT MAX(kode) FROM pembelian", conn);
                conn.Open();
                var currentID = cmd.ExecuteScalar() as string;

                if (currentID == null)
                {
                    textBox1.Text = "KB001";
                }
                else
                {
                    int intval = int.Parse(currentID.Substring(2, 3));
                    intval++;
                    textBox1.Text = String.Format("KB{0:000}", intval);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        void cbBarang()
        {
            SqlConnection conn = Konn.GetConn();
            cmd = new SqlCommand("SELECT * FROM barang", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox1.Items.Clear();
            SendMessage(this.comboBox1.Handle, CB_SETCUEBANNER, 0, "Please select an item...");
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["kode"] + " - " + reader["nama"]);
            }
            conn.Close();
        }

        void clearText()
        {
            autoID();
            cbBarang();
            textBox2.Text = "";
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            clearText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Konn.GetConn();
            if (comboBox1.SelectedIndex == -1 || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!", "Informasi");
            }
            else
            {
                string kodebrg = comboBox1.Text.Substring(0, 5);
                cmd = new SqlCommand("SELECT * FROM barang WHERE kode = '" + kodebrg + "'", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int stoklama = int.Parse(reader["stok"].ToString());
                int stokbaru = int.Parse(textBox2.Text.Trim()) + stoklama;
                cmd = new SqlCommand("INSERT INTO pembelian VALUES ('" + textBox1.Text + "', '" + kodebrg + "', " + textBox2.Text.Trim() + ")", conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("UPDATE barang SET stok = " + stokbaru + "WHERE kode = '" + kodebrg + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data " + textBox1.Text + " Berhasil Ditambah!", "Informasi");
                clearText();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var homeShow = new Form1();
            homeShow.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
