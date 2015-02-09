using RestaurantManager.Models;

namespace RestaurantManager.Engine.Factories
{
    using Interfaces.Engine;
    using Interfaces;

    public class RestaurantFactory : IRestaurantFactory
    {
        public IRestaurant CreateRestaurant(string name, string location)
        {
            return new Restaurant(name, location);
        }
    }
}
