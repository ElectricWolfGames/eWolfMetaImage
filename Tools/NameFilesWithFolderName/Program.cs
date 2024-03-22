namespace NameFilesWithFolderName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string path = "E:\\Trains\\_WebsiteData\\ModelEvents\\2023-08-12 Loughborough model railway exhibition";

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
                        fName = fName.Replace("2023-08-12 ", "");
                        File.Move(file, $"{folder}\\{fName}");
                    }
                }

            }


        }
    }
}
