using Labb3Database.AppModels;
using Labb3Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(" Vad vill du se");
                Console.WriteLine(" 1.Alla personal:\n 2.Alla elever:\n 3.Alla elever som går i viss klass:\n 4.Alla betyg som satts senaste månaden:" +
                    " \n 5.Lista med alla kurser och snittbetyg samt högsta och lägsta betyg: \n 6.Lägga till ny elever:\n 7 Lägga till nya personal:");
                int input;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int number))
                    {
                        input = number;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt inmatning");
                    }
                }
                switch (input)
                {
                    case 1:
                        Console.WriteLine(" 1: se alla alla lärare \n 2: se alla anställda ");
                        string val1 = Console.ReadLine();
                        switch (val1)
                        {
                            case "1":
                                App MyApp1 = new App();
                                MyApp1.GetAllEmployees();
                                break;
                            case "2":
                                App MyApp2 = new App();
                                MyApp2.GetAllEmpo();
                                break;
                        }
                        break;
                    case 2:
                        App MyApp3 = new App();
                        MyApp3.GetAllSortByName();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val");
                        break;
                    case 3:
                        App MyApp4 = new App();
                        MyApp4.GetAllClasses();
                        break;
                    case 4:
                        App MyApp5 = new App();
                        MyApp5.GetAllGrades();
                        break;
                    case 5:
                        Console.WriteLine(" 1: Högsta betyget \n 2: Lägsta betyg ");
                        string Snittbetyg = Console.ReadLine();
                        switch(Snittbetyg)
                        {
                            case "1":
                                App MyApp1 = new App();
                                MyApp1.MaxGrades();
                                break;
                            case "2":
                                App Myapp2 = new App();
                                Myapp2.LowestGrades();
                                break;
                        }
                        break;
                    case 6:
                        App MyApp6 = new App();
                        MyApp6.AddNewStudents();
                        break;
                    case 7:
                        App MyApp7 = new App();
                        MyApp7.AddNewEmployees();
                        break;
                }
            }
        }
    }
}