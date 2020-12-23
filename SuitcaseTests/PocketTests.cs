using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Suitcase;
using Suitcase.Implementation.Composite;
using Suitcase.Interfaces;

namespace SuitcaseTests
{
    [TestFixture]
    public class PocketTests
    {
        private IComponent _pocket;
        private IComponent _testAnimal;
        
        [SetUp]
        public void Setup()
        {
            _testAnimal = new Animal("Test1", 10, AnimalType.Comuflora, _pocket);
            _pocket = new Pocket("Test", AnimalType.Comuflora, null);
        }

        [Test]
        public void Add_AddsAnimalWithCorrectType()
        {
            _pocket.Add(_testAnimal).Should().Be(_testAnimal);
        }
        
        [Test]
        public void FoodRequired_ReturnsSumOfAllFood()
        {
            _pocket.Add(_testAnimal);
            _pocket.FoodRequired.Should().Be(10);
        }

        [Test]
        public void Scream_AllAnimalsScreams()
        {
            _pocket.Add(_testAnimal);
            _pocket.Scream(null).Should().Contain("Test1 screams!");
        }

        [Test]
        public void Scream_WithName_ReturnsOneScream()
        {
            _pocket.Add(_testAnimal);
            _pocket.Scream("Test1").Should().Contain("Target scream of Test1 screams!");
        }
    }
}