/*using Maze.Cells.Creatures.Interfaces;
using Maze.Cells.Creatures;
using Maze.LevelStaff;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Tests.Cells.Creatures
{
    public class Terminator3000Test
    {
        [Test]
        [TestCase(21, 7)]
        [TestCase(36, 12)]
        [TestCase(25, 8)]
        public void Terminator3000_Step_CheckCreatureMoney(int moneyBefore, int moneyAfter)
        {
            var levelMock = new Mock<ILevel>();
            var creatureMock = new Mock<IBaseCreature>();
            creatureMock.SetupProperty(x => x.Money);
            creatureMock.Object.Money = moneyBefore;

            var terminator3000 = new Terminator3000(0, 0, levelMock.Object);

            var answer = terminator3000.Step(creatureMock.Object);

            Assert.That(creatureMock.Object.Money, Is.EqualTo(moneyAfter));
        }
    }
}
*/