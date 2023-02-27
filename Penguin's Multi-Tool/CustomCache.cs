using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin_s_Multi_Tool
{
    public class CustomCache
    {

        public static void runCheck()
        {
            string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            Pathing p = new Pathing();

            bool process = false;
            Console.WriteLine("Would you like to delete FiveM process cache files? (y/n)");
            if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "data", "cache"));
                process = true;
            }

            if (process != true)
            {
                Console.WriteLine("Would you like to delete FiveM subprocess cache files? (y/n)");
                if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "data", "cache", "subprocess"));
                }
            }

            Console.WriteLine("Would you like to delete FiveM content manifest file? (y/n)");
            if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                p.delFile(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "content_index.xml"));
            }

            bool game = false;
            Console.WriteLine("Would you like to delete FiveM game cache? (y/n)");
            if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "data", "game-storage"));
                game = true;
            }

            if (game != true)
            {
                Console.WriteLine("Would you like to delete FiveM game browser cache? (y/n)");
                if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "data", "game-storage", "ros_documents_b576", "Cache"));
                }
            }

            bool nui = false;
            Console.WriteLine("Would you like to delete the FiveM NUI cache? (y/n)");
            if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "data", "nui-storage"));
                nui = true;
            }

            if (nui != true)
            {
                Console.WriteLine("Would you like to delete the FiveM GPU cache? (y/n)");
                if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
                {

                    p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "data", "nui-storage", "GPUCache"));
                }
            }

            if (nui != true)
            {
                Console.WriteLine("Would you like to delete the FiveM code cache? (y/n)");
                if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
                {

                    p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "data", "nui-storage", "Code Cache"));
                }
            }

            Console.WriteLine("Would you like to delete the FiveM server cache? (y/n)");
            if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "data", "server-cache"));
                p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "data", "server-cache-priv"));
            }

            Console.WriteLine("Would you like to delete FiveM crash files? (y/n)");
            if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "crashes"));
                p.delFile(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "citizen", "crash-data.json"));
                p.delFile(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "data", "cache", "crashometry"));
            }

            Console.WriteLine("Would you like to delete FiveM log files? (y/n)");
            if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "FiveM", "FiveM.app", "logs"));
            }

            Console.WriteLine("Would you like to delete the Rockstar License files? You WILL have to sign back into Social Club on FiveM. (y/n)");
            if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "DigitalEntitlements"));
            }

            Console.WriteLine("Would you like to delete the CitizenFX cache? (y/n)");
            if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                p.delPath(Path.Combine(userProfilePath, "AppData", "Roaming", "CitizenFX"));
            }

            Console.WriteLine("Would you like to clear your Windows temp folder too? This can contain some FiveM files (y/n)");
            Console.WriteLine("Reccommended: System Restore Point BEFORE (only for temp folder)");
            if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "Temp"));
            }

            GC.Collect();
        }

    }
}
