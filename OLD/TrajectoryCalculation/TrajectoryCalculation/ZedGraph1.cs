using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using Navigation;

namespace TrajectoryCalculation
{
    public partial class ZedGraph1 : Form
    {
        public ZedGraph1(Navigation.TrajectoryEnsemble T, MathLib.Vector Coor, MathLib.Vector Speed, Navigation.FlightData Min)
        {
            InitializeComponent();
            DrawGraph(T,Coor,Speed,Min);
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void DrawGraph(Navigation.TrajectoryEnsemble T, MathLib.Vector Coor, MathLib.Vector Speed, Navigation.FlightData Min)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear() ;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            list2.Add(Coor.X, Coor.Y);
            list2.Add(Speed.X + Coor.X, Speed.Y + Coor.Y);
            list3.Add(Coor.X, Coor.Y);
            list3.Add(Min.X, Min.Y);
            for (double i = 0; i <= T.T1 + T.T2 + T.T3 + T.T4; i += 0.01)
            {
                list1.Add(T.GetCoord(i).X, T.GetCoord(i).Y);
            }
            LineItem mycurve1 = pane.AddCurve("StSpeed", list1, Color.Blue,SymbolType.None);
            LineItem mycurve2 = pane.AddCurve("StSpeed", list2, Color.DarkViolet, SymbolType.None);
            LineItem mycurve3 = pane.AddCurve("StSpeed", list3, Color.Orange, SymbolType.None);
            zedGraphControl1.Invalidate();
        }
    }
}
