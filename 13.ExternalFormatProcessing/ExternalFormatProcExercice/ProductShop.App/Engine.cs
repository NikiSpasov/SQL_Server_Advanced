namespace ProductsShop.App
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.EntityFrameworkCore.Extensions.Internal;
    using Newtonsoft.Json;
    using ProductsShop.Data;
    using ProductsShop.Models;

    internal class Engine
    {
        private readonly ProductsShopContext context;

        public Engine()
        {
            this.context = new ProductsShopContext();
        }

        public void Run()
        {

            //this.context.Database.EnsureDeleted();
            //this.context.Database.EnsureCreated();

            // J S O N //

            //Console.WriteLine(ImportUsersFromJson());
            //Console.WriteLine(ImportCategoriesFromJson());
            //Console.WriteLine(ImportProductsFromJson());

            //SetCategories();

            //GetProductsInRange();

            //GetSuccessfullySoldProducts();


            /*    X - M - L    */

            // ImportUsersFromXml();

            //  ImportCategories();

           // Console.WriteLine(ImportProductsFromXml());

            Export();
        }
        //XML:

        static string ImportUsersFromXml()
        {
            string path = "Files/users.xml";

            string xmlString = File.ReadAllText(path);

            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();

            var users  = new List<User>();

            foreach (var e in elements)
            {
                string firstName = e.Attribute("firstName")?.Value; //? - if not null - take the value
                string lastName = e.Attribute("lastName")?.Value; //? - if not null - take the value

                int? age = null;

                if (e.Attribute("age") != null)
                {
                    age = int.Parse(e.Attribute("age").Value);
                }

                var user = new User
                {
                    FirstName =  firstName, 
                    LastName =  lastName,
                    Age = age
                };

                users.Add(user);
            }
            using (var context  = new ProductsShopContext())
            {
                context.Users.AddRange(users);
                context.SaveChanges();
            }

            return $"{users.Count} users were added!";
        }

        static string ImportCategories()
        {
            string path = "Files/categories.xml";

            string xmlString = File.ReadAllText(path);

            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();

            var categories = new List<Category>();

            foreach (var e in elements)
            {
                var category = new Category()
                {
                    Name = e.Element("name").Value
                };

                categories.Add(category);
            }

            using (var context = new ProductsShopContext())
            {
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            return $"{categories.Count} categories were added!";

        }

        static string ImportProductsFromXml()
        {

            string path = "Files/products.xml";

            string xmlString = File.ReadAllText(path);

            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();

            using (var context = new ProductsShopContext())
            {
                var catProducts = new List<CategoryProducts>();

                var userIds = context.Users.Select(u => u.Id).ToArray();
                var categoryIds = context.Categories.Select(c => c.Id).ToArray();

                Random rnd = new Random();

                foreach (var e in elements)
                {
                    string name = e.Element("name").Value;
                    decimal price = decimal.Parse(e.Element("price").Value);

                    int sellerIndex = rnd.Next(0, userIds.Length);
                    int sellerId = userIds[sellerIndex];

                    var product = new Product()
                    {
                        Name = name,
                        Price = price,
                        SellerId = sellerId
                    };

                    int categoryIndex = rnd.Next(0, categoryIds.Length);
                    int categoryId = categoryIds[categoryIndex];

                    var catProduct = new CategoryProducts()
                    {
                        Product = product,
                        CategoryId = categoryId
                    };
                     
                    catProducts.Add(catProduct);
                }
                context.AddRange(catProducts);

                context.SaveChanges();

                return $"{catProducts.Count} products were added!";
            }
        }

        static void Export()
        {
            using (var context = new ProductsShopContext())
            {
                string[] names = context.Users.Select(
                    u => $"{u.FirstName} {u.LastName}")
                    .ToArray();

                var xDoc = new XDocument(new XElement("users"));

                foreach (var n in names)
                {
                    xDoc.Root.Add(new XElement("user",
                        new XElement("name", n)));
                }

                string xmlString = xDoc.ToString();

                File.WriteAllText("Files/usersExport.xml", xmlString);
            }
        }


        // JSON:
        static void GetSuccessfullySoldProducts()
        {
            using (var context = new ProductsShopContext())
            {
                var users = context.Users
                    .Where(u => u.SoldProducts.Any(p => p.BuyerId != null))
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new
                    {
                        u.FirstName,
                        u.LastName,
                        SoldProducts = u.SoldProducts.Select(p => new
                        {
                           p.Name,
                           p.Price,
                           BuyerFirstName = $"{p.Buyer.FirstName}",
                           BuyerLastName =  $"{p.Buyer.LastName}"
                        })
                    }).ToArray();


                var jsonString = JsonConvert.SerializeObject(users,
                    Formatting.Indented, new JsonSerializerSettings()
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore                   
                    });

                File.WriteAllText("Files/users-sold-products.json", jsonString);
            }       
        }

        static void GetProductsInRange()
        {
            using (var context = new ProductsShopContext())
            {
                var products = context.Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .OrderBy(p => p.Price)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        seller = p.Seller.FirstName + " " + p.Seller.LastName
                    }).ToArray();

                var jsonString = JsonConvert.SerializeObject(products, Formatting.Indented);

                File.WriteAllText("Files/products-in-range.json", jsonString);
            }
        }

        static void SetCategories()
        {
            using (var context = new ProductsShopContext())
            {
                var productIds = context.Products.Select(p => p.Id).ToArray();
                var categoryIds = context.Categories.Select(c => c.Id).ToArray();

                int categoryCount = categoryIds.Length;

                Random rnd = new Random();

                var categoryProducts = new List<CategoryProducts>();

                foreach (var p in productIds)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int index = rnd.Next(0, categoryIds.Length);
                        while (categoryProducts.Any(cp => cp.ProductId == p
                        && cp.CategoryId == categoryIds[index]))
                        {
                            index = rnd.Next(0, categoryCount);
                        }

                        var catPr = new CategoryProducts()
                        {
                            ProductId = p,
                            CategoryId = categoryIds[index]
                        };

                       categoryProducts.Add(catPr);
                    }
                }

                context.CategoryProducts.AddRange(categoryProducts);

                context.SaveChanges();
            }
        }

        static string ImportProductsFromJson()
        {
            string path = "Files/products.json";

            Random rnd = new Random();

            Product[] products = ImportJson<Product>(path);

            using (var context = new ProductsShopContext())
            {
                int[] userIds = context.Users.Select(u => u.Id).ToArray();


                foreach (var p in products)
                {
                    int index = rnd.Next(0, userIds.Length); //the last one is not included!!!
                    int sellerId = userIds[index];

                    int? buyerId = sellerId;
                    while (buyerId == sellerId)
                    {
                        int buyerIndex = rnd.Next(0, userIds.Length);
                        buyerId = userIds[buyerIndex];
                    }
                    if (buyerId - sellerId < 5) //randomize nulls!
                    {
                        buyerId = null;
                    }
                    p.SellerId = sellerId;
                    p.BuyerId = buyerId;
                }


                context.Products.AddRange(products);

                context.SaveChanges();
            }

            return $"{products.Length} products were imported from: {path}!";

        }

        static string ImportCategoriesFromJson()
        {
            string path = "Files/categories.json";

            Category[] categories = ImportJson<Category>(path);

            using (var context = new ProductsShopContext())
            {
                context.Categories.AddRange(categories);

                context.SaveChanges();
            }

            return $"{categories.Length} categories were imported from: {path}!";

        }

        static string ImportUsersFromJson()
        {
            var path = "Files/users.json";

            User[] users = ImportJson<User>(path);

            using (var context = new ProductsShopContext())
            {
                context.Users.AddRange(users);

                context.SaveChanges();
            }
            return $"{users.Length} users were imported from: {path}!";
        }

        static T[] ImportJson<T>(string path)
        {

            string jsonString = File.ReadAllText(path);

            T[] objects = JsonConvert.DeserializeObject<T[]>(jsonString);

            return objects;
        }

    }
}