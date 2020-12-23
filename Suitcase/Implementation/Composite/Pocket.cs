using System;
using System.Collections.Generic;
using Suitcase.Interfaces;

namespace Suitcase.Implementation.Composite
{
    public class Pocket : ISuitcase
    {
        private ICollection<IComponent> _components = new List<IComponent>();

        public Pocket(string name, AnimalType animalType, IComponent parent)
        {
            Name = name;
            AnimalType = animalType;
            Parent = parent;
        }
        
        public string Name { get; }

        public IComponent Parent { get; }

        public DayTime DayTime { get; set; }

        public int FoodRequired
        {
            get
            {
                var totalFoodRequired = 0;
                foreach (var component in _components)
                {
                    totalFoodRequired += component.FoodRequired;
                }

                return totalFoodRequired;
            }
        }

        public AnimalType AnimalType { get; }

        public string Scream(string animalName)
        {
            var screams = "";

            foreach (var component in _components)
            {
                if (string.IsNullOrEmpty(animalName) && DayTime == DayTime.Day)
                {
                    screams += component.Scream(component.Name);
                }
                else
                {
                    if (component.Name.Equals(animalName))
                    {
                        screams += component.Scream($"Target scream of {component.Name}");
                    }
                }
            }

            return screams;
        }

        public IComponent Add(IComponent component)
        {
            if((AnimalType == AnimalType.AnyType) || (AnimalType == component.AnimalType))
            {
                _components.Add(component);
                return component;
            }

            throw new ArgumentOutOfRangeException(nameof(AnimalType), "This animal type is unknown!");
        }
    }
}