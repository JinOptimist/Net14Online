using Maze.Cells;
using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.Cells.Creatures
{
    public class BerryTest
    {
        [Test]
        public void Berry_Step_AlwaysCanStepOnBerry()
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var creaturerMock = new Mock<IBaseCreature>();
            var berry = new Berry(0, 0, levelMock.Object);

            // Act
            var answer = berry.Step(creaturerMock.Object);

            // Assert
            Assert.That(answer, Is.True, "Dude, everybody can step on the berry!");
        }

        [Test]
        [TestCase(5, 6)]
        [TestCase(3, 4)]
        [TestCase(1, 2)]
        [TestCase(0, 0)]
        public void Berry_healing_creature(int hpBefore, int hpAfter)
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var creaturerMock = new Mock<IBaseCreature>();
            
            creaturerMock.SetupProperty(x => x.Hp);
            creaturerMock.Object.Hp = hpBefore;

            var berry = new Berry(0, 0, levelMock.Object);

            // Act
            var answer = berry.Step(creaturerMock.Object);

            // Assert
            Assert.That(creaturerMock.Object.Hp == hpAfter, Is.True, "Berry must heal creatures");
        }
    }
}
