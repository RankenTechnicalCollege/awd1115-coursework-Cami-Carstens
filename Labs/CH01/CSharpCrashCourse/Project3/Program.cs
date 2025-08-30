// See https://aka.ms/new-console-template for more information
int rows;
int columns;

bool isValid;
do {
    Console.WriteLine("How many rows would you like?");
    isValid = int.TryParse(Console.ReadLine(), out rows);
} 
while(!isValid);

do
{
    Console.WriteLine("How many columns would you like?");
    isValid = int.TryParse(Console.ReadLine(), out columns);

}
while(!isValid);

for (int row = 0; row <= rows; row++)
{
    if (row == 0)
    {
        Console.Write($"{"",6} |");

        for (int column = 1; column <= columns; column++)
        {
            Console.Write($"{column,6} |");
        }
        Console.WriteLine(); 
        Console.WriteLine(new string('-', (columns + 1) * 8 ));
        Console.WriteLine();


    }
    else
    {
        Console.Write($"{row,6} |");
        for (int column = 1; column <= columns; column++)
        {
            Console.Write($"{row * column,6} |");
        }
        Console.WriteLine();
    }
}

