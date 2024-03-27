﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_C_
{
    public class Spell
    {
        int _level;
        int _needXP;



        string _name;
        CharacterType _type;

        float _consumedPT;
        float _attackRatio;
        public int Level { get => _level; }
        public int NeedXP { get => _needXP; }
        public float AttackRation { get => _attackRatio; }
        public string Name { get => _name; set => _name = value; }
        public CharacterType Type { get => _type; private set => _type = value; }
        public float ConsumedPT { get => _consumedPT; set => _consumedPT = value; }

        public event Action LevelUpSpell;

        public Spell(int level, string name, float attack, float consumed, CharacterType type)
        {
            _level = level;
            _needXP = 500 * level;
            Name = name;
            Type = type;
            _attackRatio = attack;

            ConsumedPT = consumed;
            StatsLevel();
        }

        public void GainExperience(int experience)
        {
            _needXP -= experience;
            while (_needXP < 0)
            {

                _level += 1;
                _needXP += 500 * _level;
                LevelUpSpell?.Invoke();
                StatsLevel();
            }
        }
        public void StatsLevel()
        {
            _attackRatio *= 1.0f + (0.1f * _level - 0.01f);
        }
    }
}