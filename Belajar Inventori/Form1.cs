using System.Data;
using System.Data.SqlClient;
using System.Globalization;

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
                dataGridView1.Columns[3].DefaultCellStyle.Format = "C2";
                dataGridView1.Columns[3].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("id-ID");
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
                cmd = new SqlCommand("SELECT MAX(kode) FROM barang", conn);
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
                cmd = new SqlCommand("SELECT * FROM barang WHERE kode = '" + textBox1.Text + "'", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    if (reader.Read())
                    {
                        DialogResult dr = MessageBox.Show("Data " + textBox1.Text + " Akan Diubah.\n\nData Sebelumnya\nNama Barang = " + reader["nama"].ToString() + "\nSatuan = " + reader["satuan"].ToString() + "\nHarga = " + reader["harga"].ToString() + "\nStok = " + reader["stok"].ToString() + "\n\nData Saat ini\nNama Barang = " + textBox2.Text + "\nSatuan = " + textBox3.Text + "\nHarga = " + textBox4.Text + "\nStok = " + textBox5.Text + "\n\nIngin Melanjutkan?", "Konfirmasi", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("UPDATE barang SET nama = '" + textBox2.Text + "', satuan = '" + textBox3.Text + "', harga = " + textBox4.Text + ", stok = " + textBox5.Text + " WHERE kode = '" + textBox1.Text + "'", conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data Berhasil Diubah!", "Informasi");
                            loadTable();
                            clearText();
                            autoID();
                        }
                        else
                        {
                        }
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
                    DialogResult dr = MessageBox.Show("Data " + textBox1.Text + " Akan Dihapus.\n\nIngin Melanjutkan?", "Konfirmasi", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("DELETE FROM barang WHERE kode = '" + textBox1.Text + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data " + textBox1.Text + " Berhasil Dihapus!", "Informasi");
                        loadTable();
                        clearText();
                        autoID();
                    }
                    else
                    {
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

        private void button4_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["kode"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["nama"].Value.ToString();
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var tambahShow = new Form2();
            tambahShow.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var buyShow = new Form3();
            buyShow.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var sellShow = new Form4();
            sellShow.ShowDialog();
            this.Close();
        }
    }
}