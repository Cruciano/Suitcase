using Suitcase.Implementation.Composite;
using Suitcase.Interfaces;

namespace Suitcase.Implementation.ChainOfResponsibility
{
    public class ComufloraFactory : IRandomFactory
    {
        public IRandomFactory Handler { get; set; }
        public IComponent HandleRequest(int random, IComponent parent)
        {
            if (random < 80 && random > 40)
            {
                return new Animal("Random comuflora", 20, AnimalType.Comuflora, parent);
            }
            
            return Handler?.HandleRequest(random, parent);
        }
    }
}