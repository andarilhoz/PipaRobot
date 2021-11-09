using System;
using CleaningRobot.Controllers;

namespace CleaningRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            MoveController moveController = new MoveController();
            InputController inputController = new InputController(moveController);

            string stdin = Console.ReadLine();
            inputController.InputReceiver(stdin);
        }
    }
}