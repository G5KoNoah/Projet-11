using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Projet_C_.FightManager;
using static System.Net.Mime.MediaTypeNames;

namespace Projet_C_
{
    public class Draw
    {
        Map _map;
        public Map Map { get => _map; set => _map = value; }
        public Draw()
        {
            Map = null;
        }

        public void DrawMap(bool drawPlayer)
        {
            //Console.Clear();
            
            Player player = GameManager.Instance.Player;
            List<string> lMap = Map.MapList;
           
            for (int i = 0; i < lMap.Count; i++)
            {
                for (int j = 0; j < lMap[i].Length; j++)
                {
                    switch (lMap[i][j])
                    {
                        case '_' or '|':
                            Console.BackgroundColor = ConsoleColor.Blue;
                           
                            break;
                        case '.':
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;
                        case '*':
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;
                        case '$':
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case '/':
                            Console.BackgroundColor = ConsoleColor.Red;
                            break;
                        case '1':
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            //Console.Write('O');
                            break;
                        case '8':
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            //Console.Write('O');
                            break;
                        case '2':
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            //Console.Write('O');
                            break;

                    }
                    
                    if (i == player.TopPos && j == player.LeftPos && drawPlayer)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write('P');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
              

                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 0);
        }
        public void Fight(Player player, Character enemy)
        {
            var fightManager = GameManager.Instance.FightManager;
            var currentCharacter = player.CurrentCharacter;
            DrawMap(false);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(14, 0);
            Console.WriteLine(currentCharacter.DefaultStats.Name + "  " + currentCharacter.DefaultStats.Type.Name);
            Console.SetCursorPosition(59, 0);
            Console.WriteLine(enemy.DefaultStats.Name + "  " + enemy.DefaultStats.Type.Name);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(14, 14);
            Console.WriteLine(currentCharacter.PV);
            Console.SetCursorPosition(59, 14);
            Console.WriteLine(enemy.PV);
            switch (fightManager.CurrentState)
            {
                case FightManager.StateFight.Start:
                    for (int i = 0; i < fightManager.Choice.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(13, 15 + i);
                        if (i + 1 == fightManager.Select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine(fightManager.Choice[i]);
                    }
                    break;

                case FightManager.StateFight.Attack:
                    for (int i = 0; i < currentCharacter.Spells.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(13, 15 + i);
                        if (i + 1 == fightManager.Select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine(currentCharacter.Spells[i].Name);
                    }

                    break;

                case FightManager.StateFight.Tools:
                    for (int i = 0; i < player.ListTools.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(13, 15 + i);
                        if (i + 1 == fightManager.Select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine(player.ListTools[i].Name);
                    }

                    break;

                case FightManager.StateFight.ChangePerso:
                    for (int i = 0; i < player.ListCharacter.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(13, 15 + i);
                        if (i + 1 == fightManager.Select)
                        {
                            if(player.ListCharacter.ElementAt(i).Value.PV == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            
                        }
                        Console.WriteLine(player.ListCharacter.ElementAt(i).Value.DefaultStats.Name);
                    }

                    break;
            }

            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);

        }


        public void Win(Player player, Character enemy)
        {
            Console.SetCursorPosition(0, 0);
            Fight(player, enemy);
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("vous avez gagnez !!");
            Console.SetCursorPosition(0, 0);
        }

        public void Loose(Player player, Character enemy)
        {
            Console.SetCursorPosition(0, 0);
            Fight(player, enemy);
            Console.SetCursorPosition(30, 20);
            Console.WriteLine("vous avez perdu !!");
            Console.SetCursorPosition(0, 0);
        }

        public void Damage(float damage, bool isEnemy)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(35, 10);
            if (isEnemy)
            {
                Console.WriteLine(" - " + damage + "<-");
            }
            else
            {
                Console.WriteLine("-> - " + damage);
            }
        }

        public void Pause()
        {
            DrawMap(false);
            Console.SetCursorPosition(33, 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ONE PIECE");

            var choices = GameManager.Instance.Choice;
            for (int i = 0; i < choices.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                if (i + 1 == GameManager.Instance.Select)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.SetCursorPosition(13, 8 + 3 * i);
                Console.WriteLine(choices[i]);
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
        }
    }
}
