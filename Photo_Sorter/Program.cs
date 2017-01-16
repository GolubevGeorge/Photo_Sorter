using System;
using System.Collections.Generic;
using System.IO;


namespace Photo_Sorter
{
    class Program
    {
        //public static string currentDirectory = @"C:\Users\Emris\Desktop\Test2";   // Использует указанное вручную местоположение
        public static string currentDirectory = Directory.GetCurrentDirectory(); // Использует местоположение Photo_Sorter.exe файла

        static void Main(string[] args)
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 120;
            Console.Title = "Photo Sorter";

            DirectoryInfo dir = new DirectoryInfo(currentDirectory);
            FileInfo[] photoCatalog = dir.GetFiles("*.jpg", SearchOption.AllDirectories); // Параметры поиска - тип файла, и вложеность папок для поиска
            PhotoDecoder photoDecoder = new PhotoDecoder(photoCatalog);

            Dictionary<FileInfo, String> dictinary = photoDecoder.publicDecode();

            PathMaker pathMaker = new PathMaker(dictinary);

            Dictionary<FileInfo, string> fullPath = pathMaker.PublicDateBuilder();

            Mover move = new Mover(fullPath);
            move.PublicMove();

            photoDecoder.ErrorList();

            Console.ReadKey();

        }
    }
}
