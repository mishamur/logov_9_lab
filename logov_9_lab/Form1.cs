using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using logov_9_lab.Models;

namespace logov_9_lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
   
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            double h = 0.05;
            int n = 10;
            double xMin = 1;
            double xMax = 3;

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.PageUnit = GraphicsUnit.Millimeter;

            //10мм -1 см

            graphics.DrawLine(new Pen(Brushes.Black), new Point(0, 0), new Point(1, 1));








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
               

             }

        }
    }
}
