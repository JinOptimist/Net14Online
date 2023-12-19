/*using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.Cells.Creatures
{
    public class CentaurTest
    {
        [Test]
        [TestCase(10, 8, 6, 5)]
        [TestCase(5, 3, 4, 3)]
        [TestCase(1, 0, 0, 0)]
        public void Centaur_Step_CentaurAtackCreature(int hpBefore, int hpAfter, int moneyBefore, int moneyAfter)
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var hero = new Mock<IHero>();
            hero.SetupProperty(h => h.Hp);
            hero.SetupProperty(h => h.Money);
            hero.Object.Hp = hpBefore;
            hero.Object.Money = moneyBefore;

            var centaur = new Centaur(0, 0, levelMock.Object);

            // Act
            centaur.Step(hero.Object);

            // Assert
            Assert.That(hero.Object.Hp == hpAfter, Is.True, "Centaur must hit hero");
            Assert.That(hero.Object.Money == moneyAfter, Is.True, "Centaur must hit hero");
        }

        [Test]
        public void Centaur_ChooseCellToStep_GetNearCell()
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var ground = new Mock<IGround>();
            var grounds = new List<IGround>()
            {
                ground.Object
            };
            var cells = new List<IBaseCell>()
            {
                ground.Object
            };

            levelMock.SetupProperty(l => l.Cells);
            levelMock.Object.Cells = cells;

            var centaur = new Centaur(0, 0, levelMock.Object);

            levelMock
                .Setup(x => x.GetNearCells<IGround>(centaur))
                .Returns(grounds);

            // Act
            var answer = centaur.ChooseCellToStep();

            // Assert
            Assert.That(ground.Object == answer, Is.True, "Centaur has to step to single exister cell");
        }
    }
}*/