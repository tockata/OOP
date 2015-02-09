using FarmersCreed.Units;

namespace FarmersCreed.Simulator
{
    class UpdatedFarmSimulator : FarmSimulator
    {
        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');

            string action = inputCommands[0];

            switch (action)
            {
                case "exploit":
                    {
                        if (inputCommands[1] == "plant")
                        {
                            this.farm.Exploit(GetPlantById(inputCommands[2]));
                        }
                        else
                        {
                            this.farm.Exploit(GetAnimalById(inputCommands[2]));
                        }
                    }
                    break;
                case "feed":
                    {
                        int quantity = int.Parse(inputCommands[3]);
                        Food product = GetProductById(inputCommands[2]) as Food;
                        this.farm.Feed(GetAnimalById(inputCommands[1]), product, quantity);
                    }
                    break;
                case "water":
                    {
                        this.farm.Water(GetPlantById(inputCommands[1]));
                    }
                    break;
                default: base.ProcessInput(input);
                    break;
            }    
        }

        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "TobaccoPlant":
                    {
                        var plant = new TobaccoPlant(id);
                        (this.farm as Farm).AddPlant(plant);
                    }
                    break;
                case "CherryTree":
                    {
                        var cherry = new CherryTree(id);
                        (this.farm as Farm).AddPlant(cherry);
                    }
                    break;
                case "Cow":
                    {
                        var cow = new Cow(id);
                        (this.farm as Farm).AddAnimal(cow);
                    }
                    break;
                case "Swine":
                    {
                        var swine = new Swine(id);
                        (this.farm as Farm).AddAnimal(swine);
                    }
                    break;
                default: base.AddObjectToFarm(inputCommands);
                    break;
            }
            
        }
    }
}
