using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    public class Item
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public virtual string ToStringItem()
        {
            return $"Item Value {Value}";
        }
    }
}
