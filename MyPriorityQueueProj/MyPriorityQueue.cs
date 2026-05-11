using System.Collections;
using System.Runtime.CompilerServices;

namespace LinkedListLibrary;

public class PriorityQueue<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private Mylinkedlist<T> _items = new Mylinkedlist<T>();

    public void Enquene(T item)
    {
        if (_items.Count == 0)
        {
            _items.AddLast(item);
        }
        else
        {
            var current = _items.Head;

            while (current != null && current.Value.CompareTo(item) > 0)
            {
                current = current.Next;
            }

            if (current == null)
            {
                _items.AddLast(item);
            }
            else
            {
                _items.AddBefore(current, item);
            }
        }
    }

    public T Dequeue()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("The Queue is empty");
        T value = _items.Head.Value;
        _items.RemoveFirst();
        return value;
    }

    public T Peek()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("The Queue is empty");
        return _items.Head.Value;
    }

    public int Count => _items.Count;

    public void Clear()
    {
        throw new NotImplementedException();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }



}