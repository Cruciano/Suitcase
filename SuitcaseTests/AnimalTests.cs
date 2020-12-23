using FluentAssertions;
using Moq;
using NUnit.Framework;
using Suitcase;
using Suitcase.Implementation.Composite;
using Suitcase.Interfaces;

namespace SuitcaseTests
{
    [TestFixture]
    public class AnimalTests
    {
        private Mock<IComponent> _mock;
        private IComponent _animal;
        private string _animalName;

        [SetUp]
        public void SetUp()
        {
            _animalName = "Test";
            _mock = new Mock<IComponent>();
            _animal = new Animal(_animalName, 10, AnimalType.Comuflora, _mock.Object);
            
            _mock.Setup(m => m.Add(It.Is<IComponent>(c => c.AnimalType == _animal.AnimalType)))
                .Returns(_animal);
        }

        [Test]
        public void Add_InvokesAnimalParentAdd()
        {
            _animal.Add(new Animal("test", 1, _animal.AnimalType, _animal)).Should().Be(_animal);
        }
        
        [Test]
        public void Scream_ReturnsCorrectScream()
        {
            _animal.Scream(_animalName).Should().Contain(_animalName);
        }
    }
}