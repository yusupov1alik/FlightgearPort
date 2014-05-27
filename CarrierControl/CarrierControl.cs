using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathLib;
namespace CarrierControl
{
    class CarrierControl
    {
        const double Pi = Math.PI;
        Carrier carrier;
        Random rand = new Random();
        double K; //period ratio
        double currentPeriod;
        double t = 0; //current time
        double TimePassed;
        public CarrierControl(Carrier carrier)
        {
            this.carrier = carrier;
            this.currentPeriod = rand.Next((int)carrier.TMin, (int)carrier.TMax);
            TimePassed = 0;
            K = 2 * Pi / currentPeriod;
        }
        public CarrierControl(Carrier carrier, double DefaultMovingDirection)
        {
            this.carrier = carrier;
            this.currentPeriod = rand.Next((int)carrier.TMin, (int)carrier.TMax);
            TimePassed = 0;
            K = 2 * Pi / currentPeriod;
        }
        /// <summary>
        /// Change carrier position 
        /// </summary>
        public void MoveCarrier(double dt)
        {
            if (Math.Abs(t - currentPeriod) < dt)
            {
                currentPeriod = rand.Next((int)carrier.TMin, (int)carrier.TMax);
                K = 2 * Pi / currentPeriod;
                TimePassed += t;
                t = 0;
            }
            
            Point res = new Point();
            //change angles
            double kt = K * t;
            res.Yaw = carrier.DefaultYaw + Math.Cos(kt) * carrier.MaxYawDev;
            res.Pitch = -Math.Sin(kt) * Math.Sin(carrier.PositionLocal.Yaw) * carrier.MaxPitchDev;
            res.Roll = -Math.Sin(kt) * Math.Cos(carrier.PositionLocal.Yaw) * carrier.MaxRollDev;
            //change coords
            res.X = carrier.PositionLocal.X + carrier.aV * Math.Sin(kt);
            res.Z = carrier.PositionLocal.Y + carrier.aV * Math.Cos(kt);
            res.Z = Math.Cos(t * K) * carrier.ZDeviation + Math.Abs(kt);
            t += dt;
            carrier.PositionLocal = res;
        }
    }
}
