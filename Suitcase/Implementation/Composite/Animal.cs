using Suitcase.Interfaces;

namespace Suitcase.Implementation.Composite
{
    public class Animal : IComponent
    {
        public Animal(string name, int foodRequired, AnimalType animalType, IComponent parent)
        {
            Name = name;
            FoodRequired = foodRequired;
            AnimalType = animalType;
            Parent = parent;
        }
        
        public string Name { get; }
        
        public IComponent Parent { get; }

        public int FoodRequired { get; }
        
        public AnimalType AnimalType { get; }
        
        public string Scream(string animalName)
        {
            return $"{animalName} screams! \n";
        }

        public IComponent Add(IComponent component)
        {
            return Parent.Add(component);
        }
    }
}