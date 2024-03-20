using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_C_
{
    public class CharacterStats : Stats
    {
        CharacterType _type;
        string _name;

 

        public CharacterStats(string name, CharacterType type, float Pv, float Pt, float attack, float defense, float attackSpeed, float precision)
        {
            _name = name;
            _type = type;
            PV *= Pv * type.PV;
            PT *= Pt * type.PT;
            Attack = attack * type.Attack;
            Defense = defense * type.Defense;
            AttackSpeed = attackSpeed * type.AttackSpeed;
            Precision = precision * type.Precision;
        }
    }
}