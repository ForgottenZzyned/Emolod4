using System.Collections.Generic;
using System;
using System.Text;

class Seat()
{
    private int number;
    private double cost = 10.00;
    private bool isOccupied;
    private string type = "Standart";

    public int GetNumber()
    {
        return number;
    }
    public void SetNumber(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Incorrect number");
        }
        this.number = number;
    }
    public double GetCost()
    {
        return cost;
    }
    public void SetCost(double cost)
    {
        if (cost < 0)
        {
            throw new ArgumentException("Incorrect cost");
        }
        this.cost = cost;
    }
    public bool GetOccupied()
    {
        return isOccupied;
    }
    public void SetOccupied(bool isOccupied)
    {
        this.isOccupied = isOccupied;
    }
    public string GetType()
    {
        return type;
    }
    public void SetType(string type)
    {
        switch (type)
        {
            case ("Standart"):
                this.type = type;
                break;
            case ("VIP"):
                this.type = type;
                break;
            case ("Premium"):
                this.type = type;
                break;
            default:
                throw new ArgumentException("Incorrect type");
        }
        
    }
}
internal class Emolod2
{
    static Seat[] seats;
    static void Main()
    {
        SetSeats();
        double balance = new Random().Next(5, 50);
        while (true)
        { 
            int numberOfSeat = GetInt($"Input a number of seat you want to book. Here is avaible numbers - {seats.Length} and your balance - {balance}");
            if (!seats[numberOfSeat].GetOccupied() && seats[numberOfSeat].GetCost() < balance)
            {
                balance -= seats[numberOfSeat].GetCost();
                seats[numberOfSeat].SetOccupied(true);
                Console.WriteLine("Booked successfully");
                break;
            }
            else if (seats[numberOfSeat].GetOccupied())
            {
                Console.WriteLine("This seat is already booked");
            }
            else
            {
                Console.WriteLine("Not enough money on balance");
            }
        }
    }

    public static void SetSeats()
    {
        seats = new Seat[15];
        bool isOccupied = false;
        Random rand = new Random();  
        string[] types = {"Standart","VIP","Premium"};
        //Setting numbers, isOccupied, types of seats and costs
        for (int i = 0; i < seats.Length; i++)
        {
            seats[i] = new Seat();
            int r = rand.Next(0, 2);
            if (r == 1) isOccupied = true;
            seats[i].SetOccupied(isOccupied);
            seats[i].SetNumber(i+1);
            isOccupied = false;
            r = rand.Next(1, 4);
            switch (r)
            {
                case 1:
                    seats[i].SetType("VIP");
                    seats[i].SetCost(15.00);
                    break;
                case 2:
                    seats[i].SetType("Premium");
                    seats[i].SetCost(25.00);
                    break;
            }
        } 
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
