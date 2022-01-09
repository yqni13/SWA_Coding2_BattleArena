using BattleArena.Singleton;
using System;

namespace BattleArena.Items.OldVersion
{
    public class LatharSword
    {
        Log log = Log.GetInstanceStatic;

        private const int _percentageVariable = 4;
        private const int _strenght = 5;

        private readonly Random _randomNumberGenerator;

        public LatharSword(Random randomNumberGenerator)
        {
            this._randomNumberGenerator = randomNumberGenerator;
            log.LogMetaData("LatharSword", "WeaponInstance");
        }

        public int Hit()
        {
            return this._randomNumberGenerator.Next(10) < _percentageVariable ? _strenght : 0;
        }
    }
}
