using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin_s_Multi_Tool
{
    public class Loader
    {

        public static void writeOpen()
        {
            Console.Clear();

            // Display the title
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=======================================");
            Console.WriteLine("|         Penguin's Multi-Tool        |");
            Console.WriteLine("=======================================");
            Console.ResetColor();
            Console.WriteLine();

            // Display the options in two columns
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" 1. Clean tmp files   |   5. Clear recycle bin");
            Console.WriteLine(" 2. Clear ALL FiveM cache   |   6. Create system restore point");
            Console.WriteLine(" 3. Clear custom FiveM cache   |   7. Check for updates");
            Console.WriteLine(" 4. Fix duplicate rockstar license   |   8. Generate password");
            Console.WriteLine(" 9. Fix Registry Entries   |   10. Quit");
            Console.ResetColor();
            Console.WriteLine();

            // Ask the user for input
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter a number to select an option: ");
            Console.ResetColor();

        }

    }
}
