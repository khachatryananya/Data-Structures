using LinkedListLibrary;

var queue = new MyQueue<int>();

queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);

Console.WriteLine("Count: " + queue.Count);
Console.WriteLine("Peek: " + queue.Peek());

Console.WriteLine("Dequeue: " + queue.Dequeue());
Console.WriteLine("Dequeue: " + queue.Dequeue());
Console.WriteLine("Count: " + queue.Count);

queue.Enqueue(10);
queue.Enqueue(20);
Console.WriteLine("\n result");
foreach (var item in queue)
{
    Console.WriteLine(item);
}

queue.Clear();
Console.WriteLine("\nCount after Clear: " + queue.Count);

try
{
    queue.Dequeue();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Exception: " + ex.Message);
}
