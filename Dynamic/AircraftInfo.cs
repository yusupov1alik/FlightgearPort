using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathLib;
namespace Dynamic
{
    public class AircraftInfo
    {
        public Dynamic Dynamics;
        public double  Mass;
        public MathLib.Matrix3 InertionTensor;
        public DynamicState DynState;
        public GlobalCoordPoint PositionGlobal;
        public Torgues MaxTorgues;
        /// <summary>
        /// Windage ratio
        /// </summary>
        public double Cx;
        /// <summary>
        /// Lift force ratio
        /// </summary>
        public double Cy;
        public double SurfaceSquare;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="Mass">Flight mass</param>
        /// <param name="InertionTensor"></param>
        /// <param name="DynamicState">Dynamic state at start point</param>
        /// <param name="GlobalCoord">Start point global coord</param>
        /// <param name="Cx">Windage ratio</param>
        /// <param name="Cy">Lift force ratio</param>
        /// <param name="SurfaceSquare">Total surface square</param>
        public AircraftInfo(double Mass, Matrix3 InertionTensor, DynamicState DynamicState, GlobalCoordPoint GlobalCoord, double Cx, double Cy, double SurfaceSquare, Torgues MaxTorgues)
        {
            this.Mass = Mass;
            this.InertionTensor = InertionTensor;
            this.PositionGlobal = GlobalCoord;
            this.DynState = DynamicState;
            this.Cx = Cx;
            this.Cy = Cy;
            this.SurfaceSquare = SurfaceSquare;
            Dynamics = new Dynamic(this);
            this.MaxTorgues = MaxTorgues;
        }
    }
}
