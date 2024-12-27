using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Variables
    {
        // 3
        public class Student
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public ushort grade { get; set; }

            public override string ToString()
            {
                return $" Имя: {firstName}\n Фамилия: {lastName}\n Оценка {grade}\n";
            }
        }
        // 4
        public class Products
        {
            public string Name { get; set; }
            public ushort Price { get; set; }
            public string Category { get; set; }
        }
        // 5
        public class Job()
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string birthday { get; set; }
            public int dateOfEmployement { get; set; }
            public override string ToString()
            {
                return $" Имя: {firstName}\n Фамилия: {lastName}\n День рождения {birthday}\n Дата трудоустройства: {dateOfEmployement}\n";
            }
        }
        // 6
        public class Book()
        {
            public string name { get; set; }
            public string author { get; set; }
            public string genre { get; set; }
            public int releaseDate { get; set; }
            public override string ToString()
            {
                return $" Название: {name}\n Автор: {author}\n Жанр: {genre}\n Дата выхода: {releaseDate}\n";
            }
        }
        // 7
        public class Customer()
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string adress { get; set; }
            public int sumOfOrder { get; set; }
            public override string ToString()
            {
                return $" Имя: {firstName}\n Фамилия: {lastName}\n Адресс: {adress}\n Сумма заказа: {sumOfOrder}\n";
            }
        }
    }
}
