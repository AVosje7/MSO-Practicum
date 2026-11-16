using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MSO_Practicum.Test
{
    public class FileReaderTest : IDisposable
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
}