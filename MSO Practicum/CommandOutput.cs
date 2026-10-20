using System;
using System.Collections.Generic;

namespace MSOPracticum
{
    public static class CommandOutput
    {
        public static void WriteSteps(List<String> steps, String endState)
        {
            Console.WriteLine(FormatSteps(steps));
            Console.WriteLine("End state " + endState + ".");
        }

        public static void WriteMetrics(List<int> metrics)
        {
            Console.WriteLine("Metrics:");
            foreach (int metric in metrics)
            {
                Console.WriteLine(metric);
            }
        }

        private static String FormatSteps(List<String> steps)
        {
            return String.Join(", ", steps);
        }
    }
}