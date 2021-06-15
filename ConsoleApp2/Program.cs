using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{


    class Program
    {

        private static int Width;
        private static int Hieght;
        private static int LocationX;
        private static int LocationY;
        private static int count = 0;

        private static ConsoleColor BorderColor;

        public static void Draw()
        {
            string s = " --";
            string space = "";
            string temp = "";
            for (int i = 0; i < Width; i++)
            {
                space += " ";
                s += "-";
            }

            for (int j = 0; j < LocationX; j++)
                temp += " ";

            s += "" + "\n";

            for (int i = 0; i < Hieght; i++)
                s += temp + " |" + space + "|" + "\n";

            s += temp + " ╚";
            for (int i = 0; i < Width; i++)
                s += "-";

            s += "" + "\n";

            Console.ForegroundColor = BorderColor;
            Console.CursorTop = LocationY;
            Console.CursorLeft = LocationX;
            Console.Write(s);
            if (count == 0)
            {

            }
            Console.ResetColor();
        }

        private static void ConsoleRectangle(int width, int hieght, int locationX, int locationY, ConsoleColor borderColor)
        {
            Width = width;
            Hieght = hieght;
            LocationX = locationX;
            LocationY = locationY;
            BorderColor = borderColor;
        }
        static void Main(string[] args)
        {


            {

                Console.SetCursorPosition(30, 10);
                Console.Write("Press Enter for starting ...");
                ConsoleRectangle(73, 22, 20, 4, ConsoleColor.Green);
                Draw();
                Console.SetCursorPosition(30, 10);
                Console.Write("Press Enter for starting ...");
                Console.ReadLine();

                Console.SetCursorPosition(30, 10);
                var rnd = new Random();
                var quit = false;
                var userScore = 0;
                var totalProblems = 0;
                var percentCorrect = 0d;
                Console.SetCursorPosition(30, 10);
                Console.Write("Press Enter for starting ...");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(30, 10);

                Console.Write("Enter count of questions that you are ready to answer ");
                int counter = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Draw();
                Console.BackgroundColor = ConsoleColor.Black;
                for (int i = 0; i < counter; i++)
                {
                    Random rn = new Random();
                    int R, G, B;
                    R = rn.Next(0, 255);
                    G = rn.Next(0, 255);
                    B = rn.Next(0, 255);

                    Console.SetCursorPosition(15, 13);
                    if (i < 0 || i == 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (i < 1 || i == 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (i < 2 || i == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                    else if (i < 3 || i == 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (i < 4 || i == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    var number1 = rnd.Next(1, 100);
                    var number2 = rnd.Next(1, 100);
                    var operation = rnd.Next(1, 5);
                    string operatorString;
                    int answer;
                    totalProblems++;
                    Console.SetCursorPosition(50, 11);
                    Console.WriteLine("Math Example : ");
                    Console.SetCursorPosition(50, 12);
                    Console.WriteLine("-------------");
                    switch (operation)
                    {
                        case 1:
                            answer = number1 + number2;
                            operatorString = "+";
                            break;
                        case 2:
                            answer = number1 - number2;
                            operatorString = "-";
                            break;
                        case 3:
                            answer = number1 * number2;
                            operatorString = "*";
                            break;
                        case 4:
                            answer = number1 / number2;
                            operatorString = "/";
                            break;
                        default:
                            answer = 0;
                            operatorString = "?";
                            break;
                    }
                    Console.SetCursorPosition(50, 13);
                    Console.Write("{0} {1} {2}", number1, operatorString, number2);
                    Console.Write(" = ");
                    var input = Console.ReadLine();
                    int inputAsInt;
                    while (!int.TryParse(input, out inputAsInt))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(35, 15);
                        Console.Write("Answer must be an integer. Try again : ");
                        input = Console.ReadLine();
                        System.Threading.Thread.Sleep(1000);
                        Console.ResetColor();
                        Console.Clear();
                        Console.Clear();
                        Draw();
                    }
                    if (inputAsInt == answer)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.SetCursorPosition(50, 15);
                        Console.WriteLine("Correct!");
                        userScore++;
                        System.Threading.Thread.Sleep(1000);
                        Console.ResetColor();
                        Console.Clear();
                        Draw();
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(38, 15);
                        Console.WriteLine("Sorry, the correct answer was: {0}", answer);
                        System.Threading.Thread.Sleep(1800);
                        Console.ResetColor();
                        Console.Clear();
                        Draw();
                    }
                }
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(22, 12);
                percentCorrect = Math.Round((double)userScore / totalProblems * 100, 2);
                Console.WriteLine("You have answered {0} of {1} questions correctly, " +
                    "for a total of {2}%.", userScore, totalProblems, percentCorrect);

                Console.SetCursorPosition(22, 13);
                Console.Write("Press 'q' to quit");
                if (Console.ReadKey().Key == ConsoleKey.Q) quit = true;

                var letterGrade =
                    percentCorrect < 60 ? "F"
                    : percentCorrect < 67 ? "D"
                    : percentCorrect < 70 ? "D+"
                    : percentCorrect < 73 ? "C-"
                    : percentCorrect < 77 ? "C"
                    : percentCorrect < 80 ? "C+"
                    : percentCorrect < 83 ? "B-"
                    : percentCorrect < 87 ? "B"
                    : percentCorrect < 90 ? "B+"
                    : percentCorrect < 93 ? "A-"
                    : "A";

                Console.SetCursorPosition(22, 14);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Thank you for playing. You've earned   " +
                    "grade  :  {0}", letterGrade);
                Console.SetCursorPosition(22, 18);

            }











        }


    }

}
