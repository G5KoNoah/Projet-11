using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Objects 
    {
        string _name;

        public string Name { get => _name; private set => _name = value; }


        public Objects( string name)
        {
            Name = name;

        }

    }
}
