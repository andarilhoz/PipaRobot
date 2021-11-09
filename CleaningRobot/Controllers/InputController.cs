using System;
using System.Collections.Generic;
using CleaningRobot.Models;
using CleaningRobot.Views;

namespace CleaningRobot.Controllers
{
    public class InputController
    {
        private MoveController moveController;

        public InputController(MoveController moveController)
        {
            this.moveController = moveController;
        }

        public int InputReceiver(string receiver)
        {
            InputCommand receivedCommands = new InputCommand(receiver);

            HashSet<Tuple<int, int>> placesVisited = moveController.ProcessCommands(receivedCommands);

            Output.OutputValue(placesVisited.Count);

            return placesVisited.Count;
        }
    }
}