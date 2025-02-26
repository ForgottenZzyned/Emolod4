using System;
using System.Text;


class Product
{
    private string name;
    private int quantity;
    private int price;
    private int id = 0;
    private static int idCr = 1;
    private int CreateId()
    {
        return idCr++;
    }
    public string GetName()
    {
        return name;
    }
    public void SetName(string name)
    {
        this.name = name;
    }
    public int GetQuantity()
    {
        return quantity;
    }
    public void SetQuantity(int quantity)
    {
        this.quantity = quantity;
    }
    public int GetPrice()
    {
        return price;
    }
    public void SetPrice(int price)
    {
        this.price = price;
    }
    public int GetId()
    {
        return id;
    }

    public Product(string name, int quantity, int price)
    {
        this.id = this.CreateId();
        this.name = name;
        this.quantity = quantity;
        this.price = price;
    }
}

internal class Emolod
{
    static Product[] products;
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        products = new Product[3];
        products[0] = new Product("Помідор", 34,12);
        products[1] = new Product("Огірок", 56,28);
        products[2] = new Product("Диня", 12,70);
        while (true)
        {
            Console.WriteLine("Here is avaible products");
            for(int i = 0; i < products.Length; i++)
            { 
                Console.WriteLine($"\n {products[i].GetName()} - which quantity is {products[i].GetQuantity()} and price {products[i].GetPrice()}");
            }
            int productId = GetInt("\nWhich product you want to buy?");
            int userBalance = GetInt("\nHow much money you got?");
            BuyProduct(productId-1,userBalance);
        }
    }

    public static void BuyProduct(int id, int money)
    {    
        if (products[id].GetQuantity() == 0)
        {
            Console.WriteLine("We don't have that product right now");
            return;
        }
        else if(money < products[id].GetPrice())
        {
            Console.WriteLine("You can't afford that product");
            return;
        }
        int cost = products[id].GetPrice();
        int buyedQuantity = money / cost;
        if(buyedQuantity > products[id].GetQuantity()) buyedQuantity = products[id].GetQuantity();
        money = money - (cost * buyedQuantity);
        products[id].SetQuantity(products[id].GetQuantity() - buyedQuantity);
        Console.WriteLine("Successfully buyed product");
        Console.WriteLine($"You buyed {buyedQuantity} of product");
        Console.WriteLine($"Your balance is now {money}");
    }
    private static int GetInt(string massage)
    {
        Console.WriteLine(massage);
        int i = Convert.ToInt32(Console.ReadLine());
        return i;
    }
    private string GetString(string massage)
    {
        Console.WriteLine(massage);
        string s = Console.ReadLine();
        if (s == null) throw new ArgumentException("String cant be null");
        return s;
    }
}
