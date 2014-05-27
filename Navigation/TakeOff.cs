using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathLib;

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
        public Coord Start;
        public Coord Destination;
        public Coord Velocity;
        public double T;
        public bool b=false;
        public TakeOff(double x, double y, double h, double H, double v, double Mx,double vx, double vy)
        {
            Velocity.z = v;
            Velocity.x = vx;
            Velocity.y = vy;
            Destination.z = H;
            Start.z = h;
            Start.x = x;
            Start.y = y;
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
                Destination.y = y + Velocity.y * T;
                Destination.x = x + Velocity.x * T;
            }

        }
        public DynamicState GetCoord(double t)
        {
            MathLib.DynamicState Coor = new MathLib.DynamicState();
            double current_alt = A * Math.Sin(omg * t) + B * Math.Cos(omg * t) + C;
            Coor.Z = current_alt;
            Coor.X = Start.x + Velocity.x * t;
            Coor.Y = Start.y + Velocity.y * t;
            Coor.Roll = 0;
            double current_vh = A * omg * Math.Cos(omg * t) - B * omg * Math.Sin(omg * t);
            Coor.VX = Velocity.x;
            Coor.VZ = current_vh;
            Coor.VY = Velocity.y;
            Coor.RPitch = 1 / (1 + current_vh * current_vh / (Velocity.x * Velocity.x + Velocity.y * Velocity.y));
            Coor.RRoll = 0;
            Coor.RYaw = 1 / (1 + Velocity.y * Velocity.y / (Velocity.x * Velocity.x));
            Coor.Pitch = Math.Atan2(current_vh, Math.Sqrt(Velocity.x * Velocity.x + Velocity.y * Velocity.y));
            Coor.Yaw=Math.Atan2(Coor.VX, Coor.VY);
            return  Coor;
        }

    }
}
