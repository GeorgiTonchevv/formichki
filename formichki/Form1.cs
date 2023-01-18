﻿using System;
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

        public Form1()
        {
            InitializeComponent();
        }
        Thread th;
        Thread th1;
        Thread th2;
        Random rdm;
        int panelY;
        int panelX;
        int panelYDiff;
        int panelXDiff;

        private void button1_Click(object sender, EventArgs e)
        {   
            th = new Thread(threadsquare);
            th.Start();
        }
        public void threadsquare()
        {
            for (int i = 0; i < 100; i++)
            {
                this.CreateGraphics().DrawRectangle(new Pen(RandomColor(), 4), new Rectangle(rdm.Next(0, this.Width),rdm.Next(0, this.Height), rdm.Next(0, this.Width), rdm.Next(0, this.Height)));
                Thread.Sleep(100);
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
            th1.Start();
        }
        private void TriangleFormula(Point p, int size)
        {
            Graphics formula = CreateGraphics();
            formula.DrawPolygon(new Pen(RandomColor()), new Point[] { p, new Point(p.X - size, p.Y + (int)(size * Math.Sqrt(3))), new Point(p.X + size, p.Y + (int)(size * Math.Sqrt(3))) });
        }
    }
}
