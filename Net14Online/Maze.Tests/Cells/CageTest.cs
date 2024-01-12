/*using Maze.Cells;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Tests.Cells
{
    public class CageTest
    {
        [Test]
        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, false)]
        [TestCase(4, true)]
        /// <summary>
        ///  when creature steps for the every odd time (1, 3, 5 etc), cage must not let it go, when creature steps for the every even time, cage must let it go
        /// </summary>
        /// <param name="numberOfSteps"></param>
        /// <param name="result"></param>

        public void CageEvenNumberOfStepsTest(int numberOfSteps, bool result)
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var creatureMock = new Mock<IBaseCreature>();
            var cage = new Cage(0, 0, levelMock.Object);

            // act
            for (var step = 0; step < numberOfSteps - 1; step++)
            {
                cage.Step(creatureMock.Object);
            }
            var answer = cage.Step(creatureMock.Object);

            // assert
            Assert.That(answer, Is.EqualTo(result), "Cage must not let creature go");
        }
    }
}
*/