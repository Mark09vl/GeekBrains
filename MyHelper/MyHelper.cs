//Коротких М.А.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyHelper
{

    #region Работа с массивами
    /// <summary>Разбивает строку по определенным символам на массив строк.</summary>
    /// <param name="text">Строка для разбиения</param>
    /// <param name="separators">Символы по которым разбиваем</param>
    /// <returns></returns>
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

        /// <summary>Рассчитывает сумму всех значений.</summary>
        /// <returns></returns>
        public int Sum()
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                count += arr[i];
            }
            return count;
        }

        /// <summary>Меняет плюс на минус и наоборот всех значений.</summary>
        /// <returns></returns>
        public void Inverse()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = -1 * arr[i];
            }
        }

        /// <summary>Умнажает все знаения на число.</summary>
        /// <param name="value">Число умножения</param>
        /// <returns></returns>
        public int Multi(int value)
        {
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                count += arr[i] * value;
            }
            return count;
        }

        /// <summary>Находит максимальное значение.</summary>
        /// <returns></returns>
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

        /// <summary>Выводит массив в строку.</summary>
        /// <returns></returns>
        public string ToString()
        {
            string stringarray = "";
            foreach (int x in arr)
            {
                stringarray += x + " ";
            }
            return stringarray;
        }
    }
    #endregion


    public class MyFunctions
    {

        #region Структуры
        /// <summary>Структура человека с необходимыми данными</summary>
        /// <param name="name">Имя</param>
        /// <param name="surName">Фамилия</param>
        /// <param name="years">Возраст</param>
        /// <param name="height">Рост</param>
        /// <param name="weight">Вес</param>
        /// <param name="indexMass">Индекс массы</param>
        /// <returns></returns>
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

        #region Конвертеры
        /// <summary>Конвертирует CSV в XML.</summary>
        /// <param name="fileNameOpen">Имя csv файла</param>
        /// <param name="fileNameSave">Имя xml файла</param>
        public static void ConverterCSVinXML(string fileNameOpen, string fileNameSave)
        {
            string[] lines = File.ReadAllLines(fileNameOpen, Encoding.GetEncoding(1251));
            string[] headers = { "Name", "Surname", "University", "Faculty", "Department", "Age", "Course", "Group", "City" };

            var xml = new XElement("Students",
               lines.Where((line, index) => index > 0).Select(line => new XElement("StudentIndo",
                  line.Split(';').Select((column, index) => new XElement(headers[index], column)))));

            xml.Save(fileNameSave);
        }

        #endregion

        #region  Функции возвращающие значение введенное пользователем 
        /// <summary>Задает вопрос и возвращает переменную типа double. Проверяет на некорректное значение.</summary>
        /// <param name="massege">Сообщение</param>
        /// <param name="thisIsInt">Проверка на целое число</param>
        /// <param name="minRange">Минимальное значение</param>
        /// <param name="maxRange">Максимальное значение</param>
        /// <param name="sizeMin">Использовать минимальное значение</param>
        /// <param name="sizeMax">Использовать максимальное значение</param>
        /// <returns></returns>
        public static double GetDouble(string massege, bool thisIsInt = false, double minRange = 0, double maxRange = 0, bool sizeMin = false, bool sizeMax = false) 
        {
            Console.Write(massege);

            bool tryOk = Double.TryParse(Console.ReadLine(), out double result);

            if ((sizeMin == true && result < minRange) 
                || (sizeMax == true && result > maxRange) 
                || (thisIsInt && result != Math.Truncate(result)) || !tryOk)
            {
                Console.WriteLine("\nВведено некорректное значение!");
                result = GetDouble(massege, thisIsInt, minRange, maxRange, sizeMin, sizeMax);
            }

            return result;
        }

        /// <summary>Задает вопрос и возвращает переменную типа string.</summary>
        /// <param name="massege">Сообщение</param>
        /// <param name="minRange">Минимальное значение</param>
        /// <param name="maxRange">Максимальное значение</param>
        /// <param name="sizeMin">Использовать минимальное значение</param>
        /// <param name="sizeMax">Использовать максимальное значение</param>
        /// <returns></returns>
        public static string GetString(string massege, int minRange = 0, int maxRange = 0, bool sizeMin = false, bool sizeMax = false)
        {
            string result;

            while (true)
            {
                Console.Write(massege);
                result = Console.ReadLine();
                if ((sizeMin == true && result.Length >= minRange) 
                    || (sizeMax == true && result.Length <= maxRange))
                {
                    break;
                }
                Console.WriteLine("\nВведено некорректное значение!");
            }
                
            return result;
        }

        /// <summary>Задает вопрос и возвращает переменную типа string.</summary>
        /// <param name="massege">Сообщение</param>
        /// <returns></returns>
        public static char GetChar(string massege)
        {
            char result;

            while (true)
            {
                Console.Write(massege);
                if (Char.TryParse(Console.ReadLine(), out result))
                {
                    break;
                }
                Console.WriteLine("\nВведено некорректное значение!");
            }

            return result;
        }

        /// <summary>Задает вопрос и возвращает переменную типа bool.</summary>
        /// <param name="massege">Сообщение</param>
        /// <returns></returns>
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
        /// <summary>Считает количество символов в double.</summary>
        /// <param name="value">Число для расчета</param>
        /// <param name="del">Удаляемые символы при расчете</param>
        /// <returns></returns>
        public static int GetLengthValue(double value, char[] del)
        {
            return value.ToString().Trim(del).Length;
        }
        public static int GetRandomValue(int minRange = 0, int maxRange = 0)
        {
            Random rnd = new Random();

            int value = rnd.Next(minRange, maxRange);

            return value;
        }

        #endregion

        #region Работа с файлами

        #region Чтение

        /// <summary>Считывает файл при помощи FileStream</summary>
        /// <param name="filename">Имя файла</param>
        /// <returns></returns>
        public static byte[] FileStreamSampleRead(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] byteArray = new byte[fs.Length];
            
            for (int i = 0; i < fs.Length; i++)
            {
                byteArray[i] = (byte)fs.ReadByte();
            }

            fs.Close();
            return byteArray;
        }

        /// <summary>Считывает файл при помощи BinaryStream</summary>
        /// <param name="filename">Имя файла</param>
        /// <returns></returns>
        public static int[] BinaryStreamSampleRead(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            int[] intArr = new int[fs.Length / 4];
            BinaryReader br = new BinaryReader(fs);
            
            for (int i = 0; i < fs.Length / 4; i++)
            {
                intArr[i] = br.ReadInt32();
            }

            fs.Close();
            return intArr;
        }

        /// <summary>Считывает файл при помощи StreamReader</summary>
        /// <param name="filename">Имя файла</param>
        /// <returns></returns>
        public static string StreamReaderSample(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string result = sr.ReadToEnd();

            fs.Close();
            return result;
        }

        /// <summary>Считывает файл при помощи BufferedStream</summary>
        /// <param name="filename">Имя файла</param>
        /// <returns></returns>
        public static byte[] BufferedStreamSampleRead(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            int countPart = 4;  //количество частей
            int bufsize = (int)(fs.Length / countPart);
            byte[] buffer = new byte[fs.Length];
            BufferedStream bs = new BufferedStream(fs, bufsize);
            
            for (int i = 0; i < countPart; i++)
            {
                bs.Read(buffer, 0, (int)bufsize);
            }

            fs.Close();
            return buffer;
        }

        #endregion


        //------------------------------------------------------------------------------------------------------------------


        #region Запись
        /// <summary>Записывает в файл при помощи FileStream</summary>
        /// <param name="filename">Имя файла</param>
        /// <param name="size">Размер файла</param>
        /// <returns></returns>
        public static long FileStreamSampleWrite(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            
            for (int i = 0; i < size; i++)
            {
                fs.WriteByte(0);
            }

            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>Записывает в файл при помощи BinaryStream</summary>
        /// <param name="filename">Имя файла</param>
        /// <param name="size">Размер файла</param>
        /// <returns></returns>
        public static long BinaryStreamSampleWrite(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            
            for (int i = 0; i < size; i++)
            {
                bw.Write((byte)0);
            }

            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>Записывает в файл при помощи StreamReader</summary>
        /// <param name="filename">Имя файла</param>
        /// <param name="size">Размер файла</param>
        /// <returns></returns>
        public static long StreamWriterSampleWrite(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            
            for (int i = 0; i < size; i++)
            {
                sw.Write(0);
            }

            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>Записывает в файл при помощи BufferedStream</summary>
        /// <param name="filename">Имя файла</param>
        /// <param name="size">Размер файла</param>
        /// <returns></returns>
        public static long BufferedStreamSampleWrite(string filename, long size)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            int countPart = 4;  //количество частей
            int bufsize = (int)(size / countPart);
            byte[] buffer = new byte[size];
            BufferedStream bs = new BufferedStream(fs, bufsize);

            for (int i = 0; i < countPart; i++)
            {
                bs.Write(buffer, 0, (int)bufsize);
            }
            
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        #endregion

        #endregion





        #region Мелочи
        /// <summary>Приостанавливает выполнение кода до нажатия кнопки.</summary>
        /// <returns></returns>
        public static void PauseConsole()
        {
            Console.ReadKey();
        }

        /// <summary>Считает расстояние между двумя точками.</summary>
        /// <param name="x1">X первой точки</param>
        /// <param name="y1">Y первой точки</param>
        /// <param name="x2">X второй точки</param>
        /// <param name="y2">Y второй точки</param>
        /// <returns></returns>
        public static double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        /// <summary>Находит минимальное значение в массиве.</summary>
        /// <param name="array">Массив чисел</param>
        /// <returns></returns>
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

        /// <summary>Проверяет, хорошее ли значение.</summary>
        /// <param name="value">Число для проверки</param>
        /// <returns></returns>
        public static bool CheckGoodValue(int value)
        {
            int tempValue = value;
            int sumValue = 0;
            while (tempValue > 0)
            {
                sumValue += tempValue % 10;
                tempValue /= 10;
            }
            return value % sumValue == 0;

        }

        /// <summary>Рассчитывает индекс массы человека.</summary>
        /// <param name="person">Структура человека с необходимыми данными</param>
        /// <returns></returns>
        public static double GetIndexMass(PersonStruct person)
        {
            return person.weight / ((person.height / 100) * (person.height / 100));
        }

        /// <summary>Рассчитывает сколько осталось до идеального индекса массы.</summary>
        /// <param name="person">Структура человека с необходимыми данными</param>
        /// <param name="greatIndexMass">Индекс к которому стремимся</param>
        /// <returns></returns>
        public static double GetMassFromGreatIndex(PersonStruct person, double greatIndexMass)
        {
            return greatIndexMass * (person.height / 100) * (person.height / 100);
        }

        /// <summary>Проверяет подходит ли значение под заданную маску.</summary>
        /// <param name="value">Строка для проверки</param>
        /// <param name="mask">Маска для проверки</param>
        /// <returns></returns>
        public static bool CheckValidValue(string value, string mask)
        {
            return !string.IsNullOrEmpty(value) && !Regex.IsMatch(value, mask);
        }

        /// <summary>Разбивает строку по определенным символам на массив строк.</summary>
        /// <param name="text">Строка для разбиения</param>
        /// <param name="separators">Символы по которым разбиваем</param>
        /// <returns></returns>
        public static string[] ParseString(string text, string separators)
        {
            return text.Split(separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }
        #endregion
    }

    public class Question
    {
        string text;       // Текст вопроса
        bool trueFalse;    // Правда или нет

        public string Text { get { return text; } set { if (value.GetType() == typeof(string)) text = value; } }
        public bool TrueFalse { get { return trueFalse; } set { if (value.GetType() == typeof(bool)) trueFalse = value; } }


        /// <summary>Для сериализации приводится пустой конструктор</summary>
        public Question()
        {
        }

        /// <summary>Метод записи вопроса</summary>
        /// <param name="text">Текст вопроса</param>
        /// <param name="trueFalse">Правильный ответ</param>
        public Question(string text, bool trueFalse)
        {
            this.text = text;
            this.trueFalse = trueFalse;
        }
    }

    public class TrueFalse
    {
        string fileName;
        List<Question> list;
        public string FileName
        {
            set { fileName = value; }
        }

        /// <summary>Конструктор записывает путь к файлу и инициализирует пустой список вопросов</summary>
        /// <param name="fileName">Имя и путь к файлу</param>
        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }

        /// <summary>Метод добавления вопроса</summary>
        /// <param name="text">Текст вопроса</param>
        /// <param name="trueFalse">Ответ на вопрос</param>
        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }

        /// <summary>Метод удаления вопроса</summary>
        /// <param name="index">Индекс вопроса в списке</param>
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }

        /// <summary>Индексатор - свойство для доступа к закрытому объекту</summary>
        /// <param name="index">Индекс вопроса</param>
        /// <returns></returns>
        public Question this[int index]
        {
            get { return list[index]; }
        }

        /// <summary>Метод сериализации списка вопросов</summary>
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }

        /// <summary>Метод десериализации списка вопросов</summary>
        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Question>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }
        /// <summary>Свойство возвращает размер списка вопросов</summary>
        public int Count
        {
            get { return list.Count; }
        }
    }

}
