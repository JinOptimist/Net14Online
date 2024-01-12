using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
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
    public class GoodMonsterTest
    {
        [Test]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        [TestCase(4, 5)]
        [TestCase(5, 6)]
        [TestCase(6, 7)]
        public void GoodMonster_Step_CheckCreatureHeal(int hpBefore, int hpAfter) 
        { 
            var levelMock = new Mock<ILevel>();
            var heroMock = new Mock<IBaseCreature>();
            heroMock.SetupProperty(x => x.Hp);
            heroMock.Object.Hp = hpBefore;

            var goodMonster = new GoodMonster(0, 0, levelMock.Object);

            var answer = goodMonster.Step(heroMock.Object);

            Assert.That(heroMock.Object.Hp, Is.EqualTo(hpAfter));
        }
    }
}
