namespace Belajar_Inventori
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboBox1 = new ComboBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new Point(129, 122);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(185, 23);
            textBox2.TabIndex = 14;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(129, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(185, 23);
            textBox1.TabIndex = 12;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 130);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 11;
            label3.Text = "Jumlah";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 86);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 10;
            label2.Text = "Nama Barang";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 42);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 9;
            label1.Text = "Kode Pembelian";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(129, 83);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(185, 23);
            comboBox1.TabIndex = 15;
            // 
            // button3
            // 
            button3.Location = new Point(138, 210);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 18;
            button3.Text = "Home";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(204, 177);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 17;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(79, 177);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 16;
            button1.Text = "Simpan";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(364, 261);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pembelian";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBox1;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}