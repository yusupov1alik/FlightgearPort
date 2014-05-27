using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PID
{
    class IntegralPart
    {
        List<double> Item;
        private double Integral;
        public IntegralPart()
        {
            Item = new List<double>();
        }
        public void AddItem(double Pr)
        {
            Item.Add(Pr * 0.01);
            if (Item.Count > 100)
            {
                Integral-=Item.ElementAt(0);
                Item.RemoveAt(0);
            }
            Integral += Pr * 0.01;
        }

        public double INTEGRAL
        {
            get
            {
                return Integral;
            }
        }
    }
}
