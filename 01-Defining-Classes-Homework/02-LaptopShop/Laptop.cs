using System;
using System.Runtime.CompilerServices;

namespace _02_LaptopShop
{
    public class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private int ram;
        private string gpu;
        private string hdd;
        private string screen;
        private Battery battery;
        private double batteryLife;
        private decimal price;

        public string Model
        {
            get { return this.model; }
            set
            {
                if (!ValidateString(value))
                {
                    throw new ArgumentNullException();
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (!ValidateString(value))
                {
                    throw new ArgumentNullException();
                }
                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (!ValidateString(value))
                {
                    throw new ArgumentNullException();
                }
                this.processor = value;
            }
        }

        public int Ram
        {
            get { return this.ram; }
            set
            {
                if (!ValidateNumber((decimal)value))
                {
                    throw new ArgumentException("Ram must be positive number!");
                }
                this.ram = value;
            }
        }

        public string Gpu
        {
            get { return this.gpu; }
            set
            {
                if (!ValidateString(value))
                {
                    throw new ArgumentNullException();
                }
                this.gpu = value;
            }
        }

        public string Hdd
        {
            get { return this.hdd; }
            set
            {
                if (!ValidateString(value))
                {
                    throw new ArgumentNullException();
                }
                this.hdd = value;
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (!ValidateString(value))
                {
                    throw new ArgumentNullException();
                }
                this.screen = value;
            }
        }

        public Battery Battery { get; set; }

        public double BatteryLife
        {
            get { return this.batteryLife; }
            set
            {
                if (!ValidateNumber((decimal)value))
                {
                    throw new ArgumentException("Battery life must be positive number!");
                }
                this.batteryLife = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (!ValidateNumber(value))
                {
                    throw new ArgumentException("Price must be positive number!");
                }
                this.price = value;
            }
        }

        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop(string model, decimal price, string manufacturer, string processor) 
            : this (model, price)
        {
            this.Manufacturer = manufacturer;
            this.Processor = processor;
        }

        public Laptop(string model, decimal price, string manufacturer, string processor, int ram, string gpu,
            string hdd, string screen, Battery battery, double batteryLife)
            : this (model, price, manufacturer, processor)
        {
            this.Ram = ram;
            this.Gpu = gpu;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Battery = battery;
            this.BatteryLife = batteryLife;
        }

        public override string ToString()
        {
            string laptopInfo = "Model: " + this.Model;
            laptopInfo = this.Manufacturer != null ? laptopInfo += "\n" + "Manufacturer: " + this.Manufacturer : laptopInfo += "";
            laptopInfo = this.Processor != null ? laptopInfo += "\n" + "Processor: " + this.Processor : laptopInfo += "";
            laptopInfo = this.Ram != 0 ? laptopInfo += "\n" + "Ram: " + this.Ram + " GB" : laptopInfo += "";
            laptopInfo = this.Gpu != null ? laptopInfo += "\n" + "Graphics card: " + this.Gpu : laptopInfo += "";
            laptopInfo = this.Hdd != null ? laptopInfo += "\n" + "HDD: " + this.Hdd : laptopInfo += "";
            laptopInfo = this.Screen != null ? laptopInfo += "\n" + "Screen: " + this.Screen : laptopInfo += "";
            laptopInfo = this.Battery != null ? laptopInfo += "\n" + "Battery: " + this.Battery : laptopInfo += "";
            laptopInfo = this.BatteryLife != 0 ? laptopInfo += "\n" + "Battery life: " + this.BatteryLife  + " hours": laptopInfo += "";
            laptopInfo = this.Price != 0 ? laptopInfo += "\n" + "Price: " + this.Price : laptopInfo += "";

            return laptopInfo;
        }

        public bool ValidateString(string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public bool ValidateNumber(decimal value)
        {
            return value >= 0;
        }
    }
}