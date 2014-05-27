using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PID
{
    public class Torgues
    {
        double TractiveForce;
        double RollTorgue;
        double YawTorgue;
        double PitchTorgue;
        public Torgues(double TractiveForce, double RollTorgue, double YawTorgue, double PitchTorgue)
        {
            this.TractiveForce = TractiveForce;
            this.RollTorgue = RollTorgue;
            this.YawTorgue = YawTorgue;
            this.PitchTorgue = PitchTorgue;
        }
    }
}
