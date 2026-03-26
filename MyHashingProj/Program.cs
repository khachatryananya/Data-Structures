namespace HashTableProj;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine(AdditiveHash("hello"));
        Console.WriteLine(FoldingHash("hello"));

        HashTable table = new HashTable(10);
        table.Insert("apple");
        table.Insert("banana");
        table.Insert("cherry");

        table.Print();

        Console.WriteLine(table.Search("apple"));
        Console.WriteLine(table.Search("grape"));

        table.Delete("apple");
        Console.WriteLine(table.Search("apple"));
    }

    private static int AdditiveHash(string input)
    {
        int currentHashValue = 0;
        foreach (char c in input)
        {
            unchecked
            {
                currentHashValue += (int)c;
            }
        }
        return currentHashValue;
    }

    private static int FoldingHash(string input)
    {
        int hashValue = 0;
        int startIndex = 0;
        int currentFourBytes;
        do
        {
            currentFourBytes = GetNextBytes(startIndex, input);
            unchecked
            {
                hashValue += currentFourBytes;
            }
            startIndex += 4;
        }
        while (currentFourBytes != 0);
        return hashValue;
    }

    private static int GetNextBytes(int startIndex, string str)
    {
        int currentFourBytes = 0;
        currentFourBytes += GetByte(str, startIndex);
        currentFourBytes += GetByte(str, startIndex + 1) << 8;
        currentFourBytes += GetByte(str, startIndex + 2) << 16;
        currentFourBytes += GetByte(str, startIndex + 3) << 24;
        return currentFourBytes;
    }

    private static int GetByte(string str, int index)
    {
        if (index < str.Length)
        {
            return (int)str[index];
        }
        return 0;
    }
}

internal class HashTable
{
    private readonly int _size;
    private readonly LinkedList<string>[] _buckets;

    public HashTable(int size)
    {
        _size = size;
        _buckets = new LinkedList<string>[size];
        for (int i = 0; i < size; i++)
            _buckets[i] = new LinkedList<string>();
    }

    private int GetIndex(string key)
    {
        int hash = 0;
        foreach (char c in key)
            unchecked { hash += (int)c; }
        return Math.Abs(hash) % _size;
    }

    public void Insert(string key)
    {
        int index = GetIndex(key);
        if (!_buckets[index].Contains(key))
            _buckets[index].AddLast(key);
    }

    public bool Search(string key)
    {
        int index = GetIndex(key);
        return _buckets[index].Contains(key);
    }

    public bool Delete(string key)
    {
        int index = GetIndex(key);
        return _buckets[index].Remove(key);
    }

    public void Print()
    {
        for (int i = 0; i < _size; i++)
        {
            Console.Write($"Bucket [{i}]: ");
            foreach (var item in _buckets[i])
                Console.Write(item + " -> ");
            Console.WriteLine("null");
        }
    }
}