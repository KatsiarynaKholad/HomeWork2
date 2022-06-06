using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();
            Console.WriteLine("Do you want continue? Y/N");
            var isContinue = Console.ReadLine().ToUpperInvariant();
            if (isContinue == "Y")
            {
                PrintMenu();
            }
            else if (isContinue == "N")
            {
                Console.WriteLine("Bye");
            }
        }
        static void PrintMenu()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1 -  X + Y");
            Console.WriteLine("2 -  X - Y");
            Console.WriteLine("3 -  X * Y");
            Console.WriteLine("4 -  X / Y");
            Console.WriteLine("5 -  X ^ Y");
            Console.WriteLine("6 -  Factorial ");
            Console.WriteLine("0 -  Exit ");

            if (int.TryParse(Console.ReadLine(), out var opt))
            {
                if (opt == 0)
                {
                    return;
                }
                else if (opt < 7 && opt > 0)
                {
                    SelectedBlock(opt);
                }
                else
                {
                    InputError();
                }
            }
            else
            {
                InputError();
            }
        }
        static void SelectedBlock(int a)
        {
            Console.WriteLine("Do you want enter a number? Y - yes / N - no, I want random numbers");
            var isChoice = Console.ReadLine().ToUpperInvariant();
            double result;
            if (a == 6)
            {
                if (isChoice == "Y")
                {
                    Console.WriteLine("Please enter number:");
                    var isNumber = double.TryParse(Console.ReadLine(), out var number);
                    if (number <= 170)
                    {
                        if (isNumber)
                        {
                            Options(a, number, 0);
                        }
                        else
                        {
                            InputError();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You enter a large number, it could lead to a stack overflow!");
                        SelectedBlock(a);
                    }

                }
                else if (isChoice == "N")
                {
                    Random random = new Random();
                    double number = random.Next(1, 170);
                    Console.WriteLine($"Number = {number}");
                    Options(a, number, 0);
                }
            }
            if (a == 5)
            {
                if (isChoice == "Y")
                {
                    Console.WriteLine("Please enter first number:");
                    var isFirstNumber = double.TryParse(Console.ReadLine(), out var firstNumber);
                    Console.WriteLine("Please enter second number:");
                    var isSecondNumber = double.TryParse(Console.ReadLine(), out var secondNumber);


                    if (firstNumber <= 140 && secondNumber <= 140)
                    {
                        if (isFirstNumber && isSecondNumber)
                        {
                            Options(a, firstNumber, secondNumber);
                        }
                        else
                        {
                            InputError();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You enter a large number, it could lead to a stack overflow!");
                        SelectedBlock(a);
                    }

                }
                else if (isChoice == "N")
                {
                    Random random = new Random();
                    double firstNumber = random.Next(1, 140);
                    double secondNumber = random.Next(1, 140);
                    Console.WriteLine($"firstNumber = {firstNumber}, secondNumber = {secondNumber}");
                    Options(a, firstNumber, secondNumber);
                }

            }
            else if (isChoice == "Y")
            {
                Console.WriteLine("Please enter first number:");
                var isFirstNumber = double.TryParse(Console.ReadLine(), out var firstNumber);
                Console.WriteLine("Please enter second number:");
                var isSecondNumber = double.TryParse(Console.ReadLine(), out var secondNumber);

                if (firstNumber < 1000 && secondNumber < 1000)
                {
                    if (isFirstNumber && isSecondNumber)
                    {
                        Options(a, firstNumber, secondNumber);
                    }
                    else
                    {
                        InputError();
                    }
                }
                else
                {
                    Console.WriteLine("You enter a large number, it could lead to a stack overflow!");
                    SelectedBlock(a);
                }
            }
            else if (isChoice == "N")
            {
                Random random = new Random();
                double firstNumber = random.Next(1, 1000);
                double secondNumber = random.Next(1, 1000);
                Console.WriteLine($"firstNumber = {firstNumber}, secondNumber = {secondNumber}");
                Options(a, firstNumber, secondNumber);
            }
            else
            {
                InputError();
            }
        }
        static void InputError()
        {
            Console.WriteLine("Incorrect input");
            PrintMenu();
        }
        static double DoAddition(double firstNumber, double secondNumber)
        {
            Console.WriteLine($"{firstNumber} + {secondNumber}");
            var result = firstNumber + secondNumber;
            return result;
        }
        static double DoSubtraction(double firstNumber, double secondNumber)
        {
            Console.WriteLine($"{firstNumber} - {secondNumber}");
            var result = firstNumber - secondNumber;
            return result;
        }

        static double DoMultiplication(double firstNumber, double secondNumber)
        {
            Console.WriteLine($"{firstNumber} * {secondNumber}");
            double result = firstNumber * secondNumber;
            return result;
        }

        static double MakeDivision(double firstNumber, double secondNumber)
        {
            if (secondNumber == 0)
            {
                InputError();
            }
            else
            {
                Console.WriteLine($"{firstNumber} / {secondNumber}");
                double result = firstNumber / secondNumber;
                return result;
            }
            return 0;
        }
        static double DoExponentiation(double firstNumber, double secondNumber)
        {
            Console.WriteLine($"{firstNumber} ^ {secondNumber}");
            double result = 1;
            for (int i = 1; i < secondNumber; i++)
            {
                result = result * firstNumber;
            }
            return result;
        }
        static double Factorial(double n)
        {
            if (n == 1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

        static void Print(double a)
        {
            Console.WriteLine($"result = {a}");
            Console.ReadLine();
            PrintMenu();
        }
        static void Options(int opt, double firstNumber, double secondNumber)
        {
            switch (opt)
            {
                case 1:
                    var result = DoAddition(firstNumber, secondNumber);
                    Print(result);
                    break;
                case 2:
                    result = DoSubtraction(firstNumber, secondNumber);
                    Print(result);
                    break;
                case 3:
                    result = DoMultiplication(firstNumber, secondNumber);
                    Print(result);
                    break;
                case 4:
                    result = MakeDivision(firstNumber, secondNumber);
                    Print(result);
                    break;
                case 5:
                    result = DoExponentiation(firstNumber, secondNumber);
                    Print(result);
                    break;
                case 6:
                    result = Factorial(firstNumber);
                    Print(result);
                    break;
                default:
                    InputError();
                    break;
            }
        }
    }
}