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
            DirectoryInfo[] dirs = di.GetDirectories(); // Is there a way to convert it to regular Array or work with it like one?
            string name = new DirectoryInfo(dir).Name;

            int num = 1;

            if (name != "mods")
            {
                Console.WriteLine("ERROR\nTHIS EXE MUST BE IN MODS FOLDER!!!\nPress any key or close the window to exit.");
                Console.ReadKey();
            }
            else
            {
                using (StreamWriter ml = File.CreateText(file)) // Hate to use spaghetti code but whatever ¯\_(ツ)_/¯
                {
                    foreach (var folder in dirs)
                    {
                        if (folder.Name == "animation_events" || folder.Name == "ui_extension")
                        {
                            ml.WriteLine(folder);
                            Console.WriteLine($"[{num++}] Added as priority  \t - <{folder}>");
                        }
                    }
                    foreach (var folder in dirs)
                    {
                        if (folder.Name == "base" || folder.Name == "dmf" || folder.Name == "animation_events" || folder.Name == "ui_extension")
                        {
                            //Console.WriteLine($"[-] Skipped\t\t - <{folder}>");
                        }
                        else
                        {
                            ml.WriteLine(folder);
                            Console.WriteLine($"[{num++}] Added  \t\t - <{folder}>");
                        }
                    }
                }

                Console.WriteLine("\nSorting completed!\n\nPress any key or close the window to exit.");
                Console.ReadKey();
            }
        }
    }
}
