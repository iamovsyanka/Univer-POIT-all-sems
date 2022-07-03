using System;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
    public static class KAOFileManager
    {
        public static void FileManager(string dirName = @"D:\\")
        { 
            var directoryInfo = new DirectoryInfo(dirName);

            var path = $@"{dirName}\KAOInspect";
            var KAOInspect = new DirectoryInfo(path);

            var filename = $@"{path}\KAOdirinfo.txt";
            var file = new FileInfo(filename);

            if (!KAOInspect.Exists)
            {
                KAOInspect.Create();
                KAOLog.Write($"Создана папка {KAOInspect.Name}");
            }

            using (var fstream = new FileStream(filename, FileMode.Create))
            {
                 var writer = new StreamWriter(fstream);

                 writer.WriteLine("Files:");
                 foreach (FileInfo s in directoryInfo.GetFiles())
                 {
                    writer.WriteLine("->" + s);
                 }

                 writer.WriteLine("\nFolders:");
                 foreach (DirectoryInfo s in directoryInfo.GetDirectories())
                 {
                    writer.WriteLine("->" + s);
                 }
                 writer.Close();
            }

            var file1 = new FileInfo($@"{path}\NewKAOdirinfo.txt");
            file.CopyTo(file1.FullName,true);
            KAOLog.Write($"Создана копия файла {file.FullName}");
            file.Delete();
            Console.ReadKey();
            file1.Delete();

            var path1 = $@"{dirName}\KAOFiles";
            var KAOFiles = new DirectoryInfo(path1);

            var dirname = @"D:\2 курс\3 семестр\ЭВМ";
            var directory = new DirectoryInfo(dirname);

            if (!KAOFiles.Exists)
            {
                KAOFiles.Create();
                KAOLog.Write($"Создана папка {KAOFiles.Name}");
            }

            foreach (FileInfo ex in directory.GetFiles())
            {
               if (ex.Extension == ".docx")
               {
                  ex.CopyTo($"{path1}/{ex.Name}",true);
               }
            }

            Directory.Move(KAOFiles.FullName, KAOInspect.FullName+'\\'+ KAOFiles.Name);
            Console.ReadKey();

            ZipFile.CreateFromDirectory(KAOInspect.FullName + '\\' + KAOFiles.Name, $"{KAOFiles.Name}.zip");
            ZipFile.ExtractToDirectory($"{KAOFiles.Name}.zip", @"D://2 курс");

            Directory.Delete(KAOInspect.FullName + '\\' + KAOFiles.Name,true);
        }
    }
}
