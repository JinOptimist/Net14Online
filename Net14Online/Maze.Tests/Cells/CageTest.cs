using Maze.Cells;
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

        //when creature steps for the every odd time (1, 3, 5 etc), cage must not let it go, when creature steps for the every even time, cage must let it go
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]


        public void CageEvenNumberOfStepsTest(int numberOfSteps)
        {
            // Preparation
            var levelMock = new Mock<ILevel>();
            var creatureMock = new Mock<IBaseCreature>();

            var cage = new Cage(0, 0, levelMock.Object);

            // act
            for (int step  = 0; step  < numberOfSteps - 1; step ++)
            {
                cage.Step(creatureMock.Object);
            }
            var answer = cage.Step(creatureMock.Object);

            // assert
            if (numberOfSteps % 2 == 0)
            {
                Assert.That(answer, Is.True, "Cage must let creature go");
            }
            else
            {
                Assert.That(answer, Is.False, "Cage must not let creature go");
            }


        }
    }
}
