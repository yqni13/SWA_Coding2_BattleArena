using BattleArena.Pawn;
using BattleArena.Singleton;
using System;

namespace BattleArena.Items
{
    public class CynradBow : IEquipment
    {
        Log log = Log.GetInstanceStatic;

        private const int _percentageVariable = 2;
        private const int _strenght = 10;

        private readonly Random _randomNumberGenerator;

        public string Name { get; } = "Cynrad Bow";

        public CynradBow(Random randomNumberGenerator)
        {
            this._randomNumberGenerator = randomNumberGenerator;
            log.LogMetaData("CynradBow", "WeaponInstance");
        }

        public CynradBow()
        {
        }

        public void Use(Hero other)
        {
            if(this._randomNumberGenerator.Next(10) < _percentageVariable)
            {
                other.ReduceHealth(_strenght);
            }
        }
         
    }
}
