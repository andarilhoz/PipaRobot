using System;
using System.Collections.Generic;

namespace CleaningRobot.Models
{
    public class InputCommand 
    {
        // >= 0  && <= 10.000
        public int Comands;
        // >= -10.000 && <= 10.000
        public int XCord;
        public int YCord;
        public List<StepCommand> StepCommands;
        
        private Dictionary<string, Direction> directionDictionary = new Dictionary<string, Direction>()
        {
            { "N", Direction.North },
            { "S", Direction.South },
            { "E", Direction.East },
            { "W", Direction.West }
        };

        public InputCommand()
        {
            
        }

        public InputCommand(string input)
        {
            string[] slices = input.Split(" ");

            int slicesIncrementor = 0;
            Comands = Int32.Parse(slices[slicesIncrementor++]);
            XCord = Int32.Parse(slices[slicesIncrementor++]);
            YCord = Int32.Parse(slices[slicesIncrementor++]);
            StepCommands = new List<StepCommand>();
            
            for (int i = 0; i < Comands; i++)
            {
                StepCommand command = new StepCommand();
                command.Direction = directionDictionary[slices[slicesIncrementor++]];
                command.Steps = Int32.Parse(slices[slicesIncrementor++]);
                StepCommands.Add(command);
            }
        }
        
        public override bool Equals( Object obj )
        {
            InputCommand other = obj as InputCommand;
            if( other == null ) 
                return false;
            return Equals (other);             
        }

        public bool Equals(InputCommand other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (Comands != other.Comands)
                return false;

            if (XCord != other.XCord)
                return false;
            if (YCord != other.YCord)
                return false;

            if (StepCommands.Count != other.StepCommands.Count)
                return false;

            for (int i = 0; i < StepCommands.Count; i++)
            {
                if (StepCommands[i].Direction != other.StepCommands[i].Direction)
                    return false;
                if (StepCommands[i].Steps != other.StepCommands[i].Steps)
                    return false;
            }

            return true;
        }
    }

    public class StepCommand
    {
        public Direction Direction;
        // > 0 < 10.000
        public int Steps;
    }
}