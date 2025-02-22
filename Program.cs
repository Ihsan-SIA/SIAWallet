using BankApp;

Menu menu = new();
// menu.MainMenu();
Print(100);
Print("Hello world");
Print(5.5);

static void Print<Generic>(Generic item)
{
    Console.WriteLine(item);
}

