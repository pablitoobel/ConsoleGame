using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleGame
{
    class Game
    {
        public static CreatedCharacter CreatedCharacter { get; set; } = new CreatedCharacter();
        public static void GameLogic()
        {
            foreach(var entity in CreatedCharacter.Characters.Concat(CreatedCharacter.Enemies))
            {
                entity.IntroduceYourself();
            }

            static bool IsAnybodyAlive()
            {
                return CreatedCharacter.Characters.Any(character => character.isAlive);
            }
            static bool IsAnybodyAliveEnemies()
            {
                return CreatedCharacter.Enemies.Any(character => character.isAlive);
            }
            while (IsAnybodyAlive() && IsAnybodyAliveEnemies())
            {
                foreach(Character character in CreatedCharacter.Characters)
                {
                    character.CharacterAction();
                }
                foreach (Entity enemy in CreatedCharacter.Enemies)
                {
                    enemy.Hit(CreatedCharacter.Characters);

                    /*if (enemy.isAlive)
                    {
                       enemy.Hit(CreatedCharacter.Characters);
                    }
                    else
                    {
                        Console.WriteLine($"{enemy.Name} is dead!!!");
                       /*Console.WriteLine("All enemies have been defeted!!");
                        Thread.Sleep(2000);
                        EndScreen.EndGame();
                    }*/
                }
            }
            if (IsAnybodyAlive())
            {
                Console.WriteLine("         -------YOU WON-------         ");
                Thread.Sleep(2889);
                ExitScreen.EndTheGame();
            }
            if (IsAnybodyAliveEnemies())
            {
                Console.WriteLine("         -------You have been defeted!-------         ");
                Thread.Sleep(2889);
                ExitScreen.EndTheGame();
            }
        }
    }
}
