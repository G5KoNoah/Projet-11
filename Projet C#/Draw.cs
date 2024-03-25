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
        Map _Map;
        Player _Player;

        

        public Map Map { get => _Map; set => _Map = value; }
        public Player Player { get => _Player; set => _Player = value; }

        public Draw(Map map, Player player)
        {
            _Map = map;
            _Player = player;
            
        }

        public List<string> FileToText(string sFilePath)
        {
            List<string> lFileText = new List<string>();
            StreamReader oFile = new StreamReader(sFilePath);
            string line = oFile.ReadLine();
            if (oFile != null)
            {
                while (line != null)
                {
                    lFileText.Add(line);
                    line = oFile.ReadLine();

                }
                oFile.Close();
            }
            return lFileText;
        }

        public void Fight(Player player, Enemy enemy, int select, Character character)
        {
            GameManager.Instance.Draw.DrawMap();
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("              " + character.DefaultStats.Name + "  "+ character.DefaultStats.Type.Name + "                              " + enemy.Character.DefaultStats.Name + "  " + enemy.Character.DefaultStats.Type.Name + "                                                   ");
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
            Console.SetCursorPosition(0,14);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("              " + character.PV + "                                        " + enemy.Character.PV + "                                                            "); ;
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

                    for (int i = 0; i < player.ListCharacter.Count; i++ )
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        if (i+1 == select)
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

        public void DrawInventory()
        {
            Console.SetCursorPosition(50, 5);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Inventaire");
            Console.SetCursorPosition(0,10);
            Console.BackgroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < GameManager.Instance.Player.ListTools.Count; i++)
            {
                Console.WriteLine(" - " + GameManager.Instance.Player.ListTools[i].Name);
            }
            Console.SetCursorPosition(0, 0);

        }

        public void DrawMap()
        {
            //Console.Clear();
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
                        case '2':
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            //Console.Write('O');
                            break;
                        case '8':
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            //Console.Write('O');
                            break;

                    }
                    if (i == Player.TopPos && j == Player.LeftPos)
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

        
    }
}
