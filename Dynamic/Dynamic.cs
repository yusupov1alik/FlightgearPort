using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathLib;
namespace Dynamic
{
    public class Dynamic
    {
        FlightLogger fl = new FlightLogger();
        AircraftInfo Aircraft;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Aircraft">Basic aircraft</param>
        public Dynamic(AircraftInfo Aircraft)
        {
            this.Aircraft = Aircraft;
        }
        /// <summary>
        /// Update dynamic state with known forces and moments
        /// </summary>
        /// <param name="Forces">Resultant forces</param>
        /// <param name="Moments"></param>
        /// <param name="dt"></param>
        public void Update(Vector Forces, Vector Moments, double dt)
        {
            Vector AngleVelDerivate = Moments * Matrix3.GetReversed(Aircraft.InertionTensor);
            Aircraft.DynState.AngularRate += AngleVelDerivate * dt;
            AngleSpeedIntegrate(ref Aircraft.DynState.Position.OrientationMatrix, Aircraft.DynState.AngularRate, dt);
            //Aircraft.DynState.Position.Orientation.Normolize();
            Aircraft.PositionGlobal.Orientation = Aircraft.DynState.Position.Orientation;
            Vector shift = Aircraft.DynState.Vel * dt;
            Aircraft.DynState.Position.Location += shift;
            Aircraft.PositionGlobal.Move(shift);
            Aircraft.DynState.Accelerations = Forces * (1 / Aircraft.Mass);
            Aircraft.DynState.Vel += Aircraft.DynState.Accelerations * dt;
        }
        /// <summary>
        /// Compute forces and update dynamic state
        /// </summary>
        /// <param name="TractionConnected">Tracrion force value</param>
        /// <param name="Moments">Force moments</param>
        /// <param name="dt"></param>
        /// <returns>Resultant force vector</returns>
        public void TranslateAndUpdate(double TractionConnected, Vector Moments, double dt)
        {
            Vector GravityLocal = new Vector(0, 0, -MathLib.Constants.Gravity * Aircraft.Mass);
            double WindageVal = Aircraft.Cx * MathLib.Constants.AreaDensity * Math.Pow(Aircraft.DynState.Vel.Length, 2) / 2 * Aircraft.SurfaceSquare;
            Vector WindageLocal = Aircraft.DynState.Vel * (1 / Aircraft.DynState.Vel.Length) * -WindageVal;
            double LiftForce = Aircraft.Cy * Constants.AreaDensity * (Math.Pow(Aircraft.DynState.Vel.X, 2) + Math.Pow(Aircraft.DynState.Vel.Y, 2)) / 2 * Aircraft.SurfaceSquare;
            Vector LiftLocal = new Vector(0, 0, LiftForce) * Matrix3.CreateRotationYawPitchRoll(0, -Aircraft.DynState.Position.Orientation.Pitch, -Aircraft.DynState.Position.Orientation.Roll);
            Vector TractionLocal = new Vector(0, TractionConnected, 0) * Matrix3.CreateRotationYawPitchRoll(Aircraft.DynState.Position.Orientation * (-1));
            Vector ForceSum = GravityLocal + WindageLocal + LiftLocal + TractionLocal;
            this.Update(ForceSum, Moments, dt);
            fl.WriteLog(Aircraft.PositionGlobal, Aircraft.DynState, ForceSum, TractionLocal.Length, WindageVal, LiftForce);
        }

        public void TranslateAndUpdate(MathLib.Torgues torgues, double dt)
        {
            TranslateAndUpdate(torgues.TractiveForce, new Vector(torgues.RollTorgue, torgues.PitchTorgue, torgues.YawTorgue), dt);
        }

        /// <summary>
        /// Puasson method
        /// </summary>
        /// <param name="Orientation"></param>
        /// <param name="AngularRate"></param>
        /// <param name="dt"></param>
        static void AngleSpeedIntegrate(ref Matrix3 Orientation, Vector AngularRate, double dt)
        {
            //Don't tuch anything in this code!!
            double w = AngularRate.Length;
            if (w < 1e-20) return;
            Matrix3 WC = new Matrix3();
            WC[0, 1] = AngularRate[2]; //Yaw = w3
            WC[0, 2] = -AngularRate[1]; //Pitch = w1
            WC[1, 0] = -AngularRate[2]; //Roll = w2
            WC[1, 2] = AngularRate[0];
            WC[2, 0] = AngularRate[1];
            WC[2, 1] = -AngularRate[0];
            Orientation = Orientation + WC * Orientation * (Math.Sin(w * dt) / w) + WC * WC * Orientation * ((1 - Math.Cos(w * dt)) / (w * w));
        }
    }
}
