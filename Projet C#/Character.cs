using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C_
{
    public class Character : Stats
    {

        CharacterStats _defaultStats;
        int _level;
        int _needXP;

        List<Spell> _spells = new List<Spell> { };

        public int Level { get => _level; }
        public int NeedXP {  get => _needXP; }

        public List<Spell> Spells { get => _spells;  }
        public event Action LevelUp;


        public Character(CharacterStats stats, int level = 1) 
        {
            _defaultStats = stats; 
            _level = level;
            _needXP = 100 * level;

            PV = _defaultStats.PV;
            PT = _defaultStats.PT;
            Attack = _defaultStats.Attack;
            Defense = _defaultStats.Defense;
            AttackSpeed = _defaultStats.AttackSpeed;
            Precision = _defaultStats.Precision;

            StatsLevel();
        }

        public void GainExperience(int experience)
        {
            _needXP -= experience;
            while (_needXP < 0)
            {
                _level += 1;
                _needXP += 100 * _level;
                LevelUp?.Invoke();
                StatsLevel();
                foreach (Spell spell in Spells)
                {
                    spell.StatsLevel();
                }
            }
        }
        public void StatsLevel()
        {
            PV += 5 * _level;
            PT += 5 * _level;
            Attack *=  1.0f + (0.01f* _level - 0.01f);
            AttackSpeed += 5 * _level;
            Defense += 5 * _level;
            Precision += 5 * _level;
        }

    }
}
