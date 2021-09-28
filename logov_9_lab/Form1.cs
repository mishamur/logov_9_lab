using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using logov_9_lab.Models;

namespace logov_9_lab
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        public Form1()
        {
            InitializeComponent();
   
        }

        public float xs(double x)
        {
            x = x - 1;
            float shift = (float) (pictureBox1.Width - 40) / 2;

            return (float)(20 + x * shift);
        }

        public float ys(float y)
        {
            double temp = (pictureBox1.Height - 40) / 2;
            double shift = temp / 10;
            double sy = y / 120 * shift;
            return (float) (temp - sy + 20);
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            
            graphics = pictureBox1.CreateGraphics();
            
            graphics.PageUnit = GraphicsUnit.Pixel;
            int margin = 20;
            int width = pictureBox1.Width ;  //526
            int height = pictureBox1.Height ;//372

            //внешняя рамочка
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(0, 0), new Point(0, height));
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(0, 0), new Point(width, 0));
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(width, 0), new Point(width, height));
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(0, height), new Point(width, height));

            width = pictureBox1.Width - margin; //516
            height = pictureBox1.Height - margin; //352

            //внутренняя рамочка
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(margin, margin), new Point(margin, height));
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(margin, margin), new Point(width, margin));
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(width, margin), new Point(width, height));
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(margin, height), new Point(width, height));

            //рисуем деления
            
            for(double y = -1200; y<= 1200; y += 120)
            {
                graphics.DrawString($"{y}", new Font(new FontFamily(GenericFontFamilies.SansSerif), 5f),
                    Brushes.Black, new PointF(1, ys((float)y)));
            }

            for(int x = 1; x <= 3; x++)
            {
                graphics.DrawString($"{x}", new Font(new FontFamily(GenericFontFamilies.SansSerif), 9f),
                    Brushes.Black, new PointF(xs(x), 350f));
            }

            //рисуем линии
            for(double x = 1; x <= 3; x += 0.05)
            {
                graphics.DrawLine(new Pen(Color.LightGray, 0.5f), new PointF(xs(x), ys(-1200)), new PointF(xs(x), ys(1200)));
            }

            for (double y = -1200; y <= 1200; y += 120)
            {
                graphics.DrawLine(new Pen(Color.LightGray, 0.5f), new PointF(xs(1), ys((float)y)), new PointF(xs(3), ys((float)y)));
            }



            //серединка

            //    graphics.DrawLine(new Pen(Color.Black, 0.5f), new PointF(xs(1), ys(1200)/*ys(1200)*/), new PointF(xs(1.15), ys(0)));





            //10мм -1 см








            double h = 0.05;
            int n = 10;
            double xMin = 1;
            double xMax = 3;
            List<PointF> pointsRe = new List<PointF>();
            List<PointF> pointsIm = new List<PointF>();


            //вычисляем S
            for (double x = xMin; x <= xMax; x += h)
            {
                Compl SResult = new Compl(0, 0);
                x = Math.Round(x, 3);
               
                for (int i = 0; i <= n; i++)
                {

                    Compl result = new Compl(0, 0);

                    Compl chisl = Compl.Ln(new Compl(i * x, -1));

                    Compl znam = Compl.Sub(Compl.Prod(new Compl(0, 1), 2), Compl.Exp(new Compl(0 ,x)));
                    result = Compl.Diviz(chisl, znam);
                    if (i == 0)
                    {
                        SResult = result;

                    }
                    else
                    {
                        SResult = Compl.Mult(SResult, result);
                    }

                    if (x == 2)
                    {
                        int a = 2;
                    }
                }

                //выводим на график
                SResult = SResult.Round();
                pointsRe.Add(new PointF(xs(x), ys((float)SResult.re)));
                pointsIm.Add(new PointF(xs(x), ys((float)SResult.im)));


            }
            graphics.DrawLines(new Pen(Color.Black, 2f) , pointsRe.ToArray());
            graphics.DrawLines(new Pen(Color.Yellow, 2f), pointsIm.ToArray());
        }
    }
}
