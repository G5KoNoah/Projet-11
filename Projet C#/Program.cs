
using Projet_C_;

Map test = new Map();
Draw draw = new Draw();
var map = test.fileToText("..\\..\\..\\text.txt");

Input input = new Input();

while (true)
{
    draw.DrawMap(map);
    input.InputTest();  
}


 