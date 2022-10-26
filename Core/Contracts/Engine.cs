using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Exceptions;
using WildFarm.Factories;

namespace WildFarm.Core.Contracts
{
    public class Engine : IEngine
    {
        private ICollection<IAnimal> animals;
        private FoodFactory foodFactory;

        public Engine()
        {
            this.animals = new List<IAnimal>();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalArg = command.Split().ToArray();
                string[] foodArg = Console.ReadLine().Split().ToArray();
                IAnimal animal = null;
                animal = ProduceAnimal(animalArg, animal);
                IFood food = this.foodFactory.ProduceFood(foodArg[0], int.Parse(foodArg[1]));
                this.animals.Add(animal);
                Console.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Feed(food);
                }
                catch (UneatableFoodException message)
                {

                    Console.WriteLine(message.Message);
                }
            }
            foreach (IAnimal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static IAnimal ProduceAnimal(string[] animalArg, IAnimal animal)
        {
            string type = animalArg[0];
            string name = animalArg[1];
            double weight = double.Parse(animalArg[2]);

            if (type == "Owl")
            {
                double wingSize = double.Parse(animalArg[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalArg[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else
            {
                string livingRegion = animalArg[3];
                if (type == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else
                {
                    string breed = animalArg[4];
                    if (type == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else if (type == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                }
            }

            return animal;
        }
    }
}
