﻿namespace NameFilesWithFolderName
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string path = "E:\\Trains\\Photos - Main\\2025\\2025-01-18 Syston Model Railway\\19\\";

            string[] folders = Directory.GetDirectories(path);

            foreach (string folder in folders)
            {
                string name = Path.GetFileNameWithoutExtension(folder);
                Console.WriteLine(name);

                string[] files = Directory.GetFiles(folder);
                foreach (string file in files)
                {
                    string fName = Path.GetFileName(file);
                    if (!fName.Contains(name))
                    {
                        fName = fName.Replace(".", $" {name}.");
                        File.Move(file, $"{folder}\\{fName}");
                    }
                }
            }
        }
    }
}