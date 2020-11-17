//Коротких М.А.

using System;
using Microsoft.VisualBasic;
using MyHelper;

namespace HomeWorkNumber2
{
    class Program
    {

        #region Задание №1
        static void MinValue()
        {
            int maxValues = Convert.ToInt32(MyFunctions.GetDouble("Введите количество чисел: ", true, 1, 0, true));

            double[] myArray = new double[maxValues];

            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = MyFunctions.GetDouble($"Введите чисело номер {i + 1}: ");
            }

            Console.WriteLine($"Минимальное число - {MyFunctions.GetMinArray(myArray)}");
        }
        #endregion

        #region Задание №2
        static void LengthValue()
        {
            double value = MyFunctions.GetDouble("Введите число для подсчета символов: ");
            Console.WriteLine($"Количество символов в числе - {MyFunctions.GetLengthValue(value, new char[] { ',', '.' })}");
        }
        #endregion

        #region Задание №3
        static void ManualArray()
        {
            int i = 0;
            double[] myArray = new double[0];
            double result = 0;
            while (true)
            {
                i++;
                Array.Resize(ref myArray, i);
                myArray[i - 1] = MyFunctions.GetDouble($"Введите число номер {i}: ");
                if (myArray[i - 1] == 0)
                {
                    break;
                }
            }

            for (i = 0; i < myArray.Length; i++)
            {
                if ((myArray[i] > 0) && (myArray[i] % 2 != 0))
                {
                    result += myArray[i];
                }
            }

            Console.WriteLine($"Сумма нечетных положительных чисел - {result}");
        }
        #endregion

        #region Задание №4
        static bool CheckAuthorization(string login, string password)
        {
            string stokLogin = "root";
            string stokPassword = "GeekBrains";

            return stokLogin == login && stokPassword == password;
        }

        static void GeekAuthorization()
        {
            bool result;
            int i = 0;
            int tryBad = 3;
            do
            {
                string login = MyFunctions.GetString("Введите логин: ");
                string password = MyFunctions.GetString("Введите пароль: ");

                result = CheckAuthorization(login, password);

                if (result)
                {
                    Console.WriteLine("Введен верный пароль!\nДобро пожаловать!");
                    break;
                }
                else
                {
                    Console.WriteLine("Введен не верный пароль!");
                }

                i++;

                Console.WriteLine($"Осталось попыток - {tryBad - i}");

            } while (i < tryBad);
        }
        #endregion

        #region Задание №5
        static void CheckIndexMass()
        {

            MyFunctions.PersonStruct person = new MyFunctions.PersonStruct
            {
                height = MyFunctions.GetDouble("Введите ваш рост(см): ", false, 0.5, 0, true),
                weight = MyFunctions.GetDouble("Введите ваш вес(кг): ", false, 0.5, 0, true),

            };

            person.indexMass = MyFunctions.GetIndexMass(person);

            Console.Write($"Индекс массы тела - {person.indexMass:f1}. ");

            if (person.indexMass < 18.5)
            {
                Console.WriteLine($"Ваш вес ниже нормального!");
            }
            else if (person.indexMass >= 18.5 && person.indexMass < 25)
            {
                Console.WriteLine($"Ваш вес нормальный!");
            }
            else if (person.indexMass >= 25 && person.indexMass < 30)
            {
                Console.WriteLine($"Ваш вес избыточный!");
            }
            else if (person.indexMass >= 30 && person.indexMass < 35)
            {
                Console.WriteLine($"У вас ожирение I степени!");
            }
            else if (person.indexMass >= 35 && person.indexMass < 40)
            {
                Console.WriteLine($"У вас ожирение II степени!");
            }
            else if (person.indexMass >= 40)
            {
                Console.WriteLine($"У вас ожирение III степени!");
            }

            if (person.indexMass < 18.5)
            {
                Console.WriteLine($"Вам необходимо набрать {MyFunctions.GetMassFromGreatIndex(person, 18.5) - person.weight:f1} кг.");
            }
            else if (person.indexMass > 25)
            {
                Console.WriteLine($"Вам необходимо сбросить {person.weight - MyFunctions.GetMassFromGreatIndex(person, 25):f1} кг.");
            }

        }
        #endregion

