using System;
using System.IO;

namespace SmartDllCleaner
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Provide path only, as string, no argument name");
                return;
            }

            var path = args[0];

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Directory does not exist!");
                return;
            }

            TraverseDirectoriesAndRemove(path);
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static void TraverseDirectoriesAndRemove(string path)
        {
            if (path.Contains("smart-dll-cleaner")) return;
            RemoveDir(path, ".idea");
            RemoveDir(path, "bin");
            RemoveDir(path, "obj");
            RemoveDir(path, "node_modules");

            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                TraverseDirectoriesAndRemove(dir);
            }
        }

        private static void RemoveDir(string path, string dir)
        {
            var objDir = path.TrimEnd('\\') + "\\" + dir;
            if (Directory.Exists(objDir))
            {
                Directory.Delete(objDir, true);
            }
        }
    }
}