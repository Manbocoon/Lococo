using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lococo
{
    static class _File
    {
        public static void CopyDirectory(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);


            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest, true);
            }

            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyDirectory(folder, dest);
            }
        }

        public static void SelectFileWithExplorer(string file_path)
        {
            if (!File.Exists(file_path))
            {
                return;
            }

            Process explorer = new Process();
            explorer.StartInfo.FileName = "explorer.exe";
            explorer.StartInfo.Arguments = "/select, \"" + file_path + "\"";
            explorer.StartInfo.UseShellExecute = true;
            explorer.StartInfo.Verb = "runas";
            explorer.Start();
        }

        public static string SearchFile(string root_dir, string file_name)
        {
            string result = null;
            string[] dirs = Directory.GetDirectories(root_dir);
            StringBuilder targetFilePath = new StringBuilder(null);

            for (int i=0; i<dirs.Length; ++i)
            {
                targetFilePath.Clear();
                targetFilePath.Append(dirs[i] + "\\" + file_name);

                if (File.Exists(targetFilePath.ToString()))
                {
                    result = targetFilePath.ToString();
                    break;
                }
            }

            return result;
        }


    }
}
