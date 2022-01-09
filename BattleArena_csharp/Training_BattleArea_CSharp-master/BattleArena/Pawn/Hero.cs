using BattleArena.Items;
using BattleArena.Singleton;
using System;
using System.Collections.Generic;

namespace BattleArena.Pawn
{
    public class Hero
    {
        Log log = Log.GetInstanceStatic;

        private readonly IEquipment _weapon;
        private int _lastKeyInput;
        private List<Goblin> _goblins = new List<Goblin>();

        public int Health { get; private set; } = 100;
        public int Coins { get; private set; } = 1;
        public int NumberOfGoblins => this._goblins.Count;
        public int Leprechaun { get; private set; } = 0;

        public string Name { get; private set; }

        public Hero(string name, IEquipment equipment)
        {
            this.Name = name;
            this._weapon = equipment;

            this._lastKeyInput = -1;
            
        }

        public bool Action(Hero other)
        {
            this._weapon.Use(other);
            log.LogMetaData("fight", "FightMethod");
            return true;
        }

        public void UpdateCoins()
        {
            this.Coins += this.Leprechaun + 1;
        }

        public void UseGoblins(Hero other)
        {
            foreach (Goblin tmpGoblin in this._goblins)
            {
                tmpGoblin.Action(other);
            }
        }

        public void ReduceHealth(int hitPoints)
        {
            this.Health -= hitPoints;
        }

        public bool AddLeprechaun()
        {
            if (this.Coins > 1)
            {
                this.Coins -= 2;
                this.Leprechaun++;
                log.LogMetaData("Leprechaun", "CreatureInstance");
                return true;
            }
            return false;
        }

        public bool AddTinyGoblin(Random randomNumberGenerator)
        {
            if (this.Coins > 0)
            {
                this.Coins -= 1;
                this._goblins.Add(new Goblin(1, randomNumberGenerator));
                log.LogMetaData("TinyGoblin", "CreatureInstance");
                return true;
            }
            return false;
        }

        public bool AddMediumGoblin(Random randomNumberGenerator)
        {
            if (this.Coins > 2)
            {
                this.Coins -= 3;
                this._goblins.Add(new Goblin(2, randomNumberGenerator));
                log.LogMetaData("MediumGoblin", "CreatureInstance");
                return true;
            }
            return false;
        }

        public bool AddBigGoblin(Random randomNumberGenerator)
        {
            if (this.Coins > 5)
            {
                this.Coins -= 6;
                this._goblins.Add(new Goblin(3, randomNumberGenerator));
                log.LogMetaData("BigGoblin", "CreatureInstance");
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}\nCoins {this.Coins}\nLeprechaun: {this.Leprechaun}\nLastKeyInput: {this._lastKeyInput}\n\n";
        }
    }
}