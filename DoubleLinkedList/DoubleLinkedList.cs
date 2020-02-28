using System;
using System.Collections;
using System.Collections.Generic;

namespace DoubleLinkedList
{
    internal class DoubleLinkedList<T> : IEnumerable<T>
    {
        private NodeDoubleLinkedList<T> first;
        private NodeDoubleLinkedList<T> last;
        private uint Count { get; set; }


        public T this[int index]
        {
            get
            {
                if (index < 0)
                    throw new ArgumentOutOfRangeException();
                NodeDoubleLinkedList<T> current = first;
                for (int i = 0; i < index; i++)
                {
                    if (current.Next == null)
                        throw new ArgumentOutOfRangeException();
                    current = current.Next;
                }
                return current.Value;
            }
        } // индексатор

        

        public void AddFirst(T value)
        {
            NodeDoubleLinkedList<T> node = new NodeDoubleLinkedList<T>(value);
            NodeDoubleLinkedList<T> temp = first;
            first = node; 
            first.Next = node;
            first.Next = temp; 
            if (Count == 0)
                last = first;
            else
                temp.Prev = first;
            Count++;
        } // Добавление элемента в начало списка



        public void AddLast(T value)
        {
            NodeDoubleLinkedList<T> node = new NodeDoubleLinkedList<T>(value);
            if (Count == 0)
                first = node;
            else
            {
                last.Next = node; 
                node.Prev = last; 
            }
            last = node; 
            Count++;
        } // Добавление элемента в конец списка



        public void AddInside(T value, int index) 
        {
            if (index > Count || index < 0)
                throw new ArgumentOutOfRangeException();
            if (index == 0)
                AddFirst(value);
            else if (index == (Count - 1))
                AddLast(value);
            else
            {
                NodeDoubleLinkedList<T> currentNode = first;
                for (int i = 0; i < index - 1; i++)
                {
                    currentNode = currentNode.Next;
                }
                NodeDoubleLinkedList<T> node = new NodeDoubleLinkedList<T>(value, currentNode.Next);
                currentNode.Next = node;
                Count++;
                Console.WriteLine("Элемент {0} добавлен в позицию с индексом {1}", value, index);
            }
        } // Добавление элемента в желаемую позицию по индексу



        public T RemoveAt(int index)
        {
            if (index > Count || index < 0)
                throw new ArgumentOutOfRangeException();
            T removedData;
            if (index == 0)
                removedData = RemoveFirst();
            else if (index == (Count - 1))
                removedData = RemoveLast();
            else
            {
                NodeDoubleLinkedList<T> current = first;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                removedData = current.Value;
                current.Next = current.Next.Next;
                Count--;
            }
            Console.WriteLine("Элемент с индексом {0} удалён", index);
            return removedData;
        } // удаление по индексу начиная с 0.



        public T RemoveFirst()
        {
            T removedData = first.Value;
            if (Count != 0)
            {
                first = first.Next;
                if (Count == 0)
                    last = null;
                else
                    first.Prev = null;
            }
            Count--;
            return removedData;
        } // Удаление первого элемента списка



        public T RemoveLast()
        {
            T removedData = last.Value;
            switch (Count)
            {
                case 0:
                    return removedData;
                case 1:
                    first = last = null;
                    break;
                default:
                    last.Prev.Next = null;
                    last = last.Prev;
                    break;
            }
            Count--;
            return removedData;
        } // Удаление последнего элемента списка



        public int FindIdByIndex(int index) 
        {
            NodeDoubleLinkedList<T> current = first;
            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                    Console.WriteLine("Элемент с индексом {0} в списке имеет значение {1}", index, current.Value);
                current = current.Next;
            }
            // нету в списке
            return -1;
        } // Удаление элемента списка по желаемому индексу



        public void GetCount()
        {
            Console.WriteLine("Количество элементов в списке = {0}", Count);
        } // Количество элементов в списке


        


        public IEnumerator<T> GetEnumerator()
        {
            NodeDoubleLinkedList<T> current = first;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        } // Возвращает экземпляр интерфейса IEnumerator <T>


       


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
