using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLib
{
    public class Torgues
    {
        public double TractiveForce;
        public double RollTorgue;
        public double YawTorgue;
        public double PitchTorgue;
        public Torgues(double TractiveForce, double RollTorgue, double YawTorgue, double PitchTorgue)
        {
            this.TractiveForce = TractiveForce;
            this.RollTorgue = RollTorgue;
            this.YawTorgue = YawTorgue;
            this.PitchTorgue = PitchTorgue;
        }
    }
}
