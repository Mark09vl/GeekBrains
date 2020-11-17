//Коротких М.А.

using System;
using System.IO;
using MyHelper;

namespace HomeWorkNumber4
{

    #region Задача №1
    public class MyArray
    {
        //Приватное поле-массив класса Array 
        private int[] arr;


        //Конструктор массива с заполением случаяными числами 
        public MyArray(int size, int min, int max)
        {
            arr = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
                arr[i] = random.Next(min, max);
        }

        //Метод подсчета пар чисел, которые делятся на 3
        public void Counting()
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] % 3 == 0 
                    || arr[i + 1] % 3 == 0)
                    count++;
                Console.WriteLine($"Пара чисел: {arr[i]} и {arr[i + 1]}");
            }
            Console.WriteLine("Количество пар: " + count);
        }

        //Метод вывода массива на консоль
        override public string ToString()
        {
            string stringarray = "";
            foreach (int x in arr)
                stringarray = stringarray + x + " ";
            return stringarray;
        }
    }
    #endregion

    #region Задача №2
    public static class StaticClass
    {
        public static int[] CreateRandomArray(int size, int min, int max)
        {
            int[] arr = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
                arr[i] = random.Next(min, max);

            return arr;
        }

        public static int[] CoolArray(string filename)
        {
            //Если файл существует
            if (File.Exists(filename))
            {
                //Считываем все строки в файл 
                string[] ss = File.ReadAllLines(filename);
                int[] a = new int[ss.Length];
                //Переводим данные из строкового формата в числовой
                for (int i = 0; i < ss.Length; i++)
                {
                    a[i] = int.Parse(ss[i]);
                }
                return a;
            }
            else
            {
                Console.WriteLine($"Файл {filename} не найден!");
                return new int[0];
            }
        }


        public static int Counting(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] % 3 == 0
                    || arr[i + 1] % 3 == 0)
                    count++;
                Console.WriteLine($"Пара чисел: {arr[i]} и {arr[i + 1]}");
            }
            Console.WriteLine("Количество пар: " + count);
            return count;
        }

        public static string ToString(int [] arr)
        {
            string stringarray = "";
            foreach (int x in arr)
                stringarray = stringarray + x + " ";
            return stringarray;
        }
    }
    #endregion


    class Program
    {
        #region Задача №1
        static void LookForPairs()
        {
            MyArray myArray = new MyArray(20, -10000, 10000);
            Console.WriteLine($"Массив:\n{myArray.ToString()} \n\nРезультат:\n");
            myArray.Counting();
        }
        #endregion

        #region Задача №2
        static void LookForPairsForStaticClass()
        {
            int numbetTask = Convert.ToInt32(MyFunctions.GetDouble("1. Рандомный массив;\n" +
                                                                    "2. Массив с файла input.txt в текущей директории.\n" +
                                                                    "Выберите вариант исполнения(1-2): ", true, 1, 2, true, true));

            int[] myInStaticArray = new int[0];

            if (numbetTask == 1)
            {
                myInStaticArray = StaticClass.CreateRandomArray(20, -10000, 10000);
            }
            else
            {
                myInStaticArray = StaticClass.CoolArray("../../../input.txt");
            }
            
            Console.WriteLine($"Массив:\n{StaticClass.ToString(myInStaticArray)} \n\nРезультат:\n");
            StaticClass.Counting(myInStaticArray);
        }
        #endregion

        static void TestMyArray()
        {
            MyHelper.MyArray myTestArray = new MyHelper.MyArray(20, 1, 100, 5);
            Console.WriteLine($"Массив:\n{myTestArray.ToString()} \n\nРезультат:\n");
            Console.WriteLine($"Sum: {myTestArray.Sum()}\n");
            Console.WriteLine($"Multi: {myTestArray.Multi(10)}\n");
            Console.WriteLine($"MaxCount: {myTestArray.MaxCount()}\n");
            myTestArray.Inverse();
            Console.WriteLine($"Inverse: {myTestArray.ToString()}\n");
        } 

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                int numbetTask = Convert.ToInt32(MyFunctions.GetDouble("Введите номер задания(1-3): ", true, 1, 3, true, true));

                Console.Clear();

                if (numbetTask == 1)
                {
                    Console.WriteLine("Задание №1:\n" +
                                        "Найти и вывести количество пар элементов массива.\n");
                    LookForPairs();
                }
                else if (numbetTask == 2)
                {
                    Console.WriteLine("Задание №2:\n" +
                                        "Реализуйте задачу 1 в виде статического класса StaticClass.\n");
                    LookForPairsForStaticClass();
                }
                else if (numbetTask == 3)
                {
                    Console.WriteLine("Задание №3:\n" +
                                        "Дописать класс для работы с одномерным массивом.\n");
                    TestMyArray();
                }

                MyFunctions.PauseConsole();

                Console.Clear();

                if (!MyFunctions.GetBool("Начать заново?(y/n) "))
                {
                    break;
                }
            }
        }
    }
}
