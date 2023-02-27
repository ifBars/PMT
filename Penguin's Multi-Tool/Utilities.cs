using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin_s_Multi_Tool
{
    public class Utilities
    {

        public static void RestartExplorer()
        {
            try
            {
                // Get the Windows Explorer process
                var explorerProcesses = Process.GetProcessesByName("explorer");
                if (explorerProcesses.Length > 0)
                {
                    // Kill the Windows Explorer process
                    explorerProcesses[0].Kill();

                    // Wait for the process to exit
                    explorerProcesses[0].WaitForExit();

                    // Start a new instance of Windows Explorer
                    Process.Start("explorer.exe");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
            }
        }

        public static void BackupRegistry(string backupPath)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true))
                {
                    if (key != null)
                    {
                        using (StreamWriter sw = new StreamWriter(backupPath))
                        {
                            sw.Write(key.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
            }
        }

        public static bool CheckFirewall()
        {
            bool enabled = false;

            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\StandardProfile", false))
                {
                    if (key != null)
                    {
                        object value = key.GetValue("EnableFirewall");
                        if (value != null)
                        {
                            enabled = (int)value == 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
            }

            return enabled;
        }

        public static bool CheckCMD()
        {
            bool enabled = false;

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Policies\Microsoft\Windows\System", false))
                {
                    if (key != null)
                    {
                        object value = key.GetValue("DisableCMD");
                        if (value != null)
                        {
                            enabled = (int)value == 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
            }

            return enabled;
        }

        public static bool CheckControlPanel()
        {
            bool enabled = false;

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", false))
                {
                    if (key != null)
                    {
                        object value = key.GetValue("NoControlPanel");
                        if (value != null)
                        {
                            enabled = (int)value == 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
            }

            return enabled;
        }

        public static bool CheckFolderOptions()
        {
            bool enabled = false;

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", false))
                {
                    if (key != null)
                    {
                        object value = key.GetValue("NoFolderOptions");
                        if (value != null)
                        {
                            enabled = (int)value == 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
            }

            return enabled;
        }

        public static bool CheckRunDialog()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer";
            const string valueName = "NoRun";

            int value = (int)Registry.GetValue(keyName, valueName, defaultValue: 0);
            return value == 1;
        }

        public static void EnableRunDialog()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer";
            const string valueName = "NoRun";

            Registry.SetValue(keyName, valueName, value: 0, RegistryValueKind.DWord);
        }

        public static void EnableFirewall()
        {
            const string keyName = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SharedAccess\Parameters\FirewallPolicy\StandardProfile";
            const string valueName = "EnableFirewall";

            Registry.SetValue(keyName, valueName, value: 1, RegistryValueKind.DWord);
        }

        public static void EnableCommandPrompt()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Policies\Microsoft\Windows\System";
            const string valueName = "DisableCMD";

            Registry.SetValue(keyName, valueName, value: 0, RegistryValueKind.DWord);
        }

        public static void EnableControlPanel()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer";
            const string valueName = "NoControlPanel";

            Registry.SetValue(keyName, valueName, value: 0, RegistryValueKind.DWord);
        }

        public static void EnableFolderOptions()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer";
            const string valueName = "NoFolderOptions";

            Registry.SetValue(keyName, valueName, value: 0, RegistryValueKind.DWord);
        }

        public static bool CheckContextMenu()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer";
            const string valueName = "NoViewContextMenu";

            int? value = Registry.GetValue(keyName, valueName, defaultValue: null) as int?;

            return (value != null && value == 0);
        }

        public static void EnableContextMenu()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer";
            const string valueName = "NoViewContextMenu";

            Registry.SetValue(keyName, valueName, value: 0, RegistryValueKind.DWord);
        }

        public static bool CheckTaskManager()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System";
            const string valueName = "DisableTaskMgr";

            int? value = Registry.GetValue(keyName, valueName, defaultValue: null) as int?;

            return (value != null && value == 0);
        }

        public static void EnableTaskManager()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System";
            const string valueName = "DisableTaskMgr";

            Registry.SetValue(keyName, valueName, value: 0, RegistryValueKind.DWord);
        }

        public static bool CheckRegEditor()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System";
            const string valueName = "DisableRegistryTools";

            int? value = Registry.GetValue(keyName, valueName, defaultValue: null) as int?;

            return (value != null && value == 0);
        }

        public static void EnableRegistryEditor()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System";
            const string valueName = "DisableRegistryTools";

            Registry.SetValue(keyName, valueName, value: 0, RegistryValueKind.DWord);
        }


    }
}
