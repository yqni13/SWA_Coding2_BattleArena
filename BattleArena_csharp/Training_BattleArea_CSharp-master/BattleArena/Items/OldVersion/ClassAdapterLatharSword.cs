using System;
using System.Collections.Generic;
using System.Text;

namespace BattleArena.Items.OldVersion
{
    
    public interface ILatharSwordClass
    {
        
        void Hit();         // abstract method
    }

    public class ClassAdapterLatharSword : ILatharSwordClass
    {
        void ILatharSwordClass.Hit()
        {
            Console.WriteLine("hit enemy"); //placeholder
        }
    }
    
}
