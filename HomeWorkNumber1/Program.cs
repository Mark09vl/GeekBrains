//Коротких М.А.
using System;
using MyHelper;

namespace HomeWorkNumber1
{
    class Program
    {
        //
        #region Задание №1
        static MyFunctions.PersonStruct HelloMan(bool printResult = true)
        {
            MyFunctions.PersonStruct person = new MyFunctions.PersonStruct
            {
                name = MyFunctions.GetString("Введите ваше имя: "),
                surName = MyFunctions.GetString("Введите вашу фамилию: "),
                years = MyFunctions.GetDouble("Введите ваш возраст(лет): ", false, 0.5, 0, true),
                height = MyFunctions.GetDouble("Введите ваш рост(см): ", false, 0.5, 0, true),
                weight = MyFunctions.GetDouble("Введите ваш вес(кг): ", false, 0.5, 0, true)
            };

            if (printResult == true)
            {
                Console.WriteLine($"Здравствуй, {person.surName}, {person.name}! Ваш вес - {person.weight:f2} кг., при росте - {person.height:f2} см. и возрасте {person.years:f1} лет!");
            }
            
            return person;

        }
        #endregion

        #region Задание №2
        static void IndexMassMan()
        {
            MyFunctions.PersonStruct person = HelloMan(false);
            person.indexMass = MyFunctions.GetIndexMass(person);
            Console.WriteLine($"Здравствуй, {person.surName}, {person.name}! Ваш индекс массы тела - {(person.indexMass):f2} при весе - {person.weight:f2} кг. и росте - {person.height:f2} см.!");

        }
        #endregion

        #region Задание №3
        static void DistancePoints()
        {
            double x1 = MyFunctions.GetDouble("Введите значение x1: ", false, 0, 0, true);
            double y1 = MyFunctions.GetDouble("Введите значение y1: ", false, 0, 0, true);
            double x2 = MyFunctions.GetDouble("Введите значение x2: ", false, 0, 0, true);
            double y2 = MyFunctions.GetDouble("Введите значение y2: ", false, 0, 0, true);

            Console.WriteLine($"Расстояние между точками равно - {MyFunctions.GetDistance(x1, y1, x2, y2):f2}");
        }
        #endregion

        #region Задание №4
        static void SwapVariable()
        {
            string valueOne = MyFunctions.GetString("Введите значение первой переменной: ");
            string valueTwo = MyFunctions.GetString("Введите значение второй переменной: ");

            Console.WriteLine($"До изменения:\nПервое значение - {valueOne}. Второе значение - {valueTwo}");

            (valueOne, valueTwo) = (valueTwo, valueOne);

            //Можно было и так, если принимать int или double
            //valueOne = valueOne + valueTwo;
            //valueTwo = valueOne - valueTwo;
            //valueOne = valueOne - valueTwo;

            Console.WriteLine($"После изменения:\nПервое значение - {valueOne}. Второе значение - {valueTwo}");

        }
        #endregion

        #region Задание №5
        static void WhoIAm()
        {
            string name = "Марк";               //GetString("Введите ваше имя: ");
            string surName = "Коротких";        //GetString("Введите вашу фамилию: ");
            string city = "Москва";             //GetString("Введите ваш город: ");

            int NameX = (Console.WindowWidth / 2) - ((surName + " " + name).Length / 2);
            int CityX = (Console.WindowWidth / 2) - (city.Length / 2);
            int Y = (Console.WindowHeight / 2) - 1;

            Console.SetCursorPosition(NameX, Y);
            Console.Write(surName + " " + name);
            Console.SetCursorPosition(CityX, Y + 1);
            Console.Write(city);

        }
        #endregion

        static void Main(string[] args)
        {
            while (true)
            {
                //Чистим от ненужного мусора
                Console.Clear();

                int numbetTask = Convert.ToInt32(MyFunctions.GetDouble("Введите номер задания(1-5): ", true, 1, 5, true, true));

                //Чистим консоль для красоты
                Console.Clear();

                if (numbetTask == 1)
                {
                    
                    Console.WriteLine("Задание №1:\n" + 
                                        "Написать программу «Анкета». \n" + 
                                        "Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес).\n" + 
                                        "В результате вся информация выводится в одну строчку:\n" +
                                        "   а) используя  склеивание;\n" +
                                        "   б) используя форматированный вывод;\n" +
                                        "   в) используя вывод со знаком $.\n");
                    

                    HelloMan();
                }
                else if (numbetTask == 2)
                {
                    Console.WriteLine("Задание №2:\n" + 
                                        "Ввести вес и рост человека.\n" + 
                                        "Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h);\n" +
                                        "   m — масса тела в килограммах;\n" + 
                                        "   h — рост в метрах.\n");
                    IndexMassMan();
                }
                else if (numbetTask == 3)
                {
                    Console.WriteLine("Задание №3:\n" + 
                                        "а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2.\n" + 
                                        "   Формула: r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2).\n" +
                                        "   Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);\n\n" +
                                        "б) * Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.\n");
                    DistancePoints();
                }
                else if (numbetTask == 4)
                {
                    Console.WriteLine("Задание №4:\n" +
                                        "Написать программу обмена значениями двух переменных:\n" + 
                                        "   а) с использованием третьей переменной;\n" + 
                                        "   б) *без использования третьей переменной.\n");
                    SwapVariable();
                }
                else if (numbetTask == 5)
                {
                    Console.WriteLine("Задание №5:\n" + 
                                        "а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.\n\n" +
                                        "б) * Сделать задание, только вывод организовать в центре экрана.\n\n" + 
                                        "в) **Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y).\n");
                    WhoIAm();
                }

                MyFunctions.PauseConsole();

                //Чистим для вопроса
                Console.Clear();

                Console.WriteLine("Задание №6:\n" +
                                        "*Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).\n" +
                                        "Класс с методами использовались в 1-4 заданиях.\n");

                if (!MyFunctions.GetBool("Начать заново?(y/n) "))
                {
                    break;
                }
            }
        }
    }
}
