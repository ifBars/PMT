using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin_s_Multi_Tool
{
    public class RegFix
    {

        public static bool FixRegistry()
        {
            bool changeDetected = false;

            try
            {
                // Backup the registry
                Console.WriteLine("Backing up registry");
                string backupPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "registry_backup.reg");
                Utilities.BackupRegistry(backupPath);

                // Enable system settings
                Console.WriteLine("Checking Firewall");
                if (Utilities.CheckFirewall())
                {
                    Console.WriteLine("Enabling Firewall");
                    Utilities.EnableFirewall();
                    changeDetected = true;
                }
                Console.WriteLine("Checking CMD");
                if (Utilities.CheckCMD())
                {
                    Console.WriteLine("Enabling CMD");
                    Utilities.EnableCommandPrompt();
                    changeDetected = true;
                }
                Console.WriteLine("Checking CntrlPnl");
                if (Utilities.CheckControlPanel())
                {
                    Console.WriteLine("Enabling CntrlPnl");
                    Utilities.EnableControlPanel();
                    changeDetected = true;
                }
                Console.WriteLine("Checking FolderOpts");
                if (Utilities.CheckFolderOptions())
                {
                    Console.WriteLine("Enabling FolderOpts");
                    Utilities.EnableFolderOptions();
                    changeDetected = true;
                }
                Console.WriteLine("Checking RunDia");
                if (Utilities.CheckRunDialog())
                {
                    Console.WriteLine("Enabling RunDia");
                    Utilities.EnableRunDialog();
                    changeDetected = true;
                }
                Console.WriteLine("Checking ContextMenu");
                if (Utilities.CheckContextMenu())
                {
                    Console.WriteLine("Enabling ContextMenu");
                    Utilities.EnableContextMenu();
                    changeDetected = true;
                }
                Console.WriteLine("Checking TaskMnger");
                if (Utilities.CheckTaskManager())
                {
                    Console.WriteLine("Enabling TaskMnger");
                    Utilities.EnableTaskManager();
                    changeDetected = true;
                }
                Console.WriteLine("Checking RegEdit");
                if (Utilities.CheckRegEditor())
                {
                    Console.WriteLine("Enabling RegEdit");
                    Utilities.EnableRegistryEditor();
                    changeDetected = true;
                }

                if (changeDetected != false)
                {
                    Console.WriteLine("Changes to registry have been made.");
                }

            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
            }

            Utilities.RestartExplorer();
            return changeDetected;
        }

    }
}
