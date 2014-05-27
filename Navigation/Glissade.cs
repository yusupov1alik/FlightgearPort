using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navigation
{
    public class Glissade
    {
        const int N = 200;
        public Coord StartPosition;
        public Coord CareerPosition;
        public double a;
        public double b;
        public double k;
        public double k1;
        public double L;
        public bool c = false;
        public double angle;
        public Glissade(MathLib.Vector CareerPosition, double CareerYaw, double L, double H)
        {
            this.L = L;
            this.CareerPosition.x = CareerPosition.X;
            this.CareerPosition.y = CareerPosition.Y;
            this.CareerPosition.z = CareerPosition.Z;
            StartPosition.x = CareerPosition.X - Math.Sin(CareerYaw) * L;
            StartPosition.y = CareerPosition.Y - Math.Cos(CareerYaw) * L;
            StartPosition.z = H;
            this.a = N / L;
            this.b = (H - CareerPosition.Z) / Math.PI;
            try
            {
                angle = Math.Atan2( CareerPosition.X - StartPosition.x,CareerPosition.Y - StartPosition.y);
                k = (CareerPosition.Y - StartPosition.y) / (CareerPosition.X - StartPosition.x);
                k1 = StartPosition.y - k * StartPosition.x;
            }
            catch
            {
                c = true;
            }
        }

        public double Height(double x, double y)
        {
            double R = Math.Sqrt((CareerPosition.y - y) * (CareerPosition.y - y) + (CareerPosition.x - x));
            if (c)
            {
                if (CareerPosition.y > StartPosition.y)
                {
                    if (y >= StartPosition.y && y <= CareerPosition.y)
                    {
                        return Math.PI / 2 + Math.Atan(R - L / 2) + CareerPosition.z;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    if (y <= StartPosition.y && y >= CareerPosition.y)
                    {
                        return Math.PI / 2 + Math.Atan(R - L / 2) + CareerPosition.z;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            else
            {
                if (CareerPosition.x > StartPosition.x)
                {
                    if (x >= StartPosition.x && x <= CareerPosition.x)
                    {
                        return Math.PI / 2 + Math.Atan(R - L / 2) + CareerPosition.z;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    if (x <= StartPosition.x && x >= CareerPosition.x)
                    {
                        return Math.PI / 2 + Math.Atan(R - L / 2) + CareerPosition.z;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        public MathLib.Vector FindCoord(MathLib.Vector Position)
        {
            if (c)
            {
                return new MathLib.Vector(StartPosition.x, Position.Y, 0);
            }
            else
            {
                if (k == 0)
                {
                    return new MathLib.Vector(Position.X, StartPosition.y, 0);
                }
                else
                {
                    double k2 = -1 / k;
                    double k3 = k1 = Position.X - k2 * Position.X;
                    double x = (k3 - k1) / (k - k2);
                    double y = k2 * x + k3;
                    return new MathLib.Vector(x, y, 0);
                }
            }
        }

        public double Multip(MathLib.Vector Position)
        {
            const int N=1;
            double L1 = Math.Sqrt((Position.X - StartPosition.x) * (Position.X - StartPosition.x) + (Position.Y - StartPosition.y) * (Position.Y - StartPosition.y));
            return N * (L1 / L) * (L1 / L) * (L1 / L);
        }
    }
}
