
using Projet_C_;

Map test = new Map();
Draw draw = new Draw();
var map = test.fileToText("..\\..\\..\\text.txt");
//draw.DrawMap(map);

Input input = new Input();

//Init Type

CharacterType speedType = new CharacterType("speed", 1.0f, 1.0f, 1.0f, 1.0f, 1.2f, 0.8f);
CharacterType rangeType = new CharacterType("range", 0.8f, 1.2f, 0.8f, 0.8f, 0.8f, 1.2f);
CharacterType strengthType = new CharacterType("strength", 1.2f, 0.8f, 1.2f, 1.2f, 1.0f, 1.0f);

speedType.Weakness = rangeType;
rangeType.Weakness = strengthType;
strengthType.Weakness = rangeType;

//Init CharacterStats

CharacterStats luffyStats = new CharacterStats("Luffy", strengthType, 200, 80, 30, 30, 80, 60);

//Init Character

Character luffy = new Character(luffyStats, 1);

//Init Player

List<Character> characters = new List<Character>();
characters.Add(luffy);

List<Tools> tools = new List<Tools>();

Player player = new Player(characters, tools);
Console.WriteLine(player.listCharacter[0].Level);
Console.WriteLine(player.listCharacter[0].NeedXP);
player.listCharacter[0].GainExperience(150);
Console.WriteLine(150);
Console.WriteLine(player.listCharacter[0].Level);
Console.WriteLine(player.listCharacter[0].NeedXP);
while (true)
{
    input.InputTest();  
}


 