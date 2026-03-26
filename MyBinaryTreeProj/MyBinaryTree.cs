using System.Collections;

namespace MyBinaryTreeProj;

public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
{
    private BinaryTreeNode<T>? _head;
    private int _count;

    public int Count => _count;

    #region Add
    public void Add(T value)
    {
        BinaryTreeNode<T> newNode = new BinaryTreeNode<T>(value);

        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            BinaryTreeNode<T> current = _head;
            while (true)
            {
                int result = value.CompareTo(current.Value);

                if (result < 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = newNode;
                        break;
                    }
                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = newNode;
                        break;
                    }
                    current = current.Right;
                }
            }
        }
        _count++;
    }
    #endregion

    #region Contains
    public bool Contains(T value)
    {
        BinaryTreeNode<T>? current = _head;

        while (current != null)
        {
            int result = value.CompareTo(current.Value);
            if (result == 0) return true;

            current = result < 0 ? current.Left : current.Right;
        }

        return false;
    }
    #endregion

    #region Remove
    public bool Remove(T value)
    {
        if (_head == null) return false;

        BinaryTreeNode<T>? parent = null;
        BinaryTreeNode<T>? current = _head;

        while (current != null)
        {
            int result = value.CompareTo(current.Value);
            if (result < 0)
            {
                parent = current;
                current = current.Left;
            }
            else if (result > 0)
            {
                parent = current;
                current = current.Right;
            }
            else break;
        }

        if (current == null) return false;

        if (current.Right == null)
        {
            ReplaceNode(parent, current, current.Left);
        }
        else if (current.Left == null)
        {
            ReplaceNode(parent, current, current.Right);
        }
        else
        {
            BinaryTreeNode<T> successorParent = current;
            BinaryTreeNode<T> successor = current.Right;

            while (successor.Left != null)
            {
                successorParent = successor;
                successor = successor.Left;
            }

            current.Value = successor.Value;

            ReplaceNode(successorParent, successor, successor.Right);
        }

        _count--;
        return true;
    }

    private void ReplaceNode(BinaryTreeNode<T>? parent, BinaryTreeNode<T> node, BinaryTreeNode<T>? newNode)
    {
        if (parent == null)
            _head = newNode;
        else if (parent.Left == node)
            parent.Left = newNode;
        else
            parent.Right = newNode;
    }
    #endregion

    #region Enumeration (In-Order Traversal)
    public IEnumerator<T> GetEnumerator()
    {
        return InOrderTraversal(_head).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerable<T> InOrderTraversal(BinaryTreeNode<T>? node)
    {
        if (node == null) yield break;

        foreach (var left in InOrderTraversal(node.Left))
            yield return left;

        yield return node.Value;

        foreach (var right in InOrderTraversal(node.Right))
            yield return right;
    }
    #endregion

    public void Clear()
    {
        _head = null;
        _count = 0;
    }
}