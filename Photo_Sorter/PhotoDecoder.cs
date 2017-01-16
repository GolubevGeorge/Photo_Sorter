using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace Photo_Sorter
{
    class PhotoDecoder
    {
        FileInfo[] photoCatalog;
        List<string> listOfBadPhoto = new List<string>();
        List<string> listOfNoDatePhoto = new List<string>();
        Dictionary<FileInfo, String> dictionary = new Dictionary<FileInfo, String>();

        public PhotoDecoder(FileInfo[] photoCatalog)
        {
            this.photoCatalog = photoCatalog;
        }

        void Decode()
        {
            foreach (var item in photoCatalog)
            {
                //string s = @"C:\Users\Emris\Desktop\Test\WP_000007.jpg"; // Указать файл вручную вместо первого параметра File.Open();

                try
                {
                    using (FileStream photo = File.Open(item.FullName, FileMode.Open, FileAccess.ReadWrite)) // Открыли файл по адресу
                    {
                        BitmapDecoder bitmapDecoder = JpegBitmapDecoder.Create(photo, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default); // "/Распаковали" снимок и создали объект Decoder
                        BitmapMetadata imgEXIF = (BitmapMetadata)bitmapDecoder.Frames[0].Metadata.Clone(); // Считали и сохранили метаданные

                        if (imgEXIF.DateTaken != null)
                        {
                            Console.WriteLine(imgEXIF.DateTaken); // Вывод полной даты 

                            dictionary.Add(item, imgEXIF.DateTaken);
                        }
                        else
                        {
                            listOfNoDatePhoto.Add(item.FullName);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Undated file");
                            Console.ResetColor();
                        }
                    }
                }
                catch (Exception)
                {
                    listOfBadPhoto.Add(item.FullName);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unreadable file");
                    Console.ResetColor();
                }
            }
        }

        public Dictionary<FileInfo, String> publicDecode()
        {
            Decode();
            return dictionary;
        }

        public void ErrorList()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTotal files in folder - {0}", photoCatalog.Length);
            Console.ResetColor();

            Console.WriteLine("\n" + new string('-', 65));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThe number of unreadable files - {0}\n", listOfBadPhoto.Count);
            Console.ResetColor();

            foreach (var badPhoto in listOfBadPhoto)
            {
                Console.WriteLine(badPhoto);
            }

            Console.WriteLine("\n" + new string('-', 65));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThe number of files without date - {0}\n", listOfNoDatePhoto.Count);
            Console.ResetColor();

            foreach (var noDatephoto in listOfNoDatePhoto)
            {
                Console.WriteLine(noDatephoto);
            }
        }
    }
}




