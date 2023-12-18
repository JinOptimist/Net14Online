using Maze.Cells;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.Cells.Creatures
{
    public class RingTest
    {
        [Test]
        [TestCase(0,5,5)]  // Герой должен получить бонус 5 ко всем характеристикам
        
        public void Ring_Step_HeroMustReceiveCorrectBonusForMoney(int initialMoney, int expectedMoney, int bonusAmount)
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var heroMock = new Mock<IHero>();
            heroMock.SetupProperty(x => x.Money, initialMoney);
         
            var ring = new Ring(0, 0, levelMock.Object, bonusAmount);

            // Action
            var result = ring.Step(heroMock.Object);

            // Assertion
            //Assert.That(result, Is.True, "Hero should be able to receive the bonus");
            Assert.That(heroMock.Object.Money, Is.EqualTo(expectedMoney), "Money should be increased on BonusAmount");
           
        }

        [Test]
        [TestCase(0, 5, 5)]
        public void Ring_Step_HeroMustReceiveCorrectBonusForHp(int initialHp, int expectedHp, int bonusAmount)
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var heroMock = new Mock<IHero>();
           
            heroMock.SetupProperty(x => x.Hp, initialHp);
           
            var ring = new Ring(0, 0, levelMock.Object, bonusAmount);

            // Action
            var result = ring.Step(heroMock.Object);

            // Assertion
            //Assert.That(result, Is.True, "Hero should be able to receive the bonus");
            
            Assert.That(heroMock.Object.Hp, Is.EqualTo(expectedHp), "HP should be increased on BonusAmount");
           
        }
        [Test]
        [TestCase(0, 5, 5)]
        public void Ring_Step_HeroMustReceiveCorrectBonusForAge(int initialAge,  int expectedAge, int bonusAmount)
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var heroMock = new Mock<IHero>();
        
            heroMock.SetupProperty(x => x.Age, initialAge);

            var ring = new Ring(0, 0, levelMock.Object, bonusAmount);

            // Action
            var result = ring.Step(heroMock.Object);

            // Assertion
            //Assert.That(result, Is.True, "Hero should be able to receive the bonus");
            
            Assert.That(heroMock.Object.Age, Is.EqualTo(expectedAge), "Age should be increased on BonusAmount");
        }
    }
}