using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vector
    {
        private int n;
        private double[] componentsArray;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность не может быть <= 0");
            }
            this.n = n;
            componentsArray = new double[n];
        }

        public Vector(double[] array)
        {
            componentsArray = array;
            n = array.Length;
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность не может быть <= 0");
            }
            this.n = n;
            componentsArray = new double[n];

            for (int i = 0; i < array.Length; i++)
            {
                componentsArray[i] = array[i];
            }
        }

        public Vector(Vector previousVector)//ссылочный тип
        {
            n = previousVector.n;
            componentsArray = new double[n];
            for (int i = 0; i < n; i++)
            {
                componentsArray[i] = previousVector.componentsArray[i];
            }
        }

        public int GetSize()//размерность
        {
            return componentsArray.Length;
        }

        public override string ToString()//инф. о векторе
        {
            return string.Join(",", componentsArray);
        }

        public void VectorAdd(Vector vector)//сумма векторов
        {
            n += vector.n;

            double[] newComponentsArray = new double[n];
            for (int i = 0; i < n - vector.n; i++)
            {
                newComponentsArray[i] = componentsArray[i];
            }
            for (int i = n - vector.n, j = 0; i < n; i++, j++)
            {
                newComponentsArray[i] = vector.componentsArray[j];
            }
            componentsArray = newComponentsArray;
        }

        public void VectorSubtract(Vector vector)//разность векторов
        {
            double[] transitionalArray = new double[vector.n];
            for (int i = 0, j = vector.n - 1; i < transitionalArray.Length; i++, j--)
            {
                transitionalArray[i] = vector.componentsArray[j];
            }

            n += vector.n;

            double[] newArray = new double[n];
            for (int i = 0; i < n - vector.n; i++)
            {
                newArray[i] = componentsArray[i];
            }
            for (int i = n - vector.n, j = 0; i < n; i++, j++)
            {
                newArray[i] = transitionalArray[j];
            }
            componentsArray = newArray;
        }

        public void ScalarMuliyply(double scalar)//вектор на скаляр
        {
            for (int i = 0; i < componentsArray.Length; ++i)
            {
                componentsArray[i] *= scalar;
            }
        }

        public void VectorInvert()//разворот
        {
            for (int i = 0; i < componentsArray.Length; ++i)
            {
                componentsArray[i] *= -1;
            }
        }

        public double GetVectorLength()//длина вектора
        {
            return componentsArray[componentsArray.Length - 1] - componentsArray[0];
        }

        public double GetComponent(int index)//получение компоненты по индексу
        {
            if (index > componentsArray.Length - 1)
            {
                throw new ArgumentException("Слишком большой индекс");
            }
            if (index < 0)
            {
                throw new ArgumentException("Индекс не может быть меньше нуля");
            }
            return componentsArray[index];
        }

        public void SetComponent(int index, double newComponent)//установка компоненты по индексу
        {
            if (index > componentsArray.Length - 1)
            {
                throw new ArgumentException("Слишком большой индекс");
            }
            if (index < 0)
            {
                throw new ArgumentException("Индекс не может быть меньше нуля");
            }
            componentsArray[index] = newComponent;
        }

        public override bool Equals(object o)//переопределение Equals
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }
            if (ReferenceEquals(o, null) || o.GetType() != GetType())
            {
                return false;
            }
            Vector v = (Vector)o;

            if (v.n != n)
            {
                return false;
            }

            for (int i = 0, j = componentsArray.Length - 1; i < componentsArray.Length; i++, j--)
            {
                if (v.componentsArray[i] != componentsArray[j])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int prime = 7;
            int hash = 1;
            int sum = 0;

            for (int i = 0; i < componentsArray.Length; i++)
            {
                sum += (int)componentsArray[i];
            }

            hash = prime * n;
            hash = prime * hash + sum.GetHashCode();

            return hash;
        }

        public static Vector GetNewVectorSumm(Vector v1, Vector v2)//сложение(новый вектор)
        {
            Vector v3 = new Vector(Math.Max(v1.n, v2.n));

            if (v1.n < v2.n)
            {
                for (int i = 0; i < v1.componentsArray.Length; i++)
                {
                    v3.componentsArray[i] = v1.componentsArray[i];
                }

                for (int i = 0; i < v3.componentsArray.Length; i++)
                {
                    v3.componentsArray[i] += v2.componentsArray[i];
                }
            }
            else
            {
                for (int i = 0; i < v2.componentsArray.Length; i++)
                {
                    v3.componentsArray[i] = v2.componentsArray[i];
                }

                for (int i = 0; i < v3.componentsArray.Length; i++)
                {
                    v3.componentsArray[i] += v1.componentsArray[i];
                }
            }
            return v3;
        }

        public static Vector GetNewVectorDifference(Vector v1, Vector v2)//вычитание(новый вектор)
        {
            Vector v3 = new Vector(Math.Max(v1.n, v2.n));


            if (v1.n > v2.n)
            {
                for (int i = 0; i < v1.componentsArray.Length; i++)
                {
                    v3.componentsArray[i] = v1.componentsArray[i];
                }

                double[] utilityComponentsArray = new double[v3.n];

                for (int i = 0; i < v2.componentsArray.Length; i++)
                {
                    utilityComponentsArray[i] = v2.componentsArray[i];
                }

                for (int i = 0; i < v3.componentsArray.Length; i++)
                {
                    v3.componentsArray[i] -= utilityComponentsArray[i];
                }
            }
            else
            {
                for (int i = 0; i < v1.componentsArray.Length; i++)
                {
                    v3.componentsArray[i] = v1.componentsArray[i];
                }

                for (int i = 0; i < v3.componentsArray.Length; i++)
                {
                    v3.componentsArray[i] -= v2.componentsArray[i];
                }
            }
            return v3;
        }

        public static double GetScalarMultiplicate(Vector v1, Vector v2)//скалярное произведение
        {
            double result = 0;
            Vector v3 = new Vector(Math.Max(v1.n, v2.n));

            if (v1.n < v2.n)
            {
                for (int i = 0; i < v1.componentsArray.Length; i++)
                {
                    v3.componentsArray[i] = v1.componentsArray[i];
                }
            }
            else
            {
                for (int i = 0; i < v2.componentsArray.Length; i++)
                {
                    v3.componentsArray[i] = v2.componentsArray[i];
                }
            }

            for (int i = 0; i < v3.componentsArray.Length; i++)
            {
                result += v3.componentsArray[i];
            }

            return result;
        }
    }
}
