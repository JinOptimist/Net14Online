using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.Cells.Creatures
{
    public class MinotaurTests
    {
        [Test]
        [TestCase(4,3)]
        [TestCase(9,8)]
        [TestCase(0,0)]
        [TestCase(16,15)]
        public void HeroStepOnMinotaurHpTest(int hpBefore, int hpAfter)
        {
            //Arrange
            var levelMock = new Mock<ILevel>();
            var heroMock = new Mock<IHero>();
            heroMock.SetupProperty(x => x.Hp);
            heroMock.Object.Hp = hpBefore;

            var minotaur = new Minotaur(0, 0, levelMock.Object, ConsoleColor.Green);

            //Act
            var result = minotaur.Step(heroMock.Object);

            //Assert
            Assert.That(heroMock.Object.Hp, Is.EqualTo(hpAfter), "Minotaur should take 1 hp"); 
        }

        [Test]
        [TestCase(4, 2)]
        [TestCase(9, 7)]
        [TestCase(-1, 0)]
        [TestCase(16, 14)]
        public void HeroStepOnMinotaurMoneyTest(int moneyBefore, int moneyAfter)
        {
            //Arrange
            var levelMock = new Mock<ILevel>();
            var heroMock = new Mock<IHero>();
            heroMock.SetupProperty(x => x.Money);
            heroMock.Object.Money = moneyBefore;

            var minotaur = new Minotaur(0, 0, levelMock.Object, ConsoleColor.Green);

            //Act
            var result = minotaur.Step(heroMock.Object);

            //Assert
            Assert.That(heroMock.Object.Money, Is.EqualTo(moneyAfter), "Minotaur should take 2 coins");
        }

        [Test]
        [TestCase(2, 1)]
        [TestCase(3, 3)]
        [TestCase(0, 0)]
        public void CreatureStepOnMinotaurTest(int hp, int money)
        {
            //Arrange
            var levelMock = new Mock<ILevel>();
            var creatureMock = new Mock<IBaseCreature>();
            creatureMock.SetupProperty(x => x.Hp);
            creatureMock.SetupProperty(x => x.Money);
            creatureMock.Object.Hp = hp;
            creatureMock.Object.Money = money;
            var minotaur = new Minotaur(0, 0, levelMock.Object, ConsoleColor.Green);

            //Act
            var result = minotaur.Step(creatureMock.Object);

            //Assert
            Assert.That(creatureMock.Object.Hp, Is.EqualTo(hp), "Minotaur should take HP only from Hero");
            Assert.That(creatureMock.Object.Money, Is.EqualTo(money), "Minotaut should take Money only from Hero");
        }
    }
}