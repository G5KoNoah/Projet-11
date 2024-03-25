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
        public void Pause( int select)
        {


            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("                                                                                                                        ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                 ONE PIECE                                                                              ") ;
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("                                                                                                                        ");


            switch (select)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("             Explore                                                                                                    ");
                    Console.WriteLine("                                                                                                                        ");
                    Console.WriteLine("                                                                                                                        ");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("             Quit                                                                                                       ");
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("             Explore                                                                                             ");
                    Console.WriteLine("                                                                                                                        ");
                    Console.WriteLine("                                                                                                                        ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("             Quit                                                                                                ");
                    break;



            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 120; j++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 0);

        }
        public void Fight(Player player, Enemy enemy, int select)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("              " + player.ListCharacter["Luffy"].DefaultStats.Name + "  "+ player.ListCharacter["Luffy"].DefaultStats.Type.Name + "                              " + enemy.Character.DefaultStats.Name + "  " + enemy.Character.DefaultStats.Type.Name + "                                                   ");
            Console.WriteLine("           ---------------                           ---------------                                                    ");
            Console.WriteLine("          |               |                         |               |                                                   ");
            Console.WriteLine("          |               |                         |               |                                                   ");
            Console.WriteLine("          |               |                         |               |                                                   ");
            Console.WriteLine("           ---------------                           ---------------                                                    ");
            Console.WriteLine("                  |                                         |                                                           ");
            Console.WriteLine("                  |                                         |                                                           ");
            Console.WriteLine("                 ---                                       ---                                                          ");
            Console.WriteLine("                  |                                         |                                                           ");
            Console.WriteLine("                  |                                         |                                                           ");
            Console.WriteLine("              " + player.ListCharacter["Luffy"].PV + "                              " + enemy.Character.PV+ "                                                                  ");
            switch (GameManager.Instance.Input.State)
            {
                case Input.StateFight.firstState:
                    switch (select)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("             attaquer                                                                                                   ");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("             fuir                                                                                                      ");
                            Console.WriteLine("             objet                                                                                                      ");
                            Console.WriteLine("             personnage                                                                                                 ");
                            break;

                        case 2:
                            Console.WriteLine("             attaquer");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("             fuir");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("             objet");
                            Console.WriteLine("             personnage");
                            break;


                        case 3:
                            Console.WriteLine("             attaquer");
                            Console.WriteLine("             fuir");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("             objet");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("             personnage");
                            break;

                        case 4:
                            Console.WriteLine("             attaquer");
                            Console.WriteLine("             fuir");
                            Console.WriteLine("             objet");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("             personnage");
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                    }

                    break;

                case Input.StateFight.FightState:

                    switch (select)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("             " + player.ListCharacter["Luffy"].Spells[0].Name);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("             spell 2");
                            Console.WriteLine("             spell 3");
                            break;
                        case 2:

                            Console.WriteLine("             " + player.ListCharacter["Luffy"].Spells[0].Name);
                            Console.ForegroundColor = ConsoleColor.Green;                           
                            Console.WriteLine("             spell 2");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("             spell 3");
                            break;
                        case 3:
                            Console.WriteLine("             " + player.ListCharacter["Luffy"].Spells[0].Name);
                            Console.WriteLine("             spell 2");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("             spell 3");
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                    }
                                      
                    break;
            }

                for (int i = 0; i < 14; i++)
                {

                    for (int j = 0; j < 120; j++)
                    {
                        Console.Write(' ');
                    }
                Console.WriteLine();
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
                        case '&':
                            Console.BackgroundColor= ConsoleColor.Black;
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
