using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Xml;
using MySql.Data.MySqlClient;

namespace BivinsBraxton_PaintShelf
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent(); // Always First
            HandleClientWindowSize(); // Background size modifier
        }

        void HandleClientWindowSize() // Code Given for iPhone background
        {
            //Modify ONLY these float values
            float HeightValueToChange = 1.4f;
            float WidthValueToChange = 6.0f;

            //DO NOT MODIFY THIS CODE
            int height = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Size.Height / HeightValueToChange);
            int width = Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Size.Width / WidthValueToChange);
            if (height < Size.Height)
                height = Size.Height;
            if (width < Size.Width)
                width = Size.Width;
            this.Size = new Size(width, height);
            //this.Size = new Size(376, 720);
        }

        private void RedButton_Click(object sender, EventArgs e) // Display all of stored paints classified as red
        {
            // 1 RED //
            PaintViewForm paintForm = new PaintViewForm(1);
            paintForm.ShowDialog();
        }

        private void BlueButton_Click(object sender, EventArgs e) // Display all of stored paints classified as blue
        {
            // 2 BLUE //
            PaintViewForm paintForm = new PaintViewForm(2);
            paintForm.ShowDialog();
        }

        private void GreenButton_Click(object sender, EventArgs e) // Display all of stored paints classified as green
        {
            // 3 GREEN //
            PaintViewForm paintForm = new PaintViewForm(3);
            paintForm.ShowDialog();
        }

        private void YellowButton_Click(object sender, EventArgs e) // Display all of stored paints classified as yellow
        {
            // 4 YELLOW //
            PaintViewForm paintForm = new PaintViewForm(4);
            paintForm.ShowDialog();
        }

        private void PinkButton_Click(object sender, EventArgs e) // Display all of stored paints classified as pink
        {
            // 5 PINK //
            PaintViewForm paintForm = new PaintViewForm(5);
            paintForm.ShowDialog();
        }

        private void BlackButton_Click(object sender, EventArgs e) // Display all of stored paints classified as black
        {
            // 6 BLACK //
            PaintViewForm paintForm = new PaintViewForm(6);
            paintForm.ShowDialog();
        }

        private void GrayButton_Click(object sender, EventArgs e) // Display all of stored paints classified as gray
        {
            // 7 GRAY //
            PaintViewForm paintForm = new PaintViewForm(7);
            paintForm.ShowDialog();
        }

        private void SilverButton_Click(object sender, EventArgs e) // Display all of stored paints classified as silver
        {
            // 8 SILVER //
            PaintViewForm paintForm = new PaintViewForm(8);
            paintForm.ShowDialog();
        }

        private void OrangeButton_Click(object sender, EventArgs e) // Display all of stored paints classified as orange
        {
            // 9 ORANGE //
            PaintViewForm paintForm = new PaintViewForm(9);
            paintForm.ShowDialog();
        }

        private void PurpleButton_Click(object sender, EventArgs e) // Display all of stored paints classified as purple
        {
            // 10 PURPLE //
            PaintViewForm paintForm = new PaintViewForm(10);
            paintForm.ShowDialog();
        }

        private void WhiteButton_Click(object sender, EventArgs e) // Display all of stored paints classified as white
        {
            // 11 WHITE //
            PaintViewForm paintForm = new PaintViewForm(11);
            paintForm.ShowDialog();
        }

        private void SpecialButton_Click(object sender, EventArgs e) // Display all of stored paints classified as special
        {
            // 12 SPECIAL //
            PaintViewForm paintForm = new PaintViewForm(12);
            paintForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) // close application
        {
            this.Close();
        }

        private void vINDecodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VinDecoderForm VDF = new VinDecoderForm();
            VDF.ShowDialog();
        }
    }
}
