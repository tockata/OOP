﻿using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal heightToSet)
        {
            if (this.ValidateHeight(heightToSet))
            {
                this.height = heightToSet;
            }
        }
    }
}
