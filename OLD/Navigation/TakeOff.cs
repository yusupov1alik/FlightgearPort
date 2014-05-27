using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navigation
{
    public class TakeOff
    {
        public double A;
        public double B;
        public double C;
        public double omg;
        public double t;
        public double v;
        public double Mx;
        public double h;
        public double H;
        public double T;
        public bool b=false;
        public TakeOff(double h, double H, double v, double Mx)
        {
            this.H = H;
            this.h = h;
            this.v = v;
            this.Mx = Mx;
            double k=0;
            if (H == h)
            {
                if (v == 0)
                {
                    t = 0;
                    b = true;
                }
                else
                {
                    b = true;
                    t = h / (2 * v);
                }
            }
            else
            {
                if (h > H)
                {
                    k = (H - h) / (-1 - Math.Sqrt(1 - v * v / (Mx * Mx)));
                    C = H + k;
                    B = k * Math.Sqrt(1 - v * v / (Mx * Mx));
                }
                else
                {
                    k = (H - h) / (1 + Math.Sqrt(1 - v * v / (Mx * Mx)));
                    C = H - k;
                    B = -k * Math.Sqrt(1 - v * v / (Mx * Mx));
                }
                omg = Mx / k;
                A = k * v / Mx;
                if (h > H)
                {
                    T = (3 * Math.PI / 2 - Math.Acos(v / Mx)) / omg;
                }
                else
                {
                    T = (Math.PI / 2 + Math.Acos(v / Mx)) / omg;
                }

            }

        }
    }
}
