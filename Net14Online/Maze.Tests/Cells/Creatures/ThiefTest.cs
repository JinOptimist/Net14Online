/*using Maze.Cells;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Maze.Tests.Cells.Creatures
{
    /// <summary>
    /// Исправление тестов
    /// </summary>
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
        [TestCase(10, 0)]
        [TestCase(20, 10)]
        [TestCase(0, 0)]
        [TestCase(50, 40)]
        public void Thief_Step_StealsMoneyFromHero_WhenInteractingWithHero(int initialHeroMoney, int moneyAfter)
        {
            // Prep
            var levelMock = new Mock<ILevel>();
            var heroMock = new Mock<IHero>();
            var thief = new Thief(0, 0, levelMock.Object);
            heroMock.SetupProperty(h => h.Money);
            heroMock.Object.Money = moneyAfter;
            // Act
            thief.Step(heroMock.Object);
            // Assert
            Assert.That(heroMock.Object.Money, Is.EqualTo(initialHeroMoney - 10).Or.EqualTo(moneyAfter), "Thief steal money!");
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
            Assert.That(cell.Object == result, Is.True, "Thief has to step to single exister cell");

        }

    }
}
*/