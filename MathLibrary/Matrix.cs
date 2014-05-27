using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathLib
{
    /// <summary>
    /// Represents 3x3 matrix. Includes methods for rotation matrixes
    /// </summary>
    public class Matrix3 : ICloneable
    {
        const int Width = 3, Height = 3;
        double[,] Data;
        public Matrix3()
        {
            this.Data = new double[Width,Height];
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="original"></param>
        public Matrix3(Matrix3 original)
            :this()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    this[i, j] = original[i, j];
                }
            }
        }

        /// <summary>
        /// Get zero matrix
        /// </summary>
        /// <returns></returns>
        public static Matrix3 GetZero()
        {
            Matrix3 res = new Matrix3();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    res[i, j] = 0;
                }
            }
            return res;
        }

        /// <summary>
        /// Get single matrix
        /// </summary>
        /// <returns></returns>
        public static Matrix3 GetSingle()
        {
            Matrix3 res = Matrix3.GetZero();
            for (int i = 0; i < Width; i++)
            {
                res[i, i] = 1;
            }
            return res;
        }

        /// <summary>
        /// Creates a copy of matrix
        /// </summary>
        /// <param name="original">Original matrix</param>
        /// <param name="result">Copy destinatio</param>
        static void CopyTo(Matrix3 original, out Matrix3 result)
        {
            result = new Matrix3();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    result[i, j] = original[i, j];
                }
            }
        }

        public static Matrix3 operator +(Matrix3 x, Matrix3 y)
        {
            Matrix3 res = new Matrix3();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    res[i, j] = x[i, j] + y[i, j];
                }
            }
            return res;
        }
        public static Matrix3 operator -(Matrix3 x, Matrix3 y)
        {
            return x + (-y);
        }
        public static Matrix3 operator *(Matrix3 x, Matrix3 y)
        {
            Matrix3 res = new Matrix3();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    res[i, j] = 0;
                    for (int l = 0; l < Height; l++)
                    {
                        res[i, j] += x.Data[i, l] * y.Data[l, j];
                    }
                }
            }
            return res;
        }
        public static Matrix3 operator -(Matrix3 x)
        {
            Matrix3 res = new Matrix3();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    res[i, j] = -x[i, j];
                }
            }
            return res;
        }
        public static Matrix3 operator *(Matrix3 x, double y)
        {
            Matrix3 res = new Matrix3();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    res[i, j] = x[i, j] * y;
                }
            }
            return res;
        }
        public double this[int i, int j]
        {
            get
            {
                return Data[i, j];
            }
            set
            {
                Data[i, j] = value;
            }
        }

        /// <summary>
        /// Get copy of current matrix
        /// </summary>
        /// <returns>Copy by value</returns>
        public Matrix3 GetCopy()
        {
            Matrix3 res;
            Matrix3.CopyTo(this, out res);
            return res;
        }

        /// <summary>
        /// Reverse matrix
        /// </summary>
        /// <param name="m"></param>
        /// <returns>Reversed matrix</returns>
        public static Matrix3 GetReversed(Matrix3 m)
        {
            Matrix3 res = new Matrix3();
            double det;

            det = 
                m[0, 0] * (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1]) - 
                m[0, 1] * (m[1, 2] * m[2, 0] - m[1, 0] * m[2, 2]) + 
                m[0, 2] * (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]);

            if (Math.Abs(det) < 1e-20)
            {
                throw new FormatException();
            }

            res[0, 0] = (m[1, 1] * m[2, 2] - m[1, 2] * m[2, 1]) / det;
            res[0, 1] = -1 * (m[0, 1] * m[2, 2] - m[0, 2] * m[2, 1]) / det; 
            res[0, 2] = (m[0, 1] * m[1, 2] - m[0, 2] * m[1, 1]) / det;
            res[1, 0] = -1 * (m[1, 0] * m[2, 2] - m[1, 2] * m[2, 0]) / det; 
            res[1, 1] = (m[0, 0] * m[2, 2] - m[0, 2] * m[2, 0]) / det; 
            res[1, 2] = -1 * (m[0, 0] * m[1, 2] - m[0, 2] * m[1, 0]) / det;
            res[2, 0] = (m[1, 0] * m[2, 1] - m[1, 1] * m[2, 0]) / det; 
            res[2, 1] = -1 * (m[0, 0] * m[2, 1] - m[0, 1] * m[2, 0]) / det; 
            res[2, 2] = (m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0]) / det;
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Roll">Angle IN RADIANS</param>
        /// <returns></returns>
        public static Matrix3 CreateRotationRoll(double Roll)
        {
            Matrix3 res = Matrix3.GetZero();
            res[0, 0] = 1;
            res[1, 1] = Math.Cos(Roll);
            res[1, 2] = -Math.Sin(Roll);
            res[2, 1] = Math.Sin(Roll);
            res[2, 2] = Math.Cos(Roll);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pitch">Angle IN RADIANS</param>
        /// <returns></returns>
        public static Matrix3 CreateRotationPitch(double Pitch)
        {
            Matrix3 res = Matrix3.GetZero();
            res[1, 1] = 1;
            res[2, 2] = Math.Cos(Pitch);
            res[2, 0] = -Math.Sin(Pitch);
            res[0, 2] = Math.Sin(Pitch);
            res[0, 0] = Math.Cos(Pitch);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Yaw">Angle IN RADIANS</param>
        /// <returns></returns>
        public static Matrix3 CreateRotationYaw(double Yaw)
        {
            Matrix3 res = Matrix3.GetZero();
            res[1, 1] = Math.Cos(Yaw);
            res[0, 1] = -Math.Sin(Yaw);
            res[1, 0] = Math.Sin(Yaw);
            res[0, 0] = Math.Cos(Yaw);
            res[2, 2] = 1;
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Yaw">Yaw angle IN RADIANS</param>
        /// <param name="Pitch">Pitch angle IN RADIANS</param>
        /// <param name="Roll">Roll angle IN RADIANS</param>
        /// <returns></returns>
        public static Matrix3 CreateRotationYawPitchRoll(double Yaw, double Pitch, double Roll)
        {
            return CreateRotationYaw(Yaw) * CreateRotationPitch(Pitch) * CreateRotationRoll(Roll);
        }

        /// <summary>
        /// Compute angles of current rotation matrix
        /// </summary>
        /// <returns>Orientation object with angles of this rotation matrix</returns>
        public OrientationObject GetAngles()
        {
            var res = new OrientationObject();
            res.Yaw = Math.Atan2(-this[1, 0], this[1, 1]);
            res.Pitch = -Math.Atan2(this[0, 2], this[2, 2]);
            res.Roll = Math.Atan2(this[1, 2], Math.Sqrt(Math.Pow(this[1, 0], 2) + Math.Pow(this[1, 1], 2)));
            //if (res.Roll < 0) throw new NotImplementedException();
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orientation">Angles in orientation object</param>
        /// <returns></returns>
        public static Matrix3 CreateRotationYawPitchRoll(OrientationObject orientation)
        {
            return CreateRotationYawPitchRoll(orientation.Yaw, orientation.Pitch, orientation.Roll);
        }

        /// <summary>
        /// Creates a copy of matrix
        /// </summary>
        /// <returns></returns>
        object ICloneable.Clone()
        {
            Matrix3 res;
            Matrix3.CopyTo(this, out res);
            return res;
        }
    }
}
