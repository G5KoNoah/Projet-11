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

        public void Fight(Player player, Enemy enemy)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("          " + player.ListCharacter[0].DefaultStats.Name + "                    " + enemy.Character.DefaultStats.Name + "          ");
            Console.WriteLine("           ---------------                           ---------------          ");
            Console.WriteLine("          |               |                         |               |         ");
            Console.WriteLine("          |               |                         |               |         ");
            Console.WriteLine("          |               |                         |               |         ");
            Console.WriteLine("           ---------------                           ---------------          ");
            Console.WriteLine("                  |                                         |          ");
            Console.WriteLine("                  |                                         |          ");
            Console.WriteLine("                 ---                                       ---          ");
            Console.WriteLine("                  |                                         |          ");
            Console.WriteLine("                  |                                         |          ");
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
