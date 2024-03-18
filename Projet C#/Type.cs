using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Type
    {
        string _name;
        string _weakness;

        int _PV;
        int _PT;
        int _attack;
        int _defense;
        int _attackSpeed;
        int _precision;
        public string Name { get { return _name; } }
        public string Weakness { get { return _weakness; } }
        public int PV { get { return _PV; } }
        public int PT { get { return _PT; } }
        public int Attack { get { return _attack; } }
        public int Defense { get { return _defense; } }
        public int AttackSpeed { get { return _attackSpeed; } }
        public int Precision { get { return _precision; } }

        public Type(string name, string weakness, int pV, int pT, int attack, int defense, int attackSpeed, int precision)
        {
            _name = name;
            _weakness = weakness;
            _PV = pV;
            _PT = pT;
            _attack = attack;
            _defense = defense;
            _attackSpeed = attackSpeed;
            _precision = precision;
        }
    }
}
