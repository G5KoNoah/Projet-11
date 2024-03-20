
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

CharacterStats luffyStats = new CharacterStats("Luffy", strengthType, 200, 80, 30, 30, 80, 60);

//Init Character

Character luffy = new Character(luffyStats, 1);

//Init Player

List<Character> characters = new List<Character>();
characters.Add(luffy);

List<Tools> tools = new List<Tools>();

Player player = new Player(characters, tools);
//Console.WriteLine(player.ListCharacter[0].Level);
//Console.WriteLine(player.ListCharacter[0].NeedXP);
//player.ListCharacter[0].GainExperience(150);
//Console.WriteLine(150);
//Console.WriteLine(player.ListCharacter[0].Level);
//Console.WriteLine(player.ListCharacter[0].NeedXP);


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


 