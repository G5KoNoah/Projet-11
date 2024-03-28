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
        List<string> _map;
        (int, int) _playerPos;
        List<PNJ> _PNJ;
        List<OBJ> _objects;

        public List<string> MapList { get => _map; set => _map = value; }
        public (int, int) PlayerPos { get => _playerPos; set => _playerPos = value; }
        public List<PNJ> PosPNJ { get => _PNJ; set => _PNJ = value; }
        public List<OBJ> Objects { get => _objects; set => _objects = value; }

        public Map(List<string> mapList, (int, int) playerPos, List<PNJ> PNJ, List<OBJ> objects)
        {
            MapList = mapList;
            PlayerPos = playerPos;
            PosPNJ = PNJ;
            Objects = objects;
        }

    }
}
