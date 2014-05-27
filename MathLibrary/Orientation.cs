using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLib
{
    /// <summary>
    /// Describes material point orientation (all angles in RADIANS)
    /// </summary>
    public struct OrientationObject
    {
        public double Yaw, Pitch, Roll;
        public OrientationObject(double Yaw, double Pitch, double Roll)
        {
            this.Yaw = Yaw;
            this.Pitch = Pitch;
            this.Roll = Roll;
        }
        /// <summary>
        /// Create orientation matrix from this orientation object
        /// </summary>
        /// <returns>Orientation matrix</returns>
        public Matrix3 GetOrientationMatrix()
        {
            return Matrix3.CreateRotationYawPitchRoll(Yaw, Pitch, Roll);
        }
        public static OrientationObject operator+(OrientationObject x, OrientationObject y)
        {
            return new OrientationObject(x.Yaw + y.Yaw, x.Pitch + y.Pitch, x.Roll + y.Roll);
        }
        public static OrientationObject operator *(OrientationObject x, double y)
        {
            return new OrientationObject(x.Yaw * y, x.Pitch * y, x.Roll * y);
        }
        /// <summary>
        /// Delete extra periods
        /// </summary>
        public void Normolize()
        {
            NormolizeNumber(ref Yaw, 2 * Math.PI);
            NormolizeNumber(ref Pitch, 2 * Math.PI);
            NormolizeNumber(ref Roll, 2 * Math.PI);
        }
        void NormolizeNumber(ref double number, double MaxAbsValue)
        {
            int sign = Math.Sign(number);
            number *= sign;
            while (number > MaxAbsValue) number -= MaxAbsValue;
            number *= sign;
        }
    }
}   