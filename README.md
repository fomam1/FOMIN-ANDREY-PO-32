using System;

class Person
{
    private int age;

    public virtual string Name { get; set; }

    public virtual int Age
    {
        get { return age; }
        set { if (value >= 1 && value <= 110) age = value; }
    }

    public virtual void Print()
    {
        Console.WriteLine(Name);
    }
}

class Employee : Person
{
    public string Company { get; set; }

    public override int Age
    {
        get { return base.Age; }
        set { if (value > 17) base.Age = value; }
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("работает в " + Company);
    }
}

class Manager : Employee
{
    public sealed override void Print()
    {
        base.Print();
    }
}

// Ошибка CS0239: Print() в Manager запечатан (sealed),
// поэтому наследник не может его переопределить.
// class Boss : Manager
// {
//     public override void Print() { }
// }

class Program
{
    static void Main()
    {
        Person p = new Person { Name = "Bob" };
        p.Print();

        Employee e = new Employee { Name = "Tom", Company = "Microsoft", Age = 18 };
        e.Print();

        e.Age = 12; // игнорируется, остаётся 18
        Console.WriteLine("Возраст: " + e.Age);

        Console.ReadLine();
    }
}
