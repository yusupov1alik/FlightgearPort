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
    public partial class Zedgraph2 : Form
    {
        public Zedgraph2(Navigation.TakeOff T)
        {
            InitializeComponent();
            DrawGraph(T);
        }
        private void DrawGraph(Navigation.TakeOff T)
        {
            GraphPane pane = zedGraphControl2.GraphPane;
            PointPairList points = new PointPairList();
            PointPairList points1 = new PointPairList();
            if (T.b == true)
            {
                if (T.t != 0)
                {
                    double y = T.B + T.C;
                    double v = T.omg * T.A;
                    for (double i = 0; i <= T.t; i += 0.01)
                    {
                        points.Add(i, y -= v * i);
                    }
                }
            }
            else
            {
                for (double i = 0; i <= 100; i += 0.01)
                {
                    points.Add(i, T.A * Math.Sin(T.omg * i) + T.B * Math.Cos(T.omg * i) + T.C);
                }
                points1.Add(0, T.h);
                points1.Add(5, T.h + T.v * 5);
            }
            LineItem mycurve1 = pane.AddCurve("Altitude", points, Color.Blue, SymbolType.None);
            LineItem mycurve2 = pane.AddCurve("Altitude", points1, Color.Orange, SymbolType.None);
            zedGraphControl2.Invalidate();
        }

        private void zedGraphControl2_Load(object sender, EventArgs e)
        {

        }
    }
}
