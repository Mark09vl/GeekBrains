using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using MyHelper;

public delegate double FunTable(double a, double x);

public delegate double FunOperations(double x);

class Student
{
    public string lastName;
    public string firstName;
    public string university;
    public string faculty;
    public int course;
    public string department;
    public int age;
    public int group;
    public string city;
    // Создаем конструктор
    public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.university = university;
        this.faculty = faculty;
        this.department = department;
        this.course = course;
        this.age = age;
        this.group = group;
        this.city = city;
    }

    public string ToString()
    {
        return firstName + " " + lastName + ", Лет: " + age + ", Курс: " + course;
    }

}


class Program
{
    #region Задание №1
    public static void Table(FunTable F, double a, double x, double b)
    {
        Console.WriteLine("----- X ----- Y -----");
        while (x <= b)
        {
            Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
            x += 1;
        }
        Console.WriteLine("---------------------");
    }
    
    public static double MyFunc(double x, double a)
    {
        return a * x * x;
    }

    public static double MySin(double x, double a)
    {
        return a * Math.Sin(x);
    }

    static void CheckDelegate()
    {
        double a = 6;

        Console.WriteLine($"Функции {a:F2}*x^2:");
        Table(new FunTable(MyFunc), a, -2, 5);

        Console.WriteLine($"\nФункция {a:F2}*sin(x):");
        Table(new FunTable(MySin), a, -2, 5);

        MyFunctions.PauseConsole();
    }
    #endregion

    #region Задание №2
    public static void SaveFunc(FunOperations F, string fileName, double start, double end, double step)
    {
        FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);

