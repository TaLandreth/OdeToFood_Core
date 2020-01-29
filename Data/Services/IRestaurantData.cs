using System;
using OdeToFood_Core.Data.Models;
using System.Collections.Generic;

namespace OdeToFood_Core.Data.Services
{
    public interface IRestaurantData
    {
        public IEnumerable<Restaurant> GetAll();
        public Restaurant Get(int id);
        public void Create(Restaurant restaurant);
        public void Update(Restaurant restaurant);
        public void Delete(int id);
    }
}
