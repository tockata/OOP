using System.Linq;
using System.Text;
using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class Restaurant : IRestaurant
    {
        private string name;
        private string location;
        private IList<IRecipe> receipes = new List<IRecipe>();

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name is required.");
                }

                this.name = value;
            }
        }

        public string Location
        {
            get { return this.location; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The location is required.");
                }

                this.location = value;
            }
        }

        public IList<IRecipe> Recipes
        {
            get { return new List<IRecipe>(this.receipes); }
        }

        public void AddRecipe(IRecipe recipe)
        {
            this.receipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.receipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            string restaurant = "";
            restaurant += "***** " + this.Name + " - " + this.Location + " *****";
            if (this.Recipes.Count == 0)
            {
                restaurant += "\nNo recipes... yet";
                return restaurant;
            }

            var sortedDrinks =
                from recipe in this.Recipes
                where recipe is Drink
                orderby recipe.Name
                select recipe;

            if (sortedDrinks.Count() != 0)
            {
                restaurant += "\n~~~~~ DRINKS ~~~~~";
                foreach (var sortedDrink in sortedDrinks)
                {
                    restaurant += "\n" + sortedDrink;
                }
            }

            var sortedSalads =
                from recipe in this.Recipes
                where recipe is Salad
                orderby recipe.Name
                select recipe;

            if (sortedSalads.Count() != 0)
            {
                restaurant += "\n~~~~~ SALADS ~~~~~";
                foreach (var sortedSalad in sortedSalads)
                {
                    restaurant += "\n" + sortedSalad;
                }
            }

            var sortedMainCourses =
                from recipe in this.Recipes
                where recipe is MainCourse
                orderby recipe.Name
                select recipe;

            if (sortedMainCourses.Count() != 0)
            {
                restaurant += "\n~~~~~ MAIN COURSES ~~~~~";
                foreach (var sortedMainCourse in sortedMainCourses)
                {
                    restaurant += "\n" + sortedMainCourse;
                }
            }

            var sortedDesserts =
                from recipe in this.Recipes
                where recipe is Dessert
                orderby recipe.Name
                select recipe;

            if (sortedDesserts.Count() != 0)
            {
                restaurant += "\n~~~~~ DESSERTS ~~~~~";
                foreach (var sortedDessert in sortedDesserts)
                {
                    restaurant += "\n" + sortedDessert;
                }
            }

            return restaurant;
        }
    }
}
