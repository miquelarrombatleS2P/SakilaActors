using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AdventureWorksSalesForm
{
    class DataAccess
    {
        private static string connectionString = "Server=localhost;Port=3306;Database=sakila;Uid=root;Pwd=Miquel1997";

        public static List<Category> returnCategories()
        {
            MySqlConnection conn = new MySqlConnection();
            List<Category> categories = new List<Category>();
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                
                string sql = "SELECT category_id, name FROM sakila.category";
               
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Category c = new Category();
                    c.category_id = int.Parse(rdr[0].ToString());
                    c.name = rdr[1].ToString();
                    categories.Add(c);
                }
                rdr.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            return categories;

        }
    }
}
