using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Penguin_s_Multi_Tool
{
    public class SRP
    {
        public void CreateRestorePoint(string description)
        {
            try
            {
                ManagementScope oScope = new ManagementScope("\\\\localhost\\root\\default");
                ManagementPath oPath = new ManagementPath("SystemRestore");
                ObjectGetOptions oGetOp = new ObjectGetOptions();
                ManagementClass oProcess = new ManagementClass(oScope, oPath, oGetOp);

                ManagementBaseObject oInParams = oProcess.GetMethodParameters("CreateRestorePoint");
                oInParams["Description"] = description;
                oInParams["RestorePointType"] = 12; // MODIFY_SETTINGS
                oInParams["EventType"] = 100;

                ManagementBaseObject oOutParams = oProcess.InvokeMethod("CreateRestorePoint", oInParams, null);
                Console.WriteLine("System Restore Point Created!");
            }
            catch (ManagementException ex)
            {
                if (ex.ErrorCode == ManagementStatus.AccessDenied)
                {
                    Console.WriteLine("Access Denied: Please restart this program with Administrator privileges.");
                }
                else
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
