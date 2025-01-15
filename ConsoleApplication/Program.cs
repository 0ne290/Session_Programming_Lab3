using Core;

namespace ConsoleApplication;

internal static class Program
{
    private static void Main()
    {
        Console.Write("Enter the numbers: ");
        SinglyLinkedList numbers;
        try
        { 
            numbers = new SinglyLinkedList(Console.ReadLine()!);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            
            Console.Write("To terminate the program, press any key...");
            Console.ReadKey();
            
            return;
        }
        
        Console.WriteLine($"Numbers: {numbers}.");
        
        Console.WriteLine($"Numbers without primes: {numbers.RemovePrimeNumbers()}.");
        
        Console.Write("To terminate the program, press any key...");
        Console.ReadKey();
    }
}