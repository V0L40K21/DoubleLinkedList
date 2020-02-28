using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList<string> linkedList = new DoubleLinkedList<string>();
            // добавление элементов
            linkedList.AddLast("Audi");
            linkedList.AddLast("BMW");
            linkedList.AddLast("KIA");
            linkedList.AddLast("Hyundai");
            linkedList.AddLast("Honda");
            linkedList.AddLast("Mercedes");
            linkedList.AddFirst("Subaru");
            // Добавление элемента в произволную позицию
            Console.WriteLine("Введите желаемый индекс для вставки элемента");
            linkedList.AddInside("Opel", Convert.ToInt32(Console.ReadLine()));

           

            // вывод списка
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            // удаление элемента по индексу
            Console.WriteLine("Введите индекс удаляемого элемента");
            linkedList.RemoveAt(Convert.ToInt32(Console.ReadLine()));
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            // Поиск элемента по желаемому индексу
            Console.WriteLine("Введите индекс желаемого элемента");
            linkedList.FindIdByIndex(Convert.ToInt32(Console.ReadLine()));

            // Количество элементов в спике
            linkedList.GetCount();

            // Элементы списка с длиной названия < 4 символов
            var list = linkedList.Where(n => n.Length < 4).Select(n => n);
            Console.WriteLine("Элементы списка с длиной названия < 4 символов");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // Сортировка элементов по длине названия
            var sort = linkedList.OrderBy(item => item.Count()).Select(item => item);
            Console.WriteLine("Сортировка элементов по длине названия:");
            foreach (var item in sort)
            {
                Console.WriteLine(item);
            }


            Console.ReadLine();
        }
    }
}
