using System;
using System.IO;

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
                    try
                    {
                        file.Delete();
                        Console.WriteLine($"File {file.FullName} has been deleted.");
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Error deleting file {file.FullName}: {ex.Message}");
                    }
                }

                // Recursively delete all subdirectories and their files
                foreach (DirectoryInfo subDirectory in directory.GetDirectories())
                {
                    foreach (FileInfo file in subDirectory.GetFiles())
                    {
                        try
                        {
                            file.Delete();
                            Console.WriteLine($"File {file.FullName} has been deleted.");
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine($"Error deleting file {file.FullName}: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting path {path}: {ex.Message}");
            }
        }

        public void delFile(string path)
        {
            try
            {
                File.Delete(path);
                Console.WriteLine($"File {path} has been deleted.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error deleting file {path}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file {path}: {ex.Message}");
            }
        }
    }
}
