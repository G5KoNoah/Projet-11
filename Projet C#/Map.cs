using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Map
    {
        List<string> _Map;
        public Map()
        {
            _Map = new List<string>();
        }
        public void TranslateMap(List<string> lMap, Player player)
        {
            Console.Clear();
            for (int i = 0; i < lMap.Count; i++)
            {
                for(int j = 0; j < lMap[i].Length; j++)
                {
                    switch (lMap[i][j])
                    {
                        case '_' or '|':
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                        case '.':
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;
                    }
                    if(i == player.TopPos && j == player.LeftPos)
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
        }

    }
}
