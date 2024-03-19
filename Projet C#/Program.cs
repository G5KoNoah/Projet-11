
using Projet_C_;
using System.Diagnostics;
using System.Numerics;

Console.CursorVisible = false;
Map test = new Map();
Player player = new Player();
Draw draw = new Draw(ref test, ref player);
var map = draw.FileToText("..\\..\\..\\map1.txt");
test.MapList = map;
Input input = new Input();
draw.DrawMap();
player.Move += draw.DrawMap;
while (true)
{
    input.InputTest(player);  
}


 