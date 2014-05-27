using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathLib;
namespace Navigation
{
    public class TraectoryEnsemble
    {
        public Trajectory Tr;
        TakeOff Th;
        public double T1;
        public double T2;
        public double T3;
        public double T4;
        public double H;
        public double x;
        public double y;
        double MaxAng;
        double xp = 0, yp = 0, tp = 0;

        public TraectoryEnsemble(double x, double y, double h, double vx, double vy, double vh, double X, double Y, double H, double Vx, double Vy, double MaxAng, double MaxVertSpeed)
        {
            Th = new TakeOff(h, H, vh, MaxVertSpeed); T1 = Th.T;
            double current_alt = h;
            this.MaxAng = MaxAng;
            //double i=0;
            /*while (Math.Abs(current_alt - H) > 1e-4 + 1)
            {
                CoordinatesX6 Coor = new CoordinatesX6();
                current_alt = Th.A * Math.Sin(Th.omg * i) + Th.B * Math.Cos(Th.omg * i) + Th.C;
                Coor.altitude = current_alt;
                x += vx * i;
                y += vy * i;
                Coor.x = x;
                Coor.y = y;
                Coor.roll = 0;
                double current_vh = Th.A * Th.omg * Math.Cos(Th.omg * i) - Th.B * Th.omg * Math.Sin(Th.omg * i);
                Coor.yaw = Math.Atan2(vy, vx) - Math.PI;
                Coor.pitch = Math.Atan2(current_vh, Math.Sqrt(vx * vx + vy * vy));
                TrajectoryE.Add(Coor);
                i += 0.01;
            }*/
            this.x = x;
            this.y = y;
            this.H = H;
            CirclePart[] T = new CirclePart[4];
            T[0] = new CirclePart(x + vx * Th.T, y + vy * Th.T, MaxAng, vx, vy, '+');
            T[1] = new CirclePart(x + vx * Th.T, y + vy * Th.T, MaxAng, vx, vy, '-');
            T[2] = new CirclePart(X, Y, MaxAng, Vx, Vy, '+');
            T[3] = new CirclePart(X, Y, MaxAng, Vx, Vy, '-');
            Tr = TimeCalculating.MinTime(T);
            T2 = Tr.T1;
            T3 = Tr.T2;
            T4 = Tr.T3;
            /*for (i = 0; i < Tr.T1; i += 0.01)
            {
                CoordinatesX6 Coor = new CoordinatesX6();
                Coor.x=(Tr.NumCirc1.Center.x + Tr.NumCirc1.Rad * Math.Cos(Tr.NumCirc1.Omg * i + Tr.NumCirc1.FI));
                Coor.y=(Tr.NumCirc1.Center.y + Tr.NumCirc1.Rad * Math.Sin(Tr.NumCirc1.Omg * i + Tr.NumCirc1.FI));
                Coor.altitude=current_alt;
                Coor.roll=MaxAng*Tr.NumCirc1.Omg/Math.Abs(Tr.NumCirc1.Omg)*Math.PI/180;
                double current_vx=-Tr.NumCirc1.Rad*Tr.NumCirc1.Omg* Math.Sin(Tr.NumCirc1.Omg * i + Tr.NumCirc1.FI);
                double current_vy =Tr.NumCirc1.Rad * Tr.NumCirc1.Omg * Math.Cos(Tr.NumCirc1.Omg * i + Tr.NumCirc1.FI);
                Coor.pitch = 0;
                Coor.yaw = Math.Atan2(current_vy, current_vx) - Math.PI;
                TrajectoryE.Add(Coor);
            }
            for (i = 0; i < Tr.T2; i += 0.01)
            {
                double current_x = 0;
                double current_y = 0;
                if (TrajectoryE.Count != 0)
                {
                    current_x=Tr.VX * i + Tr.Ax * i * i / 2 + TrajectoryE.Last().x;
                    current_y = Tr.VY * i + Tr.Ay * i * i / 2 + TrajectoryE.Last().y;
                }
                else
                {
                    current_x = Tr.VX * i + Tr.Ax * i * i / 2 + x;
                    current_y = Tr.VY * i + Tr.Ay * i * i / 2 + y;
                }
                CoordinatesX6 Coor = new CoordinatesX6();
                Coor.x = current_x;
                Coor.y = current_y;
                Coor.altitude = current_alt;
                Coor.roll = 0;
                Coor.pitch = 0;
                Coor.yaw = Math.Atan2(current_y, current_x) - Math.PI;
                TrajectoryE.Add(Coor);
            }
            for (i = 0; i < Tr.T3; i += 0.01)
            {
                CoordinatesX6 Coor = new CoordinatesX6();
                Coor.x = (Tr.NumCirc2.Center.x + Tr.NumCirc2.Rad * Math.Cos(Tr.NumCirc2.Omg * (i-Tr.T3) + Tr.NumCirc2.FI));
                Coor.y = (Tr.NumCirc2.Center.y + Tr.NumCirc2.Rad * Math.Sin(Tr.NumCirc2.Omg * (i - Tr.T3) + Tr.NumCirc2.FI));
                Coor.altitude = current_alt;
                Coor.roll = MaxAng * Tr.NumCirc2.Omg / Math.Abs(Tr.NumCirc2.Omg) * Math.PI / 180;
                double current_vx = -Tr.NumCirc2.Rad * Tr.NumCirc2.Omg * Math.Sin(Tr.NumCirc2.Omg * (i - Tr.T3) + Tr.NumCirc2.FI);
                double current_vy = Tr.NumCirc2.Rad * Tr.NumCirc2.Omg * Math.Cos(Tr.NumCirc2.Omg * (i - Tr.T3) + Tr.NumCirc2.FI);
                Coor.pitch = 0;
                Coor.yaw = Math.Atan2(current_vy, current_vx) - Math.PI;
                TrajectoryE.Add(Coor);
            }*/
        }

