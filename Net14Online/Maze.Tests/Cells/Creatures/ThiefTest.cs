using Maze.Cells;
using Maze.Cells.CellInterfaces;
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

    public class ThiefTests
    {
        [Test]
        public void Thief_Step_CreatureCanStepOnThief()
        {
            // Prep
            var levelMock = new Mock<ILevel>();
            var creatureMock = new Mock<IBaseCreature>();

            var thief = new Thief(0, 0, levelMock.Object);
            // Act
            var answer = thief.Step(creatureMock.Object);
            // Assert
            Assert.That(answer, Is.True, "All creatures can step on thief!");
        }
        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(0)]
        [TestCase(50)]
        public void Thief_Step_StealsMoneyFromHero_WhenInteractingWithHero(int initialHeroMoney)
        {
            // Prep
            var levelMock = new Mock<ILevel>();
            var hero = new Hero(1, 0, levelMock.Object);
            var thief = new Thief(0, 0, levelMock.Object);
            hero.Money = initialHeroMoney;
            // Act
            thief.Step(hero);
            // Assert
            Assert.That(hero.Money, Is.EqualTo(initialHeroMoney - 10).Or.EqualTo(0));
        }
        [Test]
        public void Thief_ChooseCellToStep_ReturnsRandomCellFromNearby()
        {
            // Prep
            var levelMock = new Mock<ILevel>();

            var cell = new Mock<IBaseCell>();
            var cells = new List<IBaseCell>() 
            { 
                cell.Object
            };

            levelMock.Setup(x => x.GetNearCells<IBaseCell>(It.IsAny<BaseCell>())).Returns(cells);

            var thief = new Thief(0, 0, levelMock.Object);

            // Act
            var result = thief.ChooseCellToStep();

            // Assert
            Assert.That(result, Is.Not.Null);

        }

    }
}
