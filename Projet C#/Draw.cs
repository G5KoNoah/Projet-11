using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Draw
    {
        public void DrawMap(IList<string> lMap)
        {
            foreach (var l in lMap)
            {
                Console.WriteLine(l);
            }
        }
    }
}
