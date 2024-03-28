using System;
using System.Collections;
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
        float _maxPv;
        float _maxPt;

        List<Spell> _spells = new List<Spell> { };

        public int Level { get => _level; private set => _level = value; }
        public int NeedXP { get => _needXP; private set => _needXP = value; }

        public List<Spell> Spells { get => _spells; private set => _spells = value; }
        public CharacterStats DefaultStats { get => _defaultStats; set => _defaultStats = value; }
        public float MaxPv { get => _maxPv; set => _maxPv = value; }
        public float MaxPt { get => _maxPt; set => _maxPt = value; }

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

        public Character(CharacterData data)
        {
            DefaultStats = GameManager.Instance.CharacterStats[data.Name];
            Level = data.Level;
            NeedXP = data.NeedXP;
            Spells = new List<Spell>();
            foreach (var spell in data.Spells)
            {
                var attack = new Spell(spell);
            }

            StatsLevel();
        }

        public void GainExperience(int experience)
        {
            _needXP -= experience;
            while (_needXP < 0)
            {
                Level += 1;
                NeedXP += 100 * _level;
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
            
            PV = (float)Math.Round(DefaultStats.PV + 5 * Level);
            PT = (float)Math.Round(DefaultStats.PT + 5 * Level);
            Attack = (float)Math.Round(DefaultStats.Attack * (1.0f + (0.01f * Level - 0.01f)));
            AttackSpeed = DefaultStats.AttackSpeed + 5   * Level;
            Defense = DefaultStats.Defense + 5 * Level;
            Precision = DefaultStats.Precision + 5 * Level;
            MaxPv = PV;
            MaxPt = PT;
        }

        public void TakeDamage(float damage)
        {
            OnDamage?.Invoke();

            PV -= damage;
            if (PV < 0)
            {
                OnDeath?.Invoke();
                PV = 0;

            }
        }

        public float SpellAttack(int spell)
        {
            onAttack?.Invoke();
            float damage = _spells[spell].AttackRation * Attack;
            if (_spells[spell].Type == DefaultStats.Type.Weakness)
            {
                damage *= 2;
            }
            else if (_spells[spell].Type.Weakness == DefaultStats.Type)
            {
                damage *= 0.5f;
            }
            return (float)Math.Round(damage);
        }

        public void ItemSet(float boostPv, float boostPt, float boostAttack)
        {

            PV += boostPv * MaxPv;
            PT += boostPt * MaxPt;
            if(PV>MaxPv)
            {
                PV = MaxPv;
            }
            if( PT>MaxPt)
            {
                PT = MaxPt;
            }
            Attack *= boostAttack ;
        }

        public void ItemDelete(float boostPv, float boostPt, float boostAttack)
        {
            PV /= boostPv;
            PT /= boostPt;
            Attack /= boostAttack;
        }
    }
}