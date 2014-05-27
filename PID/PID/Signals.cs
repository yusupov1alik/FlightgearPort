using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Navigation;
using MathLib;

namespace PID
{
    public class Signals
    {
        IntegralPart VelocityInt=new IntegralPart();
        IntegralPart RollInt= new IntegralPart();
        IntegralPart PitchInt = new IntegralPart();
        IntegralPart YawInt = new IntegralPart();
        public MathLib.Torgues GetSignal(MathLib.Vector Position, MathLib.Vector Velocity, MathLib.Vector Acceleration, MathLib.OrientationObject Orientation, TrajectoryEnsemble e, Torgues TMax, MathLib.OrientationObject CareerOrientation)
        {
            Vector NextPosition = new Vector(Position.X + Velocity.X * 0.01, Position.Y + Velocity.Y * 0.01, Position.Z + Velocity.Z * 0.01);
            DynamicState Data = FindVector.FindPoint(e, Position, Velocity);
            double WishRoll = Data.Roll;
            double WishRollVelocity = Data.RRoll;
            double WishYaw = Math.Atan2(NextPosition.X - Position.X, NextPosition.Y - Position.Y);
            double WishYawVelocity = 0;
            double WishPitch=Math.Atan2(NextPosition.Z-Position.Z,Math.Sqrt((NextPosition.X - Position.X)*(NextPosition.X - Position.X)+(NextPosition.Y - Position.Y)*(NextPosition.Y - Position.Y)));
            double WishPitchVelocity = 0;
            Vector WishVelocity=Data.Velocity;
            Vector WishAcceleration = Data.Accelerations;
            double F = 0;
            double YawTorgue = 0;
            double PitchTorgue = 0;
            double RollTorgue = 0;
            double Multip = 1;
            MathLib.Vector G = e.G.FindCoord(Position);
            double WishHeight = G.Z;
            bool b = false;
            if (e.G.Height(G.X, G.Y) > 0)
            {

               WishHeight= e.G.Height(G.X, G.Y);
               b = true;
            }
            F = Force(Position.Z,WishHeight, Data.VZ,0);
            if (F > TMax.TractiveForce)
            {
                F = TMax.TractiveForce;
            }
            else
            {
                if (F < 0)
                    F = 0;
            }

            RollTorgue = TorRoll(Orientation.Roll, WishRoll, 0, WishRollVelocity, Multip);
            if (RollTorgue > TMax.RollTorgue)
            {
                RollTorgue = TMax.RollTorgue;
            }
            else
            {
                if (RollTorgue < -TMax.RollTorgue)
                {
                    RollTorgue = -TMax.RollTorgue;
                }
            }
            if (b)
            {
                WishRoll = CareerOrientation.Roll;
                WishPitch = CareerOrientation.Pitch + Math.PI / 36;
            }
            PitchTorgue = TorPitch(Orientation.Pitch, WishPitch, 0, WishPitchVelocity, Multip);
            if (PitchTorgue > TMax.PitchTorgue)
            {
                PitchTorgue = TMax.PitchTorgue;
            }
            else
            {
                if (PitchTorgue < -TMax.PitchTorgue)
                {
                   PitchTorgue = -TMax.PitchTorgue;
                }
            }

            YawTorgue = TorYaw(Orientation.Yaw, WishYaw, 0, WishYawVelocity, Multip);
            if (YawTorgue > TMax.YawTorgue)
            {
                YawTorgue = TMax.YawTorgue;
            }
            else
            {
                if (YawTorgue < -TMax.YawTorgue)
                {
                    YawTorgue = -TMax.YawTorgue;
                }
            }

            return new Torgues(F, RollTorgue, YawTorgue, PitchTorgue);

        }

        public double Force(double WishHeight,double CurrentHeight, double WishVelocityZ, double CurrentVelocityZ)
        {
            const double kv = 5000;
            const double ka = 5000;
            const double ki = 5000;
            VelocityInt.AddItem(CurrentHeight - WishHeight);
            return -kv * (CurrentHeight - WishHeight) - ka * (CurrentVelocityZ-WishVelocityZ) - ki * VelocityInt.INTEGRAL;
        }
        public double TorRoll(double CurrentRoll, double WishRoll, double CurrentRollVelocity, double WishRollVelocity,double Multip)
        {
            const double k=1;
            const double kv=1;
            const double ki=1;
            double Delt = CurrentRoll - WishRoll;
            if (Delt >= 0)
            {
                while (Delt >= Math.PI)
                {
                    Delt -= Math.PI * 2;
                }
            }
            else
            {
                while (Delt <= -Math.PI)
                {
                    Delt += Math.PI * 2;
                }
            }
            RollInt.AddItem(Delt);
            return -k * (Delt) - kv * (CurrentRollVelocity - WishRollVelocity) - ki * RollInt.INTEGRAL;
        }
        public double TorPitch(double CurrentPitch, double WishPitch, double CurrentPitchVelocity, double WishPitchVelocity, double Multip)
        {
            const double k = 1;
            const double kv = 1;
            double Delt = CurrentPitch - WishPitch;
            if (Delt >= 0)
            {
                while (Delt >= Math.PI)
                {
                    Delt -= Math.PI * 2;
                }
            }
            else
            {
                while (Delt <= -Math.PI)
                {
                    Delt += Math.PI * 2;
                }
            }
            const double ki = 1;
            PitchInt.AddItem(Delt);
            return -k * (Delt) - kv * (CurrentPitchVelocity - WishPitchVelocity) - ki * PitchInt.INTEGRAL;
        }
        public double TorYaw(double CurrentYaw, double WishYaw, double CurrentYawVelocity, double WishYawVelocity, double Multip)
        {
            const double k = 1;
            const double kv = 1;
            const double ki = 1;
            double Delt =0;
            Delt=  WishYaw-CurrentYaw;
            if (Delt >= 0)
            {
                while (Delt >= Math.PI)
                {
                    Delt -= Math.PI * 2;
                }
            }
            else
            {
                while (Delt <= -Math.PI)
                {
                    Delt += Math.PI * 2;
                }
            }
            YawInt.AddItem(Delt);
            return -k * (Delt) - kv * (CurrentYawVelocity - WishYawVelocity) - ki * YawInt.INTEGRAL;
        }
    }
}
