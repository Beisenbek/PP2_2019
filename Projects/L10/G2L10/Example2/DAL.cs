using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    class DAL
    {
        string connectionString = "Data Source = northwindEF.db";

        public DataTable GetDataAsTable(string tableName)
        {
            DataTable table = new DataTable();
            string sql = string.Format("SELECT * FROM {0};", tableName);
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            conn.Open();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, conn);
            dataAdapter.Fill(table);
            conn.Close();
            return table;
        }
        public void InsertCustomer(Customer customer)
        {
            string sql = string.Format("INSERT INTO Customers (CustomerID, CompanyName, ContactName, Address, City, PostalCode, Country) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');",
                customer.CustomerID,customer.CompanyName, customer.ContactName,customer.Address,customer.City,customer.PostalCode,customer.Country);
            SQLiteConnection conn = new SQLiteConnection(connectionString);
            conn.Open();

            SQLiteCommand command = new SQLiteCommand(sql, conn);
            command.ExecuteNonQuery();

            conn.Close();
        }
    }
}
