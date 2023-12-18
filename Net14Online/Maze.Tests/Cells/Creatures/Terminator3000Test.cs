using Maze.Cells.Creatures.Interfaces;
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
        [TestCase(10, 5)]
        [TestCase(20, 10)]
        public void Terminator3000_Step_CheckCreatureMoney(int moneyBefore, int moneyAfter)
        {
            var levelMock = new Mock<ILevel>();
            var heroMock = new Mock<IBaseCreature>();
            heroMock.SetupProperty(x => x.Money);
            heroMock.Object.Money = moneyBefore;

            var terminator3000 = new Terminator3000(0, 0, levelMock.Object);

            var answer = terminator3000.Step(heroMock.Object);

            Assert.That(heroMock.Object.Money, Is.EqualTo(moneyAfter));
        }
    }
}
