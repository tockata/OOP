using System.Text;
using Estates.Interfaces;
using System;

namespace Estates.Data.Estates
{
    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private int rooms;

        public int Rooms
        {
            get
            {
                return this.rooms;
            }
            set
            {
                if (value < 0 || 20 < value)
                {
                    throw new ArgumentOutOfRangeException("Rooms must be in range [0 ... 20]");
                }

                this.rooms = value;
            }
        }

        public bool HasElevator { get; set; }

        public override string ToString()
        {
            StringBuilder buildlingEstate = new StringBuilder(base.ToString());
            buildlingEstate.Append(", Rooms: " + this.Rooms);
            buildlingEstate.Append(", Elevator: " + (this.HasElevator ? "Yes" : "No"));
            return buildlingEstate.ToString();
        }
    }
}
