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
        int _LeftPos;
        int _TopPos;

        public List<Character> ListCharacter { get => _character; }
        public List<Tools> ListTools { get => _tools; }

        public int LeftPos { get => _LeftPos; private set => _LeftPos = value; }
        public int TopPos { get => _TopPos; private set => _TopPos = value; }
        public Player()
        {
            _character = new List<Character> { };
            _tools = new List<Tools> { };
            _LeftPos = 0;
            _TopPos = 0;
        }

        public event Action Move;
        public void MoveLeft(int nb)
        {
            LeftPos += nb;
            Move?.Invoke();
        }
        public void MoveTop(int nb)
        {
            TopPos += nb;
            Move?.Invoke();
        }
    }
}
