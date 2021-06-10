using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UserControlSales
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private int film_Id;

        public int Film_Id
        {
            get { return film_Id; }
            set
            {
                if (film_Id == 0)
                {
                    film_Id = 1;
                }
                film_Id = value;
                //MessageBox.Show(_ProductModelID.ToString());
                UpdateFIlm(film_Id);
            }
        }

        public void UpdateFIlm(int film_id)
        {
            List<Film> films = DataAccess.returnFilmDetail(film_id);

            foreach (Film filmy in films)
            {
                titleTextBox.Text = filmy.title;
                descriptionTextBox.Text = filmy.description;
                ratingTextBox.Text = filmy.rating;
                durationTextBox.Text = filmy.length + "'";
                specialFeaturesTextBox.Text = filmy.specialFeature;
            }
                        
        }

        public void updateActors(int film_id)
        {
            List<Actor> actors = DataAccess.returnActor(film_id);

            foreach (Actor actor in actors)
            {
                ActorsInfo.ActorInfo actorInfo = new ActorsInfo.ActorInfo();
                actorInfo.Actor_Id = actor.actor_id;
                actorInfo.BorderStyle = BorderStyle.FixedSingle;

                flowLayoutPanel1.Controls.Add(actorInfo);
            }
        }

    }
}
