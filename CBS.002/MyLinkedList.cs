using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS._002.Task00._01
{
    public class MyLinkedList<T>: IMyLinkedList<T>
    {

        public MyLinkedList()
        {
            First = null;
            Last = null;
            Count = 0;
        }

        
        public MyLinkedListNode<T> First { get; private set; }

        public MyLinkedListNode<T> Last { get; private set; }

        public int Count { get; private set; }

        public bool IsReadOnly { get; set; }

        public MyLinkedListNode<T> Add(T value)
        {
            if (IsReadOnly)
            {
                throw new Exception("The list is ReadOnly");
            }

            return AddAfter(Last, value);                
        }

        public MyLinkedListNode<T> AddAfter(MyLinkedListNode<T> node, T value)
        {
            if (IsReadOnly)
            {
                throw new Exception("The list is ReadOnly");
            }

            var newNode = new MyLinkedListNode<T>(value)
            {
                List = this,
                Previous = node
            };

            if (node == null)
            {
                if (First != null)
                {
                    return AddBefore(First, value);
                }
                else
                {                    
                    First = Last = newNode;
                    newNode.Next = null;
                }
            }
            else
            {
                newNode.Next = node.Next;                
                node.Next = newNode;
                if (newNode.Next == null)
                {
                    Last = newNode;
                }
                else
                {
                    newNode.Next.Previous = newNode;
                }
            }
            Count++;
            return newNode;
        }

        public MyLinkedListNode<T> AddBefore(MyLinkedListNode<T> node, T value)
        {
            if (IsReadOnly)
            {
                throw new Exception("The list is ReadOnly");
            }

            if (node == null)
            {
                throw new ArgumentNullException("Node cannot be null");
            }

            var newNode = new MyLinkedListNode<T>(value)
            {
                List = this,
                Previous = node.Previous,
                Next = node
            };            
            node.Previous = newNode;
            if (newNode.Previous == null)
            {
                First = newNode;
            }
            else
            {
                newNode.Previous.Next = newNode;
            }
            Count++;
            return newNode;
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new Exception("The list is ReadOnly");
            }

            foreach (var node in this as IEnumerable<MyLinkedListNode<T>>)
            {
                node.Clear();
            }
            First = Last = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var value in this)
            {
                if (value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Target array is null");
            }
            if (array.Length < Count - arrayIndex)
            {
                throw new ArgumentException($"Target array length [{array.Length}] is less than needed: [{Count - arrayIndex}]");
            }

            int i = 0;
            foreach (var item in this)
            {
                if (i >= arrayIndex)
                {
                    array[i - arrayIndex] = item;
                }
                i++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = First;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        public void Remove(MyLinkedListNode<T> node)
        {
            if (IsReadOnly)
            {
                throw new Exception("The list is ReadOnly");
            }

            if (node.List == this)
            {
                if (node.Previous == null)
                {
                    First = node.Next;
                }
                else
                {
                    node.Previous.Next = node.Next;
                }
                if (node.Next == null)
                {
                    Last = node.Previous;
                }
                else
                {
                    node.Next.Previous = node.Previous;
                }
                node.Clear();
                //node.List = null;
                //node.Next = node.Previous = null;
                Count--;
            }
            else
            {
                throw new ArgumentException("The list doesn't contain this node");
            }
        }

        public bool Remove(T value)
        {
            if (IsReadOnly)
            {
                throw new Exception("The list is ReadOnly");
            }

            foreach (var node in this as IEnumerable<MyLinkedListNode<T>>)
            {
                if (node.Value.Equals(value))
                {
                    Remove(node);
                    return true;
                }
            }
            return false;
        }

        void ICollection<T>.Add(T value)
        {
            if (IsReadOnly)
            {
                throw new Exception("The list is ReadOnly");
            }

            Add(value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<MyLinkedListNode<T>> IEnumerable<MyLinkedListNode<T>>.GetEnumerator()
        {
            var node = First;
            while (node != null)
            {
                yield return node;
                node = node.Next;
            }
        }

        public override string ToString()
        {
            string data = "";
            foreach (var item in this)
            {
                data = string.Concat(data, string.IsNullOrEmpty(data) ? "" : ",", item);
            }
            string result = string.Concat(
                "First: ", First == null ? "NULL" : First.Value.ToString(), 
                $"\nData: ", string.IsNullOrEmpty(data) ? "NULL" : data,
                "\nLast: ", Last == null ? "NULL" : Last.Value.ToString(),
                $"\nCount: {Count}"
                );
            return result;
        }
    }
}
