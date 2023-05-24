using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskTuwaiq
{
    internal class Program
    {

        static void Main(string[] args)
        {

            int number1;
            int number2;
            string operation;
            string choice;

            Calculator calculator = new Calculator();

            do
            {
                Console.WriteLine("Please Enter First Number");
                number1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please Enter Second Number");
                number2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please Enter Operation [+ , - , * , /]");
                operation = Console.ReadLine();

                switch (operation)
                {
                    case "+":
                        Console.WriteLine("Addition:" + calculator.Add(number1, number2));
                        break;
                    case "-":
                        Console.WriteLine("Subtraction:" + calculator.Subtract(number1, number2));
                        break;
                    case "*":
                        Console.WriteLine("Multiplication:" + calculator.Multiply(number1, number2));
                        break;
                    case "/":
                        Console.WriteLine("Division:" + calculator.Divide(number1, number2));
                        break;
                    default:
                        Console.WriteLine("error input, sorry please try again");
                        break;
                }
                Console.ReadLine();
                Console.Write("Do you want to continue [yes or no]:");
                choice = Console.ReadLine();
            }
            while (choice == "yes" || choice == "Yes");
        }

    }
}
