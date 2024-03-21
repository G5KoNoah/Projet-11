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
            PV = (float)Math.Round(Pv * type.PV);
            PT = (float)Math.Round(Pt * type.PT);
            Attack = (float)Math.Round(attack * type.Attack);
            Defense = (float)Math.Round(defense * type.Defense);
            AttackSpeed = (float)Math.Round(attackSpeed * type.AttackSpeed);
            Precision = (float)Math.Round(precision * type.Precision);
        }
    }
}