using System;
using System.Collections.Generic;
using CleaningRobot.Controllers;
using CleaningRobot.Models;
using NUnit.Framework;

namespace TestCleaningRobot
{
    public class MoveControllerTests
    {
        private MoveController MoveController;
        
        [SetUp]
        public void Setup()
        {
            MoveController = new MoveController();
        }

        [Test]
        public void TestTwoCommands()
        {
            InputCommand finalCommand = new InputCommand();
            finalCommand.Comands = 2;
            finalCommand.XCord = 10;
            finalCommand.YCord = 22;
    

            StepCommand first = new StepCommand();
            first.Direction = Direction.East;
            first.Steps = 2;
            StepCommand second = new StepCommand();
            second.Direction = Direction.North;
            second.Steps = 1;

            finalCommand.StepCommands = new List<StepCommand>() { first, second };

            HashSet<Tuple<int, int>> finalTuple = new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int>(10, 22),
                new Tuple<int, int>(11, 22),
                new Tuple<int, int>(12, 22),
                new Tuple<int, int>(12, 23)
            };

            HashSet<Tuple<int, int>> responseSet = MoveController.ProcessCommands(finalCommand);
            
            Assert.AreEqual(finalTuple, responseSet);
        }
        
        [Test]
        public void TestSingleCommand()
        {
            string testString = "1 10 22 E 2";
            InputCommand finalCommand = new InputCommand();
            finalCommand.Comands = 1;
            finalCommand.XCord = 10;
            finalCommand.YCord = 22;
    

            StepCommand first = new StepCommand();
            first.Direction = Direction.East;
            first.Steps = 2;

            finalCommand.StepCommands = new List<StepCommand>() { first };

            HashSet<Tuple<int, int>> finalTuple = new HashSet<Tuple<int, int>>
            {
                new Tuple<int, int>(10, 22),
                new Tuple<int, int>(11, 22),
                new Tuple<int, int>(12, 22)
            };

            HashSet<Tuple<int, int>> responseSet = MoveController.ProcessCommands(finalCommand);
            
            Assert.AreEqual(finalTuple, responseSet);
        }
    }
}