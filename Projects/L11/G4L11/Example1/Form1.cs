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

namespace Example1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            DAL dal = DAL.GetInstance;
            dataGridView1.DataSource = dal.GetDataFromTable("Customers");
            //MessageBox.Show(dataTable.Rows.Count.ToString());
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DAL dal = DAL.GetInstance;
            dataGridView1.DataSource = dal.GetDataFromTable(comboBox1.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DAL dal = DAL.GetInstance;
            NewCustomer newCustomer = new NewCustomer();
            if (newCustomer.ShowDialog() == DialogResult.OK)
            {
                Customer customer = new Customer
                {
                    CustomerID = newCustomer.textBox1.Text,
                    CompanyName = newCustomer.textBox2.Text,
                    ContactName = newCustomer.textBox3.Text,
                    Address = newCustomer.textBox4.Text,
                    City = newCustomer.textBox5.Text,
                    PostalCode = newCustomer.textBox6.Text,
                    Country = newCustomer.textBox7.Text
                };
                dal.AddNewCustomer(customer);
            }
        }
    }
}
