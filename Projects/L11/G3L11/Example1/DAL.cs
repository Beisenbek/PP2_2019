using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class DAL
    {
        public string id = null;
        string connString = "Data Source = northwindEF.db";
        SQLiteConnection conn = null;

        private static DAL dal = null;

        public static DAL GetInstance
        {
            get
            {
                if(dal == null)
                {
                    dal = new DAL();
                }
                return dal;
            }
        }

        private DAL()
        {
            conn = new SQLiteConnection(connString);
            id = Guid.NewGuid().ToString();
        }
        public DataTable GetDataForTable(string tableName)
        {
            DataTable dataTable = new DataTable();
            conn.Open();

            string sql = string.Format("SELECT * FROM {0};", tableName);

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, conn);
            dataAdapter.Fill(dataTable);
            
            conn.Close();

            return dataTable;
        }

        public void InsertNewCustomer(Customer customer)
        {
            try
            {
                conn.Open();
                string sql = string.Format("INSERT INTO Customers (CustomerID, CompanyName, ContactName, Address, City, PostalCode, Country) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');",
                    customer.CustomerID,
                    customer.CompanyName,
                    customer.ContactName,
                    customer.Address,
                    customer.City,
                    customer.PostalCode,
                    customer.Country);

                SQLiteCommand command = new SQLiteCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
