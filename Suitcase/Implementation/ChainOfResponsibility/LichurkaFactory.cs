using Suitcase.Implementation.Composite;
using Suitcase.Interfaces;

namespace Suitcase.Implementation.ChainOfResponsibility
{
    public class LichurkaFactory : IRandomFactory
    {
        public IRandomFactory Factory { get; set; }
        
        public IComponent Create(int random, IComponent parent)
        {
            if (random < 40)
            {
                return new Animal("Random lichurka", 10, AnimalType.Lichurka, parent);
            }

            return Factory?.Create(random, parent);
        }
    }
}