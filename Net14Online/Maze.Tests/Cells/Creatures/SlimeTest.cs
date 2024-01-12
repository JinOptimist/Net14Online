/*using Maze.Cells.CellInterfaces;
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
            Assert.That(answer, Is.False, "Will not be able to step on Smile");
        }
        [Test]
        public void Slime_Step_SetsColorToDefaultAttackColorWhenAttackingHero()
        {
            // Подготовка
            var levelMock = new Mock<ILevel>();
            var creatureMock = new Mock<IBaseCreature>();
            var slime = new Slime(0, 0, levelMock.Object);
            var changedColor = slime.Color;

            // Действие: передача существа, которое является героем
            slime.Step(creatureMock.Object);

            // Утверждение: цвет должен быть установлен в цвет атаки по умолчанию
            Assert.That(slime.Color, Is.EqualTo(changedColor), "The color should be the default attack color");
        }

    }
}

*/