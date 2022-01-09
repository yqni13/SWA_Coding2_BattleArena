using BattleArena.Pawn;
using BattleArena.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleArena.Observer
{
    
    public enum EAchievementsList
    {        
        DownTo90PercentHealth = 90,
        DownTo50PercentHealth = 50,
        DownTo25PercentHealth = 25,
        DownTo10PercentHealth = 10,
        Victory = 0
    }

    class Achievements
    {
        IDictionary<string, int> listeners = new Dictionary<string, int>();
        IDictionary<string, bool> eAchievementsList = new Dictionary<string, bool>();

        // Need to compare in %.
        private int _maxHealthToCompare;    

        public Achievements()
        {
            foreach(string i in Enum.GetNames(typeof(EAchievementsList)))
            {
                // Set up dict for enums with bool to compare if achievement is already unlocked or not.
                eAchievementsList.Add(i, false);
            }
        }
        
        public void Subscribe(string name, int health)
        {
            // Fill up dict (players-key, health-value) => compare for changes.
            listeners.Add(name, health);
            this._maxHealthToCompare = health;
        }
        
        public void Notification(double enumCode)
        {
            Log log = Log.GetInstanceStatic;

            if (enumCode <= 90 && enumCode > 50 && !eAchievementsList["DownTo90PercentHealth"])
            {
                eAchievementsList["DownTo90PercentHealth"] = true;
                log.LogMetaData("drop down to 90% health", "Achievement");
            }
            else if (enumCode <= 50 && enumCode > 25 && !eAchievementsList["DownTo50PercentHealth"])
            {
                eAchievementsList["DownTo50PercentHealth"] = true;
                log.LogMetaData("drop down to 50% health", "Achievement");
            }
            else if (enumCode <= 25 && enumCode > 10 && !eAchievementsList["DownTo25PercentHealth"])
            {
                eAchievementsList["DownTo25PercentHealth"] = true;
                log.LogMetaData("drop down to 25% health", "Achievement");
            }
            else if (enumCode <= 10 && enumCode > 0 && !eAchievementsList["DownTo10PercentHealth"])
            {
                eAchievementsList["DownTo10PercentHealth"] = true;
                log.LogMetaData("drop down to 10% health", "Achievement");
            }
            else if (enumCode <= 0 && !eAchievementsList["Victory"])
            {
                eAchievementsList["Victory"] = true;
                log.LogMetaData("win the game", "Achievement");
            }            
        }

        public void GetEnumCompareValue(string name, int currentHealth)
        {
            /// check if health of player changed and return rounded down percentage of health
            if (currentHealth != listeners[name])
                Notification(Math.Floor((double)currentHealth / this._maxHealthToCompare * 100));            
        }        
    }
}
