using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActorsInfo
{
    public partial class ActorInfo : UserControl
    {
        public ActorInfo()
        {
            InitializeComponent();
        }

        private int actor_Id;

        public int Actor_Id
        {
            get { return actor_Id; }
            set
            {
                if (actor_Id == 0)
                {
                    actor_Id = 1;
                }
                actor_Id = value;
                
                UpdateFIlm(actor_Id);
            }
        }

        private void UpdateFIlm(int film_Id)
        {

            byte[] photo;
            MemoryStream ms = new MemoryStream(photo);
            Image image = Image.FromStream(ms);
            photoPictureBox.Image = image;
        }
    }
}
