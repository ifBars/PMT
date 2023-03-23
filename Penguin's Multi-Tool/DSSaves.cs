using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using SevenZip;

namespace Penguin_s_Multi_Tool
{
    public class DSSaves
    {

        public static void ConvertDsvToDsz(string dsvFilePath)
        {
            string dszFilePath = Path.ChangeExtension(dsvFilePath, "dsz");
            string fileName = Path.GetFileName(dsvFilePath);

            // Create a temporary directory for the 7za command
            string tempDirectory = Path.Combine(Path.GetDirectoryName(dsvFilePath), "7za_temp");
            Directory.CreateDirectory(tempDirectory);

            // Move the DSV file to the temporary directory
            string tempFilePath = Path.Combine(tempDirectory, Path.GetFileName(dsvFilePath));
            File.Move(dsvFilePath, tempFilePath);

            // Create a 7z archive with the contents of the temporary directory
            SevenZipCompressor compressor = new SevenZipCompressor();
            compressor.CompressFiles(dszFilePath, tempDirectory + "\\" + fileName);

            // Clean up the temporary directory
            Directory.Delete(tempDirectory, true);
            Console.WriteLine("Converted " + Path.GetFileName(dszFilePath) + " to dsz.");
        }

        public static void ConvertDszToDsv(string dszFilePath)
        {
            string extractedFilePath = Path.ChangeExtension(dszFilePath, "7z");
            string dsvFilePath = Path.ChangeExtension(dszFilePath, "dsv");

            // Extract the contents of the DSZ file using Squid-Box.SevenZipSharp
            using (var extractor = new SevenZipExtractor(dszFilePath))
            {
                extractor.ExtractArchive(Path.GetDirectoryName(dszFilePath));
            }

            // Rename the extracted file to have a DSV extension
            // File.Move(extractedFilePath, dsvFilePath);
            File.Delete(dszFilePath);
            Console.WriteLine("Converted " + Path.GetFileName(dszFilePath) + " to dsv.");
        }

        public static void Convert()
        {
            SevenZipBase.SetLibraryPath("7z.dll"); // Set the path to the 7z.dll library

            Console.WriteLine("Please enter the path to your DSZ/DSV file, to convert it");
            string path = Console.ReadLine();
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("Going back to the menu.");
            }
            else if (Path.GetExtension(path) == ".dsz") {
                ConvertDszToDsv(path);
            }
            else if (Path.GetExtension(path) == ".dsv")
            {
                ConvertDsvToDsz(path);
            }
            else
            {
                Console.WriteLine("Going back to the menu.");
            }
        }

    }
}
