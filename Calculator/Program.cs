using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Modern Calculator");
            string status = "on";
            int result;

            while (status == "on")
            {
                Console.Write("Enter a number: ");
                string input1 = Console.ReadLine();
                while (CheckOperand(input1) is not int)
                {
                    Console.WriteLine(CheckOperand(input1));
                    Console.Write("Enter a number: ");
                    input1 = Console.ReadLine();
                }
                int operand1 = (int) CheckOperand(input1);
                Console.Write("Enter an operation (+, -, *, /): ");

                string operation = Console.ReadLine().Trim();
                while (CheckOperation(operation) != 1)
                {
                    Console.WriteLine("Please enter an operator among the above operations");
                    Console.Write("Enter an operation (+, -, *, /): ");
                    operation = Console.ReadLine().Trim();
                }
                Console.Write("Enter a second number: ");
                string  input2 = Console.ReadLine();
                while (CheckOperand(input2) is not int)
                {
                    Console.WriteLine(CheckOperand(input2));
                    Console.Write("Enter a number: ");
                    input2 = Console.ReadLine();
                }
                int operand2 = (int) CheckOperand(input2);
                result=   ModernCalculator.Operation(operand1, operand2, operation);
                
                Console.WriteLine(result);
                status = "off";

            }
           
            
            
        }
        
        static Object CheckOperand (string operand)
        {
            bool result = int.TryParse(operand, out int value);
            if (!result)
            {
                return ("Please enter an integer");
            }

            return value;
        }


        static  int CheckOperation(string operation)
        {
            List<string> operations = new  List <string>{ "+", "-", "*", "/" };
            return operations.Contains(operation) ? 1 : 0;
        }


        
    }
}