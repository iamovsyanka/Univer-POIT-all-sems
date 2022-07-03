using System;
using System.IO;

namespace Lab13
{
    public static class KAODiskInfo
    {
        public static void DiskInf(string driveName = "D:\\")
        {
            DriveInfo[] driveInfo = DriveInfo.GetDrives();
            Console.WriteLine("~~~~~~~~~~~Information about disk:");
            foreach (var drive in driveInfo)
            {
                Console.WriteLine("Name: " + drive.Name);
                Console.WriteLine("Total size: " + drive.TotalSize);
                Console.WriteLine("Available free space: " + drive.AvailableFreeSpace);
                Console.WriteLine("Volume label: " + drive.VolumeLabel);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
