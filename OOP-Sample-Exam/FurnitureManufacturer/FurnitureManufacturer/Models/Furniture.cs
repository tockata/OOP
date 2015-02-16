using System;
using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture : IFurniture
    {
        private readonly string model;
        private readonly string material;
        private decimal price;
        protected decimal height;

        protected Furniture(string model, string material, decimal price, decimal height)
        {
            if (ValidateModel(model))
            {
                this.model = model;
            }

            this.material = material;
            this.price = price;

            if (ValidateHeight(height))
            {
                this.height = height;
            }
        }

        public string Model
        {
            get { return this.model; }
        }

        public string Material
        {
            get { return this.material; }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be positive.");
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get { return this.height; }
        }

        private bool ValidateModel(string modelToCheck)
        {
            if (string.IsNullOrEmpty(modelToCheck) || modelToCheck.Length < 3)
            {
                throw new ArgumentException("Model cannot be null or empty and must be at least 3 symbold long.");
            }

            return true;
        }

        protected bool ValidateHeight(decimal heightToCheck)
        {
            if (heightToCheck <= 0)
            {
                throw new ArgumentOutOfRangeException("Height must be positive.");
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder furniture = new StringBuilder();
            furniture.AppendFormat("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height);

            return furniture.ToString();
        }
    }
}
