using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathLib;
namespace Navigation
{
    public class TrajectoryEnsemble
    {
        public Glissade G;
        public Trajectory Tr;
        public TakeOff Th;
        public double T1;
        public double T2;
        public double T3;
        public double T4;
        public double T5;
        double MaxAng;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InitialPosition">UAV start position</param>
        /// <param name="vx">UAV start Vx</param>
        /// <param name="vy">UAV start Vy</param>
        /// <param name="vh">UAV start Vz</param>
        /// <param name="CareerPosition">Carrier start position</param>
        /// <param name="H">Glidepath height</param>
        /// <param name="EndVelocity">Landing velocity norm</param>
        /// <param name="MaxAng">Max roll</param>
        /// <param name="MaxVertSpeed">Maximum Vz</param>
        /// <param name="CareerYaw">Carrier yaw</param>
        /// <param name="GlissadeLength">Glissade norm</param>
        public TrajectoryEnsemble(Vector InitialPosition, double vx, double vy, double vh, Vector CareerPosition, double H, double EndVelocity, double MaxAng, double MaxVertSpeed, double CareerYaw,double GlissadeLength)
        {
            Th = new TakeOff(InitialPosition.X,InitialPosition.Y, InitialPosition.Z, H, vh, MaxVertSpeed,vx,vy); T1 = Th.T;
            G = new Glissade(CareerPosition, CareerYaw,GlissadeLength, H);
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
            CirclePart[] T = new CirclePart[4];
            T[0] = new CirclePart(Th.Destination.x,Th.Destination.y, MaxAng, vx, vy, '+',H);
            T[1] = new CirclePart(Th.Destination.x, Th.Destination.y, MaxAng, vx, vy, '-', H);
            T[2] = new CirclePart(G.StartPosition.x, G.StartPosition.y, MaxAng, EndVelocity * Math.Sin(CareerYaw), EndVelocity * Math.Cos(CareerYaw), '+', H);
            T[3] = new CirclePart(G.StartPosition.x, G.StartPosition.y, MaxAng, EndVelocity * Math.Sin(CareerYaw), EndVelocity * Math.Cos(CareerYaw), '-', H);
            Tr = TimeCalculating.MinTime(T);
            T2 = Tr.T1;
            T3 = Tr.T2;
            T4 = Tr.T3;
         
        }

        public MathLib.DynamicState GetCoord(double t)
        {
            MathLib.DynamicState res;
            if (t <= T1)
            {
                res = Th.GetCoord(t);
            }
            else
            {
                if (t <= T1 + T2)
                {
                    res = Tr.NumCirc1.GetCoord(t-T1);
                }
                else
                {
                    if (t <= T1 + T2 + T3)
                    {
                        res = Tr.NumCirc1.GetCoord(t - T1 - T2, true);
                    }
                    else
                    {
                        /*if (t <= T1 + T2 + T3 + T4)
                        {*/
                            res = Tr.NumCirc2.GetCoord(t-T1-T2-T3);
                        /*}
                        else
                        {
                            MathLib.DynamicState Coor =new DynamicState();
                            Coor.X=(G.x+(G.a*t*t*t+G.b*t*t+G.c*t)*Math.Sin(alph));
                            Coor.Y=(G.y+(G.a*t*t*t+G.b*t*t+G.c*t)*Math.Cos(alph));
                            Coor.Z=G.K*Math.Atan(G.a*t*t*t+G.b*t*t+G.c*t-G.L/2);
                            Coor.VX = (G.a1 * t * t + G.b1 * t + G.c1)*Math.Sin(alph);
                            Coor.VY = (G.a1 * t * t + G.b1 * t + G.c1) * Math.Sin(alph);
                            Coor.VZ = -G.K / (1 + (G.a * t * t * t + G.b * t * t + G.c * t - G.L / 2) * (G.a * t * t * t + G.b * t * t + G.c * t - G.L / 2));
                            Coor.Pitch = Math.Atan2(Coor.VZ,Math.Sqrt(Coor.VX * Coor.VX + Coor.VY * Coor.VY))+Math.PI/36;
                            res = Coor;
                        }*/
                    }
                }
            }//NaN in next line on the first iteration
            return res;
        }
        /// <summary>
        /// Constructor with MatLibrary params
        /// </summary>
        /// <param name="Location">Initial aircraft position</param>
        /// <param name="Speeds">Initial aircraft speed</param>
        /// <param name="CarrierLocation">Carrier location</param>
        /// <param name="GlidepathSpeed">Speed on glidepath start</param>
        /// <param name="MaxRoll">Max roll deviation</param>
        /// <param name="MaxVertSpeed">Max altitude speed</param>
        public TrajectoryEnsemble(DynamicState AircraftDynState, Vector CarrierLocation, Vector GlidepathSpeed, Vector GlidepathPosition, double MaxRoll, double MaxVertSpeed, double CarrierYaw, double GlidepathLength)
            : this(AircraftDynState.Coord, AircraftDynState.VX, AircraftDynState.VY, AircraftDynState.VZ, CarrierLocation, GlidepathPosition.Z,  GlidepathSpeed.Length, MaxRoll, MaxVertSpeed, CarrierYaw, GlidepathLength)
        {
            ;
        }
    }
 }
