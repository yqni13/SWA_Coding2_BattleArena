using System;
using System.IO;

namespace BattleArena.Singleton
{
    /*The Singleton is called an Anti-Pattern for different reasons, like:
        - hard to unit test and breaking the single responsibility principle
        - usage as global variables, thus a disadvantage for encapsulation
        - limiting options of multi-threading with single object
        - decreasing performance with multiple Singletons
        - limitations in extending Singletons
      Furthermore, in a garbage collected system, Singletons can become very hard to handle in regards
      to memory management. As long as the Singleton class does not consume time extraordinarly 
      or has big time side-effects, the static is to prefer against lazy initialization.*/
    public class Log
    {
        private Log() { LogMetaData("Log"); }

        private string _logData = "";       // member in Singleton which is used only for this purpose
        

        // lazy initialization
        private Lazy<Log> _lazyLog = null;

        public Lazy<Log> GetInstanceLazy
        {
            get
            {
                if (_lazyLog == null)
                {
                    _lazyLog = new Lazy<Log>();
                }
                return _lazyLog;
            }
        }


        // static initialization
        private static Log _staticLog = null;

        public static Log GetInstanceStatic
        {
            get
            {
                return _staticLog = new Log();
            }
        }

        public void LogMetaData(string _object)
        {
            DateTimeOffset timestamp = (DateTimeOffset)DateTime.UtcNow.AddHours(1);     // AddHours() to adapt current timezone
            _logData += timestamp.ToString("dd.MM.yyyy, HH:mm:ss:fff") + $" | call instance by {_object}\n";
        }

        public void PrintLogFile()
        {
            StreamWriter logfile = new StreamWriter("../../../Singleton/LogFile" + DateTime.UtcNow.AddHours(1).ToString("yyyyMMdd_HH-mm-ss") + "." + "txt", true);
            logfile.Write(_logData);
            logfile.Close();            
        }
    }
}
