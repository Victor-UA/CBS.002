using System;

namespace CBS._002.Task00._01
{
    public sealed class MyLinkedListNode<T>: IMyLinkedListNode<T>
    {
        public MyLinkedListNode(T value)
        {
            this.Value = value;
        }

        public IMyLinkedList<T> List { get; internal set; }

        public MyLinkedListNode<T> Next { get; internal set; }

        public MyLinkedListNode<T> Previous { get; internal set; }

        public T Value { get; set; }        

        internal void Clear()
        {
            List = null;
            Next = Previous = null;
            Value = default(T);
        }
    }
}