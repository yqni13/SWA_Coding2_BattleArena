using BattleArena.Pawn;
using BattleArena.Singleton;
using System;

namespace BattleArena.Items
{
    public class CynradBow : IEquipment
    {
        Log log = Log.GetInstanceStatic;

        private const int percentageVariable = 2;
        private const int strenght = 10;

        private readonly Random randomNumberGenerator;

        public string Name { get; } = "Cynrad Bow";

        public CynradBow(Random randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
            log.LogMetaData("CynradBow", "WeaponInstance");
        }

        public CynradBow()
        {
        }

        public void Use(Hero other)
        {
            if(this.randomNumberGenerator.Next(10) < percentageVariable)
            {
                other.ReduceHealth(strenght);
            }
        }
         
    }
}
