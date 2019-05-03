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
        string dataSource = "Data Source = northwindEF.db";
        public void Create(string sql)
        {
            using (SQLiteConnection conn = new SQLiteConnection(dataSource))
            {
                //SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                SQLiteCommand command = new SQLiteCommand(sql, conn);
                conn.Open();
                command.ExecuteNonQuery();
            }
            
        }
        public DataTable Read()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT contactname, address FROM Customers";

            using (SQLiteConnection conn = new SQLiteConnection(dataSource))
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        void Update()
        {

        }
        void Delete()
        {

        }
    }
}
