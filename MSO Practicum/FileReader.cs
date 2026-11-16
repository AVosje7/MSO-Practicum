namespace MSO_Practicum
{
    public class FileReader
    {
    
        String filePath;
        public FileReader()
        {
            filePath = "";
        }

        public void LoadFile(String filePath)
        {
            this.filePath = filePath;
        }

        public List<String> GetLines()
        {
            List<String> lines = new List<String>();
            String line;
            using (StreamReader reader = new StreamReader(this.filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }
    }
}