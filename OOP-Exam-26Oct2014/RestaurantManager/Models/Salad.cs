using System.Text;
using RestaurantManager.Interfaces;
using System;

namespace RestaurantManager.Models
{
    public class Salad : Meal, ISalad
    {
        private bool containsPasta;

        public Salad(string name, decimal price, int calories, int quantityPerServing,
            int timeToPrepare, bool containsPasta) 
            : base(name, price, calories, quantityPerServing, timeToPrepare, true)
        {
            this.containsPasta = containsPasta;
        }

        public bool ContainsPasta
        {
            get { return this.containsPasta; }
        }

        public override string ToString()
        {
            string salad = base.ToString();
            salad += "\nContains pasta: " + (this.ContainsPasta ? "yes" : "no");

            return salad;
        }
    }
}
