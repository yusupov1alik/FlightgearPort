using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathLib;
namespace CarrierControl
{
    /// <summary>
    /// Carrier character
    /// </summary>
    public class Carrier
    {
        public Point PositionLocal;
        public Point GlidepathPositionConnected;
        public GlobalCoordPoint PositionGlobal;
        const double Pi = Math.PI;
        static Random rand = new Random();
        public double aV;
        public double MaxPitchDev;
        public double MaxRollDev;
        public double MaxYawDev; //How waves can change moving direction
        public double DefaultYaw; //Default moving direction
        public double TMin; //Min wave period
        public double TMax; //Max wave period
        public double ZAv;
        public double ZDeviation;
        CarrierControl CC;

        #region Constructors
        public Carrier(
            GlobalCoordPoint GlobalCoord,
            Point StartPointLocal,
            Point GlidepathPosition_connected,
            double aV = 10, //10 m/s
            double MaxPitchDeviation = 10 * Pi / 180, //10 deg
            double MaxRollDeviation = 10 * Pi / 180, //10 deg
            double MaxYawDeviation = 10 * Pi / 180,
            double TMin = 120,
            double TMax = 600,
            double YMin = -5,
            double YMax = 10)
        {
            this.PositionGlobal = GlobalCoord;
            this.PositionLocal = StartPointLocal;
            this.DefaultYaw = rand.Next(-50, 50) * Pi / 180;
            this.GlidepathPositionConnected = GlidepathPosition_connected;
            this.aV = aV;
            this.MaxPitchDev = MaxPitchDeviation;
            this.MaxRollDev = MaxRollDeviation;
            this.MaxYawDev = MaxYawDeviation;
            this.TMin = TMin;
            this.TMax = TMax;
            this.ZAv = YMin;
            this.ZDeviation = YMax;
            this.CC = new CarrierControl(this);
        }
        Carrier(Point StartPoint, Point GlidepathPos)
        {
            this.GlidepathPositionConnected = GlidepathPos;
            this.PositionLocal = StartPoint;
            this.CC = new CarrierControl(this);
        }
        #endregion
        /// <summary>
        /// Change carrier position (in time step)
        /// </summary>
        public void Move(double dt)
        {
            Vector PrevPosition = PositionLocal.Location;
            CC.MoveCarrier(dt);
            PositionGlobal.Move(PositionLocal.Location + (-PrevPosition));
        }
        public Point GlidepathPositionLocal
        {
            get
            {
                Point res = new Point();
                res.Location = PositionLocal.Location + GlidepathPositionConnected.Location * Matrix3.CreateRotationYawPitchRoll(PositionLocal.Orientation);
                res.Orientation = GlidepathPositionConnected.Orientation;
                return res;
            }
        }
    }
}