using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop.Core.Models
{
    public class Pizza
    {
        // Id is of string type because we are going to
        // auto-generate an ID based off GUID instead
        // of letting the database generate the ID
        public string Id { get; set; }

        [StringLength(30)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0, 1000)]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        public Pizza()
        {
            // Auto-generate the 
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
