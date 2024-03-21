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

        public List<string> MapList { get => _map; set => _map = value; }

        public Map()
        {
            MapList = new List<string>();
        }

    }
}
