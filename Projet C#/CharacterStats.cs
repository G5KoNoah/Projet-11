﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_C_
{
    public struct CharacterStats
    {
        CharacterType _type;
        string _name;

        float _PV;
        float _PT;
        float _attack;
        float _defense;
        float _attackSpeed;
        float _precision;

        public float PV { get => _PV; set => _PV = value; }
        public float PT { get => _PT; set => _PT = value; }  
        public float Attack { get => _attack; }
        public float Defense { get => _defense; }
        public float AttackSpeed { get => _attackSpeed; }
        public float Precision { get => _precision;}
        public string Name { get => _name; set => _name = value; }
        public CharacterType Type { get => _type; set => _type = value; }

        public CharacterStats(string name, CharacterType type, float PV, float PT, float attack, float defense, float attackSpeed, float precision)
        {
            _name = name;
            _type = type;
            _PV = PV * type.PV;
            _PT = PT * type.PT;
            _attack = attack * type.Attack;
            _defense = defense * type.Defense;
            _attackSpeed = attackSpeed * type.AttackSpeed;
            _precision = precision * type.Precision;
        }
    }
}