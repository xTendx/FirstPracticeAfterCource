using FirstPracticeAfterCource;

internal class Program
{
    public static void Main()
    {
        List<Category> categories = new()
        {
            new Category(1, "Laptops"),
            new Category(2, "Phones"),
            new Category(3, "Monitors"),
            new Category(4, "Keyboards")
        };

        List<Product> products = new()
        {
            new Product(1, "MacBook Pro", 1, 2200m, 5),
            new Product(2, "Dell XPS", 1, 1800m, 0),
            new Product(3, "Lenovo Legion", 1, 1500m, 8),
            new Product(4, "iPhone 17", 2, 1100m, 12),
            new Product(5, "Samsung S26", 2, 900m, 3),
            new Product(6, "Google Pixel", 2, 700m, 0),
            new Product(7, "LG UltraGear", 3, 500m, 7),
            new Product(8, "Samsung Odyssey", 3, 800m, 2),
            new Product(9, "Logitech G Pro", 4, 150m, 20),
            new Product(10, "Keychron K8", 4, 120m, 0)
        };

        List<Customer> customers = new()
        {
            new Customer(1, "Misha", "Lodz"),
            new Customer(2, "Alex", "Warsaw"),
            new Customer(3, "Anna", "Lodz"),
            new Customer(4, "John", "Krakow"),
            new Customer(5, "Max", "Warsaw")
        };

        IEnumerable<Product> productsExpensiveThan1000 = products.Where(product => product.Price > 1000);

        foreach (Product product in productsExpensiveThan1000)
        {
            Console.WriteLine($"{product.Name}, {product.Price}");
        }

        PrintSeperator();

        IEnumerable<string> productNames = products.Select(product => product.Name);

        foreach (string productName in productNames)
        {
            Console.WriteLine(productName);
        }

        PrintSeperator();

        var productSummaries = products.Select(product => new
        {
            product.Name,
            product.Price
        });

        foreach (var newProduct in productSummaries)
        {
            Console.WriteLine($"{newProduct.Name} - {newProduct.Price}");
        }

        PrintSeperator();

        IEnumerable<Product> productsSortedByPrice = products.OrderBy(product => product.Price);

        Console.WriteLine("Sorted by price.");

        foreach (Product product in productsSortedByPrice)
        {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }

        PrintSeperator();

        IEnumerable<Product> productsSortedByDescendingPrice = products.OrderByDescending(product => product.Price);

        Console.WriteLine("Sorted by descending price.");

        foreach (Product product in productsSortedByDescendingPrice)
        {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }

        PrintSeperator();

        Console.WriteLine(
            $"Count of products: {products.Count()}, Average Price: {products.Average(product => product.Price)}");
        // Console.WriteLine(
        //     $"Max Price: {products.Max(product => product.Price)} - {(products.First(product => product.Price == products.Max(product => product.Price)).Name)} ");
        // Console.WriteLine(
        //     $"Min Price: {products.Min(product => product.Price)} - {(products.First(product => product.Price == products.Min(product => product.Price)).Name)} ");
        Product? mostExpensiveProduct = products.MaxBy(product => product.Price);
        Console.WriteLine($"Max Price: {mostExpensiveProduct?.Price} - {mostExpensiveProduct?.Name}");

        Product? cheapestProduct = products.MinBy(product => product.Price);
        Console.WriteLine($"Max Price: {cheapestProduct?.Price} - {cheapestProduct?.Name}");

        Console.WriteLine($"Count of all products in the storage: {products.Sum(product => product.Stock)}");

        // first of all we sorted an anonimous object and after that we use method Any() on it
        if (products.Any(product => product.Price > 2000))
        {
            Console.WriteLine("Exist product more expensive than 2000");

            var productsMoreExpensiveThan2000 = products.Where(product => product.Price > 2000).Select(product => new
            {
                product.Name,
                product.Price
            });
            Console.WriteLine("Products more expensive than 2000.");

            foreach (var product in productsMoreExpensiveThan2000)
            {
                Console.WriteLine($"Name of the product: {product.Name} - Price: {product.Price}");
            }

            PrintSeperator();
        }
        else
        {
            Console.WriteLine("Doesn't exist product more expensive than 2000");
        }

        if (products.All(product => product.Price > 50))
        {
            Console.WriteLine("All products have the price more than 50.");
        }
        else
        {
            Console.WriteLine("Exist at least one product has the price less than 50");
        }

        Console.WriteLine(
            $"First product that has price more than 1000: {products.First(product => product.Price > 1000).Name}");

        Product? firstProductMoreExpensiveThan1000 = products.FirstOrDefault(product => product.Price > 3000);

        Console.WriteLine(
            $"First product that has price more than 3000: {firstProductMoreExpensiveThan1000?.Name ?? "No product found"}"
        );

        PrintSeperator();

        IEnumerable<Product> productsSortedByCategoryIdThenByDescendingPrice =
            products.OrderBy(product => product.CategoryId).ThenByDescending(product => product.Price);

        foreach (Product product in productsSortedByCategoryIdThenByDescendingPrice)
        {
            Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Category: {product.CategoryId}");
        }

        PrintSeperator();

        IEnumerable<Customer> uniqCityOfCustomer = customers.Select(customer => customer).Distinct();

        foreach (Customer customer in uniqCityOfCustomer)
        {
            Console.WriteLine($"Customer Name: {customer.Name} - {customer.City}");
        }

        PrintSeperator();

        IEnumerable<Product> mostExpesiveProducts = products.OrderByDescending(product => product.Price).Take(3);

        Console.WriteLine("Three most expensive products");
        foreach (Product mostExpesiveProduct in mostExpesiveProducts)
        {
            Console.WriteLine($"Product name: {mostExpesiveProduct.Name} - {mostExpesiveProduct.Price}");
        }

        PrintSeperator();

        var productAndCategory = products.Join(categories, product => product.CategoryId,
            category => category.Id, (product, category) => new
            {
                product.Name,
                product.Price,
                CategoryName = category.Name
            });

        foreach (var product in productAndCategory)
        {
            Console.WriteLine($"{product.Name} - {product.CategoryName} - {product.Price}");
        }

        PrintSeperator();

        var productAndCategoryThatHasPriceMoreThan700 = products.Join(categories,
                product => product.CategoryId,
                category => category.Id, (product, category) => new
                {
                    product.Name,
                    product.Price,
                    product.Stock,
                    CategoryName = category.Name
                }).Where(product => product.Price > 700 && product.Stock > 0)
            .OrderByDescending(product => product.Price);

        foreach (var product in productAndCategoryThatHasPriceMoreThan700)
        {
            Console.WriteLine($"{product.Name} - {product.CategoryName} - {product.Price}");
        }

        PrintSeperator();

        var averageCostEachCategory = products.Join(categories,
            product => product.CategoryId, category => category.Id,
            (product, category) => new
            {
                Name = category.Name,
                Price = product.Price
            }).GroupBy(category => category.Name).Select(category => new
        {
            Name = category.Key,
            Price = category.Average(product => product.Price)
        });

        Console.WriteLine("Avarage of each category:");

        foreach (var product in averageCostEachCategory)
        {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }

        PrintSeperator();

        var countOfEachCategory = products.Join(categories, product => product.CategoryId, category => category.Id,
            (product, category) => new
            {
                Name = category.Name,
                Stock = product.Stock
            }).GroupBy(product => product.Name).Select(product => new
        {
            Name = product.Key,
            Count = product.Count()
        });

        Console.WriteLine("Count products of each category: ");

        foreach (var product in countOfEachCategory)
        {
            Console.WriteLine($"{product.Name} - {product.Count}");
        }

        PrintSeperator();

        var averagePriceOfProductIfIsStock =
            products.Join(categories, product => product.CategoryId,
                    category => category.Id, (product, category) => new
                    {
                        Name = category.Name,
                        Price = product.Price,
                        Stock = product.Stock
                    }).Where(product => product.Stock > 0).GroupBy(prod => prod.Name)
                .Select(p => new
                {
                    Name = p.Key,
                    Average = p.Average(prods => prods.Price)
                });

        foreach (var product in averagePriceOfProductIfIsStock)
        {
            Console.WriteLine($"{product.Name} - {product.Average}");
        }
                
        PrintSeperator();
    }


    public static void PrintSeperator()
    {
        Console.WriteLine(
            "<------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------>");
    }
}