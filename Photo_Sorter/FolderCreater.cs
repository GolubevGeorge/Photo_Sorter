using System;
using System.IO;

namespace Photo_Sorter
{
    class FolderCreater
    {

        void FoldCreater(string path)
        {
            try
            {
                if (Directory.Exists(path)) // Определить, существует ли каталог
                {
                    //Console.WriteLine("Path exists");
                    return;
                }

                DirectoryInfo di = Directory.CreateDirectory(path); // Попытка создания каталога


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The directory - {1} was created at {0}.", Directory.GetCreationTime(path), path);
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public void PublicFoldCreater(string path)
        {
            FoldCreater(path);
        }
    }
}
