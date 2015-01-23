using System;

namespace _02_LaptopShop
{
    class Battery
    {
        private string batteryType;
        private int mAh;
        private int cells;

        public string BatteryType
        {
            get { return this.batteryType; }
            set
            {
                if (value == "Li-Ion" || value == "Ni-Mh")
                {
                    this.batteryType = value;
                }
                else
                {
                    throw new ArgumentException("Accepted battery types: Li-Ion and Ni-Mh");
                }
            }
        }

        public int MAh
        {
            get { return this.mAh; }
            set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentException("Battery mAh must be between 0 and 10000.");
                }
                this.mAh = value;
            }
        }

        public int Cells
        {
            get { return this.cells; }
            set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentException("Cells must be between 2 and 6.");
                }
                this.cells = value;
            }
        }

        public Battery(string batteryType, int mAh, int cells)
        {
            this.BatteryType = batteryType;
            this.MAh = mAh;
            this.Cells = cells;
        }

        public override string ToString()
        {
            return this.BatteryType + ", " + this.Cells + "-cells, " + this.MAh + " mAh";
        }
    }
}
