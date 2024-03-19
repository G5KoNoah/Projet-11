
using Projet_C_;
using System.Numerics;

Map test = new Map();
Draw draw = new Draw();
Player player = new Player();
var map = draw.FileToText("..\\..\\..\\map1.txt");

Input input = new Input();
player.Move += test.TranslateMap(map, player);
while (true)
{
    
    
    //input.InputTest(player);  
}


 