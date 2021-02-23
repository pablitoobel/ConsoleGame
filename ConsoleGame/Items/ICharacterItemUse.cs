using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    interface ICharacterItemUse
    {
        void Use(Character user);
        string ToStringItem();
    }
}
