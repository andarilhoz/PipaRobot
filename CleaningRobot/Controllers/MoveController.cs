using System;
using System.Collections.Generic;
using CleaningRobot.Models;
using CleaningRobot.Views;

namespace CleaningRobot.Controllers
{
    public class MoveController
    {
        public HashSet<Tuple<int, int>> ProcessCommands(InputCommand inputCommand)
        {
            int originX = inputCommand.XCord;
            int originY = inputCommand.YCord;
            
            HashSet<Tuple<int, int>> currentHashSet = new HashSet<Tuple<int, int>>();
            currentHashSet.Add( new Tuple<int, int>(originX, originY));

            foreach (StepCommand stepCommand in inputCommand.StepCommands)
            {
                HashSet<Tuple<int, int>> commandSet = ProcessStepCommand(ref originX, ref originY, stepCommand);
                // unionWith could cause some performance issues, that would be better perhaps to use sortedHash, or even made a single hashSet
                // i'm using the same hashset in this case, cause i dont think the use case would require maximum performance
                // in this case, UnionWith is used only by code aesthetics.
                currentHashSet.UnionWith(commandSet); 
            }
            return currentHashSet;
        }

        private HashSet<Tuple<int, int>> ProcessStepCommand(ref int originX, ref int originY, StepCommand stepCommand)
        {
            HashSet<Tuple<int, int>> currentHashSet = new HashSet<Tuple<int, int>>();

            for (int i = 0; i < stepCommand.Steps; i++)
            {
                Tuple<int, int> stepOutput = ProcessStepDirection(originX, originY, stepCommand.Direction);
                originX = stepOutput.Item1;
                originY = stepOutput.Item2;
                currentHashSet.Add(stepOutput);
            }

            return currentHashSet;
        }

        private Tuple<int, int> ProcessStepDirection(int originX, int originY, Direction direction)
        {
            switch (direction)
            {
                case Direction.East:
                    originX++;
                    break;
                case Direction.West:
                    originX--;
                    break;
                case Direction.South:
                    originY--;
                    break;
                case Direction.North:
                    originY++;
                    break;
            }
            return new Tuple<int, int>(originX, originY);
        }
    }
}