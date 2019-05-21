using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Vector
    {
        private double[] components;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность не может быть <= 0");
            }
            components = new double[n];
        }

        public Vector(double[] array)
        {
            if (array.Length <= 0)
            {
                throw new ArgumentException("Размерность не может быть <= 0");
            }

            components = new double[array.Length];
            Array.Copy(array, components, array.Length);
        }

        public Vector(int n, double[] array)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность не может быть <= 0");
            }

            components = new double[array.Length];
            Array.Copy(array, components, array.Length);
            Array.Resize(ref components, n);
        }

        public Vector(Vector previousVector)
        {
            components = new double[previousVector.components.Length];
            Array.Copy(previousVector.components, components, previousVector.components.Length);
        }

        public int GetSize()//размерность
        {
            return components.Length;
        }

        public override string ToString()//инф. о векторе
        {
            StringBuilder vectorInfo = new StringBuilder();

            vectorInfo.Append("{")
                      .Append(string.Join(",", components))
                      .Append("}");

            return vectorInfo.ToString();
        }

        public void Add(Vector addedVector)//сумма векторов
        {
            if (components.Length < addedVector.components.Length)
            {
                Array.Resize(ref components, addedVector.components.Length);
            }

            int minLength = Math.Min(components.Length, addedVector.components.Length);
            for (int i = 0; i < minLength; i++)
            {
                components[i] += addedVector.components[i];
            }
        }

        public void Substract(Vector substractedVector)//разность векторов
        {
            if (components.Length < substractedVector.components.Length)
            {
                Array.Resize(ref components, substractedVector.components.Length);
            }

            int minLength = Math.Min(components.Length, substractedVector.components.Length);
            for (int i = 0; i < minLength; i++)
            {
                components[i] -= substractedVector.components[i];
            }
        }

        public void ScalarMultiply(double scalar)//вектор на скаляр
        {
            for (int i = 0; i < components.Length; ++i)
            {
                components[i] *= scalar;
            }
        }

        public void Invert()//разворот
        {
            ScalarMultiply(-1);
        }

        public double GetLength()//длина вектора
        {
            /*double result = 0;
            foreach (int e in components)
            {
                result += e;
            }
            return result;*/
            return components.Length;
        }

        public double GetComponent(int index)//получение компоненты по индексу
        {
            if (index >= components.Length)
            {
                throw new IndexOutOfRangeException("Слишком большой индекс");
            }
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Индекс не может быть меньше нуля");
            }
            return components[index];
        }

        public void SetComponent(int index, double newComponent)//установка компоненты по индексу
        {
            if (index >= components.Length)
            {
                throw new IndexOutOfRangeException("Слишком большой индекс");
            }
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Индекс не может быть меньше нуля");
            }
            components[index] = newComponent;
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

            Vector vector = (Vector)o;

            if (components.Length != vector.components.Length)
            {
                return false;
            }

            for (int i = 0; i <= components.Length; i++)
            {
                if (components[i] != vector.components[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return components.Length.GetHashCode();
        }

        public static Vector GetSum(Vector v1, Vector v2)//сложение(новый вектор)
        {
            Vector resultVector = new Vector(Math.Max(v1.components.Length, v2.components.Length));
            Array.Copy(v1.components, resultVector.components, v1.components.Length);
            resultVector.Add(v2);
            return resultVector;
        }

        public static Vector GetDifference(Vector v1, Vector v2)//вычитание(новый вектор)
        {
            Vector resultVector = new Vector(Math.Max(v1.components.Length, v2.components.Length));
            Array.Copy(v1.components, resultVector.components, v1.components.Length);
            resultVector.Substract(v2);
            return resultVector;
        }

        public static double GetScalarMultiplicate(Vector v1, Vector v2)//скалярное произведение
        {
            double[] utilityComponents = new double[Math.Max(v1.components.Length, v2.components.Length)];
            Array.Copy(v1.components, utilityComponents, utilityComponents.Length);

            int minLength = Math.Min(v1.components.Length, v2.components.Length);
            for (int i = 0; i < minLength; i++)
            {
                utilityComponents[i] *= v2.components[i];
            }

            double result = 0;

            for (int i = 0; i < utilityComponents.Length; i++)
            {
                result += utilityComponents[i];
            }
            return result;
        }
    }
}
