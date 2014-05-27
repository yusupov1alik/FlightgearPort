using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLib
{
    /// <summary>
    /// 3D linear vector
    /// </summary>
    public struct Vector 
    {
        public double X, Y, Z; //X - to the East, Y - to the North, Z - Up
        public Vector(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Vector length
        /// </summary>
        public double Length
        {
            get
            {
                return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
            }
        }

        /// <summary>
        /// Get (0,0,0) vector
        /// </summary>
        public static Vector GetZero()
        {
            return new Vector();
        }

        public static Vector operator +(Vector x, Vector y)
        {
            return new Vector(x.X + y.X, x.Y + y.Y, x.Z + y.Z);
        }
        public static Vector operator -(Vector x)
        {
            return new Vector(-x.X, -x.Y, -x.Z);
        }
        /// <summary>
        /// Multiplication of Vector and Matrix
        /// </summary>
        /// <param name="x">Original vector</param>
        /// <param name="transform">Transformation Matrix4</param>
        /// <returns>Transformed vector</returns>
        public static Vector operator *(Vector x, Matrix3 transform)
        {
            Vector res = new Vector();
            for (int i = 0; i < 3; i++)
            {
                res[i] = 0;
                for (int j = 0; j < 3; j++)
                {

                    res[i] += x[j] * transform[i, j];
                }
            }
            return res;
        }
        public static Vector operator *(Vector x, double y)
        {
            return new Vector(x.X * y, x.Y * y, x.Z * y);
        }

        /// <summary>
        /// For 0, 1 and 2 returns vector component, else 1
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double this[int index]
        {
            get
            {
                switch(index)
                {
                    case 0: return X;
                    case 1: return Y;
                    case 2: return Z;
                    default: return 1;
                }
            }
            set
            {
                switch(index)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    case 2: Z = value; break;
                    default: return;
                }
            }
        }

        public override string ToString()
        {
            return X.ToString() + ',' + Y.ToString() + ',' + Z.ToString();
        }
    }
}
