using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandIO
{
    public static class CommandOutput
    {
        public void WriteSteps(List<String> steps, String endState)
        {
            Console.WriteLine(FormatSteps(steps));
            Console.WriteLine("End state " + endState + ".");
        }

        public void WriteMetrics(List<int> metrics)
        {
            Console.WriteLine("Metrics:");
            foreach (int metric in metrics)
            {
                Console.WriteLine(metric);
            }
        }

        private String FormatSteps(List<String> steps)
        {
            return String.Join(", ", steps);
        }
    }
}