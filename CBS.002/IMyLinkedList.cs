using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS._002.Task00._01
{
    public interface IMyLinkedList<T>: ICollection<T>, IEnumerable<MyLinkedListNode<T>>
    {
        MyLinkedListNode<T> First { get; }
        MyLinkedListNode<T> Last { get; }        
        new MyLinkedListNode<T> Add(T value);
        MyLinkedListNode<T> AddAfter(MyLinkedListNode<T> node, T value);
        MyLinkedListNode<T> AddBefore(MyLinkedListNode<T> node, T value);
        void Remove(MyLinkedListNode<T> node);
    }
}
