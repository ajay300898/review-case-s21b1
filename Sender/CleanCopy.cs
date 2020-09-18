using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    public class CleanCopy
    {
        public static string Create(string oldFilePath)
        {
            var newFileName = Path.GetFileName(oldFilePath);
            var newFilePath = Path.GetFullPath(newFileName);

            Func<string, bool> lineFilter = (string line) => line.Length > 3;

            Action<StreamWriter, string> writeLine = (StreamWriter writer, string line) => writer.WriteLine(line);
            
            FilterLines(lineFilter, writeLine, oldFilePath, newFilePath);

            return newFilePath;
        }

        public static bool FilterLines(Func<string, bool> filter, Action<StreamWriter, string> write, string copyFrom, string copyTo)
        {
            if (copyFrom != null && copyTo != null && PathChecker.DoesPathExists(copyFrom))
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(copyTo))
                    {
                        using (StreamReader sr = File.OpenText(copyFrom))
                        {
                            string line = "";
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (filter.Invoke(line))
                                {
                                    write.Invoke(sw, line);
                                }
                            }

                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Failed to create File");
                }
                
            }

            return false;
        }

    }
}
