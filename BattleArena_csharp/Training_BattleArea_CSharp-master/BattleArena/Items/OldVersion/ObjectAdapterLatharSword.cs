using BattleArena.Pawn;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleArena.Items.OldVersion
{
       
    public class ObjectAdapterLatharSword : IEquipment
    {
        private LatharSword instance;

        public ObjectAdapterLatharSword(LatharSword instance)
        {
            this.instance = instance;
        }

        public void Use(Hero opponent)
        {
            int damage = this.instance.Hit();
            opponent.ReduceHealth(damage);
        }
    }
    
}
