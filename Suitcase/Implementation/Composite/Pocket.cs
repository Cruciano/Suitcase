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
            switch (AnimalType)
            {
                case AnimalType.AnyType:
                    _components.Add(component);
                    return component;
                
                case AnimalType.Lichurka:
                    if (AnimalType != AnimalType.Lichurka) return null;
                    _components.Add(component);
                    return component;
                
                case AnimalType.Comuflora:
                    if (AnimalType != AnimalType.Comuflora) return null;
                    _components.Add(component);
                    return component;

                case AnimalType.Occam:
                    if (AnimalType != AnimalType.Occam) return null;
                    _components.Add(component);
                    return component;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(AnimalType), "This animal type is unknown!");
            }
        }
    }
}