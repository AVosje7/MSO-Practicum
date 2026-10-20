using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileReader
{
    public class FileReader
    {
        private File file;
        
        public FileReader()
        {}

        public void LoadFile(String filePath)
        {
            file = new File(filePath);
        }

        public List<String> GetLines()
        {
            List<String> lines = new List<String>();
            String line;
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }
            return lines;
        }
    }
}