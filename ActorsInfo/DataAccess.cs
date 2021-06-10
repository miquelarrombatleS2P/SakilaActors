using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ActorsInfo
{
    class DataAccess
    {
        private static string connectionString = "Server=localhost;Port=3306;Database=sakila;Uid=root;Pwd=Miquel1997";

        public static List<Actor> returnActor(int film_id)
        {
            MySqlConnection conn = new MySqlConnection();
            List<Actor> actors = new List<Actor>();
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open();

                string sql = $@"SELECT actor_id, first_name, last_name, photo FROM sakila.actor where actor_id = {film_id}";

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
