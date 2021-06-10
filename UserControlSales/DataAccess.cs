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

        public static List<Actor> returnActor(int film_id)
        {
            MySqlConnection conn = new MySqlConnection();
            List<Actor> actors = new List<Actor>();
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open();

                string sql = $@"SELECT a.actor_id, a.first_name, a.last_name, a.photo FROM sakila.actor as a inner join sakila.film_actor as fa on a.actor_id = fa.actor_id 
                                inner join sakila.film as f on fa.film_id = f.film_id
                                where f.film_id = {film_id}";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Actor a = new Actor();
                    a.actor_id = int.Parse(rdr[0].ToString());
                    a.first_name = rdr[1].ToString();
                    a.last_name = rdr[2].ToString();
                    a.photo = (byte[])rdr[3];
                    actors.Add(a);
                }
                rdr.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            return actors;

        }
    }
}
