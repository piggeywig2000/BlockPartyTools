using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockPartyTools
{
    public partial class FormColourDisplay : Form
    {
        public FormColourDisplay()
        {
            InitializeComponent();
        }

        private Queue<int> ColourQueue = new Queue<int>();

        public void SetColour(int colourId)
        {
            ColourQueue.Enqueue(colourId);
        }

        public void ClearColour()
        {
            ColourQueue.Enqueue(-1);
        }

        private void timerSetColour_Tick(object sender, EventArgs e)
        {
            if (ColourQueue.Count == 0) return;

            int colourId = ColourQueue.Dequeue();

            switch (colourId)
            {
                case -1:
                    BackgroundImage = null;
                    labelCurrentColour.Text = "";
                    break;
                case 0:
                    //White
                    BackgroundImage = Properties.Resources.white;
                    labelCurrentColour.Text = "White";
                    labelCurrentColour.ForeColor = Color.Black;
                    break;
                case 1:
                    //Orange
                    BackgroundImage = Properties.Resources.orange;
                    labelCurrentColour.Text = "Orange";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 2:
                    //Magenta
                    BackgroundImage = Properties.Resources.magenta;
                    labelCurrentColour.Text = "Magenta";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 3:
                    //Light Blue
                    BackgroundImage = Properties.Resources.lightblue;
                    labelCurrentColour.Text = "Light Blue";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 4:
                    //Yellow
                    BackgroundImage = Properties.Resources.yellow;
                    labelCurrentColour.Text = "Yellow";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 5:
                    //Lime
                    BackgroundImage = Properties.Resources.lime;
                    labelCurrentColour.Text = "Lime";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 6:
                    //Pink
                    BackgroundImage = Properties.Resources.pink;
                    labelCurrentColour.Text = "Pink";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 7:
                    //Grey
                    BackgroundImage = Properties.Resources.grey;
                    labelCurrentColour.Text = "Grey";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 8:
                    //Light Grey
                    BackgroundImage = Properties.Resources.lightgrey;
                    labelCurrentColour.Text = "Light Grey";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 9:
                    //Cyan
                    BackgroundImage = Properties.Resources.cyan;
                    labelCurrentColour.Text = "Cyan";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 10:
                    //Purple
                    BackgroundImage = Properties.Resources.purple;
                    labelCurrentColour.Text = "Purple";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 11:
                    //Blue
                    BackgroundImage = Properties.Resources.blue;
                    labelCurrentColour.Text = "Blue";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 12:
                    //Brown
                    BackgroundImage = Properties.Resources.brown;
                    labelCurrentColour.Text = "Brown";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 13:
                    //Green
                    BackgroundImage = Properties.Resources.green;
                    labelCurrentColour.Text = "Green";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 14:
                    //Red
                    BackgroundImage = Properties.Resources.red;
                    labelCurrentColour.Text = "Red";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                case 15:
                    //Black
                    BackgroundImage = Properties.Resources.black;
                    labelCurrentColour.Text = "Black";
                    labelCurrentColour.ForeColor = Color.White;
                    break;
                default:
                    return;
            }

            if (colourId >= 0)
            {
                ResizeLabelFontSize();
            }
        }

        private void ResizeLabelFontSize()
        {
            labelCurrentColour.Font = new Font(labelCurrentColour.Font.FontFamily, 1f, FontStyle.Regular);

            while (labelCurrentColour.Width > TextRenderer.MeasureText(labelCurrentColour.Text, new Font(labelCurrentColour.Font.FontFamily, labelCurrentColour.Font.Size + 1f, labelCurrentColour.Font.Style)).Width
                && labelCurrentColour.Height > TextRenderer.MeasureText(labelCurrentColour.Text, new Font(labelCurrentColour.Font.FontFamily, labelCurrentColour.Font.Size + 1f, labelCurrentColour.Font.Style)).Height)
            {
                labelCurrentColour.Font = new Font(labelCurrentColour.Font.FontFamily, labelCurrentColour.Font.Size + 1f, FontStyle.Regular);
            }
        }
    }
}
