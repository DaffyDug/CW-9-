using System;
using System.Collections.Generic;
using System.Windows.Input;
using static Program;

class Program
{
    static ICommand[] commands = new ICommand[]
    {
        new AddProduct(),
        new RemoveProduct(),
        new SendOrder()
    };


    static void Main(string[] args)
    {
        Menu menu = new Menu
            (
            new AddProduct(),
            new RemoveProduct(),
            new SendOrder()
            );
        while (true)
        {
            menu.ShowMenu();
        }
    }
}
public class Menu
{
    private ICommand[] Button = { };

    public Menu(params ICommand[] _button)
    {
        Button = _button;
    }
    private static int CurrentButton = 0;
    public void ShowMenu()
    {
        Clamp();
        for (int i = 0; i < Button.Length; i++)
        {
            if (i == CurrentButton)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine($"{i + 1} - {Button[i]}");
            Console.ResetColor();
        }
        var currentkey = Console.ReadKey().Key;
        Console.Clear();
        switch (currentkey)
        {
            case ConsoleKey.UpArrow:
                CurrentButton--;
                break;

            case ConsoleKey.DownArrow:
                CurrentButton++;
                break;

            case ConsoleKey.Enter:
                Button[CurrentButton].Run();
                break;
        }
    }
    private void Clamp()
    {
        if (CurrentButton < 0)
        {
            CurrentButton = Button.Length - 1;
        }
        else if (CurrentButton > Button.Length - 1)
        {
            CurrentButton = 0;
        }
    }
}
public class BasketManager
{
    List<Product> products = new List<Product>();
    public static readonly BasketManager basketManager;
    static BasketManager()
    {
        basketManager = new BasketManager();
    }
    private BasketManager()
    {

    }
    public void AddProduct(Product product)
    {
        Console.WriteLine("продукт добавлен");
    }
    public void RemoveProduct()
    {
        Console.WriteLine("продукт удален");
    }
    public void SendOrder()
    {
        Console.WriteLine("продукт заказан");
    }
}
public class AddProduct : ICommand
{
    public void Run()
    {
        Console.WriteLine("продукт добавлен");
    }
}
public class RemoveProduct : ICommand
{
    public void Run()
    {
        Console.WriteLine("продукт удален");
    }
}
public class SendOrder : ICommand
{
    public void Run()
    {
        Console.WriteLine("продукты заказаны");
    }
}
public class Product
{
    private int Price { get; }
    private string Name { get; }
    private int Kg { get; }
    public Product(int Price2, string Name2, int Kg2)
    {
        Price = Price2;
        Name = Name2;
        Kg = Kg2;
    }
}
public interface ICommand
{
    public void Run();
}