using System;
using System.IO;
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

                Parallel.ForEach(directory.GetFiles(), file =>
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
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting file {file.FullName}: {ex.Message}");
                    }
                });

                Parallel.ForEach(directory.GetDirectories(), subDirectory =>
                {
                    try
                    {
                        subDirectory.Delete(true);
                        Console.WriteLine($"Directory {subDirectory.FullName} has been deleted.");
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Error deleting directory {subDirectory.FullName}: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting directory {subDirectory.FullName}: {ex.Message}");
                    }
                });
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
