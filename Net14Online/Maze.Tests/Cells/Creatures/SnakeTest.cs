/*using Maze.Cells.CellInterfaces;
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
    public class SnakeTest
    {
        [Test]
        public void Snake_Step_NeverCanStepToSnake()
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var monstrMock = new Mock<IBaseCreature>();

            var Snake = new Snake(0, 0, levelMock.Object);

            // Act
            var answer = Snake.Step(monstrMock.Object);

            // Assert
            Assert.That(answer, Is.False, "Dude, nobody can step to the snake");
        }

        [Test]
        [TestCase(10, 9)]
        [TestCase(5, 4)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        public void Snake_Step_SnekeAtackCreature(int hpBefore, int hpAfter)
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var monstrMock = new Mock<IBaseCreature>();
            monstrMock.SetupProperty(x => x.Hp);
            monstrMock.Object.Hp = hpBefore;

            var snake = new Snake(0, 0, levelMock.Object);

            // Act
            var answer = snake.Step(monstrMock.Object);

            // Assert
            Assert.That(monstrMock.Object.Hp == hpAfter, Is.True, "Snake must hit enemy");
        }

        [Test]
        public void Snake_ChooseCellToStep_GetNearCell()
        {
            // Preparation
            var levelMock = new Mock<ILevel>();

            var cell = new Mock<IBaseCell>();
            var cells = new List<IBaseCell>()
            {
                cell.Object
            };
            var snake = new Snake(0, 0, levelMock.Object);
            levelMock
                .Setup(x => x.GetNearCells<IBaseCell>(snake))
                .Returns(cells);

            // Act
            var answer = snake.ChooseCellToStep();

            // Assert
            Assert.That(cell.Object == answer, Is.True, "Snake has to step to single exister cell");
        }

    }
}
*/