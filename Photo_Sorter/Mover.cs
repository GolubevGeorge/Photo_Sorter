using System;
using System.Collections.Generic;
using System.IO;

namespace Photo_Sorter
{
    class Mover
    {
        Dictionary<FileInfo, string> fullPath;

        public Mover(Dictionary<FileInfo, string> fullPath)
        {
            this.fullPath = fullPath;
        }

        void Move()
        {
            try
            {
                foreach (var item in fullPath)
                {
                    item.Key.MoveTo(item.Value);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public void PublicMove()
        {
            Move();
        }

    }
}
