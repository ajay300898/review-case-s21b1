using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    public class CsvInfo
    {
        public static string[] GetColumns(string filePath)
        {
            if (filePath == null || !PathChecker.DoesPathExists(filePath))
            {
                throw new Exception("File doesn't Exist");
            }

            var sr = File.OpenText(filePath);
            string[] columns = null;
            var firstLine = sr.ReadLine();
            if (!string.IsNullOrEmpty(firstLine))
            {
                columns = firstLine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            return columns;
        }

        public static int GetColumnIndex(string[] columns, string columnName)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                if (columns[i].Contains(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
