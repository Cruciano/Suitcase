namespace Suitcase.Interfaces
{
    public interface IRandomFactory
    {
        public IRandomFactory Handler { get; set; }

        public IComponent HandleRequest(int random, IComponent parent);
    }
}