using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class Potions : Item, ICharacterItemUse
    {

        public int HpRestore { get; set; }
        public int ManaRestore { get; set; }

        public void Use(Character user)
        {
            user.Hp += HpRestore;
            user.Mana += ManaRestore;
            Console.WriteLine($"{user.Name} Hp is now {user.Hp}");
        }

        public override string ToStringItem()
        {
            return $"Potion restored {HpRestore} hp and {ManaRestore} mana.";
        }
    }
}
