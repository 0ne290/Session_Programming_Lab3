namespace Core;

public class SinglyLinkedList
{
    private class Node
    {
        public required int Value { get; init; }

        public Node? Next { get; set; }
    }
    
    // Можно было бы построить список за один проход, начав с хвоста, а не с головы.
    public SinglyLinkedList(string text)
    {
        var nodes = text.Split(",").Select(number => new Node { Value = Math.Abs(int.Parse(number.Trim())) }).ToList();

        for (var i = 0; i < nodes.Count - 1; i++)
            nodes[i].Next = nodes[i + 1];

        _head = nodes[0];
    }

    public SinglyLinkedList RemovePrimeNumbers()
    {
        var current = _head;
        Node prev = null!;
        
        while (current != null)
        {
            if (IsPrime(current.Value))
            {
                if (current == _head)
                {
                    _head = current.Next;
                    current = _head;
                    
                    continue;
                }
                
                prev.Next = current.Next;
                current = current.Next;
                
                continue;
            }

            prev = current;
            current = current.Next;
        }

        return this;
    }

    public static bool IsPrime(int number)
    {
        if (number is 0 or 1)
            return false;
        
        for (var i = 2; i <= number / 2; i++)
            if (number % i == 0)
                return false;

        return true;
    }

    public override string ToString()
    {
        var ret = string.Empty;
        var current = _head;

        while (current != null)
        {
            ret += $"{current.Value}, ";

            current = current.Next;
        }

        return ret == string.Empty ? ret : ret[..^2];
    }

    private Node? _head;
}