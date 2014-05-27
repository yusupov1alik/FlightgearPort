using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navigation
{
    public class PID
    {
        static double FindTakeOff(TrajectoryEnsemble e, MathLib.Vector coor, MathLib.Vector Speed,ref bool b)
        {
            double vx = e.Tr.NumCirc1.VX;
            double vy = e.Tr.NumCirc1.VY;
            double xn = e.Th.Start.x;
            double yn = e.Th.Start.y;
            double t = (Speed.X * (coor.X - xn) + Speed.Y * (coor.Y - yn)) / (Speed.X * vx + Speed.Y * vy);
            if (t > e.T1)
            {
                b = false;
                return 0;
            }
            else
            {
                return t;
            }
        }

        static double FindCirc1(TrajectoryEnsemble e, MathLib.Vector coor, MathLib.Vector Speed, ref bool b)
        {
            double x = coor.X;
            double y = coor.Y;
            double z = coor.Z;
            double zc=e.Tr.NumCirc1.CoorSpeed.z;
            double vx=Speed.X;
            double vy=Speed.Y;
            double vz=Speed.Z;
            double xc = e.Tr.NumCirc1.Center.x;
            double yc = e.Tr.NumCirc1.Center.y;
            double R = e.Tr.NumCirc1.Rad;
            double omg = e.Tr.NumCirc1.Omg;
            double phi = e.Tr.NumCirc1.FI;
            double phi1 = Math.Acos(vx / Math.Sqrt(vx * vx + vy * vy));
            if(vy<0)
            {
                phi1=-phi1;
            }
            double S=((x-xc)*vx+(y-yc)*vy+(z-zc)*vz)/(R*Math.Sqrt(vx*vx+vy*vy));
            if(Math.Abs(S)>1)
            {
                b=false;
                return 0;
            }
            else
            {
                 double t1=(Math.Acos(S)-phi+phi1)/omg;
                 if (t1 > e.T2)
                 {
                     while (t1 > e.T2)
                     {
                         t1 -= Math.Abs(2 * Math.PI / omg);
                     }
                     if (t1 >= 0)
                     {
                         return t1;
                     }
                 }
                 else
                 {
                     if (t1 < 0)
                     {
                         while (t1 < 0)
                         {
                             t1 += Math.Abs(2 * Math.PI / omg);
                         }
                         if (t1 < e.T2)
                         {

                             return t1;
                         }
                     }
                     else return t1;
                 }
                 double t2 = (-Math.Acos(S) - phi + phi1)/omg;
                 if (t2 > e.T2)
                 {
                     while (t2> e.T2)
                     {
                         t2 -= Math.Abs(2 * Math.PI / omg);
                     }
                     if (t2 >= 0)
                     {
                         return t2;
                     }
                 }
                 else
                 {
                     if (t2 < 0)
                     {
                         while (t2 < 0)
                         {
                             t2 += Math.Abs(2 * Math.PI / omg);
                         }
                         if (t2 < e.T2)
                         {

                             return t2;
                         }
                     }
                     else return t2;
                 }
                 b = false;
                 return 0;
            }
        }

        static double FindLine(TrajectoryEnsemble e, MathLib.Vector coor, MathLib.Vector Speed, ref bool b)
        {
            double x = coor.X;
            double y = coor.Y;
            double z = coor.Z;
            double vx = Speed.X;
            double vy = Speed.Y;
            double vz = Speed.Z;
            double VX = e.Tr.VX;
            double VY = e.Tr.VY;
            double Ax = e.Tr.Ax;
            double Ay = e.Tr.Ay;
            double xc = e.Tr.X;
            double yc = e.Tr.Y;
            double h=e.Tr.NumCirc1.Center.z;
            double a = Ax * vx / 2 + Ay * vy / 2;
            double bk = vx * VX + vy * VY;
            double c = vx * (xc - x) + vy * (yc - y) + vz * (h - z);
            double D=bk * bk - 4 * a * c;
            if (D < 0)
            {
                b = false;
                return 0;
            }
            else
            {
                double t1=(-bk+Math.Sqrt(D))/(2*a);
                double t2 = (-bk - Math.Sqrt(D)) / (2 * a);
                if (0 <= t1 && t1 <= e.T3)
                    return t1;
                if (0 <= t2 && t2 <= e.T3)
                    return t2;
            }
            b = false;
            return 0;
        }

        static double FindCirc2(TrajectoryEnsemble e, MathLib.Vector coor, MathLib.Vector Speed, ref bool b)
        {
            double x = coor.X;
            double y = coor.Y;
            double z = coor.Z;
            double h = e.Tr.NumCirc2.Center.z;
            double vx = Speed.X;
            double vy = Speed.Y;
            double vz = Speed.Z;
            double xc = e.Tr.NumCirc2.Center.x;
            double yc = e.Tr.NumCirc2.Center.y;
            double R = e.Tr.NumCirc2.Rad;
            double omg = e.Tr.NumCirc2.Omg;
            double phi = e.Tr.NumCirc2.FI;
            double phi1 = Math.Acos(vx / Math.Sqrt(vx * vx + vy * vy));
            if (vy < 0)
            {
                phi1 = -phi1;
            }
            double S = ((x - xc) * vx + (y - yc) * vy + (z - h) * vz) / (R * Math.Sqrt(vx * vx + vy * vy));
            if (Math.Abs(S) > 1)
            {
                b = false;
                return 0;
            }
            else
            {
                double t1 =( Math.Acos(S) - phi + phi1)/omg;
                if (t1 > 0)
                {
                    while (t1 > 0)
                    {
                        t1 -= Math.Abs(2 * Math.PI / omg);
                    }
                    if (t1 >= -e.T4)
                    {
                        return t1+e.T4;
                    }
                }
                else
                {
                    if (t1 < -e.T4)
                    {
                        while (t1 < -e.T4)
                        {
                            t1 += Math.Abs(2 * Math.PI / omg);
                        }
                        if (t1 <0)
                        {

                            return t1+e.T4;
                        }
                    }
                    else return t1 + e.T4;
                }
                double t2 = (-Math.Acos(S) - phi + phi1)/omg;
                if (t2 > 0)
                {
                    while (t2 > 0)
                    {
                        t2 -= Math.Abs(2 * Math.PI / omg);
                    }
                    if (t2 >= -e.T4)
                    {
                        return t2 + e.T4;
                    }
                }
                else
                {
                    if (t2 < -e.T4)
                    {
                        while (t2 < -e.T4)
                        {
                            t2 += Math.Abs(2 * Math.PI / omg);
                        }
                        if (t2 < 0)
                        {

                            return t2 + e.T4;
                        }
                    }
                    else return t2 + e.T4;
                }
                b = false;
                return 0;
            }
        }

        public static MathLib.Vector Find(TrajectoryEnsemble e, MathLib.Vector coor, MathLib.Vector Speed)
        {
            bool b1 = true;
            bool b2 = true; bool b3 = true; bool b4 = true;
            List<double> time = new List<double>();
            double t1 = FindTakeOff(e, coor, Speed, ref b1);
            if (b1) time.Add(t1);
            double t2 = FindCirc1(e, coor, Speed, ref b2);
            if (b2) time.Add(t2+e.T1);
            double t3 = FindLine(e, coor, Speed, ref b3);
            if (b3) time.Add(t3+e.T1+e.T2);
            double t4 = FindCirc2(e, coor, Speed, ref b4);
            if (b4) time.Add(t4 + e.T1 + e.T2+e.T3);
            List<MathLib.Vector> coord = new List<MathLib.Vector>();
            foreach (double t in time)
            {
                MathLib.Point p = e.GetCoord(t).Position;
                MathLib.Vector T = new MathLib.Vector(p.X, p.Z, p.Y);
                coord.Add(T);
            }
            MathLib.Vector Tmin=coord.ElementAt(0);
            foreach (MathLib.Vector T in coord)
            {
                if (((T.X - coor.X) * (T.X - coor.X) + (T.Y - coor.Y) * (T.Y - coor.Y) + (T.Z - coor.Z) * (T.Z - coor.Z)) <= ((Tmin.X - coor.X) * (Tmin.X - coor.X) + (Tmin.Y - coor.Y) * (Tmin.Y - coor.Y) + (Tmin.Z - coor.Z) * (Tmin.Z - coor.Z)))
                {
                    Tmin = T;
                }
            }
            return Tmin;
        }
    }
}
