
using Projet_C_;
using System.Diagnostics;
using System.Numerics;



//try
//{
//    //Pass the filepath and filename to the StreamWriter Constructor
//    StreamWriter sw = new StreamWriter("..\\..\\..\\Save.txt");
//    //Write a line of text
//    sw.WriteLine("bonour!!");
//    //Write a second line of text
//    sw.WriteLine("From the StreamWriter class");
//    //Close the file
//    sw.Close();
//}

//catch (Exception e)
//{
//    Console.WriteLine("Exception: " + e.Message);
//}
//finally
//{
//    Console.WriteLine("Executing finally block.");
//}



//String line;
//try
//{
//    //Pass the file path and file name to the StreamReader constructor
//    StreamReader sr = new StreamReader("..\\..\\..\\Save.txt");
//    //Read the first line of text
//    line = sr.ReadLine();
//    Console.WriteLine(line);
//    line = sr.ReadLine();
//    Console.WriteLine(line);

//    sr.Close();
//    //Console.ReadLine();
//}
//catch (Exception e)
//{
//    Console.WriteLine("Exception: " + e.Message);
//}
//finally
//{
//    Console.WriteLine("Executing finally block.");
//}


Console.CursorVisible = false;

GameManager.Instance.MainLoop();


 