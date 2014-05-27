using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MathLib;
namespace Dynamic
{
    class FlightLogger
    {
        StreamWriter sw;
        public FlightLogger(string path = "logs.log")
        {
            sw = new StreamWriter(path, false);
            sw.WriteLine("Lonitude           Latitude           Altitude           Yaw                Pitch              Roll               X                  Y                  Z                  Vx                Vy                 Vz                 Wx                 Wy                 Wz                 Fx                 Fy                 Fz                 Trac               Wind                Lift");
        }
        public void WriteLog(
            MathLib.GlobalCoordPoint gc, 
            DynamicState dynState, 
            MathLib.Vector Forces, 
            double Traction, 
            double Windage, 
            double Lift)
        {
            string log = gc.Longitude.ToString("E8") + "___" + gc.Latitude.ToString("E8") + "___" + gc.Altitude.ToString("E8") + "___" +
            gc.Orientation.Yaw.ToString("E8") + "___" + gc.Orientation.Pitch.ToString("E8") + "___" + gc.Orientation.Roll.ToString("E8") + "___" +
            dynState.Position.X.ToString("E8") + "___" + dynState.Position.Y.ToString("E8") + "___" + dynState.Position.Z.ToString("E8") + "___" +
            dynState.Vel.X.ToString("E8") + "___" + dynState.Vel.Y.ToString("E8") + "___" + dynState.Vel.Z.ToString("E8") + "___" +
            dynState.AngularRate.X.ToString("E8") + "___" + dynState.AngularRate.Y.ToString("E8") + "___" + dynState.AngularRate.Z.ToString("E8") + "___" +
            Forces.X.ToString("E8") + "___" + Forces.Y.ToString("E8") + "___" + Forces.Z.ToString("E8") + "___" +
            Traction.ToString("E8") + "___" + Windage.ToString("E8") + "___" + Lift.ToString("E8");
            string res = "";
            for (int i = 0; i < log.Length; i++)
            {
                if (i == 0 && log[i] != '-') res += '+';
                
                if (log[i] == '_')
                {
                    res += ' ';
                    if (i < log.Length - 1 && Char.IsDigit(log[i + 1])) res += '+';
                }
                else if (log[i] != ' ' && log[i] != ' ') res += log[i];
            }
            sw.WriteLine(res);
        }
    }
}
