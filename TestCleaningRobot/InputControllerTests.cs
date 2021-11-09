using System;
using System.Collections.Generic;
using CleaningRobot.Controllers;
using CleaningRobot.Models;
using NUnit.Framework;

namespace TestCleaningRobot
{
    public class InputControllerTests
    {
        private MoveController MoveController;
        private InputController InputController;
        
        [SetUp]
        public void Setup()
        {
            MoveController = new MoveController();
            InputController = new InputController(MoveController);
        }

        [Test]
        public void TestRoomCount()
        {
            string testString = "2 10 22 E 2 N 1";
            int placesVisited = InputController.InputReceiver(testString);
            
            Assert.AreEqual(4, placesVisited);
        }
        
        [Test]
        public void TestRoomCountRepeatRooms()
        {
            string testString = "4 10 22 E 2 N 1 S 1 N 1";
            int placesVisited = InputController.InputReceiver(testString);
            
            Assert.AreEqual(4, placesVisited);
        }
    }
}