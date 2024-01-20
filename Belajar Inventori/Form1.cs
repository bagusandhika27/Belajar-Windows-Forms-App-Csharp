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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadTable();
            clearText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

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
    }
}