using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathLib;
public struct Coord
{
    public double x;
    public double y;
    public double z;
}
namespace Navigation
{
    public class CirclePart
    {
        double R; //radius
        double Omega; //angle V
        public Coord Centre;
        public Coord SpeedCntr;
        public Coord Destination;
        public Coord Velocity;
        public Coord Acceleration;
        double Fi; //start angle
        double Vx;
        double Vy;
        double MaxAng;
        public CirclePart(double x, double y, double MaxAng, double Vx, double Vy,char P,double z)
        {
            Destination.z = z;
            this.MaxAng = MaxAng;
            Centre.z = z;
            R = (Vx * Vx + Vy * Vy) / ((Math.Tan(MaxAng ) * 9.81));
            double omg = Math.Sqrt(Vx * Vx + Vy * Vy) / R;
            SpeedCntr.x = x;
            SpeedCntr.y = y;
            SpeedCntr.z = z;
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
        public DynamicState GetCoord(double t)
        {
            MathLib.DynamicState Coor = new DynamicState();
            Coor.X = (Center.x + R * Math.Cos(Omega * t + Fi));
            Coor.Y = (Center.y + R * Math.Sin(Omega * t + Fi));
            Coor.Z = Centre.z;
            Coor.Roll = -MaxAng * Omega / Math.Abs(Omega);
            double current_vx = GetVelocity(t).x;
            double current_vy = GetVelocity(t).y;
            Coor.VX = current_vx;
            Coor.VZ = 0;
            Coor.VY = current_vy;
            Coor.Pitch = 0;

            Coor.RPitch = 0;
            Coor.RRoll = 0;
            Coor.RYaw = 1 / (1 + current_vy * current_vy / (current_vx * current_vx));
            Coor.Yaw = Math.Atan2( current_vx,current_vy);
            return Coor;
        }
        public Coord GetVelocity(double t)
        {
            Coord Velocity;
            Velocity.x=-R * Omega * Math.Sin(Omega * t + Fi);
            Velocity.y = R * Omega * Math.Cos(Omega * t + Fi);
            Velocity.z = 0;
            return Velocity;
        }

        public DynamicState GetCoord(double t, bool b)
        {
            double current_x = 0;
            double current_y = 0;
            current_x = Velocity.x * (t ) + Acceleration.x * (t) * (t) / 2 + Destination.x;
            current_y = Velocity.y * (t) + Acceleration.y * (t) * (t) / 2 + Destination.y;
            MathLib.DynamicState Coor = new DynamicState();
            Coor.X = current_x;
            Coor.Y = current_y;
            Coor.Z = Centre.z;
            Coor.VX =Velocity.x+Acceleration.x*t;
            Coor.VY = Velocity.y + Acceleration.y * t; ;
            Coor.Roll = 0;
            Coor.Pitch = 0;

            Coor.RPitch = 0;
            Coor.RRoll = 0;
            Coor.RYaw = 0;
            Coor.Yaw = Math.Atan2(current_x, current_y);
            return Coor;

        }
    }
}
