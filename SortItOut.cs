using System;
using System.Collections.Generic;
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

            string[] topMod = { "LogMeIn" };
            string[] endMod = { "animation_events", "ui_extension" };

            List<string> topList = new List<string>();
            List<string> list = new List<string>();
            List<string> endList = new List<string>();


            //-----------------------------------------------------------------------------------------------------------------------------//

            foreach (var folder in dirs)
            {
                if (folder.Name == "base" || folder.Name == "dmf")
                {
                    //
                }
                else if (folder.Name.Contains(topMod[0]))
                {
                    topList.Add(folder.Name);
                }
                else if (folder.Name.Contains(endMod[0]) ^ folder.Name.Contains(endMod[1]))
                { 
                    endList.Add(folder.Name); 
                } 
                else 
                {
                    list.Add(folder.Name);
                }
            }

            if (name != "mods")
            {
                Console.WriteLine("ERROR\nTHIS EXE MUST BE IN MODS FOLDER!!!\nPress any key or close the window to exit.");
                    Console.ReadKey();
            }
            else
            {
                using (StreamWriter ml = new StreamWriter(file))
                {
                    foreach (var item in topList)
                    {
                        ml.WriteLine(item);
                        Console.WriteLine($"[{num++}] Added -\t(High Priority)\t - <{item}>");
                    }
                    foreach (var item in list)
                    {
                        ml.WriteLine(item);
                        Console.WriteLine($"[{num++}] Added -\t\t\t - <{item}>");
                    }
                    foreach (var item in endList)
                    {
                        ml.WriteLine(item);
                        Console.WriteLine($"[{num++}] Added -\t(Low Priority)\t - <{item}>");
                    }
                }
            }

            Console.WriteLine("\nSorting completed!\n\nPress any key or close the window to exit.");
                Console.ReadKey();
        }
    }
}
