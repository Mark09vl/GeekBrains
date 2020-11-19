//Коротких М.А.

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace MyHelperForm
{
    /// <summary>Список слов</summary>
    class CheckWord
    {
        string fileName;
        List<Dictionary> list;
        public string FileName
        {
            set { fileName = value; }
        }

        /// <summary>Конструктор</summary>
        /// <param name="fileName">Имя и путь к файлу</param>
        public CheckWord(string fileName)
        {
            this.fileName = fileName;
            list = new List<Dictionary>();
        }

        /// <summary>Добавить слово</summary>
        /// <param name="endText">Слово на английском</param>
        /// <param name="ruText">Слово на русском</param>
        public void Add(string endText, string ruText)
        {
            bool contain = list.Contains(new Dictionary(endText, ruText));
            if (!contain)
            {
                list.Add(new Dictionary(endText, ruText));
            }
            else
            {
                MessageBox.Show("Слово уже есть в списке!", "Внимание");
            }
        }

        /// <summary>Удалить слово</summary>
        /// <param name="wordToRemove">Слово из списка</param>
        public void Remove(Dictionary wordToRemove)
        {
            int index = list.IndexOf(wordToRemove);
            if (list != null 
                && index < list.Count 
                && index >= 0) 
            {
                list.RemoveAt(index);
            }
        }

        /// <summary>Индексатор</summary>
        /// <param name="index">Индекс</param>
        /// <returns></returns>
        public Dictionary this[int index]
        {
            get { return list[index]; }
        }

        /// <summary>Сериализация</summary>
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Dictionary>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }

        /// <summary>Десериализация</summary>
        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Dictionary>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Dictionary>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }
        /// <summary>Размер списка</summary>
        public int Count
        {
            get { return list.Count; }
        }
    }

    /// <summary>Слово с переводом</summary>
    [Serializable]
    public class Dictionary : IEquatable<Dictionary>
    {
        string englishText;
        string russianText;

        public string EnglishText { get { return englishText; } set { if (value.GetType() == typeof(string)) englishText = value; } }
        public string RussianText { get { return russianText; } set { if (value.GetType() == typeof(string)) russianText = value; } }

        /// <summary>Сравнение с другим словом</summary>
        /// <param name="another">Слово для сравнения</param>
        /// <returns></returns>
        public bool Equals(Dictionary another)
        {
            if (this.englishText == another.englishText 
                && this.russianText == another.russianText)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Пустой конструктор</summary>
        public Dictionary()
        {
        }

        /// <summary>Запись слова</summary>
        /// <param name="engText">Текст слова на англ</param>
        /// <param name="ruText">Текст слова на рус</param>
        public Dictionary(string engText, string ruText)
        {
            this.englishText = engText;
            this.russianText = ruText;
        }
    }

}
