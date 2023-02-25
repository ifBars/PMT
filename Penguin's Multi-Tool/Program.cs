using Penguin_s_Multi_Tool;
using System;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        while (!quit)
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
            Console.WriteLine(" 4. Fix duplicate rockstar license   |   8. Quit");
            Console.ResetColor();
            Console.WriteLine();

            // Ask the user for input
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter a number to select an option: ");
            Console.ResetColor();
            string input = Console.ReadLine();

            // Convert the input to an integer
            int choice;
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 8.");
                continue;
            }

            bool doOutput = true;

            // Check which option was selected
            switch (choice)
            {
                case 1:
                    Option1();
                    break;
                case 2:
                    Option2();
                    break;
                case 3:
                    Option3();
                    break;
                case 4:
                    Option4();
                    break;
                case 5:
                    Option5();
                    break;
                case 6:
                    Option6();
                    break;
                case 7:
                    Task<string> emp = Option7();
                    doOutput = false;
                    Console.ReadKey();
                    break;
                case 8:
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 8.");
                    break;
            }

            if(doOutput == true)
            {
                Console.WriteLine();
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    static void Option1()
    {
        Console.Clear();
        Cache c = new Cache();

        c.runClearTmp();
    }

    static void Option2()
    {
        Console.Clear();
        Cache c = new Cache();

        c.runClear();
    }

    static void Option3()
    {
        Console.Clear();
        CustomCache cc = new CustomCache();

        cc.runCheck();
    }

    static void Option4()
    {
        Console.Clear();
        Console.WriteLine("Are you sure you wanna do this? You WILL have to sign back into Social Club on FiveM.");

        if(Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Fixing Duplicate Rockstar License Issue...");
            Pathing p = new Pathing();
            string userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            p.delPath(Path.Combine(userProfilePath, "AppData", "Local", "DigitalEntitlements"));
        }
        else
        {
            Console.WriteLine("Going back to menu...");
        }
        
    }

    static void Option5()
    {
        Console.Clear();
        Console.WriteLine("Are you sure you wanna do this? You will lose all files in your recycle bin.");

        if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Bin b = new Bin();

            b.EmptyRecycleBin();
            Console.WriteLine("Recycle Bin Cleared");
        }
        else
        {
            Console.WriteLine("Going back to menu...");
        }
    }

    static void Option6()
    {
        Console.Clear();
        SRP srp = new SRP();

        srp.CreateRestorePoint("Created by Penguin's Multi-Tool, Date: " + DateTime.Today.ToString());
    }

    static async Task<string> Option7()
    {
        Console.Clear();
        Console.WriteLine("Checking for updates...");
        Penguin_s_Multi_Tool.Version v = new Penguin_s_Multi_Tool.Version("ifBars", "PMT");

        var updateTask = v.checkUpdate();
        string update = await updateTask;
        return update;
    }
}
