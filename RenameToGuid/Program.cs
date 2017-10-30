using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RenameToGuid
{
    class Program
    {
        static void Main(string[] args)
        {
            var paths = new List<string>();
            DirectoryInfo destination = null;
            
            if (args.Length > 1)
            {
                destination = new DirectoryInfo(args[0]);
                paths = args.Skip(1).ToList();
            }
            else
            {
                paths.Add(args[0]);
            }

            foreach (var path in paths)
            {
                var directory = new DirectoryInfo(path);
                if (directory.Exists)
                {
                    Array.ForEach(directory.GetFiles(), (f) => RenameFile(f, destination ?? directory));
                }
                else
                {
                    var file = new FileInfo(path);
                    if (file.Exists)
                        RenameFile(file, destination ?? file.Directory);
                    else
                        Console.WriteLine($"File or directory {path} does not exist.");
                } 
            }
        }

        static void RenameFile(FileInfo file, DirectoryInfo destination)
        {
            file.MoveTo($"{destination.FullName}/{Guid.NewGuid()}{file.Extension}");
        }
    }
}
