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
    public partial class NewCustomer : Form
    {
        public NewCustomer()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Format("INSERT INTO Customers (CustomerID, CompanyName, ContactName, Address, City, PostalCode, Country) VALUES(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\");", int.Parse(textBox2.Text), textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text);
            DAL dAL = new DAL();
            dAL.Create(sql);
            this.DialogResult = DialogResult.OK;
        }
    }
}
