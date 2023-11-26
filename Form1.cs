using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balls
{
    public partial class Form1 : Form
    {

        private const int ballsCntr = 2;
        private Ball[] balls = new Ball[ballsCntr];
        private Thread[] threads = new Thread[ballsCntr];

        public Form1()
        {
            InitializeComponent();


            this.DoubleBuffered = true;


            Random rnd = new Random();
            for (int i = 0; i < balls.Length; i++)
            {
                Color color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                balls[i] = new Ball(rnd.Next(100, ClientSize.Width - 100), rnd.Next(100, ClientSize.Height - 100),
                                    rnd.Next(1, 5), rnd.Next(1, 5),
                                    0, 0, 100, color);
                balls[i].setEnv(true, ClientSize.Width, ClientSize.Height);
                int index = i;
                threads[i] = new Thread(() => balls[index].move(index, this));
            }

            foreach (Thread t in threads)
            {
                t.Start();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Brush brush;

            for (int i = 0; i < balls.Length; i++)
            {
                brush = new SolidBrush(balls[i].color);

                e.Graphics.FillEllipse(brush, balls[i].x - balls[i].rad,
                                              balls[i].y - balls[i].rad,
                                              2 * balls[i].rad,
                                              2 * balls[i].rad);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            foreach (Ball b in balls)
            {
                b.isMoving = false;
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
