using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoubleLinkedList
{
    class NodeDoubleLinkedList<T>
    {
        //конструктор 
        public NodeDoubleLinkedList(T value)
        {
            Value = value;
        }
        public NodeDoubleLinkedList(T value, NodeDoubleLinkedList<T> next)
        {
            Value = value;
            Next = next;
        }
        // значение узла (data)
        public T Value { get; set; }
        //  установка следущего узла в списке, если ничего то NULL (просто сам указатель) 
        public NodeDoubleLinkedList<T> Next { get; set; }
        public NodeDoubleLinkedList<T> Prev { get; set; } // предыдущий

    }
}
