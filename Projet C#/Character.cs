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
        CharacterStats _maxStats;
        int _level;
        int _needXP;
        float _maxPv;
        float _maxPt;

        List<Spell> _spells = new List<Spell> { };

        public int Level { get => _level;  set => _level = value; }
        public int NeedXP { get => _needXP; private set => _needXP = value; }

        public List<Spell> Spells { get => _spells; }
        public CharacterStats DefaultStats { get => _defaultStats; set => _defaultStats = value; }
        public CharacterStats MaxStats { get => _maxStats; set => _maxStats = value; }
        public float MaxPv { get => _maxPv; set => _maxPv = value; }
        public float MaxPt { get => _maxPt; set => _maxPt = value; }

        public event Action LevelUp;
        public event Action OnDamage;
        public event Action OnDeath;
        public event Action onAttack;

        public Character(CharacterStats stats, int level = 1)
        {
            DefaultStats = stats;
            MaxStats = stats;
            _level = level;
            _needXP = 100 * level;

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

        public float TakeDamage(float damage)
        {
            OnDamage?.Invoke();
            float trueDamage = (float)Math.Round(damage * (1 - Defense / 100));
            PV -= trueDamage;
            if (PV < 0)
            {
                OnDeath?.Invoke();
                PV = 0;

            }
            return trueDamage;
        }

        public float SpellAttack(int spell, Character enemy)
        {
            onAttack?.Invoke();
            float damage = Spells[spell].AttackRation * Attack;
            if (Spells[spell].Type == enemy.DefaultStats.Type.Weakness)
            {
                damage *= 2;
            }
            else if (Spells[spell].Type.Weakness == enemy.DefaultStats.Type)
            {
                damage *= 0.5f;
            }
            PT -= Spells[spell].ConsumedPT;
            if (new Random().Next(1, (int)Precision / 10) == 1) damage = 0;
            if (Spells[spell]== Spells.ElementAt(0)) PT += (float)Math.Round( 0.5f * MaxPt);

            if (PT > MaxPt) PT = MaxPt;
            Spells[spell].GainExperience(100);
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