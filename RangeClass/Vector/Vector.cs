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
            if (n < array.Length)
            {
                throw new ArgumentException("Размерность вектора не может быть меньше массива компонент");
            }

            components = new double[n];
            Array.Copy(array, components, array.Length);
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
            return string.Join(",", components);
        }

        public void Adding(Vector addedVector)//сумма векторов
        {
            if (components.Length < addedVector.components.Length)
            {
                double[] utilityComponents = new double[Math.Max(components.Length, addedVector.components.Length)];
                Array.Copy(components, utilityComponents, components.Length);
                components = new double[utilityComponents.Length];
                Array.Copy(utilityComponents, components, components.Length);
            }
          
            for (int i = 0; i < Math.Min(components.Length, addedVector.components.Length); i++)
            {
                components[i] += addedVector.components[i];
            }
        }

        public void Substracting(Vector substractedVector)//разность векторов
        {
            if (components.Length < substractedVector.components.Length)
            {
                double[] utilityComponents = new double[Math.Max(components.Length, substractedVector.components.Length)];
                Array.Copy(components, utilityComponents, components.Length);
                components = new double[utilityComponents.Length];
                Array.Copy(utilityComponents, components, components.Length);
            }

            for (int i = 0; i < Math.Min(components.Length, substractedVector.components.Length); i++)
            {
                components[i] -= substractedVector.components[i];
            }
        }

        public void ScalarMuliyply(double scalar)//вектор на скаляр
        {
            for (int i = 0; i < components.Length; ++i)
            {
                components[i] *= scalar;
            }
        }

        public void Invert()//разворот
        {
            ScalarMuliyply(-1);
        }

        public double GetLength()//длина вектора
        {
            double result = 0;
            for (int i = 0; i < components.Length; i++)
            {
                result += components[i];
            }
            return result;
        }

        public double GetComponent(int index)//получение компоненты по индексу
        {
            if (index >= components.Length)
            {
                throw new ArgumentException("Слишком большой индекс");
            }
            if (index < 0)
            {
                throw new ArgumentException("Индекс не может быть меньше нуля");
            }
            return components[index];
        }

        public void SetComponent(int index, double newComponent)//установка компоненты по индексу
        {
            if (index >= components.Length)
            {
                throw new ArgumentException("Слишком большой индекс");
            }
            if (index < 0)
            {
                throw new ArgumentException("Индекс не может быть меньше нуля");
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

            if (components.Length == vector.components.Length)
            {
                for (int i = 0; i <= components.Length; i++)
                {
                    if (components[i] != vector.components[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return components.GetHashCode();
        }

        public static Vector GetNewSumm(Vector v1, Vector v2)//сложение(новый вектор)
        {
            Vector resultVector = new Vector(Math.Max(v1.components.Length, v2.components.Length));
            Array.Copy(v1.components, resultVector.components, v1.components.Length);
            resultVector.Adding(v2);
            return resultVector;
        }

        public static Vector GetNewDifference(Vector v1, Vector v2)//вычитание(новый вектор)
        {
            Vector resultVector = new Vector(Math.Max(v1.components.Length, v2.components.Length));
            Array.Copy(v1.components, resultVector.components, v1.components.Length);
            resultVector.Substracting(v2);
            return resultVector;
        }

        public static double GetScalarMultiplicate(Vector v1, Vector v2)//скалярное произведение
        {
            double[] utilityComponents = new double[Math.Max(v1.components.Length, v2.components.Length)];
            Array.Copy(v1.components, utilityComponents, utilityComponents.Length);

            for (int i = 0; i < Math.Min(v1.components.Length, v2.components.Length); i++)
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
