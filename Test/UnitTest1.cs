using Projet_C_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Test
{
    
    public class UnitTest1
    {
        [Test]
        [TestCase(101,2)]
        [TestCase(302, 3)]
        [TestCase(750, 4)]

        public void GainXP(int XP, int expect)
        {
            
            Player player;
            CharacterStats stats = new CharacterStats();
            Character character = new Character(stats,1);
            character.GainExperience(XP);
            Assert.That(character.Level, Is.EqualTo(expect));
        }


        [Test]
        [TestCase(10, 15)]
        [TestCase(15, 10)]
        [TestCase(500, 0)]

        public void TakeDamage(int damage, int expect)
        {

            Player player;
            CharacterType type = new CharacterType("oui", 10, 10,   10, 10, 1, 0);
            CharacterStats stats = new CharacterStats("name", type,2,2,  2,2,2,2);
            Character character = new Character(stats, 1);
            character.TakeDamage(damage);
            Assert.That(character.PV, Is.EqualTo(expect));
        }


        [Test]
        [TestCase(10, 25)]
        [TestCase(30, 65)]
        [TestCase(200, 405)]

        public void InitPV(float PV, int expect)
        {

            Player player;
            CharacterType type = new CharacterType("oui", PV, 10, 2, 10, 1, 0);
            CharacterStats stats = new CharacterStats("name", type, 2, 2, 2, 2, 2, 2);
            Character character = new Character(stats, 1);
            
            Assert.That(character.PV, Is.EqualTo(expect));
        }

        [Test]
        [TestCase(10, 1)]
        [TestCase(501, 2)]
        [TestCase(1600, 3)]

        public void WinXPSpell(int XP, int expect)
        {
            Player player;
            CharacterType type = new CharacterType("oui", 1, 10, 2, 10, 1, 0);
            Spell spell = new Spell(1, "attaque de base", 10.0f, 2.0f, type);
            spell.GainExperience(XP);
            Assert.That(spell.Level, Is.EqualTo(expect));
        }


        [Test]
        [TestCase(10,2, 20)]
        [TestCase(30, 5, 150)]
        [TestCase(10, 10, 100)]


        public void InitAttack(float attackType, float attackStat, int expect)
        {
            CharacterType type = new CharacterType("oui", 10, 10, attackType, 10, 1, 0);
            CharacterStats stats = new CharacterStats("name", type, 2, 2, attackStat, 2, 2, 2);
            Assert.That(stats.Attack, Is.EqualTo(expect));
        }
    }
}