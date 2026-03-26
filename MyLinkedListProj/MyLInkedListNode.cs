namespace ConsoleApp1;

public class MylinkedNode<T>
{
    public T Value { get; set; }
    public MylinkedNode<T>? Next { get; set; }
    public MylinkedNode(T value)
    {
        this.Value = value;
    }

}