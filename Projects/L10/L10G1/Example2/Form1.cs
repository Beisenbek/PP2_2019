using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DAL dAL = new DAL();

        private void Button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dAL.Read();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            NewCustomer newCustomer = new NewCustomer();
            if (newCustomer.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = dAL.Read(); ;
            }
        }
    }
}
