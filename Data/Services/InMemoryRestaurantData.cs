using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood_Core.Data.Models;

namespace OdeToFood_Core.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>{
                new Restaurant { Id = 1, Name = "Pizza Hut", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 1, Name = "Prems", Cuisine = CuisineType.Indian },
                new Restaurant { Id = 1, Name = "Applebee's", Cuisine = CuisineType.American },
                new Restaurant { Id = 1, Name = "Brio's", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 1, Name = "McDonald's", Cuisine = CuisineType.None }
            };
        }

        public void Create(Restaurant r)
        {
            restaurants.Add(r);
            r.Id = restaurants.Max(resto => resto.Id) + 1;
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant r)
        {
            var existing = Get(r.Id);

            if (existing != null)
            {
                existing.Name = r.Name;
                existing.Cuisine = r.Cuisine;
            }
        }

        public void Delete(int Id)
        {
        }
    }
}
