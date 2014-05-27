using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLib
{
    public static class Constants
    {
        /// <summary>
        /// Air average density
        /// </summary>
        public const double AreaDensity = 129e-5;
        /// <summary>
        /// Free fall acceleration
        /// </summary>
        public const double Gravity = 9.817;
        /// <summary>
        /// Semimajor axis
        /// </summary>
        public const double EarthRadius = 6378137;
        /// <summary>
        /// Square of Earth eccenticity
        /// </summary>
        public const double EccentricitySquared = 6.69438e-3;
        public const double RadToDeg = 180 / Math.PI;
        public const double DegToRad = 1 / RadToDeg;
        public const double MeterToFoot = 1 / 0.3048;
        public const double FootToMeter = 1 / MeterToFoot;

    }
}
