using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS._002.Task00._01
{
    public interface IMyLinkedListNode<T>
    {        
        IMyLinkedList<T> List { get; }        
        MyLinkedListNode<T> Next { get; }
        MyLinkedListNode<T> Previous { get; }        
        T Value { get; set; }
    }
}
