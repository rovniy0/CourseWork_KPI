using System;
using CourseWork.UI;

namespace CourseWork
{
    internal class Start
    {
        public static void Main(string[] args)
        {
        Console.WriteLine("=====================================");
        Console.WriteLine("\t Welcome to the store\t");
        Console.WriteLine("=====================================\n");
        var newController = new MainController();
        newController.RunProgram();
        }
    }
}