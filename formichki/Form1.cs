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

        public Form1()
        {
            InitializeComponent();
        }
        Thread th;
        Thread th1;
        Random rdm;

        private void button1_Click(object sender, EventArgs e)
        {   
            th = new Thread(threadsquare);
            th.Start();
        }
        public void threadsquare()
        {
            for (int i = 0; i < 100; i++)
            {
                this.CreateGraphics().DrawRectangle(new Pen(RandomColor(), 4), new Rectangle(rdm.Next(0, this.Width),rdm.Next(0, this.Height), 40, 20));
                Thread.Sleep(100);
            }
            MessageBox.Show("Completed");
        }
        public void threadtriangle()
        {
            //th1 = new Thread(threadtriangle);
            //th1.Start();
        }
        private Color RandomColor()
        {
            return Color.FromArgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdm = new Random();
        }
    }
}
