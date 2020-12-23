namespace Suitcase.Interfaces
{
    public interface IComponent
    {
        public string Name { get; }

        public IComponent Parent { get; }

        public int FoodRequired { get; }

        public AnimalType AnimalType { get; }

        public string Scream(string animalName);

        public IComponent Add(IComponent component);
    }
}