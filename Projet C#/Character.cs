using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Character
    {

        CharacterStats _defaultStats;
        int _level;
        int _needXP;

        float _PV;
        float _PT;
        float _attack;
        float _defense;
        float _attackSpeed;
        float _precision;

        public int Level { get => _level; }
        public int NeedXP {  get => _needXP; }
        public float PV { get => _PV; }
        public float PT { get => _PT; }
        public float Attack { get => _attack; }
        public float Defense { get => _defense; }
        public float AttackSpeed { get => _attackSpeed; }
        public float Precision { get => _precision; }
        public CharacterStats DefaultStats { get => _defaultStats; set => _defaultStats = value; }

        public event Action LevelUp;


        public Character(CharacterStats stats, int level = 1) 
        {
            DefaultStats = stats; 
            _level = level;
            _needXP = 100 * level;

            _PV = DefaultStats.PV;
            _PT = DefaultStats.PT;
            _attack = DefaultStats.Attack;
            _defense = DefaultStats.Defense;
            _attackSpeed = DefaultStats.AttackSpeed;
            _precision = DefaultStats.Precision;

            StatsLevel();
        }

        public void GainExperience(int experience)
        {
            _needXP -= experience;
            if (_needXP < 0)
            {
                int xp = _needXP;
                _level += 1;
                _needXP += 100 * _level;
                LevelUp?.Invoke();
                StatsLevel();
            }
        }
        public void StatsLevel()
        {
            _PV += 1 * _level;
            _PT += 1 * _level;
            _attack += 1 * _level;
            _attackSpeed += 1 * _level;
            _defense += 1 * _level;
            _precision += 1 * _level;
        }

    }
}
