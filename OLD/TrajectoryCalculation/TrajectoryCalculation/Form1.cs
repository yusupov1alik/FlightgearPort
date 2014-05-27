using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PID;

namespace TrajectoryCalculation
{
    public partial class Form1 : Form
    {
        Navigation.CirclePart[] T = new Navigation.CirclePart[4];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double X = Convert.ToDouble(textBox1.Text);
            double Y = Convert.ToDouble(textBox2.Text);
            double Z = Convert.ToDouble(textBox12.Text);
            double VX = Convert.ToDouble(textBox3.Text);
            double VY = Convert.ToDouble(textBox4.Text);
            double VZ = Convert.ToDouble(textBox11.Text);

            double X3 = Convert.ToDouble(textBox5.Text);
            double Y3 = Convert.ToDouble(textBox6.Text);
            double VX3 = Convert.ToDouble(textBox7.Text);
            double VY3 = Convert.ToDouble(textBox8.Text);
            double Z3 = Convert.ToDouble(textBox13.Text);
            double Vmax = Convert.ToDouble(textBox10.Text);

            double XC = Convert.ToDouble(textBox14.Text);
            double YC = Convert.ToDouble(textBox15.Text);
            double ZC = Convert.ToDouble(textBox16.Text);
            double VXC = Convert.ToDouble(textBox17.Text);
            double VYC = Convert.ToDouble(textBox18.Text);
            double VZC = Convert.ToDouble(textBox19.Text);

            MathLib.Vector Coor = new MathLib.Vector(XC, YC, ZC);
            MathLib.Vector Speed = new MathLib.Vector(VXC, VYC, VZC);

            double MaxAng = Convert.ToDouble(textBox9.Text);
                T[0] = new Navigation.CirclePart(X, Y, MaxAng, VX, VY, '+');
                T[1] = new Navigation.CirclePart(X, Y, MaxAng, VX, VY, '-');
                T[2] = new Navigation.CirclePart(X3, Y3, MaxAng, VX3, VY3, '+');
                T[3] = new Navigation.CirclePart(X3, Y3, MaxAng, VX3, VY3, '-');
                Navigation.Trajectory Tr = Navigation.TimeCalculating.MinTime(T);
                Navigation.TrajectoryEnsemble Te = new Navigation.TrajectoryEnsemble(X, Y,Z, VX, VY,VZ, X3, Y3,Z3, VX3, VY3, MaxAng, Vmax);
                Navigation.FlightData Tmin = new Navigation.FlightData();
                Tmin.Location.Location = PID.FindVector.FindPoint(Te, Coor, Speed);
                //MathLib.Vector Tmin = FindVector.FindPoint(Te, Coor, Speed);
                ZedGraph1 F = new ZedGraph1(Te,Coor,Speed,Tmin);
                F.Show();
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
