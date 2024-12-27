using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Program : Variables
    {
        public static void Main(string[] args)
        {
            Console.Write("1) Слова с буквы А: ");
            WordsFilter();

            Console.Write("2) Одинаковые числа: ");
            TwoArrays();

            Console.WriteLine("3) Студент с максимальной оценкой: ");
            School();

            Console.WriteLine("4) Средняя цена фруктов: ");
            Shop();

            Console.WriteLine("\n 5) Работники работающие в компании больше 5 лет: ");
            Workers();

            Console.WriteLine(" 6) Книги жанра фантастика, которые вышли позже 2010 года: ");
            Books();

            Console.WriteLine(" 7) Люди с суммой заказа больше 1000$: ");
            Customers();

        }

        // 1) Написати програму на C#, яка отримує набір рядків зі словами та фільтрує лише ті, які починаються з літери "A".
        // Вивести результат на екран
        public static void WordsFilter()
        {
            List<string> words = new List<string>()
            {"Aurora", "Warhammer", "Book", "Array", "Diablo", "Already", "Apocalypse", "Root" };

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i][0] == 'A')
                {
                    Console.Write($" {words[i]} " );
                }
            }
            Console.WriteLine("\n");
        }

        //2) Створити два масиви цілих чисел різної довжини.
        //Використовуючи LINQ, знайти всі значення, які містяться в обох масивах та відобразити їх на екран.

        public static void TwoArrays()
        {
            short[] array1 = new short[] { 12, 15, 22, 91, 2, 5, 31, 27 };
            short[] array2 = new short[] { 5, 12, 34, 56, 89, 27};

            var sameNumbers = array1.Intersect(array2);

            foreach (var value in sameNumbers)
            {
                Console.Write($" {value} ");
            }
            Console.WriteLine("\n");
        }

        // 3) Написати програму, яка створює колекцію об'єктів класу Student, в яких є поля "Ім'я", "Прізвище" та "Оцінка".
        // Використовуючи LINQ, знайти студента з максимальною оцінкою та вивести його на екран.

        public static void School()
        {
            List<Student> students = new List<Student>()
            {
                new Student { firstName = "Pavel", lastName = "Durov", grade = 10 },
                new Student { firstName = "Kolya", lastName = "Black", grade = 9 },
                new Student { firstName = "Katya", lastName = "Nevezhina", grade = 11},
                new Student { firstName = "Natan", lastName = "Drake", grade = 5},
                new Student { firstName = "Peter", lastName = "Parker", grade = 12},
                new Student { firstName = "Eddie", lastName = "Broke", grade = 4}
            };
             
            var maxGrade = students.MaxBy(x => x.grade);


            foreach(var value in students.Where(grade => grade == maxGrade))
            {
                Console.WriteLine($"{value}");
            }
        }

        // 4) Створити колекцію об'єктів класу Product, в яких є поля "Назва", "Ціна" та "Категорія".
        // Використовуючи LINQ, згрупувати продукти за категорією та обчислити середню ціну кожної категорії.

        public static void Shop()
        {
            List<Products> products = new List<Products>
            {
               new Products { Name = "Киви", Price = 23, Category = "Фрукты" },
               new Products { Name = "Баклажаны", Price = 35, Category = "Овощи" },
               new Products { Name = "Спаржа", Price = 16, Category = "Овощи" },
               new Products { Name = "Бананы", Price = 27, Category = "Фрукты" },
               new Products { Name = "Молоко", Price = 51, Category = "Молочные продукты" },
               new Products { Name = "Говядина", Price = 42, Category = "Мясо" },
               new Products { Name = "Курица", Price = 32, Category = "Мясо" },
               new Products { Name = "Сыр", Price = 85, Category = "Молочные продукты" }
            };

            var groupedProducts = products.GroupBy(p => p.Category);

            var averagePrices = groupedProducts.ToDictionary(
            g => g.Key,
            g => g.Average(p => p.Price)
            );

            foreach (var category in averagePrices.Keys)
            {
                Console.WriteLine( $" Категория: {category}, Средняя цена: {averagePrices[category]:F2}");
            }
        }

        // 5) Створити колекцію об'єктів класу Employee, в яких є поля "Ім'я", "Прізвище", "Дата народження" та "Дата працевлаштування".
        // Використовуючи LINQ, знайти робітників, які працюють в компанії більше 5 років.

        public static void Workers()
        {
            List<Job> work = new List<Job>()
            {
                new Job {firstName = "Isaac", lastName = "Clarke", birthday = "November 16", dateOfEmployement = 2018},
                new Job {firstName = "Hoakin", lastName = "Phoenix", birthday = "September 21", dateOfEmployement = 2020},
                new Job {firstName = "Brad", lastName = "Pitt", birthday = "January 28", dateOfEmployement = 2023},
                new Job {firstName = "Kolya", lastName = "Black", birthday = "January 1", dateOfEmployement = 2016},
                new Job {firstName = "Vladimir", lastName = "Bloodovich", birthday = "April 19", dateOfEmployement = 2015}
            };

            var maxWorksYears = work.Where(x => 2024 - x.dateOfEmployement > 5);
            foreach (var workers in maxWorksYears)
            {
                Console.WriteLine($"{workers}");
            }
        }

        // 6) Створити колекцію об'єктів класу Book, в яких є поля "Назва", "Автор", "Рік видання" та "Жанр".
        // Використовуючи LINQ, знайти книги, які були видані після 2010 року та належать до жанру "Фантастика"

        public static void Books()
        {
            List<Book> books = new List<Book>()
            {
                new Book {name = "Дюна", author = "Фрэнк Герберт", genre = "Фантастика", releaseDate = 2015},
                new Book {name = "Солярис", author = "Станислав Лем", genre = "Фантастика", releaseDate = 2012},
                new Book {name = "Пришедший Извне", author = "Борис Надеждин", genre = "Роман", releaseDate = 2019},
                new Book {name = "Все Грядущие Дни", author = "Косемен", genre = "Спекулятивная Эволюция", releaseDate = 2006},
                new Book {name = "Поле Роз", author = "Мария Семёновна", genre = "Роман", releaseDate = 2011}
            };
            var result = books.Where(x => x.genre == "Фантастика" && x.releaseDate > 2010);
            foreach (var book in result)
            {
                Console.WriteLine($"{book}");
            }
        }

        // 7) Створити колекцію об'єктів класу Customer, в яких є поля "Ім'я", "Прізвище", "Адреса" та "Замовлення".
        // Використовуючи LINQ, знайти клієнтів, які зробили замовлення на суму більше 1000 грн та вивести їх замовлення у вигляді переліку.

        public static void Customers()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer {firstName = "Питер", lastName = "Паркер", adress = "Квинс Стрит 68", sumOfOrder = 953},
                new Customer {firstName = "Норман", lastName = "Осборн", adress = "Оскорп 13", sumOfOrder = 1050},
                new Customer {firstName = "Флинт", lastName = "Марко", adress = "71 Метрополоса", sumOfOrder = 500},
                new Customer {firstName = "Гарри", lastName = "Осборн", adress = "Оскорп 13", sumOfOrder = 54},
                new Customer {firstName = "Айзек", lastName = "Кларк", adress = "Ишимура 21", sumOfOrder = 2500},
                new Customer {firstName = "Анри", lastName = "Клеман", adress = "Жудэ де пари 1", sumOfOrder = 3000},
                new Customer {firstName = "Таси", lastName = "Трианон", adress = "Арка Свободы 33", sumOfOrder = 843},
                new Customer {firstName = "Леон", lastName = "Де Врис", adress = "Под Не Бэс 12", sumOfOrder = 159}
            };
            var result = customers.Where(x => x.sumOfOrder > 1000);
            foreach (var customer in result)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
