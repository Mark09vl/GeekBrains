//Коротких М.А.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MyHelper;

namespace HomeWorkNumber5
{
    public class MyMessage
    {
        public static void PrintWordsForMessage(string message, int sizeWord)
        {
            Console.WriteLine($"Текст: {message}");

            string[] words = MyFunctions.ParseString(message, " .:,;!\n");
            
            int count = 0;

            if (words.Length == 0)
            {
                Console.WriteLine($"\nСлова, которые содержат не более {sizeWord} букв не найдены.");
            }
            else
            {
                Console.WriteLine($"\nСлова, которые содержат не более {sizeWord} букв: ");
            }
            

            foreach (var word in words)
            {
                if (word.Length <= sizeWord)
                {
                    count++;
                    Console.WriteLine($"{count}. {word}");
                }
            }
        }

        public static void DeleteWordsForMessage(ref string message, char value)
        {
            string[] words = MyFunctions.ParseString(message, " .:,;!\n");

            message = "";

            foreach (var word in words)
            {
                Regex regex = new Regex(Convert.ToString(value));
                if (!regex.IsMatch(Convert.ToString(word[^1])))
                {
                    message += word + " ";
                }
            }
            Console.WriteLine(message);
        }

        public static string SearchBigWord(string message)
        {
            string result = "";

            string[] words = MyFunctions.ParseString(message, " .:,;!\n");

            foreach (var word in words)
            {
                if (word.Length > result.Length)
                {
                    result = word;
                }
            }

            return result;
        }

        public static StringBuilder LongWords(string message)
        {
            int lengthBigWord = 0;
            string[] words = MyFunctions.ParseString(message, " .:,;!\n");
            StringBuilder sb = new StringBuilder();
            foreach (var word in words)
            {
                if (word.Length > lengthBigWord)
                {
                    lengthBigWord = word.Length;
                }
            }
            foreach (var word in words)
            {
                if (word.Length == lengthBigWord)
                {
                    sb.Append(word + " ");
                }
            }
            return sb;
        }

        public struct MyWords
        {
            public string word;
            public int frequency;
            public MyWords(string name_, int frequency_)
            {
                word = name_;
                frequency = frequency_;
            }
            
        }

        public static void FrequencyAnalysis(string message, List<MyWords> myWords)
        {
            string[] words = MyFunctions.ParseString(message, " .:,;!\n");

            foreach (var word in words)
            {

                for (int i = 0; i < myWords.Count; ++i)
                {
                    var tmp = myWords[i];
                    if (word.ToLower() == tmp.word.ToLower())
                    {
                        tmp.frequency++;
                        myWords[i] = tmp;
                    }
                }
            }

            foreach (var word in myWords)
            {
                Console.WriteLine($"Слово «{word.word}» встречается в тексте {word.frequency} раз");
            }

        }
        public static void CheckFrequencyAnalysis(string message)
        {
            Console.WriteLine($"Текст в котором будет производиться частотный анализ: \n\n{message}\n");

            int listLength = Convert.ToInt32(MyFunctions.GetDouble("Введите количество слов для анализа: ", true));
            Console.WriteLine();
            List<MyWords> myWords = new List<MyWords>();
            for (int i = 0; i < listLength; i++)
            {
                myWords.Add(new MyWords (MyFunctions.GetString("Введите слово для проверки: ", 2, 0, true), 0));
            }
            Console.WriteLine();
            FrequencyAnalysis(message, myWords);
        }
    }

    class Program
    {

        #region Задание №1
        static void CheckLogin()
        {
            while (true)
            {
                string login = MyFunctions.GetString("Введите логин(2-10 символов): ", 2, 10, true);

                Regex regex = new Regex(@"\D");
                if (regex.IsMatch(Convert.ToString(login[0])) 
                    && MyFunctions.CheckValidValue(login, @"[^a-zA-z\d_]"))
                //if (!Char.IsNumber(pass[0]))
                {
                    break;
                }
                Console.WriteLine("\nВведен некорректрый логин!\n" +
                                    "Логин должен состоять из 2-10 букв латинского алфавита или цифрр, при этом цифра не может быть первой!\n");
            }

            Console.WriteLine("Поздравляем! Вы ввели корректрый логин!");
        }
        #endregion

        #region Задание №2
        static void CheckClassMessage()
        {
            while (true)
            {
                int numbetTask = Convert.ToInt32(MyFunctions.GetDouble("Введите номер задания(1-5): ", true, 1, 5, true, true));
                //— объектно - ориентированный язык программирования. 
                string message = "Мой дядя самых честных правил, \n" +
                                    "Когда не в шутку занемог, \n" +
                                    "Он уважать себя заставил \n" +
                                    "И лучше выдумать не мог. \n" +
                                    "Его пример другим наука; \n" +
                                    "Но, боже мой, какая скука \n" +
                                    "С больным сидеть и день и ночь, \n" +
                                    "Не отходя ни шагу прочь! \n" +
                                    "Какое низкое коварство \n" +
                                    "Полуживого забавлять, \n" +
                                    "Ему подушки поправлять, \n" +
                                    "Печально подносить лекарство, \n" +
                                    "Вздыхать и думать про себя: \n" +
                                    "Когда же черт возьмет тебя! \n";

                Console.Clear();

                if (numbetTask == 1)
                {
                    Console.WriteLine("1. Вывести только те слова сообщения,  которые содержат не более n букв.\n");

                    MyMessage.PrintWordsForMessage(message, 5);
                }
                else if (numbetTask == 2)
                {
                    Console.WriteLine("2. Удалить из сообщения все слова, которые заканчиваются на заданный символ.\n");

                    MyMessage.DeleteWordsForMessage(ref message, MyFunctions.GetChar("Введите символ, на который заканчиваются слова для удаления: "));
                    Console.WriteLine($"Полученное сообщение: \n{message}");
                }
                else if (numbetTask == 3)
                {
                    Console.WriteLine("3. Найти самое длинное слово сообщения.\n");
                    Console.WriteLine($"Самое длинное слово: \n{MyMessage.SearchBigWord(message)}");
                }
                else if (numbetTask == 4)
                {
                    Console.WriteLine("4. Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.\n");
                    Console.WriteLine($"Сформированная строка: \n{MyMessage.LongWords(message)}");
                }
                else if (numbetTask == 5)
                {
                    Console.WriteLine("5. Частотный анализ слов в тексте.\n");
                    MyMessage.CheckFrequencyAnalysis(message);
                }
                break;
            }

        }
        #endregion

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                int numbetTask = Convert.ToInt32(MyFunctions.GetDouble("Введите номер задания(1-2): ", true, 1, 2, true, true));

                Console.Clear();

                if (numbetTask == 1)
                {
                    Console.WriteLine("Задание №1:\n" +
                                        "Проверка корректности ввода логина.\n");
                    CheckLogin();
                }
                else if (numbetTask == 2)
                {
                    Console.WriteLine("Задание №2:\n" +
                                        "Разработать статический класс Message.\n");
                    CheckClassMessage();
                }
                else if (numbetTask == 3)
                {
                    Console.WriteLine("Задание №3:\n" +
                                        "Дописать класс для работы с одномерным массивом.\n");
                    //TestMyArray();
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
