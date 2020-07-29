using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Task2ClassVektor
{
    /// <summary>
    /// Class Vector1
    /// </summary>
    public class Vector1
    {
        /// <summary>
        /// Property Nmemb
        /// </summary>
        public int Nmemb { get; set; }
        /// <summary>
        /// Property Vect
        /// </summary>
        public double[] Vect { get; set; }
        /// <summary>
        /// Constructor Vector1(int nmemb)
        /// </summary>
        /// <param name="nmemb"></param>
        public Vector1(int nmemb)
        {
            Nmemb = nmemb;
            Vect = new double[nmemb];
            for (int i = 0; i < nmemb; i++)
            {
                Vect[i] = 0.0;
            }
        }
        /// <summary>
        /// Constructor Vector1(double[] vect)
        /// </summary>
        /// <param name="vect"></param>
        public Vector1(double[] vect)
        {
            Nmemb = vect.Length;
            Vect = vect;
        }
        /// <summary>
        /// Indexer this[int i]
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public double this[int i]
        {
            get
            {
                if (i < 0 || i > Nmemb)
                {
                    throw new Exception("Index is out of range!");
                }
                return Vect[i];
            }
            set { Vect[i] = value; }
        }
        /// <summary>
        /// Property GetVectorSize
        /// </summary>
        public int GetVectorSize
        {
            get { return Nmemb; }
        }

        /// <summary>
        /// Method SwapVectorEntries(int m, int n)
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public Vector1 SwapVectorEntries(int m, int n)
        {
            double temp = Vect[m];
            Vect[m] = Vect[n];
            Vect[n] = temp;
            return new Vector1(Vect);
        }
        /// <summary>
        /// Method ToString()
        /// </summary>
        /// <returns>Returns a string representation</returns>
        public override string ToString()
        {
            string str = "(";
            for (int i = 0; i < Nmemb - 1; i++)
            {
                str += Vect[i].ToString() + ", ";
            }
            str += Vect[Nmemb - 1].ToString() + ")";
            return str;
        }
        /// <summary>
        /// Method Length(Vector1 v1)
        /// </summary>
        /// <param name="v1"></param>
        /// <returns>Vector length</returns>
        public Vector1 Length(Vector1 v1)
        {          
            Vector1 result = new Vector1(v1.Nmemb);

            for (int i = 0; i < Nmemb-1; i++)
            {
                result[i]= Math.Sqrt(Vect[i] * Vect[i]);
            }
            return  result;
        }
        /// <summary>
        /// Method Equals(object obj)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Compares vectors</returns>
        public override bool Equals(object obj)
        {
            return (obj is Vector) && this.Equals((Vector1)obj);
        }
        /// <summary>
        /// Method Equals(Vector1 v)
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Compares vectors</returns>
        public bool Equals(Vector1 v)
        {
            return Vect == v.Vect;
        }
        /// <summary>
        /// Method GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Vect.GetHashCode();
        }
        /// <summary>
        /// Method  operator==(Vector1 v1, Vector1 v2)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Compares for equality</returns>
        public static bool operator ==(Vector1 v1, Vector1 v2)
        {
            return v1.Equals(v2);
        }
        /// <summary>
        /// Method operator!=(Vector1 v1, Vector1 v2)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Compares for inequality</returns>
        public static bool operator !=(Vector1 v1, Vector1 v2)
        {
            return !v1.Equals(v2);
        }

        /// <summary>
        /// Method operator+(Vector1 v)
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Addition operation</returns>
        public static Vector1 operator +(Vector1 v)
        {
            return v;
        }
        /// <summary>
        /// Method operator+(Vector1 v1, Vector1 v2)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Operation of adding two vectors</returns>
        public static Vector1 operator +(Vector1 v1, Vector1 v2)
        {
            Vector1 result = new Vector1(v1.Nmemb);
            for (int i = 0; i < v1.Nmemb; i++)
            {
                result[i] = v1[i] + v2[i];
            }
            return result;
        }

        /// <summary>
        /// Method operator -(Vector1 v)
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Negative vector (unary operation !!!)</returns>
        public static Vector1 operator -(Vector1 v)
        {
            double[] result = new double[v.Nmemb];
            for (int i = 0; i < v.Nmemb; i++)
            {
                result[i] = -v[i];
            }
            return new Vector1(result);
        }

        /// <summary>
        /// Method operator -(Vector1 v1, Vector1 v2)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Vector difference</returns>
        public static Vector1 operator -(Vector1 v1, Vector1 v2)
        {
            Vector1 result = new Vector1(v1.Nmemb);
            for (int i = 0; i < v1.Nmemb; i++)
            {
                result[i] = v1[i] - v2[i];
            }
            return result;
        }

        /// <summary>
        /// Method operator *(Vector1 v, double d)
        /// </summary>
        /// <param name="v"></param>
        /// <param name="d"></param>
        /// <returns>Vector-scalar multiplication</returns>
        public static Vector1 operator *(Vector1 v, double d)
        {
            Vector1 result = new Vector1(v.Nmemb);
            for (int i = 0; i < v.Nmemb; i++)
            {
                result[i] = v[i] * d;
            }
            return result;
        }
        /// <summary>
        /// Method operator *(double d, Vector1 v)
        /// </summary>
        /// <param name="d"></param>
        /// <param name="v"></param>
        /// <returns>Vector-scalar multiplication</returns>
        public static Vector1 operator *(double d, Vector1 v)
        {
            Vector1 result = new Vector1(v.Nmemb);
            for (int i = 0; i < v.Nmemb; i++)
            {
                result[i] = d * v[i];
            }
            return result;
        }

        /// <summary>
        /// Method operator /(Vector1 v, double d)
        /// </summary>
        /// <param name="v"></param>
        /// <param name="d"></param>
        /// <returns>Dividing a vector by a scalar</returns>
        public static Vector1 operator /(Vector1 v, double d)
        {
            Vector1 result = new Vector1(v.Nmemb);
            for (int i = 0; i < v.Nmemb; i++)
            {               
                result[i] = v[i] / d;                
            }
            return result;
        }

        /// <summary>
        /// Method DotProduct(Vector1 v1, Vector1 v2)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Dot product of vectors</returns>
        public static double DotProduct(Vector1 v1, Vector1 v2)
        {
            double result = 0.0;
            for (int i = 0; i < v1.Nmemb; i++)
            {
                result += v1[i] * v2[i];
            }
            return result;
        }
        /// <summary>
        /// Method Angle(Vector1 v1, Vector1 v2)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Angle between v1 and v2</returns>
        public static double Angle(Vector1 v1, Vector1 v2)
        {
            double result = 0.0, norm1 = 0.0, norm2 = 0.0;
            for (int i = 0; i < v1.Nmemb; i++)
            {
                result += v1[i] * v2[i];
                norm1 += v1[i] * v1[i];
                norm2 += v2[i] * v2[i];
            }
            result = result / Math.Sqrt(norm1) / Math.Sqrt(norm2);
            return Math.Acos(result);
        }
        /// <summary>
        /// Method GetNorm()
        /// </summary>
        /// <returns>Getting rate</returns>
        public double GetNorm()
        {
            double result = 0.0;
            for (int i = 0; i < Nmemb; i++)
            {
                result += Vect[i] * Vect[i];
            }
            return Math.Sqrt(result);
        }
        /// <summary>
        /// Method GetNormSquare()
        /// </summary>
        /// <returns>Obtaining area norm</returns>
        public double GetNormSquare()
        {
            double result = 0.0;
            for (int i = 0; i < Nmemb; i++)
            {
                result += Vect[i] * Vect[i];
            }
            return result;
        }
        /// <summary>
        /// Method Normalize()
        /// </summary>
        public void Normalize()
        {
            double norm = GetNorm();
            if (norm == 0)
            {
                throw new Exception("Normalize a vector with a norm of zero");
            }
            for (int i = 0; i < Nmemb; i++)
            {
                Vect[i] /= norm;
            }
        }
        /// <summary>
        /// Method GetUnitVector()
        /// </summary>
        /// <returns>Get the unit of a vector</returns>
        public Vector1 GetUnitVector()
        {
            Vector1 result = new Vector1(Vect);
            result.Normalize();
            return result;
        }
        /// <summary>
        /// Method CrossProduct(Vector1 v1, Vector1 v2)
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Cross product</returns>
        public static Vector1 CrossProduct(Vector1 v1, Vector1 v2)
        {
            if (v1.Nmemb != 3)
            {
                throw new Exception("Vector v1 must be 3 dimensional!");
            }
            if (v2.Nmemb != 3)
            {
                throw new Exception("Vector v2 must be 3 dimensional!");
            }
            Vector1 result = new Vector1(v1.Nmemb);
            result[0] = v1[1] * v2[2] - v1[2] * v2[1];
            result[1] = v1[2] * v2[0] - v1[0] * v2[2];
            result[2] = v1[0] * v2[1] - v1[1] * v2[0];
            return result;
        }
    }
}
