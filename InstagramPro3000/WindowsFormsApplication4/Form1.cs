using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleImageProcessing;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap Image1;
        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "*.jpg|*.jpg" };
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                Image1 = (Bitmap)Image.FromFile(ofd.FileName);
                pictureBox1.Image = Image1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x, y;
            for(x=0; x<Image1.Width; x++)
            {
                for(y=0; y<Image1.Height;y++)
                {
                    Color oldColor = Image1.GetPixel(x, y);
                    Color newColor;
                    newColor = Color.FromArgb(oldColor.A, 255 - oldColor.R, 255 - oldColor.G, 255 - oldColor.B);
                    Image1.SetPixel(x, y, newColor);
                    
                }
            }
            pictureBox2.Image = Image1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x, y;
            for (x = 0; x < Image1.Width; x++)
            {
                for (y = 0; y < Image1.Height; y++)
                {
                    Color oldColor = Image1.GetPixel(x, y);
                    int grayScale = (int)((oldColor.R * .3) + (oldColor.G * .59) + (oldColor.B * .11));
                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    Image1.SetPixel(x, y, newColor);
                }
            }
            
            pictureBox2.Image = Image1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
            pictureBox2.Invalidate();
            pictureBox1.Image = null;
            pictureBox1.Invalidate();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int x, y;
            for (x = 0; x < Image1.Width; x++)
            {
                for (y = 0; y < Image1.Height; y++)
                {
                    Color pixelColor = Image1.GetPixel(x, y);
                    Color newColor = Color.FromArgb(pixelColor.R, pixelColor.A, pixelColor.A);
                    Image1.SetPixel(x, y, newColor);
                }
            }
            pictureBox2.Image = Image1;

        }

        
    }
}
