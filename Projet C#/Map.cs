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
        public void TranslateMap(List<string> lMap)
        {
            foreach (string l in lMap)
            {
                foreach(char m in l)
                {
                    switch (m)
                    {
                        case '_' or '|':
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                        case '.':
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;
                    }
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

    }
}
