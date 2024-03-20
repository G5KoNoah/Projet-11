using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Tools : Stats
    {
        string _name;
        string _type;

        public string Name { get { return _name; } }
        public string Type { get { return _type; } }


        public Tools( string name, string type, int pV, int pT, int attack, int defense, int attackSpeed, int precision)
        {
            _type = type;
            _name = name;
            PV = pV ;
            PT = pT ;
            Attack = attack;
            Defense = defense;
            AttackSpeed = attackSpeed;
            Precision = precision;
        }
    }
}
