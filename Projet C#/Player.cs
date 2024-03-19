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

        public List<Character> ListCharacter
        { 
            get => _character; 
        }
        public List<Tools> ListTools
        {
            get => _tools;
        }
        public Player(List<Character> listCharacters, List<Tools> listTools)
        {
            _character = listCharacters;
            _tools = listTools;
        }
    }
}
