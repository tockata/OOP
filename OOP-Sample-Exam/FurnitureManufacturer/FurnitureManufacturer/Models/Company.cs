using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures = new List<IFurniture>();

        public Company(string name, string registrationNumber)
        {
            if (ValidateName(name))
            {
                this.name = name;   
            }

            if (ValidateRegistrationNumber(registrationNumber))
            {
                this.registrationNumber = registrationNumber;   
            }
        }

        public string Name
        {
            get { return this.name; }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return new List<IFurniture>(this.furnitures); }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {

            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            IFurniture result = this.Furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
            return result;
        }

        public string Catalog()
        {
            StringBuilder catalog = new StringBuilder();
            catalog.AppendFormat("{0} - {1} - {2} {3}",
                this.Name, this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            if (this.Furnitures.Count != 0)
            {
                var sortedFurnitures =
                    from f in this.Furnitures
                    orderby f.Price ascending, f.Model ascending
                    select f;

                foreach (var furniture in sortedFurnitures)
                {
                    catalog.AppendFormat("\n" + furniture);
                }
            }

            return catalog.ToString();
        }

        private bool ValidateName(string nameToCheck)
        {
            if (string.IsNullOrEmpty(nameToCheck) || nameToCheck.Length < 5)
            {
                throw new ArgumentException("Company name cannot be null or empty and must be at least 5 symbold long.");
            }

            return true;
        }

        private bool ValidateRegistrationNumber(string registrationNumberToCheck)
        {
            string pattern = @"\d{10}";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(registrationNumberToCheck))
            {
                throw new ArgumentException("Registration number must be 10 digits extactly.");
            }

            return true;
        }
    }
}
