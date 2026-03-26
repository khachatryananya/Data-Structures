using System.Collections;
using System.Numerics;
using ConsoleApp1;

namespace LinkedListLibrary;

public class Mylinkedlist<T> : ICollection<T>
{
    public MylinkedNode<T>? Head { get; private set; }
    public MylinkedNode<T>? Tail { get; private set; }

    #region ICollection

    public int Count { get; private set; }

    public bool IsReadOnly { get => false; }

    public void Add(T item)
    {
        AddFirst(item);
        //AddLast(item);
    }

    void ICollection<T>.Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    bool ICollection<T>.Contains(T item)
    {
        var current = Head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, item))
                return true;

            current = current.Next;
        }

        return false;
    }

    void ICollection<T>.CopyTo(T[] array, int arrayIndex)
    {
        var current = Head;

        while (current != null)
        {
            array[arrayIndex++] = current.Value;
            current = current.Next;
        }
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        var current = Head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
    }
    #endregion

    #region Add
    public void AddFirst(T item)
    {
        AddFirst(new MylinkedNode<T>(item));
    }
    private void AddFirst(MylinkedNode<T> node)
    {
        MylinkedNode<T>? Temp = Head;
        Head = node;
        Head.Next = Temp;
        Count++;
        if (Count == 1)
            Tail = Head;
    }

    public void AddLast(T item)
    {
        AddLast(new MylinkedNode<T>(item));
    }
    private void AddLast(MylinkedNode<T> node)
    {
        if (Head == null)
        {
            Head = node;
            Tail = node;
        }
        else
        {
            Tail!.Next = node;
            Tail = node;
        }
        Count++;
    }

    #endregion

    #region Remove
    public void RemoveFirst()
    {
        if (Count != 0)
        {
            Head = Head.Next;
            Count--;

            if (Count == 0)
                Tail = null;
        }
    }

    public void RemoveLast()
    {
        if (Head == null)
            throw new InvalidOperationException("Empty");

        if (Head == Tail)
        {
            Head = null;
            Tail = null;
            Count = 0;
            return;
        }

        var current = Head;

        while (current.Next != Tail)
        {
            current = current.Next;
        }

        current.Next = null;
        Tail = current;
        Count--;
    }
    #endregion
}