using System;
using MyHelper;

namespace HomeWorkNumber3
{
    #region Описание комплексных чисел к заданию №1
    class Complex
    {
        public double im;
        public double re;

        public static Complex operator +(Complex x1, Complex x2)
        {
            Complex x3 = new Complex
            {
                re = x1.re + x2.re,
                im = x1.im + x2.im
            };
            return x3;
        }

        public static Complex operator -(Complex x1, Complex x2)
        {
            Complex x3 = new Complex
            {
                re = x1.re - x2.re,
                im = x1.im - x2.im           
            };
            return x3;
        }

        public static Complex operator *(Complex x1, Complex x2)
        {
            Complex x3 = new Complex
            {
                re = x1.re * x2.re - x1.im * x2.im,
                im = x1.im * x2.re + x1.re * x2.im
            };
            return x3;
        }

        public string ToString()
        {
            return (re == 0 ? "" : Convert.ToString(re)) + (im < 0 || re == 0 ? "" : "+") + (im == 0 ? "" : Convert.ToString(im) + "i");
        }

    }
    #endregion

    #region Описание дробей к заданию №3
    class Fraction
    {
        public double numerator = 0;
        public double denominator = 0;
        public double decimalValue = 0;

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
            this.decimalValue = DemicalValue();
        }

        public double DemicalValue()
        {
            return numerator / denominator;
        }

        public string ToString()
        {
            return $"({numerator:f2}".TrimEnd('0').TrimEnd(',') + $"/{denominator:f2}".TrimEnd('0').TrimEnd(',') + ")";
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction t = new Fraction(1, 1)
            {
                //Находим числитель
                numerator = (a.numerator * b.denominator + a.denominator * b.numerator),
                //Находим знаменатель
                denominator = a.denominator * b.denominator
            };

            //Сокращаем
            Fraction.SetFormat(t);

            return t;

        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction t = new Fraction(1, 1)
            {
                //Находим числитель
                numerator = (a.numerator * b.denominator - a.denominator * b.numerator),
                //Находим знаменатель
                denominator = a.denominator * b.denominator
            };

            //Сокращаем
            Fraction.SetFormat(t);

            return t;
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction t = new Fraction(1, 1)
            {
                //Находим числитель
                numerator = (a.numerator * b.numerator),
                //Находим знаменатель
                denominator = a.denominator * b.denominator
            };

            //Сокращаем
            Fraction.SetFormat(t);
            return t;

        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction t = new Fraction(1, 1)
            {
                //Находим числитель
                numerator = (a.numerator / b.numerator),
                //Находим знаменатель
                denominator = a.denominator / b.denominator
            };

            //Сокращаем
            Fraction.SetFormat(t);

            return t;
        }
        
