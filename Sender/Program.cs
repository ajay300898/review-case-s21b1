using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Sender
{
    public class Sender
    {

        static void Main(string[] args)
        {
            string path = "https://raw.githubusercontent.com/ajay300898/review-case-s21b1/master/Sample.csv"          //"..\Sample.csv";
            while (!PathChecker.DoesPathExists(path))
            {
                path = Console.ReadLine();                                 // Modify to reduce Complexity
            }
            //handle exception
            path = CleanCopy.Create(path);                                 // What if data has comma in tye text

            string[] columns = CsvInfo.GetColumns(path);                   // handle exception

            var reviewColumnIndex = CsvInfo.GetColumnIndex(columns,"Comments");

            Action<string, string> sendWordsWithTimestamp = (string timestamp, string line) =>
            {
                string[] words = line.Split(new char[] { ' ','.','?',',',':' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    Console.WriteLine(timestamp + " " + words[i]);
                }
            };
            Func<string, bool> filterDefaultComments = (string comment) => !comment.Equals("No Additional Comments");

            if (Timestamp.DoesTimestampExists(columns))
            {
                var timestampColumnIndex = CsvInfo.GetColumnIndex(columns, "ReviewDate");

                
                FilterAndSend(sendWordsWithTimestamp, filterDefaultComments,timestampColumnIndex, reviewColumnIndex,path);
            }
            else
            {
                FilterAndSend(sendWordsWithTimestamp, filterDefaultComments,reviewColumnIndex, path);
            }

        }

        public static void FilterAndSend(Action<string, string> sendWordsWithTimestamp, Func<string, bool> filterDefaultComments,int timestampColumn, int reviewColumn, string filePath)
        {
            using (var sr = File.OpenText(filePath))
            {
                var line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split(',');
                    if(filterDefaultComments.Invoke(row[reviewColumn]))           // add filters to comment 
                        sendWordsWithTimestamp.Invoke(row[timestampColumn], row[reviewColumn]);
                }
            }
        }

        public static void FilterAndSend(Action<string, string> sendWordsWithoutTimestamp, Func<string, bool> filterDefaultComments,int reviewColumn, string filePath)
        {
            using (var sr = File.OpenText(filePath))
            {
                var line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] row = line.Split(',');
                    if (filterDefaultComments.Invoke(row[reviewColumn]))
                        sendWordsWithoutTimestamp.Invoke("NoDateTime", row[reviewColumn]);
                }
            }
        }

    }
}
