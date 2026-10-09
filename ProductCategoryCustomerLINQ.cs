namespace FirstPracticeAfterCource;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Product(int id, string name, int categoryId, decimal price, int stock)
    {
        Id = id;
        Name = name;
        CategoryId = categoryId;
        Price = price;
        Stock = stock;
    }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }

    public Customer(int id, string name, string city)
    {
        Id = id;
        Name = name;
        City = city;
    }
}