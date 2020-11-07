//Коротких М.А.
using System;
using System.Linq;

namespace MyHelper
{

    #region Работа с массивами
    public class MyArray
    {
        private int[] arr;
        
        public MyArray(int size, int min, int max, int step)
        {
            arr = new int[size];
            int count = min;
            for (int i = 0; i < size; i++)
            {
                arr[i] = count;
                if (count < max)
                {
                    count += step;
                    if (count > max)
                    {
                        count -= (count - max);
                    }
                }
            }    
        }

        public int Sum()
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                count += arr[i];
            }
            return count;
        }

        public void Inverse()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = -1 * arr[i];
            }
        }

        public int Multi(int value)
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                count += arr[i] * value;
            }
            return count;
        }

        public int MaxCount()
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }

            var count = 0;

            foreach (var current in arr)
            {
                if (current == max)
                {
                    count++;
                }
            }
            return count;
        }

        public string ToString()
        {
            string stringarray = "";
            foreach (int x in arr)
                stringarray = stringarray + x + " ";
            return stringarray;
        }
    }
    #endregion

    public class MyFunctions
    {

        #region Структуры
        public struct PersonStruct
        {
            public string name;
            public string surName;
            public double years;
            public double height;
            public double weight;
            public double indexMass;
        }
        #endregion

        #region  Функции возвращающие значение введенное пользователем 
        //Задает вопрос и возвращает переменную типа double. Проверяет на некорректное значение
        public static double GetValue(string massege, bool thisIsInt = false, double minRange = 0.0000000999, double maxRange = 0.0000000999) //С minRange и maxRange - это костыль. Не нашел альтернативы 
        {
            Console.Write(massege);

            bool tryOk = Double.TryParse(Console.ReadLine(), out double result);

            if ((minRange != 0.0000000999 && result < minRange) || (maxRange != 0.0000000999 && result > maxRange) || (thisIsInt && result != Math.Truncate(result)) || !tryOk)
            {
                Console.WriteLine("\nВведено некорректное значение!");
                result = GetValue(massege, thisIsInt, minRange, maxRange);
            }

            return result;
        }

        //Задает вопрос и возвращает переменную типа string
        public static string GetString(string massege)
        {
            Console.Write(massege);

            return Console.ReadLine();
        }

        //Задает вопрос и возвращает переменную типа bool
        public static bool GetBool(string massege)
        {
            Console.Write(massege);

            string result = Console.ReadLine();

            if (String.IsNullOrEmpty(result))
            {
                result = "";
            }

            string resultLower = result.ToLower();

            return (resultLower == "y" || resultLower == "у"
                    || resultLower == "yes" || resultLower == "+"
                    || resultLower == "ok" || resultLower == "ок") ? true : false;

        }
        #endregion

        #region Работа с числами
        public static int GetLengthValue(double value, char[] del)
        {
            return value.ToString().Trim(del).Length;
        }
        #endregion

        



        //Расчет расстояния между точками
        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public static double GetMinArray(double[] array)
        {
            //Можно так, а можно воспользоваться уже готовым решением.
            /*double result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > result)
                {
                    result = array[i];
                }
            return result;
            }*/

            return array.Min();
        }

        public static bool CheckGoodValue(int i)
        {
            int tempValue = i;
            int sumValue = 0;
            while (tempValue > 0)
            {
                sumValue += tempValue % 10;
                tempValue /= 10;
            }
            return i % sumValue == 0;

        }

        public static double GetIndexMass(PersonStruct person)
        {
            return person.weight / ((person.height / 100) * (person.height / 100));
        }

        public static double GetMassFromGreatIndex(PersonStruct person, double greatIndexMass)
        {
            return greatIndexMass * (person.height / 100) * (person.height / 100);
        }

        #region Мелочи
        public static void PauseConsole()
        {
            Console.ReadKey();
        }
        #endregion
    }
}
