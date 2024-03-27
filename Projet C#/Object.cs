using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public abstract class Object
    {
        string _name;
        int _useTurn;
        Character _character;
        public string Name { get => _name; private set => _name = value; }

        public int UseTurn { get => _useTurn; set => _useTurn = value; }
        public Character ObjectCharacter { get => _character; set => _character = value; }

        public Object(string name, int turn)
        {
            Name = name;
            UseTurn = turn;
        }

        public abstract bool Use(Character character);

        public virtual void DeleteStats()
        {

        }
    }
}
