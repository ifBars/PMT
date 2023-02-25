using System;
using System.IO;

namespace Penguin_s_Multi_Tool
{
    public class Bin
    {
        public void EmptyRecycleBin()
        {
            Pathing p = new Pathing();

            try
            {
                // Clear the recycle bin
                var recycleBin = new DirectoryInfo(@"C:\$Recycle.Bin");
                foreach (var file in recycleBin.GetFiles("*", SearchOption.AllDirectories))
                {
                    p.delFile(file.FullName);
                }
                foreach (var dir in recycleBin.GetDirectories("*", SearchOption.AllDirectories))
                {
                    p.delPath(dir.FullName);
                }
                Console.WriteLine("Recycle bin cleared successfully.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access to the recycle bin is denied. Please run the program as Administrator.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while clearing the recycle bin: {ex.Message}");
            }
        }

    }
}
