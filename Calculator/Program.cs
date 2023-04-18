using System.Drawing;

namespace Calculator
{
    internal class Program
    {
        static double Add(ref double number1, ref double number2)
        {
            return number1 + number2;
        }

        static double subtract(ref double number1, ref double number2)
        {
            return number1 - number2;
        }

        static double multiply(ref double number1, ref double number2)
        {
            return number1 * number2;
        }

        static double divide(ref double number1, ref double number2)
        {
            if (number2 == 0) { throw new Exception("Second number con not be zero!"); }

            return number1 / number2;
        }

        static void Main(string[] args)
        {
            //  Operations
            List<string> operations = new List<string>()
            {
                "Add",
                "Subtract",
                "Multiply",
                "Divide",
            };

            int select = 0;
            dynamic button;
            while (true)
            {
                Console.Clear();

                //  Show menu
                int x = 50;
                int y = 15;
                Console.SetCursorPosition(x, y);
                Console.Write("Please choose operation from menu:");
                x += 5;
                for (int i = 0; i < operations.Count(); i++)
                {
                    y++;
                    Console.SetCursorPosition(x, y);
                    if (select == i) { Console.BackgroundColor = ConsoleColor.DarkGreen; }
                    Console.WriteLine(operations[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.SetCursorPosition(0, 0);

                button = Console.ReadKey(true);
                //  To navigate through in menu
                switch (button.Key)
                {
                    //  Move down
                    case ConsoleKey.DownArrow:
                        if (select <= 2 && select >= 0)
                        {
                            select++;
                        }
                        break;

                    //  Move up
                    case ConsoleKey.UpArrow:
                        if (select <= 3 && select >= 1)
                        {
                            select--;
                        }
                        break;

                    //  Select from menu
                    case ConsoleKey.Enter:
                        double result, number1, number2 = default;

                        //  Input first number
                        Console.Clear();
                        Console.SetCursorPosition(50, 16);
                        Console.Write("Please enter first number: ");
                        number1 = double.Parse(Console.ReadLine());

                        //  Input second number
                        Console.Clear();
                        Console.SetCursorPosition(50, 16);
                        Console.Write("Please enter second number: ");
                        number2 = double.Parse(Console.ReadLine());

                        Console.Clear();
                        Console.SetCursorPosition(50, 16);
                        Console.ForegroundColor = ConsoleColor.Green;
                        switch (select)
                        {
                            case 0:
                                result = Program.Add(ref number1, ref number2);
                                Console.Write($"Result: {result}");
                                break;
                            case 1:
                                result = Program.subtract(ref number1, ref number2);
                                Console.Write($"Result: {result}");
                                break;
                            case 2:
                                result = Program.multiply(ref number1, ref number2);
                                Console.Write($"Result: {result}");
                                break;
                            case 3:
                                result = Program.divide(ref number1, ref number2);
                                Console.Write($"Result: {result}");
                                break;

                            default:
                                break;
                        }
                        Console.SetCursorPosition(0, 0);
                        System.Threading.Thread.Sleep(2000);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}