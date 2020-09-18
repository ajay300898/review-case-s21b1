using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{

    public class Timestamp
    {
        public static bool DoesTimestampExists(string[] columns)
        {
            bool date = Array.Exists(columns, str => str.Contains("date", StringComparison.OrdinalIgnoreCase));
            bool time = Array.Exists(columns, str => str.Contains("time", StringComparison.OrdinalIgnoreCase));
            return date || time;
        }
    }
}
