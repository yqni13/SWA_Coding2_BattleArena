using System;

namespace BattleArena.Pawn
{
    internal class Goblin
    {        
        private const int _percentageVariable = 3;

        private int _strength;
        private Random _randomNumberGenerator;

        public Goblin(int strength, Random randomNumberGenerator)
        {
            this._strength = strength;
            this._randomNumberGenerator = randomNumberGenerator;
        }

        internal void Action(Hero other)
        {
            if (this._randomNumberGenerator.Next(10) < _percentageVariable)
            {
                other.ReduceHealth(_strength);
            }
        }
    }
}