using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lococo.Config
{
    /// <summary>
    /// 모든 설정 관리 객체에서 동일하게 사용하는 함수들이 담긴 클래스입니다.
    /// </summary>
    public static class _public
    {
        /// <summary>
        /// 프로그램의 설정 파일들의 기본 폴더 경로입니다. "%프로그램%\db\settings"
        /// </summary>
        public static readonly string configDir = Program.Path + "\\db\\settings";


        public static void CreateDirectories()
        {
            Directory.CreateDirectory(Program.Path + "\\db");
            Directory.CreateDirectory(configDir);
            
            Directory.CreateDirectory(configDir + "\\favorites");
            Directory.CreateDirectory(configDir + "\\favorites\\browser");
            Directory.CreateDirectory(configDir + "\\favorites\\image");
            Directory.CreateDirectory(configDir + "\\favorites\\text");

        }

    }
}
