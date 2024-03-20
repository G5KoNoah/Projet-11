using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class CharacterType : Stats
    {
        string _name;
        CharacterType _weakness;

        public string Name { get => _name; }
        public CharacterType Weakness { get => _weakness; set => _weakness = value; }


        public CharacterType(string name,float pV, float pT, float attack, float defense, float attackSpeed, float precision)
        {
            _name = name;
            PV = pV;
            PT = pT;
            Attack = attack;
            Defense = defense;
            AttackSpeed = attackSpeed;
            Precision = precision;
        }
    }
}
