using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class ObjectQuest : Object
    {
        public ObjectQuest(string name, string desc, int turn) : base(name, desc, turn)
        {
            
        }

        public override bool Use(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
