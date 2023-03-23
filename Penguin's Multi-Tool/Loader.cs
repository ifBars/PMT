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
            Console.WriteLine(" 1. Clean tmp files                  |   7. Check for updates");
            Console.WriteLine(" 2. Clear ALL FiveM cache            |   8. Generate password");
            Console.WriteLine(" 3. Clear custom FiveM cache         |   9. Fix registry entries");
            Console.WriteLine(" 4. Fix duplicate rockstar license   |   10. Convert DS Save");
            Console.WriteLine(" 5. Clear recycle bin                |   11. Quit");
            Console.WriteLine(" 6. Create system restore point      |           ");
            Console.ResetColor();
            Console.WriteLine();

            // Ask the user for input
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter a number to select an option: ");
            Console.ResetColor();

        }

    }
}
