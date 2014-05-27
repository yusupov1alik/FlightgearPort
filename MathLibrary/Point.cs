using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLib
{
    /// <summary>
    /// Describes the position of material point (coordinates and angles)
    /// </summary>
    public struct Point
    {
        public Vector Location;
        public Matrix3 OrientationMatrix;
        public OrientationObject Orientation
        {
            get
            {
                if (OrientationMatrix == null) return new OrientationObject(0, 0, 0);
                return OrientationMatrix.GetAngles();
            }
            set
            {
                OrientationMatrix = Matrix3.CreateRotationYawPitchRoll(value);
            }
        }
        public double X
        {
            get
            {
                return Location.X;
            }
            set
            {
                Location.X = value;
            }
        }
        public double Y
        {
            get
            {
                return Location.Y;
            }
            set
            {
                Location.Y = value;
            }
        }
        public double Z
        {
            get
            {
                return Location.Z;
            }
            set
            {
                Location.Z = value;
            }
        }
        public double Yaw
        {
            get
            {
                return Orientation.Yaw;
            }
            set
            {
                OrientationObject or = Orientation;
                Orientation = new OrientationObject(value, or.Pitch, or.Roll);
            }
        }
        public double Pitch
        {
            get
            {
                return Orientation.Pitch;
            }
            set
            {
                OrientationObject or = Orientation;
                Orientation = new OrientationObject(or.Yaw, value, or.Roll);
            }
        }
        public double Roll
        {
            get
            {
                return Orientation.Roll;
            }
            set
            {
                OrientationObject or = Orientation;
                Orientation = new OrientationObject(or.Yaw, or.Pitch, value);
            }
        }

        public Point(Vector Position, OrientationObject Orientation)
        {
            this.Location = Position;
            OrientationMatrix = Matrix3.CreateRotationYawPitchRoll(Orientation);
        }

        public Point(double x, double y, double z, double yaw, double pitch, double roll)
        {
            OrientationMatrix = Matrix3.CreateRotationYawPitchRoll(yaw, pitch, roll);
            this.Location = new Vector(x, y, z);
        }

        /// <summary>
        /// Get object discription in string format
        /// </summary>
        /// <returns>String in format X,Y,Z,Yaw,Pitch,Roll\n</returns>
        public override string ToString()
        {
            string sw = "";
            sw += X.ToString("N6") + '/';
            sw += Y.ToString("N6") + '/';
            sw += (Z * Constants.MeterToFoot).ToString("N6") + '/';
            sw += (Yaw * Constants.RadToDeg).ToString("N6") + '/';
            sw += (Pitch * Constants.RadToDeg).ToString("N6") + '/';
            sw += (Roll * Constants.RadToDeg).ToString("N6");
            string res = "";
            for (int i = 0; i < sw.Length; i++) //Change format
            {
                if (char.IsDigit(sw[i]) || sw[i] == '-') res+= sw[i];
                else if (sw[i] == ',') res += '.';
                else if (sw[i] == '/') res += ',';
            }
            return res;
        }
    }
}
