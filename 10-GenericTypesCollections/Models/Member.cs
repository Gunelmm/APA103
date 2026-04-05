using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace _10_GenericTypesCollections.Models;

public class Member
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Email {get; set;}

    public List<Book> BorrowedBooks { get; set; }

    public Member(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
        BorrowedBooks = new List<Book>();
    }
    public void BorrowBook(Book book)
    {
        if (BorrowedBooks.Count<3) 
        {
            BorrowedBooks.Add(book); Console.WriteLine($"Kitab götürüldü: [{book.Title}]");
        }
        else Console.WriteLine("Maksimum 3 kitab götürə bilərsiniz!");
    }
    public void ReturnBook(int bookId)
    {
        var book = BorrowedBooks.Find(x => x.Id == bookId);
        if (book != null)
        {
            BorrowedBooks.Remove(book); Console.WriteLine($"Kitab qaytarıldı: {book.Title}");
        }
        else Console.WriteLine($"Kitab tap;lmad;");
    }
    public void DisplayBorrowedBooks()
    {
        if (BorrowedBooks.Count == 0) Console.WriteLine($"Borc kitab yoxdur.");
        else foreach(var book in BorrowedBooks) book.DisplayInfo();
    }
}