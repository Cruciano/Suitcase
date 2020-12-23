namespace Suitcase.Interfaces
{
    public interface IRandomFactory
    {
        public IRandomFactory Factory { get; set; }

        public IComponent Create(int random, IComponent parent);
    }
}