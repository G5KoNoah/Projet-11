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

        public List<string> MapList { get => _Map; set => _Map = value; }
        public Map()
        {
            _Map = new List<string>();
        }
        

    }
}
