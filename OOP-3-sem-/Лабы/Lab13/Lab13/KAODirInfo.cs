using System;
using System.IO;

namespace Lab13
{
    public static class KAODirInfo
    {
        public static void DirInfo(string dirName = @"D:\2 курс")
        {
            Console.WriteLine("~~~~~~~~~~~~Information about directories:");
            var directoryInfo = new DirectoryInfo(dirName);
            if (directoryInfo.Exists)
            {
                Console.WriteLine($"Name: {directoryInfo.Name}");
                Console.WriteLine($"FullName: {directoryInfo.FullName}");
                Console.WriteLine($"Files: {directoryInfo.GetFiles().Length}");
                Console.WriteLine($"Creation time: {directoryInfo.CreationTime}");
                Console.WriteLine($"Subdirectories: {directoryInfo.GetDirectories().Length}");
                Console.WriteLine($"Root: {directoryInfo.Root}");
                Console.Write("Parent: ");
                do
                {
                    Console.Write($"{directoryInfo.Parent.Name}\t");
                    directoryInfo = directoryInfo.Parent;
                } while (directoryInfo.Parent != null);
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }
    }
}
