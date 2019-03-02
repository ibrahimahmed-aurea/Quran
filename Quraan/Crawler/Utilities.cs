using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public static class Utilities
    {
        internal static void CreateDirectory(string targetDir)
        {
            string parent = Path.GetDirectoryName(targetDir);
            if (!Directory.Exists(parent))
                CreateDirectory(parent);
            Directory.CreateDirectory(targetDir);
        }
    }
}
