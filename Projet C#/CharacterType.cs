using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class CharacterType
    {
        string _name;
        CharacterType _weakness;

        float _PV;
        float _PT;
        float _attack;
        float _defense;
        float _attackSpeed;
        float _precision;
        public string Name { get => _name; }
        public CharacterType Weakness { get => _weakness; set => _weakness = value; }
        public float PV { get => _PV; }
        public float PT { get => _PT; }
        public float Attack { get => _attack; }
        public float Defense { get => _defense; }
        public float AttackSpeed { get => _attackSpeed; }
        public float Precision { get => _precision; }

        public CharacterType(string name,float pV, float pT, float attack, float defense, float attackSpeed, float precision)
        {
            _name = name;
            _PV = pV;
            _PT = pT;
            _attack = attack;
            _defense = defense;
            _attackSpeed = attackSpeed;
            _precision = precision;
        }
    }
}
