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
            _tools = null;
            _LeftPos = 6;
            _TopPos = 10;
        }

        public event Action Move;
        public void MoveLeft(int nb)
        {
            List<string> collisions = GameManager.Instance.ListMap[0].MapList;
            if (collisions[TopPos][LeftPos + nb] != '|') {
                LeftPos += nb;
                Move?.Invoke();
            }
            

        }
        public void MoveTop(int nb)
        {
            List<string> collisions = GameManager.Instance.ListMap[0].MapList;
            if (collisions[TopPos + nb][LeftPos] != '|')
            {
                TopPos += nb;
                Move?.Invoke();
            }
            
        }
    }
}
