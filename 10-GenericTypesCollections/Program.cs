using _10_GenericTypesCollections.Models;

Console.WriteLine("===============Book====================");

Book book1 = new Book(1, "Martin Eden", "Jack London", 1909, 400);
Book book2 = new Book(2, "1984", "George Orwell", 1949, 328);
Book book3 = new Book(3, "Animal Farm", "George Orwell", 1945, 112);
Book book4 = new Book(4, "Ağ Gəmi", "Cingiz Aytmatov", 1970, 200);
Book book5 = new Book(5, "Qırıq Budaq", "Elçin", 1998, 350);

book1.DisplayInfo();
book2.DisplayInfo();
book3.DisplayInfo();
book4.DisplayInfo();
book5.DisplayInfo();

Console.WriteLine("===============Library====================");

Library<Book> library = new Library<Book>("Milli Kitabxana");
library.Add(book1);
library.Add(book2);
library.Add(book3);
library.Add(book4);
library.Add(book5);

Console.WriteLine($"Kitab sayı: {library.Count()}");

Console.WriteLine("===================================");

library.FindByIndex(0).DisplayInfo();
library.FindByIndex(2).DisplayInfo();

Console.WriteLine("===================================");

foreach (var book in library.GetAll())
{
    book.DisplayInfo();
}

Console.WriteLine("===============Member====================");

List<Member> members = new List<Member>()
{
    new Member(1, "Ali Məmmədov", "ali@mail.com"),
    new Member(2, "Leyla Həsənova", "leyla@mail.com"),
    new Member(3, "Vüqar Əliyev", "vuqar@mail.com")
};
members[2].BorrowBook(book1);
members[2].BorrowBook(book2);

members[2].DisplayBorrowedBooks();

Console.WriteLine("===================================");

members[2].ReturnBook(1);

members[2].DisplayBorrowedBooks();

Console.WriteLine("===================================");

members[2].BorrowBook(book3);
members[2].BorrowBook(book4);
members[2].BorrowBook(book5);

Console.WriteLine("===============BookManager====================");

BookManager bookManager = new();
bookManager.AddBook(book1);
bookManager.AddBook(book2);
bookManager.AddBook(book3);
bookManager.AddBook(book4);
bookManager.AddBook(book5);

var georgeBooks = bookManager.GetBooksByAuthor("George Orwell");
foreach (var book in georgeBooks) book.DisplayInfo();

var cingizBooks = bookManager.GetBooksByAuthor("Cingiz Aytmatov");
foreach (var book in cingizBooks) book.DisplayInfo();

var jackBooks = bookManager.GetBooksByAuthor("Jack London");
foreach (var book in jackBooks) book.DisplayInfo();

var dostoyevski = bookManager.GetBooksByAuthor("Dostoyevski");
foreach (var book in dostoyevski) book.DisplayInfo();


Console.WriteLine("================Queue===================");

BookManager member = new();
member.AddToWaitingQueue("Nigar");
member.AddToWaitingQueue("Rəşad");
member.AddToWaitingQueue("Səbinə");

member.ServeNextInQueue();
member.ServeNextInQueue();
member.ServeNextInQueue();
member.ServeNextInQueue();

Console.WriteLine("================Stack===================");

BookManager returnBook = new();
returnBook.ReturnBook(book1);
returnBook.ReturnBook(book2);
returnBook.ReturnBook(book3);

Console.WriteLine($"Kitab sayı: {returnBook.RecentlyReturned.Count}");

Console.WriteLine($"Son qaytarılan kitab: {returnBook.GetLastReturnedBook().Title}");

returnBook.RecentlyReturned.Pop();
Console.WriteLine("Bir kitab çıxarıldı.");
Console.WriteLine($"Kitab sayı: {returnBook.RecentlyReturned.Count}");

Console.WriteLine($"Son qaytarılan kitab: {returnBook.GetLastReturnedBook().Title}");

Console.WriteLine("================Axtaris===================");

var searchBook = bookManager.SearchByTitle("1984");
if (searchBook != null) searchBook.DisplayInfo();
else Console.WriteLine("Kitab tapılmadı.");

var searchBook2 = bookManager.SearchByTitle("HarryPotter");
if (searchBook2 != null) searchBook2.DisplayInfo();
else Console.WriteLine("Kitab tapılmadı.");

Console.WriteLine("================Statistika===================");

Console.WriteLine($"Ümumi kitab sayı: {library.Count()}");
Console.WriteLine($"Ümumi üzv sayı: {members.Count()}");
Console.WriteLine($"Növbədə nəfər sayı: {member.WaitingQueue.Count()}");
Console.WriteLine($"Stack-də kitab sayı: {returnBook.RecentlyReturned.Count()}");

int yearOfOldestBook = int.MaxValue;
foreach (var book in library.GetAll())
{
    if (book.Year < yearOfOldestBook) yearOfOldestBook = book.Year;
}
Console.WriteLine($"Ən köhnə kitabın ili: {yearOfOldestBook}");

int yearOfNewestBook = int.MinValue;
foreach (var book in library.GetAll())
{
    if (book.Year > yearOfNewestBook) yearOfNewestBook = book.Year;
}
Console.WriteLine($"Ən yeni kitabın ili: {yearOfNewestBook}");
