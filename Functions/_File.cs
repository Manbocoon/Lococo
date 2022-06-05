using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lococo
{
    /// <summary>
    /// 파일과 관련된 함수들이 담긴 정적 객체입니다.
    /// </summary>
    static class _File
    {
        /// <summary>
        /// 특정 폴더를 하위 폴더/파일까지 통째로 복사합니다.
        /// </summary>
        /// <param name="sourceFolder">복사할 원본 폴더의 경로입니다.</param>
        /// <param name="destFolder">붙여넣어질 목적지 폴더 경로입니다.</param>
        public static void CopyDirectory(string sourceFolder, string destFolder)
        {
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

        /// <summary>
        /// 특정 파일을 윈도우 탐색기를 열어 선택합니다. 실행은 하지 않습니다.
        /// </summary>
        /// <param name="file_path">선택할 파일의 경로입니다.</param>
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

        /// <summary>
        /// 특정 폴더에서 file_name과 이름이 부합하는 파일을 찾습니다. 하위 폴더까지 찾지는 않습니다. 파일이 없다면 null을 반환합니다.
        /// </summary>
        /// <param name="root_dir">파일을 찾아볼 폴더 경로입니다.</param>
        /// <param name="file_name">찾을 파일 이름입니다.</param>
        /// <returns></returns>
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

        /// <summary>
        /// 윈도우에서 허용된 파일 이름인지 확인합니다.
        /// </summary>
        /// <param name="fileName">파일 이름입니다.</param>
        /// <returns></returns>
        public static bool IsValidFileName(string fileName)
        {
            bool is_valid = true;

            foreach (char file_char in fileName)
            {
                foreach (char invalid_char in Path.GetInvalidFileNameChars())
                {
                    if (file_char == invalid_char)
                    {
                        is_valid = false;
                        break;
                    }
                }

                if (!is_valid)
                {
                    break;
                }
            }


            return is_valid;
        }
    }
}
