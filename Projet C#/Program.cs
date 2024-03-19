
using Projet_C_;

Map test = new Map();
Draw draw = new Draw();
var map = draw.FileToText("..\\..\\..\\map1.txt");
draw.DrawMap(map);
Input input = new Input();


while (true)
{
    input.InputTest();  
}


 