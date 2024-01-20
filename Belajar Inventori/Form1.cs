using System.Data;
using System.Data.SqlClient;

namespace Belajar_Inventori
{
    public partial class Form1 : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        Koneksi Konn = new Koneksi();

        public Form1()
        {
            InitializeComponent();
        }

        void loadTable()
        {
            SqlConnection conn = Konn.GetConn();

            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM barang", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "barang");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "barang";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    dataGridView1.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
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

        void clearText()
        {
            autoID();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        void autoID()
        {
            SqlConnection conn = Konn.GetConn();

            try
            {
                cmd = new SqlCommand("SELECT MAX(kodebarang) FROM barang", conn);
                conn.Open();
                var currentID = cmd.ExecuteScalar() as string;

                if (currentID == null)
                {
                    textBox1.Text = "KD001";
                }
                else
                {
                    int intval = int.Parse(currentID.Substring(2, 3));
                    intval++;
                    textBox1.Text = String.Format("KD{0:000}", intval);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            loadTable();
            clearText();
            autoID();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!", "Informasi");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();

                try
                {
                    cmd = new SqlCommand("INSERT INTO barang VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', " + textBox4.Text + ", " + textBox5.Text + ")", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data " + textBox1.Text + " Berhasil Ditambah!", "Informasi");
                    loadTable();
                    clearText();
                    autoID();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!", "Informasi");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                cmd = new SqlCommand("SELECT * FROM barang WHERE kodebarang = '" + textBox1.Text + "'", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    if (reader.Read())
                    {
                        cmd = new SqlCommand("UPDATE barang SET namabarang = '" + textBox2.Text + "', satuan = '" + textBox3.Text + "', harga = " + textBox4.Text + ", stok = " + textBox5.Text + " WHERE kodebarang = '" + textBox1.Text + "'", conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Diubah!", "Informasi");
                        loadTable();
                        clearText();
                        autoID();
                    }
                    else
                    {
                        MessageBox.Show("Barang Tidak Ditemukan!", "Informasi");
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!", "Informasi");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();

                try
                {
                    cmd = new SqlCommand("DELETE FROM barang WHERE kodebarang = '" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data " + textBox1.Text + " Berhasil Dihapus!", "Informasi");
                    loadTable();
                    clearText();
                    autoID();
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["kodebarang"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["namabarang"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["satuan"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["harga"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["stok"].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}