using System;
using System.IO;

namespace BattleArena.Singleton
{
    /// The Singleton is called an Anti-Pattern for different reasons, like:
    ///    - hard to unit test and breaking the single responsibility principle
    ///    - usage as global variables, thus a disadvantage for encapsulation
    ///    - limiting options of multi-threading with single object
    ///    - decreasing performance with multiple Singletons
    ///    - limitations in extending Singletons
    /// Furthermore, in a garbage collected system, Singletons can become very hard to handle in regards
    /// to memory management. As long as the Singleton class does not consume time extraordinarly 
    /// or has big time side-effects, the static is to prefer against lazy initialization.
    
    public class Log
    {
        private Log() { LogMetaData("Log", "LogInstance"); }

        // Use string to log data until generating logfile each program run.
        private string _logData = "";

        // Save name of hero (player) to assign action each log line.
        private string _player = "";            

        // Lazy initialization; not used.
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


        // Static initialization.
        private static Log s_staticLog = new Log();

        public static Log GetInstanceStatic
        {
            get
            {
                return s_staticLog;
            }
        }

        public void LogMetaData(string msg, string category)
        {
            // AddHours() to adapt current timezone.
            DateTimeOffset timestamp = DateTime.UtcNow.AddHours(1);     

            if (category == "CreatureInstance")
            {
                _logData += timestamp.ToString("dd.MM.yyyy, HH:mm:ss:fff") + $" | hero: {_player} gets creature {msg}\n";
            }
            else if (category == "FightMethod")
            {
                _logData += timestamp.ToString("dd.MM.yyyy, HH:mm:ss:fff") + $" | hero: {_player} chooses to {msg}!\n";
            }
            else if (category == "WeaponInstance")
            {
                _logData += timestamp.ToString("dd.MM.yyyy, HH:mm:ss:fff") + $" | hero: {_player} chooses weapon {msg}\n";
            }
            else if (category == "Achievement")
            {
                _logData += $"Achievement: a player did {msg}\n";
            }
            else
            {
                _logData += timestamp.ToString("dd.MM.yyyy, HH:mm:ss:fff") + $" | Initialization call of {msg}\n";
            }
        }

        public void GetPlayerName(string name)
        {
            this._player = name;
        }

        public void PrintLogFile()
        {
            /// by saving log messages in string and writing into "log"file 
            /// at the end while saving with date and time,
            /// only one file each program run is generated
            /// don't move the .exe!!!
            StreamWriter logfile = new StreamWriter("../../../Singleton/LogFile" + DateTime.UtcNow.AddHours(1).ToString("yyyyMMdd_HH-mm-ss") + "." + "txt", true);
            logfile.Write(_logData);
            logfile.Close();            
        }
    }
}
