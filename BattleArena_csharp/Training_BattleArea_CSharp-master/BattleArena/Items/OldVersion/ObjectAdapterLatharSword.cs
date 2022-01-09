using BattleArena.Pawn;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleArena.Items.OldVersion
{   
    /// The used Object Adapter Pattern holds an instance of adaptee (composition as adaptee object inside adapter) meanwhile the Class Adapter Pattern
    /// uses inheritance instead of composition which requires multiple inheritance for implementation (fits C++).
    /// 
    /// Advantages Object Adapter:
    /// - no multiple inheritance necessary (most programing languages)
    /// - more flexibilty and re-usability
    /// 
    /// Advantages Class Adapter:
    /// - easily override behaviour of adaptee / doesn't need to wrap up any objects

    public class ObjectAdapterLatharSword : IEquipment
    {
        private LatharSword _instance;

        public ObjectAdapterLatharSword(LatharSword instance)
        {
            this._instance = instance;
        }

        public void Use(Hero opponent)
        {
            int damage = this._instance.Hit();
            opponent.ReduceHealth(damage);
        }
    }
}
