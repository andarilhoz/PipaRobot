using System.Collections.Generic;
using CleaningRobot.Controllers;
using CleaningRobot.Models;
using NUnit.Framework;

namespace TestCleaningRobot
{
    public class InputCommandTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestStringCreation()
        {
            string testString = "2 10 22 E 2 N 1";
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

            InputCommand receivedCommand = new InputCommand(testString);

            bool equals = receivedCommand.Equals(finalCommand);

            Assert.True(equals);
        }
        
        [Test]
        public void TestStringCreationSingleValue()
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

            InputCommand receivedCommand = new InputCommand(testString);

            bool equals = receivedCommand.Equals(finalCommand);

            Assert.True(equals);
        }
    }
}