
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

//Init Character

Character luffy = new Character(luffyStats, 1);

//Init Spells

Spell redHawk = new Spell(1, "Red Hawk", 1.5f,50.0f, strengthType, luffy);

luffy.Spells.Add(redHawk);
//Init Player

List<Character> characters = new List<Character>();
characters.Add(luffy);

List<Tools> tools = new List<Tools>();

Player player = new Player(characters, tools);
Console.WriteLine(player.ListCharacter[0].Level);
Console.WriteLine(player.ListCharacter[0].Attack);
Console.WriteLine(player.ListCharacter[0].Spells[0].Level);
Console.WriteLine(player.ListCharacter[0].Spells[0].Attack);
//Console.WriteLine(player.ListCharacter[0].Level);
//Console.WriteLine(player.ListCharacter[0].NeedXP);
player.ListCharacter[0].GainExperience(10000);
Console.WriteLine(player.ListCharacter[0].Spells[0].Attack);
player.ListCharacter[0].Spells[0].GainExperience(10000);
//Console.WriteLine(150);
Console.WriteLine(player.ListCharacter[0].Level);
Console.WriteLine(player.ListCharacter[0].Attack);
//Console.WriteLine(player.ListCharacter[0].NeedXP);
Console.WriteLine(player.ListCharacter[0].Spells[0].Level);
Console.WriteLine(player.ListCharacter[0].Spells[0].Attack);
//Console.WriteLine(player.ListCharacter[0].Spells[0].Level);
Console.CursorVisible = false;
Console.BackgroundColor = ConsoleColor.Blue;
Map test = new Map();
Draw draw = new Draw(test, player);
var map = draw.FileToText("..\\..\\..\\map1.txt");
test.MapList = map;
Input input = new Input();

draw.DrawMap();
player.Move += draw.DrawMap;
while (true)
{
    input.InputTest(player);  
}


 