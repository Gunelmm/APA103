using System.Security.Cryptography.X509Certificates;

namespace _10_GenericTypesCollections.Models;

public class Library<T> where T : Book
{
    public List<T> Items { get; set; }
    public string Name { get; set; }
    
    public Library(string name)
    {
        Name = name;
        Items = new List<T>();
    }
    public void Add(T item)
    {
        Items.Add(item);
        Console.WriteLine($"{item.Title} əlavə edildi");
    }
    public void Remove(T item)
    {
        Items.Remove(item);
        Console.WriteLine("Silindi");
    }
    public List<T> GetAll()
    {
        return Items;
    }
    public int Count()
    {
        return Items.Count;
    }
    public T FindByIndex(int index)
    {
        if (index < 0 || index >= Items.Count) throw new Exception ("Index sehvdir");
        else return Items[index];
    }
}