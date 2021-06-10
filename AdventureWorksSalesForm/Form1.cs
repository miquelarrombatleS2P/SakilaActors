using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace AdventureWorksSalesForm
{
    public partial class Form1 : Form
    {
        List<Category> categories;
        List<Film> films;
        public Form1()
        {
            InitializeComponent();
            insertIntoCategoryComboBox();
        }

        private void insertIntoCategoryComboBox()
        {
            categories = DataAccess.returnCategories();

            foreach (Category category in categories)
            {
                categoryComboBox.Items.Add(category.ToString());
            }
            
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Category category = new Category();
            //category.name = ((category).sender).ToString();
            category.name = categoryComboBox.Text;

            foreach (Category categori in categories)
            {
                if (categori.name == category.name)
                {
                    category.category_id = categori.category_id;
                }
            }

            films = DataAccess.returnFilms(category.category_id);

            foreach (Film film in films)
            {
                filmComboBox.Items.Add(film.ToString());
            }
        }

        private void filmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filmString = filmComboBox.SelectedItem.ToString();

            string[] filmArray = filmString.Split(',');

            string filmTitle = filmArray[0];

            Film film = new Film();
            film.title = filmTitle.ToString();

            foreach (Film filmy in films)
            {
                if (filmy.title == film.title)
                {
                    film.film_id = filmy.film_id;
                }
            }
            //MessageBox.Show(film.film_id.ToString());
            userControlFilmDetail.Film_Id = film.film_id;
        }
    }
}
