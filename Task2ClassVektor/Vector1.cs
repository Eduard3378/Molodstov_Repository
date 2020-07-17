using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Task2ClassVektor
{
    public class Vector1
    {        
        public int Nmemb { get; set; }
        public double[] Vect { get; set; }      

        public Vector1(int nmemb)
        {
            Nmemb = nmemb;
            Vect = new double[nmemb];
            for (int i = 0; i < nmemb; i++)
            {
                Vect[i] = 0.0;
            }
        }      

        public Vector1(double[] vect)
        {
            Nmemb = vect.Length;
            Vect = vect;
        }

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

        public int GetVectorSize
        {
            get { return Nmemb; }
        }

        public Vector1 SwapVectorEntries(int m, int n)
        {
            double temp = Vect[m];
            Vect[m] = Vect[n];
            Vect[n] = temp;
            return new Vector1(Vect);
        }

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

        public Vector1 Length(Vector1 v1)
        {          
            Vector1 result = new Vector1(v1.Nmemb);

            for (int i = 0; i < Nmemb-1; i++)
            {
                result[i]= Math.Sqrt(Vect[i] * Vect[i]);
            }
            return  result;
        }

        public override bool Equals(object obj)
        {
            return (obj is Vector) && this.Equals((Vector1)obj);
        }

        public bool Equals(Vector1 v)
        {
            return Vect == v.Vect;
        }

        public override int GetHashCode()
        {
            return Vect.GetHashCode();
        }
        // сравнение векторов
        public static bool operator ==(Vector1 v1, Vector1 v2)
        {
            return v1.Equals(v2);
        }

        public static bool operator !=(Vector1 v1, Vector1 v2)
        {
            return !v1.Equals(v2);
        }

        // положительный вектор
        public static Vector1 operator +(Vector1 v)
        {
            return v;
        }
        //сложение векторов
        public static Vector1 operator +(Vector1 v1, Vector1 v2)
        {
            Vector1 result = new Vector1(v1.Nmemb);
            for (int i = 0; i < v1.Nmemb; i++)
            {
                result[i] = v1[i] + v2[i];
            }
            return result;
        }

        // отрицательный вектор (унарная операция!!!)
        public static Vector1 operator -(Vector1 v)
        {
            double[] result = new double[v.Nmemb];
            for (int i = 0; i < v.Nmemb; i++)
            {
                result[i] = -v[i];
            }
            return new Vector1(result);
        }

        // разность векторов
        public static Vector1 operator -(Vector1 v1, Vector1 v2)
        {
            Vector1 result = new Vector1(v1.Nmemb);
            for (int i = 0; i < v1.Nmemb; i++)
            {
                result[i] = v1[i] - v2[i];
            }
            return result;
        }

        // умножение вектора на скаляр
        public static Vector1 operator *(Vector1 v, double d)
        {
            Vector1 result = new Vector1(v.Nmemb);
            for (int i = 0; i < v.Nmemb; i++)
            {
                result[i] = v[i] * d;
            }
            return result;
        }

        public static Vector1 operator *(double d, Vector1 v)
        {
            Vector1 result = new Vector1(v.Nmemb);
            for (int i = 0; i < v.Nmemb; i++)
            {
                result[i] = d * v[i];
            }
            return result;
        }

        // деление вектора на скаляр
        public static Vector1 operator /(Vector1 v, double d)
        {
            Vector1 result = new Vector1(v.Nmemb);
            for (int i = 0; i < v.Nmemb; i++)
            {               
                result[i] = v[i] / d;                
            }
            return result;
        }       

        // скалярное произедение векторов (dot product)
        public static double DotProduct(Vector1 v1, Vector1 v2)
        {
            double result = 0.0;
            for (int i = 0; i < v1.Nmemb; i++)
            {
                result += v1[i] * v2[i];
            }
            return result;
        }

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

        public double GetNorm()
        {
            double result = 0.0;
            for (int i = 0; i < Nmemb; i++)
            {
                result += Vect[i] * Vect[i];
            }
            return Math.Sqrt(result);
        }

        public double GetNormSquare()
        {
            double result = 0.0;
            for (int i = 0; i < Nmemb; i++)
            {
                result += Vect[i] * Vect[i];
            }
            return result;
        }

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

        public Vector1 GetUnitVector()
        {
            Vector1 result = new Vector1(Vect);
            result.Normalize();
            return result;
        }
        // векторное произведение векторов (cross product)
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
