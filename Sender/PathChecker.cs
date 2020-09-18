using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    public class PathChecker
    {
        public static bool DoesPathExists(string path)
        {
            if (File.Exists(path))
                return true;
            Console.WriteLine("Given File Path doesn't Exist");
            return false;
        }
    }
}
