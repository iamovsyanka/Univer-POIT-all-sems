using System;
using System.IO;

namespace Lab13
{
    public static class KAOFileInfo
    {
        public static void FileInf(string path= @"D:\2 курс\3 семестр\ООП\Лабы\Lab13\Lab13\bin\Debug\iamfile.txt")
        {
            var fileInfo = new FileInfo(path);
            Console.WriteLine("~~~~~~~~~Information about file:");
            if(fileInfo.Exists)
            {
                Console.WriteLine($"Directory name: {fileInfo.DirectoryName}");
                Console.WriteLine($"Name: {fileInfo.Name}");
                Console.WriteLine($"Extension: {fileInfo.Extension}");
                Console.WriteLine($"Length: {fileInfo.Length}");
                Console.WriteLine($"Creation time: {fileInfo.CreationTime}");
            }
            Console.WriteLine();
        }
    }
}
