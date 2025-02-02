using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo
{
    // === PARTEA 1: Persoane și Roluri ===

    // Clasa Person cu proprietăți: PersonId, FirstName, LastName, Age, RoleId
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int RoleId { get; set; }

        public override string ToString()
        {
            return $"[{PersonId}] {FirstName} {LastName}, Age: {Age}, RoleId: {RoleId}";
        }
    }

    // Clasa Role cu proprietăți: RoleId, RoleDescription
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleDescription { get; set; }

        public override string ToString()
        {
            return $"RoleId: {RoleId}, Description: {RoleDescription}";
        }
    }

    // === PARTEA 2: Produse, Clienți, Comenzi, Detalii comenzi ===

    // Clasa Product cu proprietăți: ProductId, Name, UnitPrice, Category
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string Category { get; set; } // Exemplu: "Food", "Drink", "Care", "Other"

        public override string ToString()
        {
            return $"[{ProductId}] {Name}, Price: {UnitPrice}, Category: {Category}";
        }
    }

    // Clasa Customer cu proprietăți: CustomerId, CustomerName, Country, City, Phone
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"[{CustomerId}] {CustomerName}, {City}, {Country}, Phone: {Phone}";
        }
    }

    // Clasa Order cu proprietăți: OrderId, OrderDate, CustomerId
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, Date: {OrderDate.ToShortDateString()}, CustomerId: {CustomerId}";
        }
    }

    // Clasa OrderDetail cu proprietăți: OrderId, ProductId, Quantity
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"OrderId: {OrderId}, ProductId: {ProductId}, Quantity: {Quantity}";
        }
    }

    // Clasa Program care conține metoda Main cu execuția interogărilor LINQ
    class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------
            // PARTEA 1: Persoane și Roluri
            // -------------------------------

            // Crearea unei liste de 5 obiecte Person
            List<Person> people = new List<Person>
            {
                new Person { PersonId = 1, FirstName = "FirstName1", LastName = "Smith", Age = 20, RoleId = 1 },
                new Person { PersonId = 2, FirstName = "Bob",       LastName = "Johnson", Age = 17, RoleId = 2 },
                new Person { PersonId = 3, FirstName = "Charlie",   LastName = "Williams", Age = 30, RoleId = 3 },
                new Person { PersonId = 4, FirstName = "David",     LastName = "Brown", Age = 60, RoleId = 1 },
                new Person { PersonId = 5, FirstName = "Eve",       LastName = "Jones", Age = 45, RoleId = 4 }
            };

            // Crearea unei liste de 5 obiecte Role
            List<Role> roles = new List<Role>
            {
                new Role { RoleId = 1, RoleDescription = "Leader" },
                new Role { RoleId = 2, RoleDescription = "Manager" },
                new Role { RoleId = 3, RoleDescription = "Staff" },
                new Role { RoleId = 4, RoleDescription = "Intern" },
                new Role { RoleId = 5, RoleDescription = "Consultant" }
            };

            // Interogări LINQ pentru persoane:

            // 1. Toate persoanele cu vârsta > 18
            var adults = people.Where(p => p.Age > 18).ToList();
            Console.WriteLine("People with age > 18:");
            adults.ForEach(p => Console.WriteLine(p));

            // 2. Toate numele persoanelor (folosim FirstName)
            var names = people.Select(p => p.FirstName).ToList();
            Console.WriteLine("\nAll person names:");
            names.ForEach(n => Console.WriteLine(n));

            // 3. Toate persoanele cu RoleId = 1
            var role1People = people.Where(p => p.RoleId == 1).ToList();
            Console.WriteLine("\nPeople with RoleId = 1:");
            role1People.ForEach(p => Console.WriteLine(p));

            // 4. Primele două persoane cele mai tinere (folosind OrderBy și Take)
            var twoYoungest = people.OrderBy(p => p.Age).Take(2).ToList();
            Console.WriteLine("\nFirst two youngest people:");
            twoYoungest.ForEach(p => Console.WriteLine(p));

            // 5. Toate persoanele, cu excepția celor două cele mai tinere (folosind Skip)
            var exceptTwoYoungest = people.OrderBy(p => p.Age).Skip(2).ToList();
            Console.WriteLine("\nAll but the two youngest people:");
            exceptTwoYoungest.ForEach(p => Console.WriteLine(p));

            // 6. Toate persoanele împreună cu rolul lor (join între people și roles)
            var peopleWithRoles = from person in people
                                  join role in roles on person.RoleId equals role.RoleId
                                  select new { person.FirstName, person.LastName, Role = role.RoleDescription };
            Console.WriteLine("\nPeople with their roles:");
            foreach (var pr in peopleWithRoles)
            {
                Console.WriteLine($"{pr.FirstName} {pr.LastName} - {pr.Role}");
            }

            // 7. Persoane ordonate descrescător după vârstă
            var peopleByAgeDesc = people.OrderByDescending(p => p.Age).ToList();
            Console.WriteLine("\nPeople ordered by age descending:");
            peopleByAgeDesc.ForEach(p => Console.WriteLine(p));

            // 8. Persoane grupate după rol (după un join cu roles)
            var peopleGroupedByRole = from person in people
                                      join role in roles on person.RoleId equals role.RoleId
                                      group person by role.RoleDescription;
            Console.WriteLine("\nPeople grouped by role:");
            foreach (var group in peopleGroupedByRole)
            {
                Console.WriteLine($"Role: {group.Key}");
                foreach (var p in group)
                    Console.WriteLine($"  {p}");
            }

            // 9. Persoana cu FirstName "FirstName1"
            var personFN1 = people.FirstOrDefault(p => p.FirstName == "FirstName1");
            Console.WriteLine("\nPerson with first name 'FirstName1':");
            Console.WriteLine(personFN1 != null ? personFN1.ToString() : "Not found");

            // 10. Totalul persoanelor cu rolul "Leader"
            var leaderRole = roles.FirstOrDefault(r => r.RoleDescription == "Leader");
            int totalLeaders = leaderRole != null ? people.Count(p => p.RoleId == leaderRole.RoleId) : 0;
            Console.WriteLine($"\nTotal of people with role 'Leader': {totalLeaders}");

            // 11. Verifică dacă există vreo persoană cu FirstName "BA"
            bool existsBA = people.Any(p => p.FirstName == "BA");
            Console.WriteLine($"\nIs there any person with first name 'BA'? {existsBA}");

            // 12. Prima persoană cu vârsta 60
            var personAge60 = people.FirstOrDefault(p => p.Age == 60);
            Console.WriteLine("\nFirst person with age 60:");
            Console.WriteLine(personAge60 != null ? personAge60.ToString() : "Not found");


            // -------------------------------
            // PARTEA 2: Produse, Clienți, Comenzi, Detalii comenzi
            // -------------------------------

            // Crearea unei liste de produse
            List<Product> products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Apple",         UnitPrice = 5.0,  Category = "Food" },
                new Product { ProductId = 2, Name = "Orange Juice",  UnitPrice = 12.5, Category = "Drink" },
                new Product { ProductId = 3, Name = "Shampoo",       UnitPrice = 15.0, Category = "Care" },
                new Product { ProductId = 4, Name = "Bread",         UnitPrice = 2.5,  Category = "Food" },
                new Product { ProductId = 5, Name = "Water",         UnitPrice = 1.0,  Category = "Drink" },
                new Product { ProductId = 6, Name = "Chocolate",     UnitPrice = 10.0, Category = "Food" },
                new Product { ProductId = 7, Name = "Lotion",        UnitPrice = 20.0, Category = "Care" }
            };

            // Crearea unei liste de clienți
            List<Customer> customers = new List<Customer>
            {
                new Customer { CustomerId = 1, CustomerName = "Alice",   Country = "UK",     City = "London",    Phone = "0711 111 111" },
                new Customer { CustomerId = 2, CustomerName = "Bob",     Country = "USA",    City = "New York",  Phone = "0722 222 222" },
                new Customer { CustomerId = 3, CustomerName = "Charlie", Country = "UK",     City = "London",    Phone = "0723 456 789" },
                new Customer { CustomerId = 4, CustomerName = "Diana",   Country = "Romania",City = "Bucharest", Phone = "0733 333 333" },
                new Customer { CustomerId = 5, CustomerName = "Eve",     Country = "France", City = "Paris",     Phone = "0744 444 444" }
            };

            // Crearea unei liste de comenzi
            List<Order> orders = new List<Order>
            {
                new Order { OrderId = 1, OrderDate = new DateTime(2021, 5, 10),  CustomerId = 1 },
                new Order { OrderId = 2, OrderDate = new DateTime(2021, 6, 15),  CustomerId = 3 },
                new Order { OrderId = 3, OrderDate = new DateTime(2022, 1, 20),  CustomerId = 2 },
                new Order { OrderId = 4, OrderDate = new DateTime(2021, 12, 25), CustomerId = 4 },
                new Order { OrderId = 5, OrderDate = new DateTime(2020, 7, 5),   CustomerId = 5 },
                new Order { OrderId = 6, OrderDate = new DateTime(2021, 3, 3),   CustomerId = 3 }
            };

            // Crearea unei liste de detalii comenzi
            List<OrderDetail> orderDetails = new List<OrderDetail>
            {
                new OrderDetail { OrderId = 1, ProductId = 2, Quantity = 2 },
                new OrderDetail { OrderId = 1, ProductId = 4, Quantity = 3 },
                new OrderDetail { OrderId = 2, ProductId = 3, Quantity = 1 },
                new OrderDetail { OrderId = 2, ProductId = 7, Quantity = 2 },
                new OrderDetail { OrderId = 3, ProductId = 1, Quantity = 10 },
                new OrderDetail { OrderId = 4, ProductId = 6, Quantity = 5 },
                new OrderDetail { OrderId = 5, ProductId = 5, Quantity = 20 },
                new OrderDetail { OrderId = 6, ProductId = 7, Quantity = 1 },
                new OrderDetail { OrderId = 6, ProductId = 2, Quantity = 1 }
            };

            // Interogări LINQ pentru produse:

            // 1. Produsele cu UnitPrice >= 10
            var productsOver10 = products.Where(p => p.UnitPrice >= 10).ToList();
            Console.WriteLine("\nProducts with UnitPrice >= 10:");
            productsOver10.ForEach(p => Console.WriteLine(p));

            // 2. Toate numele produselor
            var productNames = products.Select(p => p.Name).ToList();
            Console.WriteLine("\nAll product names:");
            productNames.ForEach(n => Console.WriteLine(n));

            // 3. Lista produselor (nume și preț) cu UnitPrice >= 10
            var productNameAndPrice = products.Where(p => p.UnitPrice >= 10)
                                              .Select(p => new { p.Name, p.UnitPrice })
                                              .ToList();
            Console.WriteLine("\nProduct names and UnitPrices (>=10):");
            foreach (var item in productNameAndPrice)
                Console.WriteLine($"{item.Name}: {item.UnitPrice}");

            // 4. Cele mai scumpe 2 produse (Take)
            var top2Expensive = products.OrderByDescending(p => p.UnitPrice).Take(2).ToList();
            Console.WriteLine("\nTop 2 expensive products:");
            top2Expensive.ForEach(p => Console.WriteLine(p));

            // 5. Toate produsele, cu excepția celor 2 mai scumpe (Skip)
            var exceptTop2Expensive = products.OrderByDescending(p => p.UnitPrice).Skip(2).ToList();
            Console.WriteLine("\nProducts except top 2 expensive:");
            exceptTop2Expensive.ForEach(p => Console.WriteLine(p));

            // 6. Lista de clienți împreună cu comenzile lor
            var customersWithOrders = from cust in customers
                                      join ord in orders on cust.CustomerId equals ord.CustomerId into orderGroup
                                      select new { Customer = cust, Orders = orderGroup };
            Console.WriteLine("\nCustomers with their orders:");
            foreach (var item in customersWithOrders)
            {
                Console.WriteLine($"{item.Customer.CustomerName} has orders:");
                foreach (var ord in item.Orders)
                    Console.WriteLine($"  Order {ord.OrderId} on {ord.OrderDate.ToShortDateString()}");
            }

            // 7. Produsele ordonate după Category și UnitPrice descrescător
            var productsByCategoryAndPrice = products.OrderBy(p => p.Category)
                                                     .ThenByDescending(p => p.UnitPrice)
                                                     .ToList();
            Console.WriteLine("\nProducts ordered by Category and descending UnitPrice:");
            productsByCategoryAndPrice.ForEach(p => Console.WriteLine($"{p.Category} - {p.Name}: {p.UnitPrice}"));

            // 8. Produsele grupate după Category
            var productsGroupedByCategory = products.GroupBy(p => p.Category);
            Console.WriteLine("\nProducts grouped by Category:");
            foreach (var group in productsGroupedByCategory)
            {
                Console.WriteLine($"Category: {group.Key}");
                foreach (var p in group)
                    Console.WriteLine($"  {p.Name}: {p.UnitPrice}");
            }

            // 9. Clienții care au comenzi în 2021
            var customersWith2021Orders = (from ord in orders
                                           where ord.OrderDate.Year == 2021
                                           join cust in customers on ord.CustomerId equals cust.CustomerId
                                           select cust)
                                           .Distinct()
                                           .ToList();
            Console.WriteLine("\nCustomers with orders in 2021:");
            customersWith2021Orders.ForEach(c => Console.WriteLine(c.CustomerName));

            // 10. Primul client cu numărul de telefon "0723 456 789"
            var customerWithPhone = customers.FirstOrDefault(c => c.Phone == "0723 456 789");
            Console.WriteLine("\nFirst customer with phone '0723 456 789':");
            Console.WriteLine(customerWithPhone != null ? customerWithPhone.CustomerName : "Not found");

            // 11. Numărul total de clienți din London
            int totalCustomersLondon = customers.Count(c => c.City == "London");
            Console.WriteLine($"\nTotal number of customers from London: {totalCustomersLondon}");

            // 12. Verifică dacă există vreun client din Romania
            bool anyFromRomania = customers.Any(c => c.Country == "Romania");
            Console.WriteLine($"\nIs there any customer from Romania? {anyFromRomania}");

            // 13. Totalul sumelor comenzilor din 2021
            // Pentru fiecare comandă din 2021, se calculează totalul = sum(quantity * UnitPrice)
            var totalOrderSum2021 = (from ord in orders
                                     where ord.OrderDate.Year == 2021
                                     join od in orderDetails on ord.OrderId equals od.OrderId
                                     join prod in products on od.ProductId equals prod.ProductId
                                     select od.Quantity * prod.UnitPrice).Sum();
            Console.WriteLine($"\nTotal sum of orders from 2021: {totalOrderSum2021}");

            // Final
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
