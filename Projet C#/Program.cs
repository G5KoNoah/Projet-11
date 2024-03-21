
using Projet_C_;
using System.Diagnostics;
using System.Numerics;



//Init Type

CharacterType speedType = new CharacterType("speed", 1.0f, 1.0f, 1.0f, 1.0f, 1.2f, 0.8f);
CharacterType rangeType = new CharacterType("range", 0.8f, 1.2f, 0.8f, 0.8f, 0.8f, 1.2f);
CharacterType strengthType = new CharacterType("strength", 1.2f, 0.8f, 1.2f, 1.2f, 1.0f, 1.0f);

speedType.Weakness = rangeType;
rangeType.Weakness = strengthType;
strengthType.Weakness = speedType;

//Init CharacterStats

CharacterStats luffyStats = new CharacterStats("Luffy", strengthType, 200.0f, 80.0f, 30.0f, 30.0f, 80.0f, 60.0f);
CharacterStats crocoStats = new CharacterStats("Croco", rangeType, 200.0f, 80.0f, 30.0f, 30.0f, 80.0f, 60.0f);
//Init Character

Character luffy = new Character(luffyStats, 1);
Character croco = new Character(crocoStats, 1);
//Init Spells

Spell redHawk = new Spell(1, "Red Hawk", 1.5f,50.0f, strengthType);

luffy.Spells.Add(redHawk);
//Init Player

List<Character> characters = new List<Character>();
characters.Add(luffy);

List<Tools> tools = new List<Tools>();

Player player = new Player(characters, tools);

Console.CursorVisible = false;

//draw.DrawMap();
player.Move += draw.DrawMap;
luffy.onAttack += attack;
croco.OnDeath += died;
croco.OnDamage += damage;




while (true)
{
    //input.InputTest(player);
    while (croco.PV > 0)
    {
        Console.WriteLine(croco.PV);
        croco.TakeDamage(luffy.SpellAttack(0));
    }

}

void attack()
{
    Console.WriteLine("Attack");
}

void died()
{
    Console.WriteLine("mort");
    Console.WriteLine(luffy.SpellAttack(0));
    luffy.GainExperience(2000);
    Console.WriteLine(luffy.Level);
    Console.WriteLine(luffy.SpellAttack(0));
}

void damage()
{
    Console.WriteLine("damage");
}
