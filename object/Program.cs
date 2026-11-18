using System;
class Book
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Year { get; private set; }
    public string Isbn { get; private set; }

    public Book(string title, string author, int year, string isbn)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Название не может быть пустым");
        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Автор не может быть пустым");
        if (year < 0 || year > DateTime.Now.Year)
            throw new ArgumentException("Неверный год издания");

        Title = title;
        Author = author;
        Year = year;
        Isbn = isbn;
    }

    public override string ToString()
    {
        if (string.IsNullOrWhiteSpace(Author))
            return base.ToString();
        return "\"" + Title + "\" — " + Author + " (" + Year + " г.) [ISBN: " + Isbn + "]";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Book other)
            return Isbn == other.Isbn;
        return false;
    }

    public override int GetHashCode()
    {
        return Isbn.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        Book book1 = new Book("Война и мир", "Л. Толстой", 1869, "978-5-9775-4000-1");
        Book book2 = new Book("Война и мир (копия)", "Л. Толстой", 1869, "978-5-9775-4000-1");
        Book book3 = new Book("Мастер и Маргарита", "М. Булгаков", 1967, "978-5-17-000000-0");

        Console.WriteLine(book1);

        Console.WriteLine(book1.GetType());
        Console.WriteLine(book1.GetType() == typeof(Book));
        Console.WriteLine(book1 is Book);

        Console.WriteLine("book1.Equals(book2): " + book1.Equals(book2));
        Console.WriteLine("book1.Equals(book3): " + book1.Equals(book3));

        Console.WriteLine("book1 == book2: " + (book1 == book2));

        Console.WriteLine("Хеш book1: " + book1.GetHashCode());
        Console.WriteLine("Хеш book2: " + book2.GetHashCode());
        Console.WriteLine("Хеш book3: " + book3.GetHashCode());

        Console.ReadLine();
    }
}
