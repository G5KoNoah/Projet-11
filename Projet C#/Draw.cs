using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void DrawMap()
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

                    }
                    
                    if (i == player.TopPos && j == player.LeftPos)
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
        public void Fight(Player player, Enemy enemy, int select)
        {
            var currentCharacter = player.CurrentCharacter;
            DrawMap();
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("              " + currentCharacter.DefaultStats.Name + "  " + currentCharacter.DefaultStats.Type.Name + "                              " + enemy.currentCharacter.DefaultStats.Name + "  " + enemy.currentCharacter.DefaultStats.Type.Name + "                                                   ");
            //Console.WriteLine("           ---------------                           ---------------                                                    ");
            //Console.WriteLine("          |               |                         |               |                                                   ");
            //Console.WriteLine("          |               |                         |               |                                                   ");
            //Console.WriteLine("          |               |                         |               |                                                   ");
            //Console.WriteLine("           ---------------                           ---------------                                                    ");
            //Console.WriteLine("                  |                                         |                                                           ");
            //Console.WriteLine("                  |                                         |                                                           ");
            //Console.WriteLine("                 ---                                       ---                                                          ");
            //Console.WriteLine("                  |                                         |                                                           ");
            //Console.WriteLine("                  |                                         |                                                           ");
            //Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(0, 14);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("              " + currentCharacter.PV + "                                        " + enemy.Character.PV + "                                                            "); ;
            switch (GameManager.Instance.Input.State)
            {
                case Input.StateFight.firstState:
                    //Console.SetCursorPosition(0, 13);

                    for (int i = 0; i < GameManager.Instance.FightManager.Choix.Length; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (i + 1 == select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("             " + GameManager.Instance.FightManager.Choix[i] + "                                                         ");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.WriteLine("             " + GameManager.Instance.FightManager.Choix[i] + "                                                         ");
                        }

                    }
                    break;

                case Input.StateFight.FightState:

                    for (int i = 0; i < character.Spells.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (i + 1 == select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("             " + character.Spells[i].Name + "                ");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.WriteLine("             " + character.Spells[i].Name + "                ");
                        }

                    }

                    break;

                case Input.StateFight.ObjectState:

                    for (int i = 0; i < player.ListTools.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (i + 1 == select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("             " + player.ListTools[i].Name + "                ");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.WriteLine("             " + player.ListTools[i].Name + "                ");
                        }

                    }

                    break;

                case Input.StateFight.PersoState:

                    for (int i = 0; i < player.ListCharacter.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (i + 1 == select)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("             " + player.ListCharacter[i].DefaultStats.Name + "                ");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.WriteLine("             " + player.ListCharacter[i].DefaultStats.Name + "                ");
                        }

                    }

                    break;
            }

            //for (int i = 0; i < 14; i++)
            //{

            //    for (int j = 0; j < 120; j++)
            //    {
            //        Console.Write(' ');
            //    }
            //Console.WriteLine();
            //}
            Console.SetCursorPosition(0, 0);

        }
    }
}
