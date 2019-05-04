namespace Example1
{
    partial class NewCustomer
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(645, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(352, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "WOLZA";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(122, 95);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(352, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Wolski Zajazd";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(122, 153);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(352, 22);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "Zbyszek Piestrzeniewicz";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(122, 209);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(352, 22);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "ul. Filtrowa 68";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(122, 265);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(352, 22);
            this.textBox5.TabIndex = 5;
            this.textBox5.Text = "Warszawa";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(122, 312);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(352, 22);
            this.textBox6.TabIndex = 6;
            this.textBox6.Text = "01-012";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(122, 366);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(352, 22);
            this.textBox7.TabIndex = 7;
            this.textBox7.Text = "Poland";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(549, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // NewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "NewCustomer";
            this.Text = "NewCustomer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox textBox5;
        public System.Windows.Forms.TextBox textBox6;
        public System.Windows.Forms.TextBox textBox7;
    }
}