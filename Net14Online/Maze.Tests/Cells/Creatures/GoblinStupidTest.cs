/*using Maze.Cells;
using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.Cells.Creatures
{
    public class GoblinStupidTest
    {
        [Test]
        public void GoblinStupid_Step_NeverCanStepToGolbin()
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var monstrMock = new Mock<IBaseCreature>();

            var goblinStupid = new GoblinStupid(0, 0, levelMock.Object);

            // Act
            var answer = goblinStupid.Step(monstrMock.Object);

            // Assert
            Assert.That(answer, Is.False, "Dude, nobody can step to the gobline");
        }

        [Test]
        [TestCase(10, 9)]
        [TestCase(5, 4)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        public void GoblinStupid_Step_GoblinAtackCreature(int hpBefore, int hpAfter)
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var monstrMock = new Mock<IBaseCreature>();
            monstrMock.SetupProperty(x => x.Hp);
            monstrMock.Object.Hp = hpBefore;

            var goblinStupid = new GoblinStupid(0, 0, levelMock.Object);

            // Act
            var answer = goblinStupid.Step(monstrMock.Object);

            // Assert
            Assert.That(monstrMock.Object.Hp == hpAfter, Is.True, "Goblin must hit enemy");
        }

        [Test]
        public void GoblinStupid_ChooseCellToStep_GetNearCell()
        {
            // Preparation
            var levelMock = new Mock<ILevel>();

            var cell = new Mock<IBaseCell>();
            var cells = new List<IBaseCell>()
            {
                cell.Object
            };
            var goblinStupid = new GoblinStupid(0, 0, levelMock.Object);
            levelMock
                .Setup(x => x.GetNearCells<IBaseCell>(goblinStupid))
                .Returns(cells);

            // Act
            var answer = goblinStupid.ChooseCellToStep();

            // Assert
            Assert.That(cell.Object == answer, Is.True, "Goblin has to step to single exister cell");
        }
    }
}
*/