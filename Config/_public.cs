using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lococo.Config
{

    public static class _public
    {

        public static void CreateDirectories()
        {
            Directory.CreateDirectory(Program.Path + "\\db");
            Directory.CreateDirectory(Program.Path + "\\db\\settings");
            Directory.CreateDirectory(Program.Path + "\\db\\settings\\favorites");
        }

    }
}
