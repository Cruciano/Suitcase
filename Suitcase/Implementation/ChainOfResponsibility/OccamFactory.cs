using Suitcase.Implementation.Composite;
using Suitcase.Interfaces;

namespace Suitcase.Implementation.ChainOfResponsibility
{
    public class OccamFactory : IRandomFactory
    {
        public IRandomFactory Factory { get; set; }
        
        public IComponent Create(int random, IComponent parent)
        {
            if (random > 80)
            {
                return new Animal("Random occam", 20, AnimalType.Occam, parent);
            }
            
            return Factory?.Create(random, parent);
        }
    }
}