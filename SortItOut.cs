using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            List<string> list = new List<string>(); // just found out there's was a list, and it's better for this kinda tasks than array, hooray!
            int num = 1;

            //-----------------------------------------------------------------------------------------------------------------------------//

            

            foreach (var folder in dirs)
            {
                if (folder.Name != "base" & folder.Name != "dmf")
                {
                    list.Add(folder.Name);
                }
            }

            if (list.Contains("animation_events") && list.Contains("ui_extension"))
            {
                list.Remove("animation_events"); list.Add("animation_events"); // pushes it to the end of the list
                list.Remove("ui_extension"); list.Add("ui_extension"); // same again
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
                    foreach (var item in list) // should be done in for loop, but who cares anyway?
                    {
                        ml.WriteLine(item);
                        Console.WriteLine($"[{num++}] Added  \t\t\t - <{item}>");
                    }
                }
            }

            Console.WriteLine("\nSorting completed!\n\nPress any key or close the window to exit.");
                Console.ReadKey();
        }
    }
}
