using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navigation
{
    public struct Trajectory
    {
        public double T1;
        public double T2;
        public double T3;
        public double VX;
        public double VY;
        public double Ax;
        public double Ay;
        public double X;
        public double Y;
        public CirclePart NumCirc1;
        public CirclePart NumCirc2;
        public bool b;
    }
    public class TimeCalculating
    {
        public static Trajectory MinTime(CirclePart[] Circles)
        {
            Trajectory []T=new Trajectory[4];
            T[0]=CurrentTime(Circles[0],Circles[2]);
            T[1] = CurrentTime(Circles[1], Circles[2]);
            T[2] = CurrentTime(Circles[0], Circles[3]);
            T[3] = CurrentTime(Circles[1], Circles[3]);
            Trajectory Tmin = T[0];
            foreach (Trajectory x in T)
            {
                if (x.b)
                {
                    Tmin = x;
                    break;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if ((T[i].T1 + T[i].T2 + T[i].T3) <= (Tmin.T1 + Tmin.T2 + Tmin.T3)&&T[i].b)
                {
                    Tmin = T[i];
                }
            }
            return Tmin;
        }
        static Trajectory CurrentTime(CirclePart Circle1, CirclePart Circle2)
        {
            double T1;
            double T2;
            double T3;
            double Angle1 = Math.Atan2((Circle2.Center.y-Circle1.Center.y),(Circle2.Center.x-Circle1.Center.x)); //circle1 ^ circle2 angle
            double Angle2 = Math.Atan2((Circle1.Center.y-Circle2.Center.y),(Circle1.Center.x-Circle2.Center.x)); //circle2 ^ circle1 angle
            double Angle_1; //circle1 start angle
            double Angle_2; //circle2 start angle
            double AngleDiff;
            double Vx; //circle1 finish angle
            double Vy; //circle2 finish angle
            double LengthR = Math.Sqrt((Circle2.Center.y - Circle1.Center.y) * (Circle2.Center.y - Circle1.Center.y) +
                (Circle1.Center.x - Circle2.Center.x) * (Circle1.Center.x - Circle2.Center.x)); //circles angle
            double LengthC;
            if (Circle1.Omg * Circle2.Omg > 0) //spin signs
            {
                //first situation + pi/2
                if (Math.Abs(Circle1.Rad - Circle2.Rad) / LengthR > 1)
                {
                    Trajectory T_err=new Trajectory();
                    T_err.b=false;
                    return T_err;
                }
                double Ang1=Math.Acos((Circle1.Rad-Circle2.Rad)/LengthR);
                double Ang2 = Math.Acos((Circle2.Rad - Circle1.Rad) / LengthR);
                Angle_1 = Angle1 + Ang1; //circle1 finish angle
                Angle_2 = Angle2 - Ang2; //circle2 start angle
                LengthC = Math.Sqrt(LengthR * LengthR - Math.Pow(Circle2.Rad - Circle1.Rad, 2));
                AngleDiff = Math.Atan2(Circle2.Center.y + Circle2.Rad * Math.Sin(Angle_2) - Circle1.Center.y - Circle1.Rad * Math.Sin(Angle_1), 
                    Circle2.Center.x + Circle2.Rad * Math.Cos(Angle_2) - Circle1.Center.x - Circle1.Rad * Math.Cos(Angle_1));
                Vx = -Circle1.Rad * Circle1.Omg * Math.Sin(Angle_1); //Vx at first angle 
                Vy = Circle1.Rad * Circle1.Omg * Math.Cos(Angle_1); //Vy at first angle
                if (Math.Abs((Math.Atan2(Vy, Vx) -AngleDiff))>=Math.Pow(10,-4)) //check velocity vector
                {
                    Angle_1 = Angle1 - Ang1; //circle1 finish angle
                    Angle_2 = Angle2 + Ang2; //circle2 start angle
                    Vx = -Circle1.Rad * Circle1.Omg * Math.Sin(Angle_1);
                    AngleDiff = Math.Atan2(Circle2.Center.y + Circle2.Rad * Math.Sin(Angle_2) - Circle1.Center.y - Circle1.Rad * Math.Sin(Angle_1), 
                        Circle2.Center.x + Circle2.Rad * Math.Cos(Angle_2) - Circle1.Center.x - Circle1.Rad * Math.Cos(Angle_1));
                    Vy = Circle1.Rad * Circle1.Omg * Math.Cos(Angle_1);
                }
            }
            else
            {
                if (LengthR < (Circle1.Rad + Circle2.Rad))
                {
                    Trajectory T_err = new Trajectory();
                    T_err.b = false;
                    return T_err;
                }
                double AngleDelt = Math.Acos((Circle1.Rad + Circle2.Rad) / LengthR);
                Angle_1 = Angle1 + AngleDelt;
                Angle_2 = Angle2 + AngleDelt;
                
                LengthC = Math.Sqrt(Math.Pow(Circle2.Center.y + Circle2.Rad * Math.Sin(Angle_2) - Circle1.Center.y - Circle1.Rad * Math.Sin(Angle_1), 2) + 
                    Math.Pow(Circle2.Center.x + Circle2.Rad * Math.Cos(Angle_2) - Circle1.Center.x - Circle1.Rad * Math.Cos(Angle_1), 2));
                
                AngleDiff = Math.Atan2(Circle2.Center.y + Circle2.Rad * Math.Sin(Angle_2) - Circle1.Center.y - Circle1.Rad * Math.Sin(Angle_1), 
                    Circle2.Center.x + Circle2.Rad * Math.Cos(Angle_2) - Circle1.Center.x - Circle1.Rad * Math.Cos(Angle_1));
                
                Vx = -Circle1.Rad * Circle1.Omg * Math.Sin(Angle_1);
                Vy = Circle1.Rad * Circle1.Omg * Math.Cos(Angle_1); //Vy at first angle
                if (Math.Abs(Math.Atan2(Vy, Vx) - AngleDiff) >= Math.Pow(10, -4)) //check velocity vector
                {
                    Angle_1 = Angle1 - AngleDelt; //change tangent
                    Angle_2 = Angle2 - AngleDelt; //circle2 angle

                    AngleDiff = Math.Atan2(Circle2.Center.y + Circle2.Rad * Math.Sin(Angle_2) - Circle1.Center.y - Circle1.Rad * Math.Sin(Angle_1), 
                        Circle2.Center.x + Circle2.Rad * Math.Cos(Angle_2) - Circle1.Center.x - Circle1.Rad * Math.Cos(Angle_1));

                    Vx = -Circle1.Rad*Circle1.Omg * Math.Sin(Angle_1);
                    Vy = Circle1.Rad*Circle1.Omg * Math.Cos(Angle_1);
                }
            }

                if (Math.Abs(Angle_1) > Math.PI)
                {
                    if (Angle_1 > 0)
                    {
                        Angle_1 -= 2 * Math.PI;
                    }
                    else
                    {
                        Angle_1 += 2 * Math.PI;
                    }
                }
                if (Math.Abs(Angle_2) > Math.PI)
                {
                    if (Angle_2 > 0)
                    {
                        Angle_2 -= 2 * Math.PI;
                    }
                    else
                    {
                        Angle_2 += 2 * Math.PI;
                    }
                }
                
                if (Circle1.Omg * (Angle_1 - Circle1.FI) < 0)
                {
                    if (Circle1.Omg > 0)
                    {
                        Angle_1 += 2 * Math.PI;
                    }
                    else
                    {
                        Angle_1 -= 2 * Math.PI;
                    }
                   
                }
                T1 = (Angle_1 - Circle1.FI) / Circle1.Omg;
                if (Circle2.Omg * (Circle2.FI - Angle_2) < 0)
                {
                    if (Circle2.Omg > 0)
                    {
                        Angle_2 -= 2 * Math.PI;
                    }
                    else
                    {
                        Angle_2 += 2 * Math.PI;
                    }
                }
                T3 = (Circle2.FI-Angle_2) / Circle2.Omg;
                Trajectory T=new Trajectory();
                if (T.Ax != 0)
                {
                    T.T2 = Math.Abs((Math.Sqrt(Circle2.VX * Circle2.VX + Circle2.VY * Circle2.VY) - Math.Sqrt(Vx * Vx + Vy * Vy))) / 
                        (Math.Sqrt(T.Ax * T.Ax + T.Ay * T.Ay));
                }
                else
                {
                    T.T2 = LengthC / Math.Sqrt(Vx*Vx+Vy*Vy);
                }
                T.b = true;
                T.T1 = T1;
                T.T3 = T3;
                T.NumCirc1 = Circle1;
                T.NumCirc2 = Circle2;
                Circle1.Acceleration.x = Math.Cos(AngleDiff) * (Circle2.VX * Circle2.VX + Circle2.VY * Circle2.VY -
                    (Circle1.VX * Circle1.VX + Circle1.VY * Circle1.VY)) / (2 * LengthC);
                Circle1.Acceleration.y = Math.Sin(AngleDiff) * (Circle2.VX * Circle2.VX + Circle2.VY * Circle2.VY -
                    (Circle1.VX * Circle1.VX + Circle1.VY * Circle1.VY)) / (2 * LengthC);
                Circle1.Velocity.x = Vx;
                Circle1.Velocity.y = Vy;
                Circle1.Velocity.z = 0;
                Circle1.Destination.x = Circle1.Rad * Math.Cos(Circle1.Omg * T1 + Circle1.FI) + Circle1.Center.x;
                Circle1.Destination.y = Circle1.Rad * Math.Sin(Circle1.Omg * T1 + Circle1.FI) + Circle1.Center.y;
                return T;
        }   
    }
}