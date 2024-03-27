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
        List<(int, int)> _posPNJ;
        (int, int) _objectPos;

        public List<string> MapList { get => _map; set => _map = value; }
        public (int, int) PlayerPos { get => _playerPos; set => _playerPos = value; }
        public List<(int, int)> PosPNJ { get => _posPNJ; set => _posPNJ = value; }
        public (int, int) ObjectPos { get => _objectPos; set => _objectPos = value; }

        public Map(List<string> mapList, (int, int) playerPos, List<(int, int)> posPNJ, (int, int) objectPos)
        {
            MapList = mapList;
            PlayerPos = playerPos;
            PosPNJ = posPNJ;
            ObjectPos = objectPos;
        }

    }
}
