using Suitcase.Implementation.Composite;
using Suitcase.Interfaces;

namespace Suitcase.Implementation.ChainOfResponsibility
{
    public class ComufloraFactory : IRandomFactory
    {
        public IRandomFactory Factory { get; set; }

        public IComponent Create(int random, IComponent parent)
        {
            if (random < 80 && random > 40)
            {
                return new Animal("Random comuflora", 20, AnimalType.Comuflora, parent);
            }
            
            return Factory?.Create(random, parent);
        }
    }
}