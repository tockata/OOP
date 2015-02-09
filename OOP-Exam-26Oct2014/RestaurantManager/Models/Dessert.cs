using System.Text;
using RestaurantManager.Interfaces;
using System;

namespace RestaurantManager.Models
{
    public class Dessert : Meal, IDessert
    {
        private bool withSugar;

        public Dessert(string name, decimal price, int calories, int quantityPerServing,
            int timeToPrepare, bool isVegan, bool withSugar = true) 
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.withSugar = withSugar;
        }

        public bool WithSugar
        {
            get { return this.withSugar; }
        }

        public void ToggleSugar()
        {
            this.withSugar = !this.withSugar;
        }

        public override string ToString()
        {
            return (this.WithSugar ? "" : "[NO SUGAR] ") + base.ToString();
        }
    }
}
