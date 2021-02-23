using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame
{
    public class Entity
    {
        public IEnumerable<Item> ItemBag { get; set; } = new List<Item>();
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Hp { get; set; }
        public int Mana { get; set; }
        public bool IsCharacter { get; set; }
        public bool isAlive
        {
            get { return Hp > 0; }
        }

        public void IntroduceYourself()
        {
            Console.WriteLine($"I am {Name} I have {Hp} health and {Mana} mana.");
        }
        public void IntroduceYourselfName()
        {
            Console.WriteLine($"I am {Name} I have {Hp} health.");
        }


        public virtual void Hit(List<Entity> enemies)
        {
            
            if (IsCharacter && isAlive)
            {
                Console.WriteLine("Who should I attack? HitMethod");
                List<string> s = new List<string>();
                int counter = 1;
                foreach (Entity enemyy in enemies)
                {
                    s.Add(enemyy.Name);
                    Console.WriteLine($"{counter} " + enemyy.Name + " " + enemyy.Hp + " hitpoints.");
                    counter++;
                }
                int choice = InputChoice.Choice();
                
                string name = s[choice - 1];
                Entity enemy = enemies.FirstOrDefault(character => (character.Name == name && character.isAlive));

                if (enemy == null)
                {
                    Console.WriteLine($"Enemy is dead.");
                    return;
                }
                else
                {
                    Hit(enemy);
                }
            }
            else
            {
                Entity enemy = enemies.FirstOrDefault(character => character.isAlive);
                if (isAlive)
                {
                    if (enemy.isAlive)
                    {
                        Hit(enemy);
                    }
                    else
                    {
                        Console.WriteLine($"{Name} is dead.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"{Name} is dead.");
                    return;
                }
            }
        }

        protected void Hit(Entity enemy)
        {
            int damageDealt;
            damageDealt = Damage;

            enemy.Hp -= damageDealt;
            Console.WriteLine($"{Name} attacked {enemy.Name} took {damageDealt} damage.\n" +
                $"{enemy.Name} hp is now {enemy.Hp}");
            Console.WriteLine();
        }
        protected void Hit(Entity entity, bool isSpecialAbility = false)//Chroniony element członkowski jest dostępny w jego klasie i wystąpieniach klasy pochodnej.
        {
            if (isAlive)
            {
                if (isSpecialAbility)
                {
                    UseSpecialAbility(entity);

                }
                else
                {
                    int damageDealt;
                    damageDealt = Damage;

                    entity.Hp = entity.Hp - damageDealt;
                    Console.WriteLine($"{Name} attacked {entity.Name} took {damageDealt} damage. \n {entity.Name} hitpoints is now: {entity.Hp}");
                }

            }
            else
            {
                Console.WriteLine($"{Name} tried to attack{entity.Name}, but {Name} is already dead.");
            }
        }

        public virtual void UseSpecialAbility(Entity entity)
        {
            Console.WriteLine($"{Name} tried to use special ability.");
        }
    }
}
