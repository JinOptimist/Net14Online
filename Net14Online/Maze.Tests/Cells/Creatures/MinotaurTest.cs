using Maze.Cells.CellInterfaces;
using Maze.Cells.Creatures;
using Maze.Cells.Creatures.Interfaces;
using Maze.LevelStaff;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.Cells.Creatures;

public class MinotaurTest
{
   [Test]
    public void Minotaur_Step_NeverCanStepToMinotaur()
    {
        var levelMock = new Mock<ILevel>();
        var monstrMock = new Mock<IBaseCreature>();

        var minotaur = new Minotaur(0, 0, levelMock.Object,ConsoleColor.Black);

        var answer = minotaur.Step(monstrMock.Object);
        
        Assert.That(answer,Is.False,"Dude, nobody can step to the minotaur");
    }
    
    
    [Test]
    public void Minotaur_ChooseCellToStep_GetNearCell()
    {
      // Preparation
      var levelMock = new Mock<ILevel>();

      var cell = new Mock<IBaseCell>();
      var cells = new List<IBaseCell>()
      {
        cell.Object
      };
      var minotaur = new Minotaur(0, 0, levelMock.Object,ConsoleColor.Black);
      levelMock
        .Setup(x => x.GetNearCells<IBaseCell>(minotaur))
        .Returns(cells);

      // Act
      var answer = minotaur.ChooseCellToStep();

      // Assert
      Assert.That(cell.Object == answer, Is.True, "Minotaur has to step to single exister cell");
    }
    [Test]
    [TestCase(15, 14)]
    [TestCase(7, 6)]
    [TestCase(1, 0)]
    [TestCase(0, 0)]
    public void Minotaur_Step_MinotaurAtackCreature(int hpBefore, int hpAfter)
    {
        //// Preparation
        var levelMock = new Mock<ILevel>();
        var monstrMock = new Mock<IHero>();
        monstrMock.SetupProperty(x => x.Hp);
        monstrMock.Object.Hp = hpBefore;

        var minotaur = new Minotaur(0, 0, levelMock.Object,ConsoleColor.Black);

        // Act
        var answer = minotaur.Step(monstrMock.Object);

        // Assert
        Assert.That(monstrMock.Object.Hp == hpAfter,Is.True, "The Minotaur must attack enemies");
    }
    
    [Test]
    [TestCase(15, 13)]
    [TestCase(7, 5)]
    [TestCase(2, 0)]
    [TestCase(0, 0)] 
    public void Minotaur_Step_MinotaurTakesTheTMoney(int moneyBefore, int moneyAfter)
    {
        // Preparation
        var levelMock = new Mock<ILevel>();
        var monstrMock = new Mock<IHero>();
        monstrMock.SetupProperty(x => x.Money);
        monstrMock.Object.Money = moneyBefore;

        var minotaur = new Minotaur(0, 0, levelMock.Object,ConsoleColor.Black);

        // Act
        var answer = minotaur.Step(monstrMock.Object);

        // Assert
        Assert.That(monstrMock.Object.Money == moneyAfter, Is.True, "Minotaur must hit enemy");
    }
}