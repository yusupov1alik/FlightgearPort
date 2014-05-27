using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CarrierControl;
using FlightgearPort;
using MathLib;
using Dynamic;
using Navigation;
using PID;
namespace ConnectionTest
{
    public partial class Form1 : Form
    {
        System.Diagnostics.Process FlightgearProc;
        bool IsPaused = false;

        //Carrier Trajectory generator
        Carrier Carrier;
        AircraftInfo Aircraft;

        //Port clients (flightgear connection)
        PortClient<GlobalCoordPoint> PCAircraft;
        PortClient<GlobalCoordPoint> PCCarrier;

        //NavigationSystem
        Navigation.TrajectoryEnsemble Trajectory;
        PID.Signals sg = new Signals();
        double time = 0;
        public Form1()
        {
            InitializeComponent();
            InitAndConfigCarrier();
            InitAndConfigAircraft();
            PCAircraft = new PortClient<GlobalCoordPoint>();
            PCCarrier = new PortClient<GlobalCoordPoint>();
        }

        void InitAndConfigCarrier()
        {
            Carrier = new Carrier(
                new GlobalCoordPoint(-122.315, 37.65, 0, 0, 0, 0), 
                new Point(0, 0, 1000, 0, 0, 0),
                new Point(0, 0, 1000, 0, 0, 0));
            Carrier.aV = 50;
            Carrier.ZAv = -10;
            Carrier.ZDeviation = 30;
            Carrier.DefaultYaw = Math.PI;
            Carrier.MaxYawDev = Math.PI / 4;
        }

        void InitAndConfigAircraft()
        {
            GlobalCoordPoint startPoint = new GlobalCoordPoint(-122, 37.3, 2000 * Constants.MeterToFoot, 0, 0, 0);
            
            Aircraft = new AircraftInfo(
             10000,
             Matrix3.GetSingle() * 2,
             new DynamicState(new Point(0, 0, 0, 0, 0, 0), new Vector(0, 400, 0), new Vector(0.0, 0.0, 0.0)),
             startPoint,
             1, 26, 40,
             new Torgues(11000, 0.1, 0.1, 0.1));
 
            Trajectory = new TrajectoryEnsemble(
                Aircraft.DynState,
                new Vector(10000, 50000, 1000),
                new Vector(400, 0, 40), 
                new Vector(5000, 3000, 5000),
                Math.PI / 4,
                1000,
                0,
                1000);
            
        }

        private void CreateConnectionEventHandler(object sender, EventArgs e)
        {
            PCAircraft.CreateConnection(49000);
            PCCarrier.CreateConnection(49001);
            Cloack.Enabled = true;
            /*Debug d = new Debug(Trajectory);
            d.Write();
            TBAlt.Text = "All";*/
        }

        private void CloackEventHandler(object sender, EventArgs e)
        {
            if (!IsPaused)
            {
                time += 0.1; //time increament
                Torgues tg = sg.GetSignal(Aircraft.DynState.Coord, Aircraft.DynState.Velocity, Aircraft.DynState.Accelerations, Aircraft.DynState.Orientation, Trajectory, Aircraft.MaxTorgues, Carrier.PositionLocal.Orientation);
                Aircraft.Dynamics.TranslateAndUpdate(tg, 0.1);
                //Aircraft.Dynamics.TranslateAndUpdate(0, new Vector(0.0, 0.0, 0.0), 0.1);
            }
            PCCarrier.Send(Carrier.PositionGlobal); //send carrier position to flightgear
            PCAircraft.Send(Aircraft.PositionGlobal); //send aircraft position to flightgear
            UpdatePictureBoxes(Aircraft.DynState.Accelerations * Aircraft.Mass); //show flight details
        }

        private void UpdatePictureBoxes(Vector Forces)
        {
            string[] text = Aircraft.PositionGlobal.ToString().Split(',');
            TBLong.Text = text[0];
            TBLat.Text = text[1];
            TBAlt.Text = text[2];
            TBYaw.Text = text[3];
            TBPitch.Text = text[4];
            TBRoll.Text = text[5];
            TBVx.Text = Aircraft.DynState.Vel.X.ToString();
            TBVy.Text = Aircraft.DynState.Vel.Y.ToString();
            TBVz.Text = Aircraft.DynState.Vel.Z.ToString();
            TBX.Text = Aircraft.DynState.Position.X.ToString();
            TBY.Text = Aircraft.DynState.Position.Y.ToString();
            TBZ.Text = Aircraft.DynState.Position.Z.ToString();
            TBFx.Text = Forces.X.ToString();
            TBFy.Text = Forces.Y.ToString();
            TBFz.Text = Forces.Z.ToString();
        }

        private void BreakConnectionEventHandler(object sender, EventArgs e)
        {
            time = 0;
            PCAircraft.BreakConnection();
            PCCarrier.BreakConnection();
            Cloack.Stop();
        }

        private void RunFlightGear(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("RunFlightGearProtocolCarrier.bat"))
            {
                MessageBox.Show("Select FlightGear folder", "FlighGear not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FlightgearProc = new System.Diagnostics.Process();
            FlightgearProc.StartInfo.FileName = "RunFlightGearProtocolCarrier.bat";
            FlightgearProc.Start();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            IsPaused = !IsPaused;
        }

        private void ChooseNewFolder(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose FlightGear root folder";
            fbd.ShowDialog();

            string path = fbd.SelectedPath;
            System.IO.File.Delete("RunFlightGearProtocolCarrier.bat");
            System.IO.StreamWriter sw = System.IO.File.CreateText("RunFlightGearProtocolCarrier.bat");
            sw.WriteLine("\"" + path + @"\bin\Win32\fgfs" + "\" ^");
            sw.WriteLine("--fg-root=\"" + path + @"\data" + "\" ^");
            sw.WriteLine("--aircraft=\"f-14b\" ^");
            sw.WriteLine("--carrier=Nimitz ^");
            sw.WriteLine("--generic=socket,in,10,127.0.0.1,49000,udp,inputprotocol --fdm=external ^");
            sw.WriteLine("--generic=socket,in,10,127.0.0.1,49001,udp,inputprotocolcarrier --fdm=external");
            sw.Close();

            System.IO.StreamWriter sw1 = System.IO.File.CreateText(path + @"\data\Protocol\inputprotocol.xml");
            sw1.Write(Properties.Resources.inputprotocol);
            sw1.Close();

            System.IO.StreamWriter sw2 = System.IO.File.CreateText(path + @"\data\Protocol\inputprotocolcarrier.xml");
            sw2.Write(Properties.Resources.inputprotocolcarrier);
            sw2.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}