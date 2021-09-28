using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace logov_9_lab.Models
{
    public class Compl
    {
        public static Compl Mult(Compl a, Compl b) 
        {
            Compl complex = new Compl(0, 0);
            complex.re = a.re * b.re - a.im * b.im;
            complex.im = a.re * b.im + a.im * b.re;
            return complex;

        }

        public Compl Round()
        {
            this.re = Math.Round(this.re, 4);
            this.im = Math.Round(this.im, 4);
            return this;
        }

        public static Compl Inv(Compl a)
        {
            Compl complex = new Compl(0, 0);
            double aNum = 0;

            aNum = Math.Pow(a.re, 2) + Math.Pow(a.im, 2);
            complex.re = a.re / aNum;
            complex.im = -a.im / aNum;

            return complex;
        }


        public static Compl Diviz(Compl a, Compl b)
        { 
            Compl temp = Inv(b);
            Compl complex = Mult(a, temp);
            return complex;
          
        }
        
        /// <summary>
        /// вычитание комплексных чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Compl Sub(Compl a, Compl b)
        {
            
            Compl complex = new Compl(0, 0);
            complex.re = a.re - b.re;
            complex.im = a.im - b.im;

            return complex;
        }

        public static Compl Prod(Compl a, double b)
        {
            Compl complex = new Compl(0, 0);
            complex.re = a.re * b;
            complex.im = a.im * b;

            return complex;
        }

        public static Compl Exp(Compl a)
        {
            Complex complex = new Complex(a.re, a.im);
            complex = Complex.Exp(complex);
            Compl compl = new Compl(complex.Real, complex.Imaginary);
            return compl;

        }

        public static Compl Ln(Compl a)
        {
            Complex complex = new Complex(a.re, a.im);
            complex = Complex.Log(complex);

            Compl compl = new Compl(complex.Real, complex.Imaginary);
            return compl;

        }

        public static Compl ExpJ(double a)
        {
            Compl compl = new Compl(0, 0);
            compl.re = Math.Cos(a);
            compl.im = Math.Sin(a);
            return compl;
        }





        public double re { get; set; }
        public double im { get; set; }

        public Compl(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

    }
}
