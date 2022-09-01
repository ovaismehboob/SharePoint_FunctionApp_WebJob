using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace adichostedapp.Utilities
{
    internal class DataManager
    {

        
        public static void InsertListCount(int count)
        {
            //TODO:Enter SQL Connection below
            using (SqlConnection conn = new SqlConnection("enter your SQL database connection"))
            {
                //TODO:Replace the query with your table 
                using (SqlCommand comm = new SqlCommand("Insert into SPTable (ListRecordCount, DateCreated) values (" + count + ", '" + DateTime.Now + "')"))
                {
                    comm.Connection = conn;
                    conn.Open();
                    comm.ExecuteNonQuery(); 

                }
            }
        }

    }
}
