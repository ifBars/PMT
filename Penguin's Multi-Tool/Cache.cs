using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin_s_Multi_Tool
{
    public class Cache
    {

        public void runClearTmp()
        {
            Pathing p = new Pathing();

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║     Are you sure you want to do this?         ║");
            Console.WriteLine("║  This can delete temporary files for many     ║");
            Console.WriteLine("║  applications. In most cases, this will only  ║");
            Console.WriteLine("║  cause a redownload of those files from said  ║");
            Console.WriteLine("║  applications. However, there are some cases  ║");
            Console.WriteLine("║    where you may have to reinstall certain    ║");
            Console.WriteLine("║                applications.                  ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nType ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("y");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" to confirm or ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" to go back to the menu");

            bool keepLooping = true;
            while (keepLooping)
            {
                string inp = Console.ReadLine();

                if (inp.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                    p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "Temp"));

                    keepLooping = false; // Exit the loop
                }
                else if (inp.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Going back to menu...");
                    keepLooping = false; // Exit the loop
                }
                else
                {
                    Console.WriteLine("Please input y or n, yes to confirm, n to go back");
                }
            }

        }

        public void runClear()
        {
            Pathing p = new Pathing();

            Console.Clear();
            Console.WriteLine("Are you sure you wanna do this? You will have to redownload many FiveM files and log back into your account. (y/n)");

            bool keepLooping = true;
            while (keepLooping)
            {
                string inp = Console.ReadLine();

                if (inp.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                    p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "data"));
                    p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "crashes"));
                    p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "logs"));
                    p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "DigitalEntitlements"));
                    p.delPath(Path.Combine(userProfilePath, "AppData", "Roaming", "CitizenFX"));

                    Console.WriteLine("Would you like to clear your windows tmp folder too? This can contain some FiveM files. (y/n)");

                    string inp2 = Console.ReadLine();
                    if (inp2.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "Temp"));
                    }

                    keepLooping = false; // Exit the loop
                }
                else if (inp.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    keepLooping = false; // Exit the loop
                }
                else
                {
                    Console.WriteLine("Please input y or n, yes to confirm, n to go back");
                }
            }
        }

    }
}
