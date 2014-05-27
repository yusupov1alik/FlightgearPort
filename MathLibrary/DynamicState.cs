using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MathLib
{
    public struct DynamicState
    {
        public Point Position;
        public Vector Vel;
        public Vector AngularRate;
        public Vector Accelerations;
        public Vector Moments;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="Velocity"></param>
        /// <param name="AngularRate">Start angular rates in format Roll, Pitch, Yaw</param>
        /// <param name="Accelerations"></param>
        /// <param name="Moments"></param>
        public DynamicState(Point Position, Vector Velocity, Vector AngularRate, Vector Accelerations, Vector Moments)
        {
            this.Position = Position;
            this.Vel = Velocity;
            this.AngularRate = AngularRate;
            this.Accelerations = Accelerations;
            this.Moments = Moments;
        }

        public DynamicState(Point Position, Vector Velocity, Vector AngularRate)
            :this(Position, Velocity, AngularRate, Vector.GetZero(), Vector.GetZero())
        {

        }

        public double VX
        {
            get
            {
                return this.Vel.X;
            }
            set
            {
                this.Vel.X = value;
            }
        }
        public double VY
        {
            get
            {
                return this.Vel.Y;
            }
            set
            {
                this.Vel.Y = value;
            }
        }
        public double VZ
        {
            get
            {
                return this.Vel.Z;
            }
            set
            {
                this.Vel.Z = value;
            }
        }
        public double RYaw
        {
            get
            {
                return this.AngularRate.Z;
            }
            set
            {
                this.AngularRate.Z = value;
            }
        }
        public double RRoll
        {
            get
            {
                return this.AngularRate.X;
            }
            set
            {
                this.AngularRate.X = value;
            }
        }
        public double RPitch
        {
            get
            {
                return this.AngularRate.Y;
            }
            set
            {
                this.AngularRate.Y = value;
            }
        }
        public double X
        {
            get
            {
                return this.Position.X;
            }
            set
            {
                this.Position.X = value;
            }
        }
        public double Y
        {
            get
            {
                return this.Position.Y;
            }
            set
            {
                this.Position.Y = value;
            }
        }
        public double Z
        {
            get
            {
                return this.Position.Z;
            }
            set
            {
                this.Position.Z = value;
            }
        }
        public double Yaw
        {
            get
            {
                return this.Position.Yaw;
            }
            set
            {
                this.Position.Yaw = value;
            }
        }
        public double Pitch
        {
            get
            {
                return this.Position.Pitch;
            }
            set
            {
                this.Position.Pitch = value;
            }
        }
        public double Roll
        {
            get
            {
                return this.Position.Roll;
            }
            set
            {
                this.Position.Roll = value;
            }
        }
        public OrientationObject Orientation
        {
            get
            {
                return this.Position.Orientation;
            }
            set
            {
                this.Position.Orientation = value;
            }
        }
        public Vector Coord
        {
            get
            {
                return this.Position.Location;
            }
            set
            {
                this.Position.Location = value;
            }
        }
        public Vector Velocity
        {
            get
            {
                return this.Vel;
            }
            set
            {
                this.Vel = value;
            }
        }
    }
}
