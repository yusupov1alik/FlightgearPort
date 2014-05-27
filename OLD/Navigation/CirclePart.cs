using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public struct Coord
{
    public double x;
    public double y;
}
namespace Navigation
{
    public class CirclePart
    {
        double R; //radius
        double Omega; //angle V
        Coord Centre;
        Coord SpeedCntr;
        double Fi; //start angle
        double Vx;
        double Vy;
        public CirclePart(double x, double y, double MaxAng, double Vx, double Vy,char P)
        {
            R = (Vx * Vx + Vy * Vy) / ((Math.Tan(MaxAng / 180 * Math.PI) * 9.81));
            double omg = Math.Sqrt(Vx * Vx + Vy * Vy) / R;
            SpeedCntr.x = x;
            SpeedCntr.y = y;
            this.Vx = Vx;
            this.Vy = Vy;
            double AbsSin=Math.Sqrt(R * R - Vy * Vy / (omg * omg));
            double AbsCos=Math.Sqrt(R * R - Vx * Vx / (omg * omg));
            if (Vx != 0)
            {
                switch (P)
                {
                    case '+': //top circle
                        Centre.y = y + AbsSin;
                        if (Vx > 0)
                        {
                            Omega = Math.Abs(omg);
                        }
                        else
                        {
                            Omega = -Math.Abs(omg);
                        }
                        Fi = -Math.Acos(Vy / (Omega*R));
                        break;
                    case '-': //bottom circle
                        Centre.y = y - AbsSin;
                        if (Vx > 0)
                        {
                            Omega = -Math.Abs(omg);
                        }
                        else
                        {
                            Omega = Math.Abs(omg);
                        }
                        Fi = Math.Acos(Vy / (Omega*R));
                        break;
                }
                if (Vy / Omega > 0)
                {
                    Centre.x = x - AbsCos;
                }
                else
                {
                    Centre.x = x + AbsCos;
                }
            }
            else
            {
                Centre.y = y;
                switch (P)
                {
                    case '+':
                        Centre.x = x + AbsCos;
                        if (Vy > 0)
                        {
                            Omega = -Math.Abs(omg);
                        }
                        else
                        {
                            Omega = Math.Abs(omg);
                        }
                        Fi = Math.PI;
                        break;
                    case '-':
                        Centre.x = x - AbsCos;
                        if (Vy > 0)
                        {
                            Omega = Math.Abs(omg);
                        }
                        else
                        {
                            Omega = -Math.Abs(omg);
                        }
                        Fi = 0;
                        break;

                }
            }
        }
        public Coord Center
        {
            get
            {
                return Centre;
            }
        }
        public Coord CoorSpeed
        {
            get
            {
                return SpeedCntr;
            }
        }
        public double Omg
        {
            get
            {
                return Omega;
            }
        }
        public double Rad
        {
            get
            {
                return R;
            }
        }
        public double FI
        {
            get
            {
                return Fi;
            }
        }
        public double VX
        {
            get
            {
                return Vx;
            }
        }
        public double VY
        {
            get
            {
                return Vy;
            }
        }
    }
}
