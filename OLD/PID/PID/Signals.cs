using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PID
{
    public class Signals
    {
        IntegralPart VelocityInt=new IntegralPart();
        IntegralPart RollInt= new IntegralPart();
        IntegralPart PitchInt = new IntegralPart();
        IntegralPart YawInt = new IntegralPart();
        /*public static Torgues GetSignal(MathLib.Vector Position, MathLib.Vector Velocity, MathLib.Vector Acceleration, MathLib.OrientationObject Orientation, MathLib.OrientationObject Velocities)
        {
        }*/

        public double Force(MathLib.Vector CurrentVelocity, MathLib.Vector CurrentAcceleration, MathLib.Vector WishVelocity, MathLib.Vector WishAccelerarion)
        {
            const double kv = 1;
            const double ka = 1;
            const double ki = 1;
            VelocityInt.AddItem(CurrentVelocity.Length - WishVelocity.Length);
            return -kv * (CurrentVelocity.Length - WishVelocity.Length) - ka * (CurrentAcceleration.Length - WishAccelerarion.Length) - ki * VelocityInt.INTEGRAL;
        }
        public double TorRoll(double CurrentRoll, double WishRoll, double CurrentRollVelocity, double WishRollVelocity)
        {
            const double k=1;
            const double kv=1;
            const double ki=1;
            RollInt.AddItem(CurrentRoll - WishRoll);
            return -k * (CurrentRoll - WishRoll) - kv * (CurrentRollVelocity - WishRollVelocity) - ki * RollInt.INTEGRAL;
        }
        public double TorPitch(double CurrentPitch, double WishPitch, double CurrentPitchVelocity, double WishPitchVelocity)
        {
            const double k = 1;
            const double kv = 1;
            const double ki = 1;
            PitchInt.AddItem(CurrentPitch - WishPitch);
            return -k * (CurrentPitch - WishPitch) - kv * (CurrentPitchVelocity - WishPitchVelocity) - ki * PitchInt.INTEGRAL;
        }
        public double TorYaw(double CurrentYaw, double WishYaw, double CurrentYawVelocity, double WishYawVelocity)
        {
            const double k = 1;
            const double kv = 1;
            const double ki = 1;
            YawInt.AddItem(CurrentYaw - WishYaw);
            return -k * (CurrentYaw - WishYaw) - kv * (CurrentYawVelocity - WishYawVelocity) - ki * YawInt.INTEGRAL;
        }
    }
}
