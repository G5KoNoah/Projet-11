using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Food : Objects
    {
        int _boostPv;
        int _boostPt;
        int _boostAttack;
        int _useTurn;

        public int BoostPv { get => _boostPv; set => _boostPv = value; }
        public int BoostPt { get => _boostPt; set => _boostPt = value; }
        public int BoostAttack { get => _boostAttack; set => _boostAttack = value; }
        public int UseTurn { get => _useTurn; set => _useTurn = value; }

        public Food(string name, int useTurn,int boostPv, int boostPt, int boostAttack) : base(name)
        {
            UseTurn = useTurn;
            BoostPv = boostPv;
            BoostPt = boostPt;
            BoostAttack = boostAttack;
        }


    }
}
