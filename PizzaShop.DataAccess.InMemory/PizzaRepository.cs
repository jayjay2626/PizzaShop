using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using PizzaShop.Core.Models;

namespace PizzaShop.DataAccess.InMemory
{
    public class PizzaRepository
    {
        // First thing to do is create an ObjectCache
        ObjectCache cache = MemoryCache.Default;

        // Internal List of Pizza
        List<Pizza> pizzas;

        public PizzaRepository()
        {
            pizzas = cache["pizzas"] as List<Pizza>;
            if (pizzas == null)
            {
                pizzas = new List<Pizza>();
            }
        }

        public void Commit()
        {
            cache["pizzas"] = pizzas;
        }

        public void Insert(Pizza p)
        {
            pizzas.Add(p);
        }

        public void Update(Pizza pizza)
        {
            Pizza pizzaToUpdate = pizzas.Find(p => p.Id == pizza.Id);

            if (pizzaToUpdate != null)
            {
                pizzaToUpdate = pizza;
            } else
            {
                throw new Exception("Pizza not found.");
            }
        }

        public Pizza Find(string Id)
        {
            Pizza pizza = pizzas.Find(p => p.Id == Id);

            if (pizza != null)
            {
                return pizza;
            }
            else
            {
                throw new Exception("Pizza not found.");
            }
        }

        public IQueryable<Pizza> Collection()
        {
            return pizzas.AsQueryable();
        }

        public void Delete(string Id)
        {
            Pizza pizzaToDelete = pizzas.Find(p => p.Id == Id);

            if (pizzaToDelete != null)
            {
                pizzas.Remove(pizzaToDelete);
            }
            else
            {
                throw new Exception("Pizza not found.");
            }
        }
    }
}
