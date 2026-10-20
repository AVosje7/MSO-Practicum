using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandIO
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
                    processedInput.Add("Programs/Basic.txt");
                    break;
                case "advanced":
                    processedInput.Add("Programs/Advanced.txt");
                    break;
                case "expert":
                    processedInput.Add("Programs/Expert.txt");
                    break;
                default:
                    processedInput.Add("Programs/" + filename + ".txt");
                    break;
            }

            processedInput.Add(operation.ToLower());

            return processedInput;
        }
    }
}