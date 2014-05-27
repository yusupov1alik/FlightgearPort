using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Navigation;
using MathLib;

namespace PID
{
    public class Debug
    {
        StreamWriter s = new StreamWriter("trajectory.logs", false);
        TrajectoryEnsemble tr;
        public void Close()
        {
            s.Close();
        }
        public Debug(TrajectoryEnsemble tr)
        {
            this.tr = tr;
        }
        public void Write()
        {
            for (double i = 0; i <= tr.T1 + tr.T2 + tr.T3 + tr.T4; i += 0.01)
            {
                DynamicState Data = tr.GetCoord(i);
                s.WriteLine(Data.X.ToString().Replace(",",".")+" "+Data.Y.ToString().Replace(",",".")+" "+Data.Z.ToString().Replace(",","."));
            }
        }
       
        
    }
}
