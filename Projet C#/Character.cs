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
        public CharacterStats DefaultStats { get => _defaultStats; set => _defaultStats = value; }

        public event Action LevelUp;
        public event Action OnDamage;
        public event Action OnDeath;
        public event Action onAttack;

        public Character(CharacterStats stats, int level = 1) 
        {
            DefaultStats = stats; 
            _level = level;
            _needXP = 100 * level;

            PV = DefaultStats.PV;
            PT = DefaultStats.PT;
            Attack = DefaultStats.Attack;
            Defense = DefaultStats.Defense;
            AttackSpeed = DefaultStats.AttackSpeed;
            Precision = DefaultStats.Precision;

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
            Attack = (float)Math.Round(Attack * (1.0f + (0.01f* _level - 0.01f)));
            AttackSpeed += 5 * _level;
            Defense += 5 * _level;
            Precision += 5 * _level;
        }
        
        public void TakeDamage(float damage)
        {
            OnDamage?.Invoke();

            PV -= damage;
            if(PV < 0)
            {
                OnDeath?.Invoke();
                PV = 0;

            }
        }

        public float SpellAttack(int spell, CharacterType type)
        {
            onAttack?.Invoke();
            float damage = Spells[spell].AttackRation * Attack;
            if (Spells[spell].Type == type.Weakness)
            {
                damage *= 2;
            }else if(Spells[spell].Type.Weakness == type)
            {
                damage *= 0.5f; 
            }
            return (float)Math.Round(damage);
        }
    }
}
