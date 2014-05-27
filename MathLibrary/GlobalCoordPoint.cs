using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLib
{
    public struct GlobalCoordPoint
    {
        public double Longitude;
        public double Latitude;
        public double Altitude;
        public OrientationObject Orientation;
        public GlobalCoordPoint(double Longitude, double Latitude, double Altitude, OrientationObject Orientation)
        {
            this.Altitude = Altitude;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.Orientation = Orientation;
        }

        public GlobalCoordPoint(double Longitude, double Latitude, double Altitude, double Yaw, double Pitch, double Roll)
        {
            this.Altitude = Altitude;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.Orientation = new OrientationObject(Yaw, Pitch, Roll);
        }

        /// <summary>
        /// Constructor with default orientation
        /// </summary>
        /// <param name="Longitude"></param>
        /// <param name="Latitude"></param>
        /// <param name="Altitude"></param>
        public GlobalCoordPoint(double Longitude, double Latitude, double Altitude)
        {
            this.Altitude = Altitude;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            Orientation = new OrientationObject();
        }

        /// <summary>
        /// Compute and apply shift to global coords
        /// </summary>
        /// <param name="Shift">Local coords shift</param>
        public void Move(Vector Shift)
        {
            double c = Math.Pow(1 - Constants.EccentricitySquared * Math.Pow (Math.Sin(Latitude * Constants.DegToRad), 2), 1.5) * 20; //10 - bad constant, should be replaced
            Longitude += Shift.X * c / (Constants.EarthRadius * Math.Cos(Latitude * Constants.DegToRad));
            Latitude += Shift.Y * c / (Constants.EarthRadius * (1 - Constants.EccentricitySquared));
            Altitude += Shift.Z * Constants.MeterToFoot;
        }

        public override string ToString()
        {
            string sw = "";
            sw += Longitude.ToString("N6") + '/';
            sw += Latitude.ToString("N6") + '/';
            sw += Altitude.ToString("N6") + '/';
            sw += (Orientation.Yaw * Constants.RadToDeg).ToString("N6") + '/';
            sw += (Orientation.Pitch * Constants.RadToDeg).ToString("N6") + '/';
            sw += (Orientation.Roll * Constants.RadToDeg).ToString("N6");
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
