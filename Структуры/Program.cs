using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Структуры
{
    class Program
    {
        private static List<Book> _books;

        private static Book _book;

        private static string _fileName;

        static void Main(string[] args)
        {
            Console.Write("Задайте имя файла для сохранения данных: ");

            _fileName = Console.ReadLine();

            string continueAdd = "";

            do
            {
                _book = new Book();

                _book.NewBook();

                WriteData(_book);

                Console.Write("Желаете добавить новую книгу? (Y/N): ");

                continueAdd = Console.ReadLine();

                Console.Clear();
            }
            while (continueAdd != "N");

            ReadData();

            PrintMore150();
        }

        static void WriteData(Book book)
        {
            using (StreamWriter writer = new StreamWriter(_fileName, true, Encoding.UTF8))
            {
                writer.WriteLine($"{book._author} {book._edition} {book._numberPages} {book._publicationDate}");
            }
        }

        static void ReadData()
        {
            _books = new List<Book>();

            using (StreamReader reader = new StreamReader(_fileName, Encoding.Default))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');

                    _book = new Book()
                    {
                        _author = data[0],

                        _numberPages = Convert.ToInt32(data[1]),

                        _edition = Convert.ToInt32(data[2]),

                        _publicationDate = Convert.ToDateTime(data[3])
                    };

                    _books.Add(_book);
                }
            }
        }

        static void PrintAll()
        {
            Console.WriteLine("Все книги: ");

            foreach (var items in _books)
            {
                Console.WriteLine(items.ToString());
            }
        }

        static void PrintMore150()
        {
            Console.WriteLine("Книги с числом страниц больше 150: ");

            foreach (var items in _books.Where(w => w._numberPages > 150))
            {
                Console.WriteLine(items.ToString());
            }
        }
    }
    public struct Book
    {
        public string _author;

        public int _numberPages;

        public int _edition;

        public DateTime _publicationDate;

        public void NewBook()
        {
            Console.WriteLine("Добавление информации о книге:");

            Console.Write("Автор: ");
            _author = Console.ReadLine();

            Console.Write("Количество страниц: ");
            _numberPages = Convert.ToInt32(Console.ReadLine());

            Console.Write("Тираж: ");
            _edition = Convert.ToInt32(Console.ReadLine());

            Console.Write("Год издания: ");
            _publicationDate = Convert.ToDateTime(Console.ReadLine());
        }

        public override string ToString()
        {
            return $"Автор: {_author}, Количество страниц: {_numberPages}, Тираж: {_edition} экземпляров, Год издания: {_publicationDate}";
        }
    }
}