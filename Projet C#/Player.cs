using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Player
    {
        List<Character> _Character;
        List<Tools> _Tools;

        public List<Character> ListCharacter
        {
            get { return _Character; }
            set { _Character = value; }
        }

        public Character Character
        {
            get { return Character; }
            set { _Character.Add(value); }
        }

        public List<Tools> ListTools
        {
            get { return _Tools; }
            set { _Tools = value; }
        }

        public Tools Tool
        {
            get { return Tool; }
            set { _Tools.Add(value); }
        }
        public Player(List<Character> listCharacters, List<Tools> listTools)
        {
            _Character = listCharacters;
            _Tools = listTools;
        }
    }
}
