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

        public int BoostPv { get => _boostPv; set => _boostPv = value; }
        public int BoostPt { get => _boostPt; set => _boostPt = value; }
        public int BoostAttack { get => _boostAttack; set => _boostAttack = value; }


        public Food(string name, int turn, int boostPv, int boostPt, int boostAttack) : base(name, turn)
        {
            BoostPv = boostPv;
            BoostPt = boostPt;
            BoostAttack = boostAttack;
        }

        public override void Use(Character character)
        {
            base.Use(character);
            ObjectCharacter.ItemSet(BoostPv, BoostPt, BoostAttack);
        }

        public override void DeleteStats()
        {
            base.DeleteStats();
            ObjectCharacter.ItemDelete(BoostPv, BoostPt, BoostAttack);
        }
    }
}
