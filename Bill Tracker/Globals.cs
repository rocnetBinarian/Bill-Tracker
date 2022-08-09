using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bill_Tracker
{
    public static class Globals
    {
        public static ConfigSettings Config { get; set; }
        public static LoggerConfiguration LogConf { get; set; }
    }
}
