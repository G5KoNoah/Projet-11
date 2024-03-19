
using Projet_C_;

//Console.WriteLine("Hello, World!");

Map test = new Map();
Draw draw = new Draw();
var map = test.fileToText("..\\..\\..\\map1.txt");
draw.DrawMap(map);
Console.WriteLine("Hello, World!");
Input input = new Input();

while (true)
{
    input.InputTest();  
}


 