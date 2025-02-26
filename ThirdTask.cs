using System;
using System.Text;

class Contact
{
    private string name;
    private string number;

    public Contact(string name, string number)
    {
        this.name = name;
        this.number = number;
    }
    public string GetName()
    {
        return name;
    }
    public void SetName(string name)
    {
        this.name = name;
    }
    public string GetNumber()
    {
        return number;
    }
    public void SetNumber(string number)
    {
        this.number = number;
    }
}
class Service
{
    List<Contact> contacts;

    public Service(List<Contact> contacts)
    {
        this.contacts = contacts;
    }
    public void Create()
    {
        int operationIndex = GetInt("What you want to do? \n1 - create new list of contacts\n2 - add new contact");
        switch(operationIndex)
        {
            case 1:
                if (contacts.Count == 0)
                {
                    Console.WriteLine("There is not necessary to create new because there nothing in already existing list");
                    break;
                }
                contacts.Clear();
                Console.WriteLine("Succesfully created new list");
                break;
            case 2:
                string name = GetString("Input name");
                string number = GetString("Input number");
                Contact newContact = new Contact(name,number);
                contacts.Add(newContact);
                break;
        }
    }
    public void Read()
    {
        int operationIndex = GetInt("What you want to do? \n1 - read info of index\n2 - show all contacts");
        switch(operationIndex)
        {
            case 1:
                if (contacts.Count == 0)
                {
                    Console.WriteLine("There is no avaible indexes");
                    break;
                }
                int id = GetInt("Which index you want to read? Here is all avaible indexes - " + contacts.Count);
                Console.WriteLine("\nHere it is");
                Console.WriteLine($"\n{contacts[id - 1].GetName()} - {contacts[id - 1].GetNumber()}");
                break;
            case 2:
                if (contacts.Count == 0)
                {
                    Console.WriteLine("There is no avaible indexes");
                    break;
                }
                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine($"\n{contacts[i].GetName()} - {contacts[i].GetNumber()}");
                }
                break;
        }
    }
    public void Update()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("There is no avaible indexes");
            return;
        }
        int id = GetInt($"Which index you want to update? Here is all avaible indexes - " + contacts.Count);
        string newName = GetString("Input new name");
        string newNumber = GetString("Input new number");
        contacts[id-1].SetName(newName);
        contacts[id-1].SetNumber(newNumber);
        Console.WriteLine("Succesfully updated info");
    }
    public void Delete()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("There is no avaible indexes");
            return;
        }
        int id = GetInt($"Which index you want to delete? Here is all avaible indexes - " + contacts.Count);
        contacts.RemoveAt(id-1);
        Console.WriteLine("Removed Succesfully");
    }
    public Contact GetContact(int id)
    {
        return contacts[id];
    }
    public void SetContact(string name,string number,int id)
    {
        contacts[id].SetName(name);
        contacts[id].SetNumber(number);
    }
    private int GetInt(string massage)
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
internal class Emolod2
{
    static void Main()
    {
        List<Contact> contacts = new List<Contact>();
        while (true)
        {
            Service service = new Service(contacts);
            int op = GetInt("\n What you want to do? \n 1 - create/add \n 2 - read/show \n 3 - update info of index \n 4 - remove contact");
            switch (op)
            {
                case 1:
                    service.Create();
                    break; 
                case 2:
                    service.Read();
                    break;
                case 3:
                    service.Update();
                    break;
                case 4: 
                    service.Delete();
                    break;
                default:
                    Console.WriteLine("Incorrect index");
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





