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

        public List<string> MapList { get => _map; set => _map = value; }
        public (int, int) PlayerPos { get => _playerPos; set => _playerPos = value; }

        public Map(List<string> mapList, (int, int) playerPos)
        {
            MapList = mapList;
            PlayerPos = playerPos;
        }

    }
}
