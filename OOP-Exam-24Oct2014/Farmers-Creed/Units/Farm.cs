using System.Linq;
using System.Text;

namespace FarmersCreed.Units
{
    using System.Collections.Generic;
    using Interfaces;

    public class Farm : GameObject, IFarm
    {
        private List<Plant> plants = new List<Plant>();
        private List<Animal> animals = new List<Animal>();
        private List<Product> products = new List<Product>(); 

        public Farm(string id)
            : base(id)
        {
        }

        public List<Plant> Plants
        {
            get
            {
                return new List<Plant>(this.plants);
            }
        }

        public List<Animal> Animals
        {
            get
            {
                return new List<Animal>(this.animals);
            }
        }

        public List<Product> Products
        {
            get
            {
                return new List<Product>(this.products);
            }
        }

        public void AddPlant(Plant plant)
        {
            this.plants.Add(plant);
        }

        public void AddAnimal(Animal animal)
        {
            this.animals.Add(animal);
        }

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public void Exploit(IProductProduceable productProducer)
        {
            var product = productProducer.GetProduct();

            bool containsProduct = false;
            for (int i = 0; i < this.products.Count; i++)
            {
                if (this.products[i].Id == product.Id)
                {
                    this.products[i].Quantity += product.Quantity;
                    containsProduct = true;
                }
            }

            if (!containsProduct)
            {
                this.products.Add(product);
            }
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            animal.Eat(edibleProduct, productQuantity);
        }

        public void Water(Plant plant)
        {
            plant.Water();
        }

        public void UpdateFarmState()
        {
            // TODO: Process all animal and plant behavior
            foreach (var plant in this.plants)
            {
                if (!plant.HasGrown)
                {
                    plant.Grow();
                }
                if (plant.HasGrown)
                {
                    plant.Wither();
                }
            }

            foreach (var animal in this.animals)
            {
                if (animal.IsAlive)
                {
                    animal.Starve();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder farm = new StringBuilder(base.ToString() + "\n");

            var sortedAnimals =
                from animal in this.Animals
                where animal.IsAlive
                orderby animal.Id
                select animal;

            var sortedPlants =
                from plant in this.Plants
                where plant.IsAlive
                orderby plant.Health ascending , plant.Id ascending 
                select plant;

            var sortedProducts =
                from product in this.Products
                orderby product.ProductType.ToString() ascending, 
                    product.Quantity descending, product.Id ascending
                select product;

            foreach (var animal in sortedAnimals)
            {
                farm.AppendLine(animal.ToString());
            }

            foreach (var plant in sortedPlants)
            {
                farm.AppendLine(plant.ToString());
            }

            foreach (var product in sortedProducts)
            {
                farm.AppendLine(product.ToString());
            }

            return farm.ToString();
        }
    }
}
