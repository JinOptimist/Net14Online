using Maze.Cells;
using Maze.Cells.CellInterfaces;
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
            var hero = new Hero(0, 0, null);
            hero.Hp = hpBefore;
            hero.Money = moneyBefore;

            var centaur = new Centaur(0, 0, null);
            centaur.Step(hero);

            Assert.That(hero.Hp == hpAfter && hero.Money == moneyAfter, Is.True, "Centaur must hit enemy");
        }

        [Test]
        public void Centaur_GetNearCell()
        {
            var levelMock = new Mock<ILevel>();
            var cell = new Ground(0, 0, levelMock.Object);
            var cells = new List<IBaseCell>()
            {
                cell
            };

            levelMock.SetupProperty(l => l.Cells);
            levelMock.Object.Cells = cells;

            var centaur = new Centaur(0, 0, levelMock.Object as Level);

            levelMock
                .Setup(x => x.GetNearCells<IBaseCell>(centaur))
                .Returns(cells);

            // Act
            var answer = centaur.ChooseCellToStep();

            // Assert
            Assert.That(cell == answer, Is.True, "Centaur has to step to single exister cell");

        }
    }
}