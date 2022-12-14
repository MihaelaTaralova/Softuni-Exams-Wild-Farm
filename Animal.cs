using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Exceptions;

namespace WildFarm
{
    public abstract class Animal : IAnimal
    {
        private const string UneatableFoodMessage = "{0} does not eat {1}!";
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
          
        }

        public string Name { get; private set; }
             

        public double Weight { get; set; }

      
        public int FoodEaten { get; private set; }
        public abstract double WeightMultiplier { get; }
        public abstract ICollection<Type> PrefferedFoods { get; }
        public abstract string ProduceSound();

        public void Feed(IFood food)
        {
            if(!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new UneatableFoodException(string.Format(UneatableFoodMessage, this.GetType().Name, food.GetType().Name));
            }
            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

    }
}
