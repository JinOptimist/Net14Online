using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.Cells.Creatures
{
    public class ElfTest
    {
        [Test]
        [TestCase(9, 10)]
        [TestCase(8, 9)]
        [TestCase(7, 8)]
        public void Elf_Step_HealCreature(int hpBefore, int hpAfter)
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var creature = new Mock<IBaseCreature>();
            creature.SetupProperty(x => x.Hp);
            creature.Object.Hp = hpBefore;

            var elf = new Elf(0, 0, levelMock.Object);

            // Act
            var answer = elf.Step(creature.Object);

            // Assert
            Assert.That(creature.Object.Hp == hpAfter, Is.True);
        }
    }
}
