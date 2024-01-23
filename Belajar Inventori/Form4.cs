﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Belajar_Inventori
{
    public partial class Form4 : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        Koneksi Konn = new Koneksi();

        void autoID()
        {
            SqlConnection conn = Konn.GetConn();

            try
            {
                cmd = new SqlCommand("SELECT MAX(kode) FROM penjualan", conn);
                conn.Open();
                var currentID = cmd.ExecuteScalar() as string;

                if (currentID == null)
                {
                    textBox1.Text = "KJ001";
                }
                else
                {
                    int intval = int.Parse(currentID.Substring(2, 3));
                    intval++;
                    textBox1.Text = String.Format("KJ{0:000}", intval);
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
            comboBox1.Text = "--- Pilih Barang ---";
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

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            clearText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Konn.GetConn();
            if (comboBox1.Text == "--- Pilih Barang ---" || textBox2.Text.Trim() == "")
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
                int jual = int.Parse(textBox2.Text.Trim());

                if (stoklama < jual)
                {
                    MessageBox.Show("Stok Tidak Cukup!", "Informasi");
                }
                else
                {
                    int stokbaru = stoklama - jual;
                    cmd = new SqlCommand("INSERT INTO penjualan VALUES ('" + textBox1.Text + "', '" + kodebrg + "', " + jual + ")", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("UPDATE barang SET stok = " + stokbaru + "WHERE kode = '" + kodebrg + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data " + textBox1.Text + " Berhasil Ditambah!", "Informasi");
                    clearText();
                }                
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
    }
}
