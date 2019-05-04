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
        string connectionString = "DataSource = C:\\Users\\bsnbk\\Desktop\\northwindEF.db";
        SQLiteConnection connection = default(SQLiteConnection);

        private DAL()
        {
            connection = new SQLiteConnection(connectionString);
        }
        private static DAL dal = default(DAL);
        public static DAL GetInstance
        {
            get
            {
                if (dal == default(DAL))
                {
                    dal = new DAL();
                }
                return dal;
            }
        }

        public DataTable GetDataFromTable(string tableName)
        {
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                string sqlCommand = string.Format("SELECT * FROM {0}", tableName);
                //SQLiteCommand command = new SQLiteCommand(sqlCommand, connection);
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sqlCommand, connection);
                dataAdapter.Fill(dataTable);
            }
            catch(Exception)
            {

            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }

        public void AddNewCustomer(Customer customer)
        {
            try
            {
                string sqlCommand = string.Format("INSERT INTO Customers (CustomerID, CompanyName, ContactName, Address, City, PostalCode, Country) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');",
                    customer.CustomerID,
                    customer.CompanyName,
                    customer.ContactName,
                    customer.Address,
                    customer.City,
                    customer.PostalCode,
                    customer.Country);
                SQLiteCommand command = new SQLiteCommand(sqlCommand, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }catch(Exception e)
            {
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
