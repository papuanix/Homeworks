using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public class Library : IEquatable<Library>
    {
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Library objAsBook = obj as Library;
            if (objAsBook == null) return false;
            else return Equals(objAsBook);
        }
        public override int GetHashCode()
        {
            return Id;
        }
        public bool Equals(Library other)
        {
            if (other == null) return false;
            return (this.Id.Equals(other.Id));
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Edition { get; set; }

        string someName { get; set; }
        string someAuthor { get; set; }
        string someEdition { get; set; }
        int someId { get; set; }
        

        public static List<Library> books = new List<Library>()
        {
               new Library {Id = 101, Name = "Непобедимый", Author = "Станислав Лем", Edition = "KDA" },
               new Library {Id = 220, Name = "Марсианин", Author = "Энди Вейер", Edition = "Azbuka"},
               new Library {Id = 31, Name = "Все Грядущие Дни", Author = "Немо Рамджет", Edition = "Bookovka"},
               new Library {Id = 45, Name = "Зов Ктулху", Author = "Говард Ф. Лавкрафт", Edition = "Livelib"},
               new Library {Id = 541, Name = "Скотный Двор", Author = "Джордж Оруэлл", Edition = "USG" }
        };



        public override string ToString()
        {
            return $" Id: {Id}, Name: {Name}, Author: {Author}, Edition: {Edition}";
        }

        public void showBooksList()
        {
          Console.WriteLine("\n Список книг: ");
          foreach (var book in books)
          {
            Console.WriteLine(book);
          }
        }

        public void addNewBook()
        {
            int number = 0;
            bool active = true;
            do
            {
                Console.Write("\n 1) Введите цифровой Id вашей книги: ");
                try
                { 
                  someId = Convert.ToInt32(Console.ReadLine());
                } 
                catch(Exception ex) 
                { 
                    Console.WriteLine("\n Неверный формат ");
                    return;
                }
                Console.Write("\n 2) Введи название книги: ");
                someName = Console.ReadLine();
                Console.Write("\n 3) Введи имя автора: ");
                someAuthor = Console.ReadLine();
                Console.Write("\n 4) Введи название издания: ");
                someEdition = Console.ReadLine();
                Console.WriteLine($"\n Ваша книга:\n Id: {someId} \n Name: {someName} \n Author: {someAuthor} \n Edition: {someEdition} ");
                Console.WriteLine("\n 1) Подтвердить \n 2) Переименовать ");
                Console.Write("\n Введите номер операции: ");
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                } 
                catch(Exception ex)
                {
                    Console.WriteLine("\n Неверный формат ");
                    return;
                }
                switch (number) 
                {
                    case 1:
                        books.Add(new Library { Id = someId, Name = someName, Author = someAuthor, Edition = someEdition });
                        showBooksList();
                        Console.WriteLine("\n Благодарим за донат! \n Нажмите любую клавишу ");
                        active = false;
                        break;
                    case 2:
                        Console.WriteLine("\n Введите названия еще раз ");
                        break;
                }
            } while (active != false);
        }
        public void removeBook()
        {
            int number = 0;
            int someId = 0;
            showBooksList();
            Console.Write("\n Введите номер Id книги: ");
            try
            {
                someId = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex) 
            {
                Console.WriteLine("\n Неверный формат ");
            }
            Library book = books.Find(book => book.Id == someId);
            if (book != null)
            {
                books.Remove(new Library() { Id = someId });
                showBooksList();
                Console.WriteLine("\n Приятного чтения! ");
            }
            else Console.WriteLine("\n ! Книга с таким Id не найдена !");
        }
        public void Search() {
            int number = 0;
            string find;
            Console.WriteLine("\n 1) Поиск по названию \n 2) Поиск по автору \n 3) Поиск по изданию");
            Console.Write("\n Введите номер операции: ");
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n Неверный формат ");
            }
            switch (number)
            {
                case 1:
                    Console.Write(" Введи название книги из списка: ");
                    find = Console.ReadLine();
                    Library book1 = books.Find(book => book.Name.ToLower() == find.ToLower());
                    if (book1 != null)
                    {
                        Console.WriteLine($"\n Твоя книга: {book1}, приятного чтения! ");
                        Console.WriteLine("\n Нажмите любую клавишу");
                        Console.ReadKey();

                    }
                    else Console.WriteLine("\n ! Такого названия не найдено ! ");

                    break;
                case 2:
                    Console.Write(" Введи автора книги из списка: ");
                    find = Console.ReadLine();
                    Library book2 = books.Find(book => book.Author.ToLower() == find.ToLower());
                    if (book2 != null)
                    {
                        Console.WriteLine($"\n Твоя книга: {book2}, приятного чтения! ");
                        Console.WriteLine("\n Нажмите любую клавишу");
                        Console.ReadKey();
                        return;
                    }
                    else Console.WriteLine("\n ! Такого названия не найдено ! ");
                    break;

                case 3:
                    Console.Write(" Введи издание книги из списка: ");
                    find = Console.ReadLine();
                    Library book3 = books.Find(book => book.Edition.ToLower() == find.ToLower());
                    if (book3 != null)
                    {
                        Console.WriteLine($"\n Твоя книга: {book3}, приятного чтения! ");
                        Console.WriteLine("\n Нажмите любую клавишу");
                        Console.ReadKey();
                        return;


                    }
                    else Console.WriteLine("\n ! Такого названия не найдено ! "); ;
                    break;
            }
        }

        
    }
}
