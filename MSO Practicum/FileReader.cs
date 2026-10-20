using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace MSOPracticum
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

    #if DEBUG
    #region Tests
    public class FileReaderTests : IDisposable
    {
        private readonly List<string> tempFiles = new List<string>();

        private string CreateTempFile(string content)
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".txt");
            File.WriteAllText(path, content);
            tempFiles.Add(path);
            return path;
        }

        public void Dispose()
        {
            foreach (string path in tempFiles)
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }

        [Fact]
        public void GetLines_ReturnsAllLinesInOrder()
        {
            string path = CreateTempFile("Move 1\nTurn right\nMove 2");
            var reader = new FileReader();
            reader.LoadFile(path);

            Assert.Equal(new List<string> { "Move 1", "Turn right", "Move 2" }, reader.GetLines());
        }

        [Fact]
        public void GetLines_EmptyFile_ReturnsEmptyList()
        {
            string path = CreateTempFile("");
            var reader = new FileReader();
            reader.LoadFile(path);

            Assert.Empty(reader.GetLines());
        }


        [Fact]
        public void GetLines_FileDoesNotExist_Throws()
        {
            var reader = new FileReader();
            reader.LoadFile(Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".txt"));

            Assert.Throws<FileNotFoundException>(() => reader.GetLines());
        }

    }
    #endregion
    #endif
}