using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Program
    {
        public void Menu()
        {
            Console.WriteLine("\n Опции ");
            Console.WriteLine($" 1) Добавить свою книгу/переименовать \n 2) Взять книгу в пользование \n 3) Поиск доступных книг \n 4) Покинуть библиотеку");
        }


        public static void Main(string[] args)
        {
            Console.WriteLine(" Добро пожаловать в крутецкую библиотеку\n");
            var library = new Library();
            var program = new Program();
            var number = 0;
            bool active = true;
            library.showBooksList();
            program.Menu();
            Console.Write("\n Введите номер операции: ");
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex) 
            {
                Console.WriteLine("\n Неверный формат ");
                return;
            }
            do
            {
                switch (number)
                {
                    case 1:
                        library.addNewBook();
                        active = false;
                        break;
                    case 2:
                        library.removeBook();
                        active = false;
                        break;
                    case 3:
                        library.Search();
                        active = false;
                        break;
                    case 4:
                        active = false;
                        Console.WriteLine("\n Всего хорошего, заходите еще!");
                        break;
                }
            } while (active != false);
            
        }
    }
}
