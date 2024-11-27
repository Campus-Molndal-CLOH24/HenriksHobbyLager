using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenriksHobbyLager.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastUpdated { get; set; }  // Frågetecknet är för att jag är osäker på datumet
    }
}
=======

public class Product
 {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; }
    public DateTime Created { get; set; }
    public DateTime? LastUpdated { get; set; }  // it means the property can hold a null value. 
}


>>>>>>> 40012c4e209916fd5c6b4dd14bc22293b2b1ba6b
