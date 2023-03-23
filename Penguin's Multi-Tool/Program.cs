using Penguin_s_Multi_Tool;
using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        bool quit = false;
        while (!quit)
        {
            Loader.writeOpen();
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
                    Option8();
                    break;
                case 9:
                    Option9();
                    break;
                case 10:
                    Option10();
                    break;
                case 11:
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 8.");
                    break;
            }

            if (doOutput == true)
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

        Cache.runClearTmp();
    }

    static void Option2()
    {
        Console.Clear();

        Cache.runClear();
    }

    static void Option3()
    {
        Console.Clear();

        CustomCache.runCheck();
    }

    static void Option4()
    {
        Console.Clear();
        Console.WriteLine("Are you sure you wanna do this? You WILL have to sign back into Social Club on FiveM.");

        if (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase))
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

    static void Option8()
    {
        Console.Clear();
        PassGen pg = new PassGen();
        Console.WriteLine("How many characters would you like the password too be?");
        string inp = Console.ReadLine();
        int length;
        if (!int.TryParse(inp, out length))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return; // or you can continue with a default length
        }

        Console.WriteLine("Would you like to include special characters? ex: !@#$%^&*().,");

        string spec = Console.ReadLine();
        bool specbool = false;

        if (spec.Equals("y", StringComparison.OrdinalIgnoreCase) || spec.Equals("yes", StringComparison.OrdinalIgnoreCase))
        {
            specbool = true;
        }

        string pass = pg.generatePass(length, specbool);

        Console.WriteLine("Your generated password is: " + pass);
    }

    static void Option9()
    {
        Console.Clear();

        // Console.WriteLine("This is still being worked on...");

        bool fixedbool = RegFix.FixRegistry();

        // Console.WriteLine("Debug: bool = " + fixedbool.ToString());

    }

    static void Option10()
    {
        Console.Clear();

        // Console.WriteLine("This is still being worked on...");

        DSSaves.Convert();
    }

}
