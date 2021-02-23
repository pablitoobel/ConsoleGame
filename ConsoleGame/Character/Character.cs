using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleGame
{
    class Character : Entity
    {
        public CreatedCharacter CreatedCharacter { get; set; }

        public int SpecialAbilityDamage
        {
            get { return Damage + 5; }
        }

        public void CharacterAction()
        {
            Console.WriteLine($"I am {Name}. What should I do?");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use an item");

            int choice = InputChoice.Choice(); 
            switch (choice)
            {
                case 1:
                    {                    
                        Hit(CreatedCharacter.Enemies);
                        break;
                    }
                case 2:
                    {
                        var item = SelectItem();
                        if (this.isAlive)
                        {
                            if (item is ICharacterItemUse usable)
                            {
                                usable.Use(this);
                                Console.WriteLine($"{item.Name} was used.");
                            }
                            else Console.WriteLine("Nie da sie");
                        }
                        else Console.WriteLine($"{Name} is already dead!");
                        
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Choose from above!");
                        Thread.Sleep(1500);
                        Console.Clear();

                        break;
                    }
            }
        }
        private Item SelectItem()
        {
            int i=0;
            int choice;
            Console.WriteLine("Choose an item.");
            foreach (var item in ItemBag)
            {
                Console.WriteLine($"{i++}. {item.ToStringItem()}");
            }
            choice = InputChoice.Choice();
            return ItemBag.ElementAt(choice);
        }

        private bool SpecialAbilityUsage()
        {
            Console.WriteLine("Do you want to use special ability?");
            Console.WriteLine("Press Y/N");
            char.TryParse(Console.ReadLine(), out char choice);
            choice.ToString().ToLower();
            return choice == 'y';

        }

        public override void UseSpecialAbility(Entity entity)
        {
            if (Mana >= 15)
            {
                Mana -= 15;
                entity.Hp -= SpecialAbilityDamage;
                Console.WriteLine($"{Name} attacked {entity.Name} took {SpecialAbilityDamage} damage. \n {entity.Name} hitpoints is now: {entity.Hp}");
            }
            else
            {
                Console.WriteLine("Not enough mana!");
            }
        }
        //The override modifier is required to extend or modify the abstract or virtual 
        //implementation of an inherited method, property, indexer, or event.
        public override void Hit(List<Entity> enemies)
        {
            if (enemies == null)
            {
                Console.WriteLine("All dead");
                return;
            }
            List<Entity> areEnemiesAlive = enemies.Where(enemy => enemy.isAlive).ToList();
            if(areEnemiesAlive.Any())
            {
                bool SpecialAbility = SpecialAbilityUsage();
                Hit(areEnemiesAlive[0], SpecialAbility);
            }
        }
    }
}
