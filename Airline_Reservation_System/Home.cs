using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airline_Reservation_System
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private int imageNumber = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        private void LoadNextImage()
        {
            if (imageNumber == 10)
            {
                imageNumber = 1;
            }
            imgSlideshowPic.ImageLocation = string.Format(@"Images\{0}.png", imageNumber);
            imageNumber++;
        }

        private void radioRoundTrip_CheckedChanged(object sender, EventArgs e)
        {
            cmbDepart.Enabled = true;
            cmbReturn.Enabled = true;
        }

        private void radioOneWay_CheckedChanged(object sender, EventArgs e)
        {
            cmbReturn.Enabled = false;   
        }
    }
}
