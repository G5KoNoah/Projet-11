using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Projet_C_
{
    public class Map
    {
        List<string> _Map;
        List<(int, int)> _Collision;

        public List<string> MapList { get => _Map; set => _Map = value; }
        public List<(int, int)> Collision { get => _Collision; set => _Collision = value; }

        public Map()
        {
            MapList = new List<string>();
            Collision = new List<(int, int)>();
        }

        public void Collisions()
        {
            for (int i = 0; i < MapList.Count; i++)
            {
                for (int j = 0; j < MapList[i].Length; j++)
                {
                    if (MapList[i][j] == '|')
                    {
                        Collision.Add((i, j));
                    }
                }
            }
        }

    }
}
