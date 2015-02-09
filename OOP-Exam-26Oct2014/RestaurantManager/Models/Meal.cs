using System.Text;
using RestaurantManager.Interfaces;
using System;

namespace RestaurantManager.Models
{
    public abstract class Meal : Recipe, IMeal
    {
        private bool isVegan;

        protected Meal(string name, decimal price, int calories, int quantityPerServing,
            int timeToPrepare, bool isVegan) 
            : base(name, price, calories, quantityPerServing, MetricUnit.Grams, timeToPrepare)
        {
            this.isVegan = isVegan;
        }

        public bool IsVegan
        {
            get { return this.isVegan; }
        }

        public void ToggleVegan()
        {
            this.isVegan = !this.IsVegan;
        }

        public override string ToString()
        {
            string meal = this.IsVegan ? "[VEGAN] " : "";
            meal += base.ToString();

            return meal;
        }
    }
}