        //Сокращение дроби
        public static Fraction SetFormat(Fraction a)
        {

            double max;

            //Ищем большее. Модуль, чтобы работало с отрицательными значениями
            if (Math.Abs(a.numerator) > Math.Abs(a.denominator))
            {
                max = Math.Abs(a.denominator);
            }
            else
            {
                max = Math.Abs(a.numerator);
            }
                                    
            for (double i = max; i >= 2; i--)
            {
                //Ищем число, на которое делилится числитель и знаменатель без остатка
                if ((a.numerator % i == 0) & (a.denominator % i == 0))
                {
                    a.numerator /= i;
                    a.denominator /= i;
                }

            }

            //Если в знаменателе минус, то переносим его в числитель
            if ((a.denominator < 0))
            {
                a.numerator = -1 * (a.numerator);
                a.denominator = Math.Abs(a.denominator);
            }
            return (a);
        }

    }
    #endregion

    class Program
    {

        #region Задание №1
        static void ComplexValue()
        {
            Complex complex1 = new Complex
            {
                re = 1,
                im = 2
            };

            Complex complex2 = new Complex
            {
                re = 3,
                im = 4
            };

            Complex result;

            int numbetCaseTask = Convert.ToInt32(MyFunctions.GetValue("1) Сумма комплексных числел;\n" +
                                                                        "2) Разность комплексных числел;\n" +
                                                                        "3) Произведение комплексных чисел.\n\n" +
                                                                        "Введите номер варианта задания(1-3): ", true, 1, 3));

            Console.Clear();

            switch (numbetCaseTask)
            {
                case 1:
                    result = complex1 + complex2;
                    Console.WriteLine($"Сумма комплескных чисел: ({complex1.re}+{complex2.re})+({complex1.im}+{complex2.im})i={result.ToString()}\n");
                    break;
                case 2:
                    result = complex1 - complex2;
                    Console.WriteLine($"Разность комплескных чисел: ({complex1.re}-{complex2.re})+({complex1.im}-{complex2.im})i={result.ToString()}\n");
                    break;
                case 3:
                    result = complex1 * complex2;
                    Console.WriteLine($"Произведение комплескных чисел: {complex1.re}*{complex2.re}-{complex1.im}*{complex2.im}+({complex1.im}*{complex2.re}+{complex1.re}*{complex2.im})i={result.ToString()}\n");
                    break;
            }
        }
        #endregion

        #region Задание №2
        static void ManualArray()
        {

            Console.Clear();

            int i = 0;
            double[] myArray = new double[0];
            double result = 0;
            while (true)
            {
                i++;
                Array.Resize(ref myArray, i);
                myArray[i - 1] = MyFunctions.GetValue($"Введите число номер {i}: ");
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

        #region Задание №3
        static void FractionValue()
        {
            int ax = Convert.ToInt32(MyFunctions.GetValue("Введите числитель первой дроби: ", true));
            int ay = Convert.ToInt32(MyFunctions.GetValue("Введите знаменатель первой дроби: ", true));

            int bx = Convert.ToInt32(MyFunctions.GetValue("Введите числитель второй дроби: ", true));
            int by = Convert.ToInt32(MyFunctions.GetValue("Введите знаменатель первой дроби: ", true));

            Console.Clear();

            Fraction a = new Fraction(ax, ay);
            Fraction b = new Fraction(bx, by);

            Fraction c;

            int numbetCaseTask = Convert.ToInt32(MyFunctions.GetValue("1) Сумма дробных числел;\n" +
                                                                        "2) Разность дробных числел;\n" +
                                                                        "3) Произведение дробных чисел.\n" +
                                                                        "4) Деление дробных чисел.\n\n" +
                                                                        "Введите номер варианта задания(1-4): ", true, 1, 4));

            Console.Clear();

            switch (numbetCaseTask)
            {
                case 1:
                    c = a + b;
                    Console.WriteLine($"Сумма дробей: {a.ToString()}+{b.ToString()}={c.ToString():f2}. Десятичный вид: {c.DemicalValue():f2}");
                    break;
                case 2:
                    c = a - b;
                    Console.WriteLine($"Разность дробей: {a.ToString()}-{b.ToString()}={c.ToString():f2}. Десятичный вид: {c.DemicalValue():f2}");
                    break;
                case 3:
                    c = a * b;
                    Console.WriteLine($"Произведение дробей: {a.ToString()}*{b.ToString()}={c.ToString():f2}. Десятичный вид: {c.DemicalValue():f2}");
                    break;
                case 4:
                    c = a / b;
                    Console.WriteLine($"Деление дробей: {a.ToString()}/{b.ToString()}={c.ToString():f2}. Десятичный вид: {c.DemicalValue():f2}");
                    break;
            }

        }
        #endregion

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                int numbetTask = Convert.ToInt32(MyFunctions.GetValue("Введите номер задания(1-3): ", true, 1, 3));

                Console.Clear();

                if (numbetTask == 1)
                {
                    Console.WriteLine("Задание №1:\n" +
                                        "Структура Complex.\n");
                    ComplexValue();
                }
                else if (numbetTask == 2)
                {
                    Console.WriteLine("Задание №2:\n" +
                                        "С клавиатуры вводятся числа, пока не будет введен 0.\n" +
                                        "Подсчитать сумму всех нечетных положительных чисел.\n");
                    ManualArray();
                }
                else if (numbetTask == 3)
                {
                    Console.WriteLine("Задание №3:\n" +
                                        "С клавиатуры вводятся числа, пока не будет введен 0.\n" +
                                        "Подсчитать сумму всех нечетных положительных чисел.\n");
                    FractionValue();
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