        while (start <= end)
        {
            bw.Write(F(start));
            start += step;
        }
        bw.Close();
        fs.Close();
    }

    public static double[] Load(string fileName, out double min)
    {
        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        BinaryReader bw = new BinaryReader(fs);

        double[] array = new double[fs.Length / sizeof(double)];
        min = double.MaxValue;
        double d;
        for (int i = 0; i < fs.Length / sizeof(double); i++)
        {
            d = bw.ReadDouble();
            array[i] = d;
            if (d < min) min = d;
        }
        bw.Close();
        fs.Close();
        return array;
    }

    static double Square(double x)
    {
        return x * x;
    }

    static double Cube(double x)
    {
        return x * x * x;
    }

    static double Sqrt(double x)
    {
        return Math.Sqrt(x);
    }

    static double Sin(double x)
    {
        return Math.Sin(x);
    }

    static void PrintResults(double start, double end, double step, double[] values)
    {
        Console.WriteLine(" _____________________\n" +
                          "|     X    |    Y     |\n" +
                          "|__________|__________|");
        int index = 0;
        while (start <= end)
        {
            Console.WriteLine($"| {start,8:F3} | {values[index],8:F3} |");
            start += step;
            index++;
        }
        Console.WriteLine("|__________|__________|");
    }

    static void CheckFuncMin()
    {
        List<FunOperations> functions = new List<FunOperations> 
        { 
            new FunOperations(Square), 
            new FunOperations(Cube), 
            new FunOperations(Sqrt), 
            new FunOperations(Sin)
        };

        int numbetTask = Convert.ToInt32(MyFunctions.GetDouble("1) f(x)=y^2\n" +
                                                                "2) f(x)=y^3\n" +
                                                                "3) f(x)=y^1/2\n" +
                                                                "4) f(x)=Sin(y)\n" +
                                                                "Введите номер функции(1-4): ", true, 0, functions.Count, false, true) - 1);

        double start = MyFunctions.GetDouble("\nВведите минимум отрезка: ");
        double end = MyFunctions.GetDouble("Введите максимум отрезка: ");
        double step = MyFunctions.GetDouble("Введите размер шага дискредитирования: ");

        double min = double.MaxValue;

        SaveFunc(functions[numbetTask], "data.bin", start, end, step);
        
        Console.WriteLine("Результат: ");
        
        PrintResults(start, end, step, Load("data.bin", out min));

        Console.WriteLine($"Минимальное значение: {min:F2}");
    }
    #endregion

    #region Задание №3

    static int SortAge(Student st1, Student st2)
    {
        return (st1.age != st2.age) ? ((st1.age > st2.age) ? 1 : -1) : -1 ;
    }

    static int SortCourceAndAge(Student st1, Student st2)
    {
        int result = 0;

        if (st1.course < st2.course)
        {
            result = -1;
        }
        if (st1.course > st2.course)
        {
            result = 1;
        }
        if (st1.course == st2.course)
        {
            if (st1.age < st2.age)
            { 
                result = -1; 
            }
            if (st1.age > st2.age)
            {
                result = 1;
            }
        }

        return result;
    }

    static void CheckCollect()
    {


        int fifthСourse = 0;
        int sixthСourse = 0;

        List<Student> list = new List<Student>();
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        DateTime dt = DateTime.Now;

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        StreamReader sr = new StreamReader("../../../students.csv", Encoding.GetEncoding(1251));

        int count = 0;
        
        while (!sr.EndOfStream)
        {
            try
            {
                string[] s = sr.ReadLine().Split(';');
                
                list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                
                Student currentStudent = list[count];

                if (currentStudent.course == 5)
                {
                    fifthСourse++;
                }
                else if (currentStudent.course == 6)
                {
                    sixthСourse++;
                }

                if (currentStudent.age > 17 && currentStudent.age < 21)
                {
                    if (frequency.ContainsKey(currentStudent.course))
                    {
                        frequency[currentStudent.course] += 1;
                    }
                    else
                    {
                        frequency.Add(currentStudent.course, 1);
                    }
                }
                count++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message +
                                    "\nОшибка!ESC - прекратить выполнение программы");
                // Выход из Main
                if (Console.ReadKey().Key == ConsoleKey.Escape) return;
            }
        }
        sr.Close();
        Console.WriteLine($"Всего студентов: {list.Count};\n" +
                            $"На 5 курсе: {fifthСourse};\n" +
                            $"На 6 курсе: {sixthСourse}.\n\n");


        Console.WriteLine("Студенты от 18 до 20 на курсах: ");
        ICollection<int> keys = frequency.Keys;
        foreach (int key in keys)
        {
            Console.WriteLine($"Курс: {key}, количество студентов: {frequency[key]}");
        }

        Console.WriteLine("\n\nСортировка по возрасту: ");
        list.Sort(new Comparison<Student>(SortAge));
        foreach (Student currentStudent in list)
        {
            Console.WriteLine(currentStudent.ToString());
        }

        Console.WriteLine("\n\nСортировка по курсу и возрасту: ");
        list.Sort(new Comparison<Student>(SortCourceAndAge));
        foreach (Student currentStudent in list)
        {
            Console.WriteLine(currentStudent.ToString());
        }

        Console.WriteLine($"\n\nВремя работы рассчета(мин:сек:мсек) - {DateTime.Now - dt:mm\\:ss\\:fff}");

    }
    #endregion

    #region Задание №4
    static void CheckReader()
    {
        long kbyte = 1024;
        long mbyte = 1024 * kbyte;
        long gbyte = 1024 * mbyte;
        long size = mbyte;
        
        Console.WriteLine("Запишем файлы при помощи разных потоков:\n" + 
                            $"FileStream. Milliseconds:{MyFunctions.FileStreamSampleWrite("../../../FileStream.bin", size)}\n" + 
                            $"BinaryStream. Milliseconds:{MyFunctions.BinaryStreamSampleWrite("../../../BinaryStream.bin", size)}\n" + 
                            $"StreamWriter. Milliseconds:{MyFunctions.StreamWriterSampleWrite("../../../StreamWriter.bin", size)}\n" + 
                            $"BufferedStream. Milliseconds:{MyFunctions.BufferedStreamSampleWrite("../../../BufferedStream.bin", size)}\n");

        Console.WriteLine("Прочтём файлы при помощи разных потоков:");
        byte[] bytesFromFileStream = MyFunctions.FileStreamSampleRead("../../../FileStream.bin");
        int[] integersFromBinatyStream = MyFunctions.BinaryStreamSampleRead("../../../BinaryStream.bin");
        string stringFromSreamReader = MyFunctions.StreamReaderSample("../../../StreamWriter.bin");
        byte[] bytesFromBufferedStream = MyFunctions.BufferedStreamSampleRead("../../../BufferedStream.bin");
    }
    #endregion

    static void Main()
    {
        while (true)
        {
            Console.Clear();

            int numbetTask = Convert.ToInt32(MyFunctions.GetDouble("Введите номер задания(1-4): ", true, 1, 4, true, true));

            Console.Clear();

            if (numbetTask == 1)
            {
                Console.WriteLine("Задание №1:\n" +
                                    "Проверка работы вывода таблицы функции.\n");
                CheckDelegate();
            }
            else if (numbetTask == 2)
            {
                Console.WriteLine("Задание №2:\n" +
                                    "Программа нахождения минимума функции.\n");
                CheckFuncMin();
            }
            else if (numbetTask == 3)
            {
                Console.WriteLine("Задание №3:\n" +
                                    "Переделанная программа 'Пример использования коллекций'.\n");
                CheckCollect();
            }
            else if (numbetTask == 4)
            {
                Console.WriteLine("Задание №4:\n" +
                                    "Считываем файл различными способами'.\n");
                CheckReader();
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