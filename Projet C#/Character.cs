using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public struct XP
    {
        public int level;
        public int needXP;
    }
    public class Character
    {
        Type _type;

        string _name;

        XP _XP;

        int _PV;
        int _PT;
        int _attack;
        int _defense;
        int _attackSpeed;
        int _precision;

        public string Name { get { return _name; } }
        public XP experience { get { return _XP; } }
        public int PV { get { return _PV; } }
        public int PT { get { return _PT; } }
        public int Attack { get { return _attack; } }
        public int Defense { get { return _defense; } }
        public int AttackSpeed { get { return _attackSpeed; } }
        public int Precision { get { return _precision; } }
        
        public Type Type { get { return _type; } set { _type = value; } }

        public Character(Type type, string name, XP xP, int pV, int pT, int attack, int defense, int attackSpeed, int precision)
        {
            _type = type;
            _name = name;
            _XP = xP;
            _PV = pV * type.PV;
            _PT = pT * type.PT;
            _attack = attack * type.Attack;
            _defense = defense * type.Defense;
            _attackSpeed = attackSpeed * type.AttackSpeed;
            _precision = precision * type.Precision;
        }
    }
}
