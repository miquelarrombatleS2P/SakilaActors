using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace UserControlSales
{
    class DataAccess
    {
        private static string connectionString = "Server=localhost;Port=3306;Database=sakila;Uid=root;Pwd=Miquel1997";

        public static List<Film> returnFilmDetail(int film_id)
        {
            MySqlConnection conn = new MySqlConnection();
            List<Film> films = new List<Film>();
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open();

                string sql = $"SELECT film_id, title, description, rating, length, special_features FROM sakila.film where film_id = {film_id}";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Film f = new Film();
                    f.film_id = int.Parse(rdr[0].ToString());
                    f.title = rdr[1].ToString();
                    f.description = rdr[2].ToString();
                    f.rating = rdr[3].ToString();
                    f.length = int.Parse(rdr[4].ToString());
                    f.specialFeature = rdr[5].ToString();
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
