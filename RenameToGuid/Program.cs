using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameToGuid
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = String.Join(" ", args);
            var directory = new DirectoryInfo(path);
            if (directory.Exists)
            {
                Array.ForEach(directory.GetFiles(), RenameFile);
            }
            else
            {
                var file = new FileInfo(path);
                if (file.Exists)
                    RenameFile(file);
                else
                    Console.WriteLine($"File or directory {path} does not exist.");
            }
        }

        static void RenameFile(FileInfo file)
        {
            file.MoveTo($"{file.Directory}/{Guid.NewGuid()}.{file.Extension}");
        }
    }
}
