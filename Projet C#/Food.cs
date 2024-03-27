using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Food : Object
    {
        float _boostPv;
        float _boostPt;
        float _boostAttack;

        public float BoostPv { get => _boostPv; set => _boostPv = value; }
        public float BoostPt { get => _boostPt; set => _boostPt = value; }
        public float BoostAttack { get => _boostAttack; set => _boostAttack = value; }


        public Food(string name, string desc, int turn, float boostPv, float boostPt, float boostAttack) : base(name, desc, turn)
        {
            BoostPv = boostPv;
            BoostPt = boostPt;
            BoostAttack = boostAttack;
        }

        public override bool Use(Character character)
        {
            ObjectCharacter = character;
            if(BoostPv > 0)
            {
                if(character.MaxPv != character.PV)
                {
                    ObjectCharacter.ItemSet(BoostPv, BoostPt, BoostAttack);
                    return true;
                }
                return false;
            }else if(BoostPt > 0)
            {
                if (character.MaxPt != character.PT)
                {
                    ObjectCharacter.ItemSet(BoostPv, BoostPt, BoostAttack);
                    return true;
                }
                return false;
            }
            else
            {
                ObjectCharacter.ItemSet(BoostPv, BoostPt, BoostAttack);
                return true;
            }
            
        }

        public override void DeleteStats()
        {
            base.DeleteStats();
            ObjectCharacter.ItemDelete(BoostPv, BoostPt, BoostAttack);
        }
    }
}
