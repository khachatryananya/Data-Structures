using System.Collections;
using System.Collections.Generic;

namespace LinkedListLibrary;

public class MyStack<T> : IEnumerable<T>
{
    private Mylinkedlist<T> _items = new Mylinkedlist<T>();

    public int Count => _items.Count;

    public bool IsEmpty => Count == 0;

    public MyStack(ICollection<T> collection)
    {
        foreach (var item in collection)
        {
            Push(item);
        }
    }

    public void Push(T value)
    {
        _items.AddFirst(value);
    }

    public T Pop()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        var itemRemove = _items.Head!.Value;
        _items.RemoveFirst();
        return itemRemove;
    }

    public T Peek()
    {
        if (_items.Count == 0)
            throw new InvalidOperationException("Stack is empty");

        return _items.Head!.Value;
    }

    public void Clear()
    {
        while (!IsEmpty)
            Pop();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)_items).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}