using System;
using System.Collections;
using System.Collections.Generic;
using LinkedListLibrary;

namespace LinkedListLibrary;

public class Queue<T> : IEnumerable<T>
{
    public Mylinkedlist<T> _list = new Mylinkedlist<T>();
    public void Enqueue(T item)
    {
        _list.AddLast(item);
    }
    public T Dequeue()
    {
        if (_list.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty");
        }

        T value = _list.Head!.Value;

        _list.RemoveFirst();

        return value;
    }

    public T Peek()
    {
        if (_list.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty");
        }

        return _list.Head!.Value;
    }


    public int Count
    {
        get
        {
            return _list.Count;
        }
    }

    public void Clear()
    {
        ((ICollection<T>)_list).Clear();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)_list).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}