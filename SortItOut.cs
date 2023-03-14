using System;
using System.IO;

namespace SortItOut
{
    class App
    {
        private static void Main()
        {
            string dir = Directory.GetCurrentDirectory();
            string file = (dir + @"\mod_load_order.txt");
            DirectoryInfo di = new DirectoryInfo(dir);
            DirectoryInfo[] dirs = di.GetDirectories();
            string name = new DirectoryInfo(dir).Name;

            int num = 1;

            if (name != "mods")
            {
                Console.WriteLine("ERROR\nTHIS EXE MUST BE IN MODS FOLDER!!!");
                Console.WriteLine("\nPress any key or close the window to exit.");
                Console.ReadKey();
            }
            else
            {
                //Console.WriteLine($"Current directory is : {dir}\n");

                using (StreamWriter ml = File.CreateText(file))
                {
                    foreach (var folder in dirs)
                    {
                        if (folder.Name != "base" && folder.Name != "dmf")
                        {
                            ml.WriteLine(folder);
                            Console.WriteLine($"[{num++}] Added  \t - <{folder}>");
                        }
                        else
                        {
                            Console.WriteLine($"[-] Skipped\t - <{folder}>");
                        }
                    }
                }

                Console.WriteLine("\nSorting completed!\n\nPress any key or close the window to exit.");
                Console.ReadKey();
            }
        }
    }
}
