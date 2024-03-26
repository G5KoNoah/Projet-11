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
        int _useTurn;
        Character _character;
        public string Name { get => _name; private set => _name = value; }

        public int UseTurn { get => _useTurn; set => _useTurn = value; }
        public Character ObjectCharacter { get => _character; set => _character = value; }

        public Objects( string name,int turn)
        {
            Name = name;
            UseTurn = turn;
        }

        public virtual void Use(Character character)
        {
            ObjectCharacter = character;
        }

        public virtual void DeleteStats()
        {

        }
    }
}
