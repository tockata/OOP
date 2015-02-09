using System.Linq.Expressions;
using System.Text;
using RestaurantManager.Interfaces;
using System;

namespace RestaurantManager.Models
{
    public class Drink : Recipe, IDrink
    {
        private bool isCarbonated;

        public Drink(string name, decimal price, int calories, int quantityPerServing,
            int timeToPrepare, bool isCarbonated) 
            : base(name, price, calories, quantityPerServing, MetricUnit.Milliliters, timeToPrepare)
        {
            this.isCarbonated = isCarbonated;
            this.ValidateCalories(calories);
            this.ValidateTimeToPrepare(timeToPrepare);
        }

        void ValidateCalories(int calories)
        {
            if (calories > 100)
            {
                throw new ArgumentException("The calories in a drink must not be greater than 100.");
            }
        }

        void ValidateTimeToPrepare(int timeToPrepare)
        {
            if (timeToPrepare > 20)
            {
                throw new ArgumentException("The time to prepare a drink must not be greater than 20 minutes.");
            }
        }

        public bool IsCarbonated
        {
            get { return this.isCarbonated; }
        }

        public override string ToString()
        {
            return (base.ToString() + "\nCarbonated: " + (this.IsCarbonated ? "yes" : "no"));
        }
    }
}
