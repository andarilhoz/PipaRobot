using System;

namespace CleaningRobot.Views
{
    public class Output
    {
        public static void OutputValue(int value)
        {
            Console.WriteLine($"=> Cleaned: {value}");
        }
    }
}