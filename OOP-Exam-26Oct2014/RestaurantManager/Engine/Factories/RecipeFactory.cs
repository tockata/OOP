﻿using RestaurantManager.Models;

namespace RestaurantManager.Engine.Factories
{
    using System;
    using Interfaces;
    using Interfaces.Engine;

    public class RecipeFactory : IRecipeFactory
    {
        public IDrink CreateDrink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
        {
            return new Drink(name, price, calories, quantityPerServing, timeToPrepare, isCarbonated);
        }

        public ISalad CreateSalad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
        {
            return new Salad(name, price, calories, quantityPerServing, timeToPrepare, containsPasta);
        }
        
        public IMainCourse CreateMainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string type)
        {
            MainCourseType mainCourseType;
            Enum.TryParse(type, out mainCourseType);
            return new MainCourse(name, price, calories, quantityPerServing, timeToPrepare, isVegan, mainCourseType);
        }

        public IDessert CreateDessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
        {
            return new Dessert(name, price, calories, quantityPerServing, timeToPrepare, isVegan);
        }
    }
}
