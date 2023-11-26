using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using System.Windows;
using System.Data;

namespace Balls
{
    internal class Ball
    {

        public int x, y;
        public int velocityX, velocityY;
        public int accelX, accelY;
        public int rad;
        public bool isMoving;
        public int WIDTH, HEIGHT;
        public Color color;


        public Ball(int x, int y, int speedX, int speedY, int accelX, int accelY, int radius, Color color)
        {
            this.x = x;
            this.y = y;
            this.velocityX = speedX;
            this.velocityY = speedY;
            this.rad = radius;
            this.accelX = accelX;
            this.accelY = accelY;
            this.color = color;
        }


        public void setEnv(bool isMoving, int width, int height)
        {
            this.isMoving = isMoving;
            this.WIDTH = width;
            this.HEIGHT = height;
        }


        public void move(int n, Form form)
        {
            

            while (isMoving)
            {

                velocityX += accelX;
                velocityY += accelY;


                x += velocityX;
                y += velocityY;


                if (x + rad > WIDTH || x - rad < 0)
                {
                    velocityX = -velocityX;
                }
                if (y + rad > HEIGHT || y - rad < 0)
                {
                    velocityY = -velocityY;
                }


                form.Invalidate();


                Thread.Sleep(10);
            }
        }
    }
}