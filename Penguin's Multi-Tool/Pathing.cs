using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penguin_s_Multi_Tool
{
    public class Pathing
    {

        public void delPath(string path)
        {
            try
            {
                DirectoryInfo directory = new DirectoryInfo(path);

                // Delete all files in the directory
                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }

                // Recursively delete all subdirectories and their files
                foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                {
                    delPath(subDirectory.FullName);
                }

                // Delete the current directory
                directory.Delete();
            }
            catch (Exception ex)
            {
                
            }
        }


        public void delFile(string path)
        {
            try
            {
                File.Delete(path);
                Console.WriteLine($"File {path} has been deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file {path}: {ex.Message}");
            }
        }

    }
}
