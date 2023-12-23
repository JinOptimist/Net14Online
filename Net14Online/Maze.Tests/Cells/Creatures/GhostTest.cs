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
    public class GhostTest
    {
        [Test]
        [TestCase(0, 0)]
        [TestCase(2, 1)]
        [TestCase(5, 4)]
        public void Ghost_Step_CheckHeroHpAfterAttack(int startHp, int resultHp)
        {
            var levelMock = new Mock<ILevel>();
            var heroMock = new Mock<IHero>();
            heroMock.SetupProperty(x => x.Hp);
            heroMock.Object.Hp = startHp;

            var ghost = new Ghost(0, 0, levelMock.Object);

            var answer = ghost.Step(heroMock.Object);

            Assert.That(heroMock.Object.Hp, Is.EqualTo(resultHp), "Hp cant be < 0");
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(4, 4)]
        public void Ghost_Step_CheckCreatureHpAfterAttack(int startHp, int resultHp)
        {
            var levelMock = new Mock<ILevel>();
            var creatureMock = new Mock<IBaseCreature>();
            creatureMock.SetupProperty(x => x.Hp);
            creatureMock.Object.Hp = startHp;

            var ghost = new Ghost(0, 0, levelMock.Object);

            var answer = ghost.Step(creatureMock.Object);

            Assert.That(creatureMock.Object.Hp, Is.EqualTo(resultHp), "Hp shouldnt changed");
        }

        [Test]
        public void Ghost_Step_CheckCreatureCanStepOnGhost()
        {
            var levelMock = new Mock<ILevel>();
            var creatureMock = new Mock<IBaseCreature>();
            var heroMock = new Mock<IHero>();

            var ghost = new Ghost(0, 0, levelMock.Object);

            var answerHero = ghost.Step(heroMock.Object);
            var answerCreature = ghost.Step(creatureMock.Object);

            Assert.That(answerHero, Is.False, "Nobody can step on Ghost");
            Assert.That(answerCreature, Is.False, "Nobody can step on Ghost");
        }
    }
}
*/