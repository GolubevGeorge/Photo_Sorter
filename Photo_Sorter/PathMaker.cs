using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Photo_Sorter
{
    class PathMaker
    {
        StringBuilder sb = new StringBuilder();
        String[] splitDate;
        Dictionary<FileInfo, string> fullPath = new Dictionary<FileInfo, string>();
        FolderCreater createFolder = new FolderCreater();
        Dictionary<FileInfo, String> dictionary;

        public PathMaker(Dictionary<FileInfo, String> dictionary)
        {
            this.dictionary = dictionary;
        }

        void DateBuilder()
        {
            try
            {
                foreach (var item in dictionary)
                {
                    sb.Clear();

                    splitDate = item.Value.Split('.', ' ');

                    sb.Append(Program.currentDirectory + @"\" + splitDate[2]);
                    createFolder.PublicFoldCreater(sb.ToString());
                    //sb.Append(@"\" + splitDate[2] + "." + splitDate[1]); // Добавление папки с месяцем 
                    //createFolder.FoldCreater(sb.ToString());             
                    sb.Append(@"\" + "(" + splitDate[0] + "." + splitDate[1] + "." + splitDate[2] + ")");
                    createFolder.PublicFoldCreater(sb.ToString());

                    sb.Append(@"\" + item.Key);

                    fullPath.Add(item.Key,sb.ToString());    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public Dictionary<FileInfo, string> PublicDateBuilder()
        {
            DateBuilder();

            return fullPath;
        }
    }
}



