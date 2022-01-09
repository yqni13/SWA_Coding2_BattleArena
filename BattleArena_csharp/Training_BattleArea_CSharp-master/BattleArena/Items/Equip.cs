using BattleArena.Items.OldVersion;
using System;

namespace BattleArena.Items
{
    class Equip
    {
        public object IEquipment { get; private set; }

        public enum EEquipmentItem
        {
            LatharSword = 0,
            CynradBow = 1
        }

        public IEquipment EquipHero(Random randomNumberGenerator)
        {
            switch (randomNumberGenerator.Next(2))
            {
                case (0):
                     return new CynradBow(randomNumberGenerator);
                case (1):
                    return new ObjectAdapterLatharSword(new LatharSword(randomNumberGenerator));
                default:
                    return new CynradBow(randomNumberGenerator);
            }
        }
    }
}
