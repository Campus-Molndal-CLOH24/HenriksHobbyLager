using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;

namespace HenriksHobbyLager
{
    internal class ListRepository : IListRepository
    {
        private readonly List<Product> _products = new List<Product>();
        private int _nextId = 1;
        public void ShowAllProducts()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine("Inga produkter finns i lagret. Dags att shoppa grossist!");
                return;
            }

            foreach (var product in _products)
            {
                DisplayProduct(product);
            }
        }
        public void DisplayProduct(Product product)
        {
            // Snygga streck som separerar produkterna
            Console.WriteLine($"\nID: {product.Id}");
            Console.WriteLine($"Namn: {product.Name}");
            Console.WriteLine($"Pris: {product.Price:C}");  // :C gör att det blir kronor automatiskt!
            Console.WriteLine($"Lager: {product.Stock}");
            Console.WriteLine($"Kategori: {product.Category}");
            Console.WriteLine($"Skapad: {product.Created}");
            if (product.LastUpdated.HasValue)  // Kollar om produkten har uppdaterats någon gång
                Console.WriteLine($"Senast uppdaterad: {product.LastUpdated}");
            Console.WriteLine(new string('-', 40));  // Snyggt streck mellan produkterna
        }
        public void AddProduct()
        {
            Console.WriteLine("=== Lägg till ny produkt ===");

            Console.Write("Namn: ");
            var name = Console.ReadLine();

            Console.Write("Pris: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Ogiltigt pris! Använd punkt istället för komma (lärde mig den hårda vägen)");
                return;
            }

            Console.Write("Antal i lager: ");
            if (!int.TryParse(Console.ReadLine(), out int stock))
            {
                Console.WriteLine("Ogiltig lagermängd! Hela tal endast (kan inte sälja halva helikoptrar)");
                return;
            }

            Console.Write("Kategori: ");
            var category = Console.ReadLine();

            var product = new Product
            {
                Id = _nextId++,
                Name = name,
                Price = price,
                Stock = stock,
                Category = category,
                Created = DateTime.Now
            };

            _products.Add(product);
            Console.WriteLine("Produkt tillagd! Glöm inte att hålla datorn igång!");
        }

        public void UpdateProduct()
        {
            Console.Write("Ange produkt-ID att uppdatera (finns i listan ovan): ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID! Bara siffror tack!");
                return;
            }

            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Console.WriteLine("Produkt hittades inte! Är du säker på att du skrev rätt?");
                return;
            }
            Console.Write("Nytt namn (tryck bara enter om du vill behålla det gamla): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                product.Name = name;

            Console.Write("Nytt pris (tryck bara enter om du vill behålla det gamla): ");
            var priceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out decimal price))
                product.Price = price;

            Console.Write("Ny lagermängd (tryck bara enter om du vill behålla den gamla): ");
            var stockInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(stockInput) && int.TryParse(stockInput, out int stock))
                product.Stock = stock;

            Console.Write("Ny kategori (tryck bara enter om du vill behålla den gamla): ");
            var category = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(category))
                product.Category = category;

            product.LastUpdated = DateTime.Now;
            Console.WriteLine("Produkt uppdaterad! Stäng fortfarande inte av datorn!");
        }
        public void DeleteProduct()
        {
            Console.Write("Ange produkt-ID att ta bort (dubbel-check att det är rätt, går inte att ångra!): ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID! Bara siffror är tillåtna här.");
                return;
            }

            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                Console.WriteLine("Produkt hittades inte! Puh, inget blev raderat av misstag!");
                return;
            }

            _products.Remove(product);
            Console.WriteLine("Produkt borttagen! (Hoppas det var meningen)");
        }
        public void SearchProducts()
        {
            Console.Write("Sök (namn eller kategori - versaler spelar ingen roll!): ");
            var searchTerm = Console.ReadLine()?.ToLower();

            var results = _products.Where(p => MakeLowerCaseName(p, searchTerm) ||
            MakeLowerCaseCategory(p, searchTerm)
            ).ToList();

            if (!results.Any())
            {
                Console.WriteLine("Inga produkter matchade sökningen. Prova med något annat!");
                return;
            }

            foreach (var product in results)
            {
                DisplayProduct(product);
            }
        }

        public bool MakeLowerCaseCategory(Product p, string? searchTerm)
        {
            return (p.Category ?? "").Contains(searchTerm ?? "");
        }

        public static bool MakeLowerCaseName(Product p, string? searchTerm)
        {
            return (p.Name ?? "").Contains(searchTerm ?? "", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
