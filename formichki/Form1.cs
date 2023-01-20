using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;



namespace formichki
{
    public partial class Form1 : Form
    {
        private static readonly Random random = new Random();
        private Graphics formula;
        private bool Rectanglespawns;
        private bool Trianglespawns;
        private bool Circlespawns;

        public Form1()
        {
            InitializeComponent();
        }
        Thread th;
        Thread th1;
        Thread th2;
        Thread th3;
        Random rdm;
        int panelY;
        int panelX;
        int panelYDiff;
        int panelXDiff;

        private void button1_Click(object sender, EventArgs e)
        {   
            th = new Thread(threadrectangle);
            Rectanglespawns = true;
            th.Start();
        }
        public void threadrectangle()
        {
            while(Rectanglespawns)
            {
                int width;
                int height;
                ValueOfStuff();
                width = random.Next(0, panelXDiff) / 4;
                height = random.Next(0, panelYDiff) / 4;
                this.CreateGraphics().DrawRectangle(new Pen(RandomColor(), 3), panelX, panelY, width, height);
                Thread.Sleep(3000);
            }
        }
        public void ValueOfStuff()
        {
            formula = CreateGraphics();
            panelY = random.Next(0, Height);
            panelX = random.Next(0, Width);
            panelYDiff = Height - panelY;
            panelXDiff = Width - panelX;
        }
        public void threadtriangle()
        {
            while(Trianglespawns)
            {
                int size;
                ValueOfStuff();
                if (panelYDiff < panelXDiff)
                {
                    size = panelYDiff / 6;
                }
                else
                {
                    size = panelXDiff / 6;
                }
                TriangleFormula(new Point(panelX, panelY), size);
                Thread.Sleep(4000);
            }
        }
        private Color RandomColor()
        {
            return Color.FromArgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdm = new Random();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            th1 = new Thread(threadtriangle);
            Trianglespawns = true;
            th1.Start();
        }
        private void TriangleFormula(Point p, int size)
        {
            Graphics formula = CreateGraphics();
            formula.DrawPolygon(new Pen(RandomColor(),3), new Point[] { p, new Point(p.X - size, p.Y + (int)(size * Math.Sqrt(3))), new Point(p.X + size, p.Y + (int)(size * Math.Sqrt(3))) });
        }
        public void threadcircle()
        {
            while (Circlespawns)
            {
                int size;
                ValueOfStuff();
                if (panelYDiff < panelXDiff)
                {
                    size = panelYDiff / 4;
                }
                else
                {
                    size = panelXDiff / 4;
                }
                this.CreateGraphics().DrawEllipse(new Pen(RandomColor(), 3), panelX, panelY, size, size);
                Thread.Sleep(4000);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            th2 = new Thread(threadcircle);
            Circlespawns = true;
            th2.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            th3 = new Thread(threadring);
            Circlespawns = true;
            th3.Start();
        }
        public void threadring()
        {
            while (Circlespawns)
            {
                var randomColor = new Pen(RandomColor(), 3);
                int size;
                ValueOfStuff();
                if (panelYDiff < panelXDiff)
                {
                    size = panelYDiff / 4;
                }
                else
                {
                    size = panelXDiff / 4;
                }
                this.CreateGraphics().DrawEllipse(randomColor, panelX - size / 4, panelY - size / 4, size, size);
                this.CreateGraphics().DrawEllipse(randomColor, panelX, panelY, size - size / 2, size - size / 2);

                Thread.Sleep(4000);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Graphics delete = CreateGraphics();
            delete.Clear(Color.White);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Rectanglespawns = false;
            Trianglespawns = false;
            Circlespawns = false;
        }
    }
}