        public DynamicState GetCoord(double t)
        {
            DynamicState res;
            if (t <= T1)
            {
                DynamicState Coor = new DynamicState();
                double current_alt = Th.A * Math.Sin(Th.omg * t) + Th.B * Math.Cos(Th.omg * t) + Th.C;
                Coor.Z = current_alt;
                Coor.X = x + Tr.NumCirc1.VX * t;
                Coor.Y = y + Tr.NumCirc1.VY * t;
                Coor.Roll = 0;
                double current_vh = Th.A * Th.omg * Math.Cos(Th.omg * t) - Th.B * Th.omg * Math.Sin(Th.omg * t);
                Coor.VX = Tr.NumCirc1.VX;
                Coor.VZ = current_vh;
                Coor.VY= Tr.NumCirc1.VY;
                Coor.Yaw = Math.Atan2(Tr.NumCirc1.VY, Tr.NumCirc1.VX);
                Coor.RPitch = 1 / (1 + current_vh * current_vh / (Tr.NumCirc1.VX * Tr.NumCirc1.VX + Tr.NumCirc1.VY * Tr.NumCirc1.VY));
                Coor.RRoll = 0;
                Coor.RYaw = 1/(1+Tr.NumCirc1.VY*Tr.NumCirc1.VY/(Tr.NumCirc1.VX*Tr.NumCirc1.VX));
                Coor.Pitch = Math.Atan2(current_vh, Math.Sqrt(Tr.NumCirc1.VX * Tr.NumCirc1.VX + Tr.NumCirc1.VY * Tr.NumCirc1.VY));
                res = Coor;
            }
            else
            {
                if (t <= T1 + T2)
                {
                    DynamicState Coor = new DynamicState();
                    Coor.X = (Tr.NumCirc1.Center.x + Tr.NumCirc1.Rad * Math.Cos(Tr.NumCirc1.Omg * (t - T1) + Tr.NumCirc1.FI));
                    Coor.Y = (Tr.NumCirc1.Center.y + Tr.NumCirc1.Rad * Math.Sin(Tr.NumCirc1.Omg * (t - T1) + Tr.NumCirc1.FI));
                    Coor.Z = H;
                    Coor.Roll = -MaxAng * Tr.NumCirc1.Omg / Math.Abs(Tr.NumCirc1.Omg);
                    double current_vx = -Tr.NumCirc1.Rad * Tr.NumCirc1.Omg * Math.Sin(Tr.NumCirc1.Omg * (t - T1) + Tr.NumCirc1.FI);
                    double current_vy = Tr.NumCirc1.Rad * Tr.NumCirc1.Omg * Math.Cos(Tr.NumCirc1.Omg * (t - T1) + Tr.NumCirc1.FI);
                    Coor.VX = current_vx;
                    Coor.VZ = 0;
                    Coor.VY = current_vy; ;
                    Coor.Pitch = 0;

                    Coor.RPitch = 0;
                    Coor.RRoll = 0;
                    Coor.RYaw = 1 / (1 + current_vy * current_vy / (current_vx * current_vx));
                    Coor.Yaw = Math.Atan2(current_vy, current_vx);
                    res = Coor;
                }
                else
                {
                    if (t <= T1 + T2 + T3)
                    {
                        double current_x = 0;
                        double current_y = 0;
                        if (T2 <= 0)
                        {
                            current_x = Tr.VX * (t - T1 - T2) + Tr.Ax * (t - T1 - T2) * (t - T1 - T2) / 2 + Tr.NumCirc1.CoorSpeed.x;
                            current_y = Tr.VY * (t - T1 - T2) + Tr.Ay * (t - T1 - T2) * (t - T1 - T2) / 2 + Tr.NumCirc1.CoorSpeed.y;
                        }
                        else
                        {
                            current_x = Tr.VX * (t - T1 - T2) + Tr.Ax * (t - T1 - T2) * (t - T1 - T2) / 2 + Tr.NumCirc1.Center.x + Tr.NumCirc1.Rad * Math.Cos(Tr.NumCirc1.Omg * T2 + Tr.NumCirc1.FI);
                            current_y = Tr.VY * (t - T1 - T2) + Tr.Ay * (t - T1 - T2) * (t - T1 - T2) / 2 + Tr.NumCirc1.Center.y + Tr.NumCirc1.Rad * Math.Sin(Tr.NumCirc1.Omg * T2 + Tr.NumCirc1.FI);
                        }
                        DynamicState Coor = new DynamicState();
                        Coor.X = current_x;
                        Coor.Y = current_y;
                        Coor.Z = H;
                        Coor.VX = Tr.VX + Tr.Ax * (t - T1 - T2);
                        Coor.VZ = 0;
                        Coor.VY = Tr.VY + Tr.Ay * (t - T1 - T2);
                        Coor.Roll = 0;
                        Coor.Pitch = 0;

                        Coor.RPitch = 0;
                        Coor.RRoll = 0;
                        Coor.RYaw = 0;
                        //Coor.yaw = Math.Atan2(current_y, current_x) - Math.PI + Math.PI / 2;
                        res = Coor;
                    }
                    else
                    {
                        DynamicState Coor = new DynamicState();
                        Coor.X = (Tr.NumCirc2.Center.x + Tr.NumCirc2.Rad * Math.Cos(Tr.NumCirc2.Omg * (t - T4 - T1 - T2 - T3) + Tr.NumCirc2.FI));
                        Coor.Y = (Tr.NumCirc2.Center.y + Tr.NumCirc2.Rad * Math.Sin(Tr.NumCirc2.Omg * (t - T4 - T1 - T2 - T3) + Tr.NumCirc2.FI));
                        Coor.Z = H;
                        Coor.Roll = -MaxAng * Tr.NumCirc2.Omg / Math.Abs(Tr.NumCirc2.Omg) * Math.PI / 180;
                        double current_vx = -Tr.NumCirc2.Rad * Tr.NumCirc2.Omg * Math.Sin(Tr.NumCirc2.Omg * (t - T4 - T1 - T2 - T3) + Tr.NumCirc2.FI);
                        double current_vy = Tr.NumCirc2.Rad * Tr.NumCirc2.Omg * Math.Cos(Tr.NumCirc2.Omg * (t - T4 - T1 - T2 - T3) + Tr.NumCirc2.FI);
                        Coor.VX = current_vx;
                        Coor.VY = current_vy;
                        Coor.VZ = 0;
                        Coor.Pitch = 0;
                        Coor.Yaw = -Math.Atan2(current_vy, current_vx) - Math.PI;

                        Coor.RPitch = 0;
                        Coor.RRoll = 0;
                        Coor.RYaw = 1 / (1 + current_vy * current_vy / (current_vx * current_vx));

                        res = Coor;
                    }
                }
            }
            res.Yaw = Math.Atan2((res.X - xp) / (t - tp), (res.Y - yp) / (t - tp));
            if (t > T1) res.Yaw += Math.PI / 25;
            else res.Yaw -= Math.PI / 40;
            if (res.Z - yp == 0) res.Yaw = Math.PI / 2;
            xp = res.X;
            yp = res.Y;
            tp = t;
            return res;
        }
        /// <summary>
        /// Constructor with MatLibrary params
        /// </summary>
        /// <param name="Location">Initial aircraft position</param>
        /// <param name="Speeds">Initial aircraft speed</param>
        /// <param name="TargetLocation">Carrier location</param>
        /// <param name="GlidepathSpeed">Speed on glidepath start</param>
        /// <param name="MaxRoll">Max roll deviation</param>
        /// <param name="MaxVertSpeed">Max altitude speed</param>
        public TraectoryEnsemble(Vector Location, Vector Speeds, Vector TargetLocation, Vector GlidepathSpeed, double MaxRoll, double MaxVertSpeed)
            : this(Location.X, Location.Y, Location.Z, Speeds.X, Speeds.Y, Speeds.Z, TargetLocation.X, TargetLocation.Y, TargetLocation.Z, GlidepathSpeed.X, GlidepathSpeed.Y, MaxRoll, MaxVertSpeed)
        {
            ;
        }
    }
 }
