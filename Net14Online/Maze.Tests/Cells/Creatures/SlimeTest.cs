using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using Moq;
using NUnit.Framework;
using System;

namespace Maze.Tests.Cells.Creatures
{
    public class SlimeTests
    {

        [Test]
        public void Slime_Step_WillBeAbleToStepOnSmile()
        {

            var levelMock = new Mock<ILevel>();
            var monstrMock = new Mock<IBaseCreature>();
            var slime = new Slime(0, 0, levelMock.Object);
            var answer = slime.Step(monstrMock.Object);
            Assert.That(answer, Is.False, "Will be able to step on Smile");
        }
        [Test]
        public void Slime_Step_SetsColorToDefaultAttackColorWhenAttackingHero()
        {
            var levelMock = new Mock<ILevel>();
            var creatureMock = new Mock<IBaseCreature>();
            var slime = new Slime(0, 0, levelMock.Object);

            slime.Step(creatureMock.Object);

            Assert.That(Slime.DEFAULT_ATTACK_COLOR, Is.EqualTo(slime.Color), "The color should be red");
        }
    }
}

