
Console.WriteLine("What is the upper limit of your fizz buzz?");
int limit = int.Parse(Console.ReadLine());

for (int i = 1; i < limit; i++)
{
    if(i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if(i % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if(i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine($"{i}");
    }
}