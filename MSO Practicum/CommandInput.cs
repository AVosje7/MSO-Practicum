using System;
using System.Collections.Generic;

namespace MSOPracticum
{
    public static class CommandInput
    {
        public static List<String> GetInput()
        {
            Console.WriteLine("Enter example (\"Basic\", \"Advanced\", or \"Expert\") or enter file:");
            String filename = Console.ReadLine();

            if (filename.ToLower() == "exit")
            {
                return new List<String> { "exit" };
            }

            Console.WriteLine("Execute or calculate:");
            String operation = Console.ReadLine();

            return ProcessInput(filename, operation);
        }

        public static List<String> ProcessInput(String filename, String operation)
        {
            List<String> processedInput = new List<String>();

            switch (filename.ToLower())
            {
                case "basic":
                    processedInput.Add(Path.Combine(AppContext.BaseDirectory, "Programs", "Basic.txt"));;
                    break;
                case "advanced":
                    processedInput.Add(Path.Combine(AppContext.BaseDirectory, "Programs", "Advanced.txt"));
                    break;
                case "expert":
                    processedInput.Add(Path.Combine(AppContext.BaseDirectory, "Programs", "Expert.txt"));
                    break;
                default:
                    processedInput.Add(Path.Combine(AppContext.BaseDirectory, "Programs", filename + ".txt"));
                    break;
            }

            processedInput.Add(operation.ToLower());

            return processedInput;
        }
    }
}
