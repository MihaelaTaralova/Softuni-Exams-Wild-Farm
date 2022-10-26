﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        private const double weightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight,wingSize)
        {
           
        }

        public override double WeightMultiplier => weightMultiplier;

        public override ICollection<Type> PrefferedFoods =>
           new List<Type>() { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
