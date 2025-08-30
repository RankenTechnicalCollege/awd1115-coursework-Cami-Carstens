using Project9;

Leaf leaf = new Leaf();
Pancake pancake = new Pancake();
Corner corner = new Corner();
Page page = new Page();

List<ITurnable> turnables = new List<ITurnable> { leaf, pancake, corner,page };

Console.WriteLine("TURNING POINTS\n\n");
static void TurnAllItems(List<ITurnable> items)
{
    foreach (ITurnable item in items)
    {
 
        Console.WriteLine(item.Turn());
    }
}
TurnAllItems(turnables);
