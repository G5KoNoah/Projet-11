using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Player
    {
        List<Character> _character;
        List<Tools> _tools;

        public List<Character> listCharacter
        {
            get { return _character; }
            set { _character = value; }
        }

        public Character character
        {
            get { return character; }
            set { _character.Add(value); }
        }

        public List<Tools> listTools
        {
            get { return _tools; }
            set { _tools = value; }
        }

        public Tools tool
        {
            get { return tool; }
            set { _tools.Add(value); }
        }
        public Player(List<Character> listCharacters, List<Tools> listTools)
        {
            _character = listCharacters;
            _tools = listTools;
        }
    }
}