        #region Задание №6
        static void GoodValue(int startValue, int endValue)
        {
            int sumGoodValue = 0;

            DateTime Time = DateTime.Now;

            for (int i = startValue; i < endValue; i++)
            {
                if (MyFunctions.CheckGoodValue(i))
                {
                    sumGoodValue++;
                }
            }

            TimeSpan workTime = DateTime.Now - Time;

            Console.WriteLine($"В диапазоне от {startValue} до {endValue} хороших чисел - {sumGoodValue} шт.\n" +
                                $"Время работы рассчета(мин:сек:мсек) - {workTime:mm\\:ss\\:fff}");
        }
        #endregion

        #region Задание №7
        static void MagicValue(int startValue, int endValue, ref int sumValue)
        {
            if (startValue <= endValue)
            {
                Console.WriteLine(startValue);
                sumValue += startValue;
                MagicValue(startValue + 1, endValue, ref sumValue);
            }
        }
        #endregion

        static void Main(string[] args)
        {

            while (true)
            {
                //Чистим от ненужного мусора
                Console.Clear();

                int numbetTask = Convert.ToInt32(MyFunctions.GetDouble("Введите номер задания(1-7): ", true, 1, 7, true, true));

                //Чистим консоль для красоты
                Console.Clear();

                if (numbetTask == 1)
                {
                    Console.WriteLine("Задание №1:\n" + 
                                        "Написать метод, возвращающий минимальное из трёх чисел.\n" + 
                                        "(Немного усложненный вариант. Необходимо сначала ввести количество числе, а потом уже числа)\n");
                    MinValue();
                }
                else if (numbetTask == 2)
                {
                    Console.WriteLine("Задание №2:\n" + 
                                        "Написать метод подсчета количества цифр числа.\n");
                    LengthValue();
                }
                else if (numbetTask == 3)
                {
                    Console.WriteLine("Задание №3:\n" + 
                                        "С клавиатуры вводятся числа, пока не будет введен 0.\n" +
                                        "Подсчитать сумму всех нечетных положительных чисел.\n");
                    ManualArray();
                }
                else if (numbetTask == 4)
                {
                    Console.WriteLine("Задание №4:\n" +
                                        "Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль.\n" + 
                                        "На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).\n" + 
                                        "Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.\n" + 
                                        "С помощью цикла do while ограничить ввод пароля тремя попытками.\n");
                    GeekAuthorization();
                }
                else if (numbetTask == 5)
                {
                    Console.WriteLine("Задание №5:\n" +
                                        "а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.\n\n" +
                                        "б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.\n");
                    CheckIndexMass();
                }
                else if (numbetTask == 6)
                {
                    Console.WriteLine("Задание №6:\n" +
                                        "*Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.\n" + 
                                        "«Хорошим» называется число, которое делится на сумму своих цифр.\n" + 
                                        "Реализовать подсчёт времени выполнения программы, используя структуру DateTime.\n");
                    GoodValue(1, 1000000);
                }
                else if (numbetTask == 7)
                {
                    Console.WriteLine("Задание №7:\n" +
                                        "a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).\n\n" +
                                        "б) * Разработать рекурсивный метод, который считает сумму чисел от a до b.\n");
                    int sumValue = 0;
                    MagicValue(Convert.ToInt32(MyFunctions.GetDouble("Введите первое число: ", true)),
                                Convert.ToInt32(MyFunctions.GetDouble("Введите последнее число: ", true)), ref sumValue);
                    Console.WriteLine($"Сумма чисел - {sumValue}");
                }

                MyFunctions.PauseConsole();

                //Чистим для вопроса
                Console.Clear();

                if (!MyFunctions.GetBool("Начать заново?(y/n) "))
                {
                    break;
                }
            }   
        }
    }
}
