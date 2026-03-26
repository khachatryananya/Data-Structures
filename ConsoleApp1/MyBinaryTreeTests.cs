using MyBinaryTreeProj;

var tree = new BinaryTree<int>();


tree.Add(10);
tree.Add(5);
tree.Add(15);
tree.Add(3);
tree.Add(7);
Console.WriteLine("Count: " + tree.Count);

Console.WriteLine("Contains 7: " + tree.Contains(7));
Console.WriteLine("Contains 99: " + tree.Contains(99));

Console.WriteLine("In-order: " + string.Join(", ", tree));


tree.Remove(5);
Console.WriteLine("After Remove(5): " + string.Join(", ", tree));
Console.WriteLine("Count: " + tree.Count);

tree.Clear();
Console.WriteLine("After Clear, Count: " + tree.Count);
