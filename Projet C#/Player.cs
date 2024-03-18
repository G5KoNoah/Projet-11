using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    internal class Player
    {
        public Player() { 
            m_lCharacters = new List<Character>();
            m_lTools = new List<Tools>();
        }
        
        public IList<Character> m_lCharacters { get; set; }
        public IList<Tools> m_lTools { get; set; }

    }
}
