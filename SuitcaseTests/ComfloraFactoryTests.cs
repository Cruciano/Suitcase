using FluentAssertions;
using Moq;
using NUnit.Framework;
using Suitcase;
using Suitcase.Implementation.ChainOfResponsibility;
using Suitcase.Implementation.Composite;
using Suitcase.Interfaces;

namespace SuitcaseTests
{
    [TestFixture]
    public class ComfloraFactoryTests
    {
        private IRandomFactory _comufloraFactory;
        private Mock<IRandomFactory> _nextFactoryMock;
        private Mock<IComponent> _pocketMock;
        
        [SetUp]
        public void SetUp()
        {
            _comufloraFactory = new ComufloraFactory();
            _nextFactoryMock = new Mock<IRandomFactory>();
            _pocketMock = new Mock<IComponent>();

            _comufloraFactory.Factory = _nextFactoryMock.Object;
        }

        [Test]
        public void HandleRequest_IfNumberIsCorrect_ReturnsComuflora()
        {
            _comufloraFactory.Create(50, _pocketMock.Object)
                .Should().BeEquivalentTo(new Animal("Random comuflora", 20, AnimalType.Comuflora, _pocketMock.Object));
        }
    }
}