using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    class CreatedCharacter
    {
        public List<Entity> Characters { get; set; }
        public List<Entity> Enemies { get; set; }

        public CreatedCharacter()
        {
            Characters = new List<Entity>()
            {
                new Character
                {
                    Name = "Wizard",
                    Damage = 20,
                    Hp = 60,
                    Mana = 100,
                    IsCharacter = true,
                    CreatedCharacter = this,
                    ItemBag = new[]
                    {
                        new Potions{HpRestore = 10, ManaRestore = 5, Name = "BigPotion"},
                        new Potions{HpRestore = 8, ManaRestore = 3, Name = "SmallPotion"}
                    }
                },
                new Character
                {
                    Name = "Warrior",
                    Damage = 30,
                    Hp = 50,
                    Mana = 50,
                    IsCharacter = true,
                    CreatedCharacter = this,
                    ItemBag = new[]
                    {
                        new Potions{HpRestore = 20, ManaRestore = 3, Name = "BigPotion"},
                        new Potions{HpRestore = 18, ManaRestore = 1, Name = "SmallPotion"}
                    }
                }
            };
            Enemies = new List<Entity>()
            {
                new Enemy
                {
                    Name = "Ghul",
                    Damage = 12,
                    IsCharacter = false,
                    Hp = 100
                },
                new Enemy
                {
                    Name = "Przeraza",
                    Damage = 18,
                    IsCharacter = false,
                    Hp = 120
                }
            };
        }
    }
}
