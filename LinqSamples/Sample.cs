using System.Collections.Generic;
using System.Linq;

namespace LinqSamples
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class Sample
    {
        private List<Product> products;

        public Sample() => CreateLists();

        public void SimpleQuery()
        {
            // foreach
            var beveragesF = new List<Product>();
            foreach (var product in products)
            {
                if (product.Category == "Beverages")
                {
                    beveragesF.Add(product);
                }
            }

            // LINQ
            var beveragesQ = from p in products
                             where p.Category == "Beverages"
                             select p;
            var beveragesPrices = from p in products
                                  where p.Category == "Beverages"
                                  select p.Price;
        }

        public void Where()
        {
            // foreach
            var beveragesF = new List<Product>();
            foreach (var product in products)
            {
                if (product.Category == "Beverages")
                {
                    beveragesF.Add(product);
                }
            }

            // LINQ
            var beveragesM = products.Where(p => p.Category == "Beverages");
            var beveragesPrices = products.Where(p => p.Category == "Beverages").Select(p => p.Price);
        }

        public void OrderBy()
        {
            IEnumerable<Product> sorted;
            IEnumerable<Product> descSorted;

            // query pattern
            sorted = from p in products orderby p.Price select p;
            descSorted = from p in products orderby p.Price descending select p;

            // method pattern
            sorted = products.OrderBy(p => p.Price);
            descSorted = products.OrderByDescending(p => p.Price);
        }

        public void Any()
        {
            var exists = false;

            // foreach
            foreach (var product in products)
            {
                if (product.Name.Contains("Alice"))
                {
                    exists = true;
                    break;
                }
            }

            // linq
            exists = products.Any(p => p.Name.Contains("Alice"));
        }

        public void All()
        {
            var exists = false;

            // foreach
            foreach (var product in products)
            {
                if (0 < product.Stock)
                {
                    exists = true;
                }
                else
                {
                    exists = false;
                    break;
                }
            }

            // linq
            exists = products.All(p => 0 < p.Stock);
        }

        public void First()
        {
            Product product;

            // foreach
            foreach (var p in products)
            {
                if (30 <= p.Price)
                {
                    product = p;
                    break;
                }
            }

            // linq
            product = products.FirstOrDefault(p => 30 <= p.Price);
        }

        public void Last()
        {
            Product product;

            // foreach
            foreach (var p in products)
            {
                if (30 <= p.Price)
                {
                    product = p;
                }
            }

            // linq
            product = products.LastOrDefault(p => 30 <= p.Price);
        }

        private void CreateLists()
        {
            // Product data created in-memory using collection initializer:
            products =
                new List<Product> {
                    new Product { Id = 1, Name = "Chai", Category = "Beverages", Price = 18.0000M, Stock = 39 },
                    new Product { Id = 2, Name = "Chang", Category = "Beverages", Price = 19.0000M, Stock = 17 },
                    new Product { Id = 3, Name = "Aniseed Syrup", Category = "Condiments", Price = 10.0000M, Stock = 13 },
                    new Product { Id = 4, Name = "Chef Anton's Cajun Seasoning", Category = "Condiments", Price = 22.0000M, Stock = 53 },
                    new Product { Id = 5, Name = "Chef Anton's Gumbo Mix", Category = "Condiments", Price = 21.3500M, Stock = 0 },
                    new Product { Id = 6, Name = "Grandma's Boysenberry Spread", Category = "Condiments", Price = 25.0000M, Stock = 120 },
                    new Product { Id = 7, Name = "Uncle Bob's Organic Dried Pears", Category = "Produce", Price = 30.0000M, Stock = 15 },
                    new Product { Id = 8, Name = "Northwoods Cranberry Sauce", Category = "Condiments", Price = 40.0000M, Stock = 6 },
                    new Product { Id = 9, Name = "Mishi Kobe Niku", Category = "Meat/Poultry", Price = 97.0000M, Stock = 29 },
                    new Product { Id = 10, Name = "Ikura", Category = "Seafood", Price = 31.0000M, Stock = 31 },
                    new Product { Id = 11, Name = "Queso Cabrales", Category = "Dairy Products", Price = 21.0000M, Stock = 22 },
                    new Product { Id = 12, Name = "Queso Manchego La Pastora", Category = "Dairy Products", Price = 38.0000M, Stock = 86 },
                    new Product { Id = 13, Name = "Konbu", Category = "Seafood", Price = 6.0000M, Stock = 24 },
                    new Product { Id = 14, Name = "Tofu", Category = "Produce", Price = 23.2500M, Stock = 35 },
                    new Product { Id = 15, Name = "Genen Shouyu", Category = "Condiments", Price = 15.5000M, Stock = 39 },
                    new Product { Id = 16, Name = "Pavlova", Category = "Confections", Price = 17.4500M, Stock = 29 },
                    new Product { Id = 17, Name = "Alice Mutton", Category = "Meat/Poultry", Price = 39.0000M, Stock = 0 },
                    new Product { Id = 18, Name = "Carnarvon Tigers", Category = "Seafood", Price = 62.5000M, Stock = 42 },
                    new Product { Id = 19, Name = "Teatime Chocolate Biscuits", Category = "Confections", Price = 9.2000M, Stock = 25 },
                    new Product { Id = 20, Name = "Sir Rodney's Marmalade", Category = "Confections", Price = 81.0000M, Stock = 40 },
                    new Product { Id = 21, Name = "Sir Rodney's Scones", Category = "Confections", Price = 10.0000M, Stock = 3 },
                    new Product { Id = 22, Name = "Gustaf's Knäckebröd", Category = "Grains/Cereals", Price = 21.0000M, Stock = 104 },
                    new Product { Id = 23, Name = "Tunnbröd", Category = "Grains/Cereals", Price = 9.0000M, Stock = 61 },
                    new Product { Id = 24, Name = "Guaraná Fantástica", Category = "Beverages", Price = 4.5000M, Stock = 20 },
                    new Product { Id = 25, Name = "NuNuCa Nuß-Nougat-Creme", Category = "Confections", Price = 14.0000M, Stock = 76 },
                    new Product { Id = 26, Name = "Gumbär Gummibärchen", Category = "Confections", Price = 31.2300M, Stock = 15 },
                    new Product { Id = 27, Name = "Schoggi Schokolade", Category = "Confections", Price = 43.9000M, Stock = 49 },
                    new Product { Id = 28, Name = "Rössle Sauerkraut", Category = "Produce", Price = 45.6000M, Stock = 26 },
                    new Product { Id = 29, Name = "Thüringer Rostbratwurst", Category = "Meat/Poultry", Price = 123.7900M, Stock = 0 },
                    new Product { Id = 30, Name = "Nord-Ost Matjeshering", Category = "Seafood", Price = 25.8900M, Stock = 10 },
                    new Product { Id = 31, Name = "Gorgonzola Telino", Category = "Dairy Products", Price = 12.5000M, Stock = 0 },
                    new Product { Id = 32, Name = "Mascarpone Fabioli", Category = "Dairy Products", Price = 32.0000M, Stock = 9 },
                    new Product { Id = 33, Name = "Geitost", Category = "Dairy Products", Price = 2.5000M, Stock = 112 },
                    new Product { Id = 34, Name = "Sasquatch Ale", Category = "Beverages", Price = 14.0000M, Stock = 111 },
                    new Product { Id = 35, Name = "Steeleye Stout", Category = "Beverages", Price = 18.0000M, Stock = 20 },
                    new Product { Id = 36, Name = "Inlagd Sill", Category = "Seafood", Price = 19.0000M, Stock = 112 },
                    new Product { Id = 37, Name = "Gravad lax", Category = "Seafood", Price = 26.0000M, Stock = 11 },
                    new Product { Id = 38, Name = "Côte de Blaye", Category = "Beverages", Price = 263.5000M, Stock = 17 },
                    new Product { Id = 39, Name = "Chartreuse verte", Category = "Beverages", Price = 18.0000M, Stock = 69 },
                    new Product { Id = 40, Name = "Boston Crab Meat", Category = "Seafood", Price = 18.4000M, Stock = 123 },
                    new Product { Id = 41, Name = "Jack's New England Clam Chowder", Category = "Seafood", Price = 9.6500M, Stock = 85 },
                    new Product { Id = 42, Name = "Singaporean Hokkien Fried Mee", Category = "Grains/Cereals", Price = 14.0000M, Stock = 26 },
                    new Product { Id = 43, Name = "Ipoh Coffee", Category = "Beverages", Price = 46.0000M, Stock = 17 },
                    new Product { Id = 44, Name = "Gula Malacca", Category = "Condiments", Price = 19.4500M, Stock = 27 },
                    new Product { Id = 45, Name = "Rogede sild", Category = "Seafood", Price = 9.5000M, Stock = 5 },
                    new Product { Id = 46, Name = "Spegesild", Category = "Seafood", Price = 12.0000M, Stock = 95 },
                    new Product { Id = 47, Name = "Zaanse koeken", Category = "Confections", Price = 9.5000M, Stock = 36 },
                    new Product { Id = 48, Name = "Chocolade", Category = "Confections", Price = 12.7500M, Stock = 15 },
                    new Product { Id = 49, Name = "Maxilaku", Category = "Confections", Price = 20.0000M, Stock = 10 },
                    new Product { Id = 50, Name = "Valkoinen suklaa", Category = "Confections", Price = 16.2500M, Stock = 65 },
                    new Product { Id = 51, Name = "Manjimup Dried Apples", Category = "Produce", Price = 53.0000M, Stock = 20 },
                    new Product { Id = 52, Name = "Filo Mix", Category = "Grains/Cereals", Price = 7.0000M, Stock = 38 },
                    new Product { Id = 53, Name = "Perth Pasties", Category = "Meat/Poultry", Price = 32.8000M, Stock = 0 },
                    new Product { Id = 54, Name = "Tourtière", Category = "Meat/Poultry", Price = 7.4500M, Stock = 21 },
                    new Product { Id = 55, Name = "Pâté chinois", Category = "Meat/Poultry", Price = 24.0000M, Stock = 115 },
                    new Product { Id = 56, Name = "Gnocchi di nonna Alice", Category = "Grains/Cereals", Price = 38.0000M, Stock = 21 },
                    new Product { Id = 57, Name = "Ravioli Angelo", Category = "Grains/Cereals", Price = 19.5000M, Stock = 36 },
                    new Product { Id = 58, Name = "Escargots de Bourgogne", Category = "Seafood", Price = 13.2500M, Stock = 62 },
                    new Product { Id = 59, Name = "Raclette Courdavault", Category = "Dairy Products", Price = 55.0000M, Stock = 79 },
                    new Product { Id = 60, Name = "Camembert Pierrot", Category = "Dairy Products", Price = 34.0000M, Stock = 19 },
                    new Product { Id = 61, Name = "Sirop d'érable", Category = "Condiments", Price = 28.5000M, Stock = 113 },
                    new Product { Id = 62, Name = "Tarte au sucre", Category = "Confections", Price = 49.3000M, Stock = 17 },
                    new Product { Id = 63, Name = "Vegie-spread", Category = "Condiments", Price = 43.9000M, Stock = 24 },
                    new Product { Id = 64, Name = "Wimmers gute Semmelknödel", Category = "Grains/Cereals", Price = 33.2500M, Stock = 22 },
                    new Product { Id = 65, Name = "Louisiana Fiery Hot Pepper Sauce", Category = "Condiments", Price = 21.0500M, Stock = 76 },
                    new Product { Id = 66, Name = "Louisiana Hot Spiced Okra", Category = "Condiments", Price = 17.0000M, Stock = 4 },
                    new Product { Id = 67, Name = "Laughing Lumberjack Lager", Category = "Beverages", Price = 14.0000M, Stock = 52 },
                    new Product { Id = 68, Name = "Scottish Longbreads", Category = "Confections", Price = 12.5000M, Stock = 6 },
                    new Product { Id = 69, Name = "Gudbrandsdalsost", Category = "Dairy Products", Price = 36.0000M, Stock = 26 },
                    new Product { Id = 70, Name = "Outback Lager", Category = "Beverages", Price = 15.0000M, Stock = 15 },
                    new Product { Id = 71, Name = "Flotemysost", Category = "Dairy Products", Price = 21.5000M, Stock = 26 },
                    new Product { Id = 72, Name = "Mozzarella di Giovanni", Category = "Dairy Products", Price = 34.8000M, Stock = 14 },
                    new Product { Id = 73, Name = "Röd Kaviar", Category = "Seafood", Price = 15.0000M, Stock = 101 },
                    new Product { Id = 74, Name = "Longlife Tofu", Category = "Produce", Price = 10.0000M, Stock = 4 },
                    new Product { Id = 75, Name = "Rhönbräu Klosterbier", Category = "Beverages", Price = 7.7500M, Stock = 125 },
                    new Product { Id = 76, Name = "Lakkalikööri", Category = "Beverages", Price = 18.0000M, Stock = 57 },
                    new Product { Id = 77, Name = "Original Frankfurter grüne Soße", Category = "Condiments", Price = 13.0000M, Stock = 32 }
            };
        }
    }
}
