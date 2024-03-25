using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Player
    {
        Dictionary<string, Character> _character;
        List<Tools> _tools;
        int _LeftPos;
        int _TopPos;
        int _nbPersoLife;

        public Dictionary<string, Character> ListCharacter { get => _character; }
        public List<Tools> ListTools { get => _tools; }

        public int LeftPos { get => _LeftPos; private set => _LeftPos = value; }
        public int TopPos { get => _TopPos; private set => _TopPos = value; }
        public int NbPersoLife { get => _nbPersoLife; set => _nbPersoLife = value; }

        public Player(Dictionary<string, Character> characters, List<Tools> tools)
        {
            _character = characters;
            _tools = tools;
            _LeftPos = 6;
            _TopPos = 10;
            NbPersoLife = 0;
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
