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
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            return categories;

        }

        public static List<Film> returnFilms(int category_id)
        {
            MySqlConnection conn = new MySqlConnection();
            List<Film> films = new List<Film>();
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open();

                string sql = $@"SELECT f.film_id, f.title, f.length FROM sakila.film as f inner join sakila.film_category as fc on f.film_id = fc.film_id 
                                inner join sakila.category as c on fc.category_id = c.category_id
                                where c.category_id = {category_id}; ";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Film f = new Film();
                    f.film_id = int.Parse(rdr[0].ToString());
                    f.title = rdr[1].ToString();
                    f.length = int.Parse(rdr[2].ToString());
                    films.Add(f);
                }
                rdr.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            return films;

        }
    }
}
