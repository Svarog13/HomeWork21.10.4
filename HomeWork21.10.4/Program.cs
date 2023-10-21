using System;
using System.Collections.Generic;

class ArithmeticExpressionCalculator
{
    static void Main()
    {
        Console.Write("Enter an arithmetic expression with + and - operators: ");
        string expression = Console.ReadLine();

        int result = CalculateArithmeticExpression(expression);
        Console.WriteLine("Result: " + result);
    }

    static int CalculateArithmeticExpression(string expression)
    {
        Stack<int> numbers = new Stack<int>();
        Stack<char> operators = new Stack<char>();
        char[] characters = expression.ToCharArray();

        for (int i = 0; i < characters.Length; i++)
        {
            char c = characters[i];

            if (c == ' ')
            {
                continue;
            }
            else if (char.IsDigit(c))
            {
                int number = c - '0';
                while (i + 1 < characters.Length && char.IsDigit(characters[i + 1]))
                {

                    number = number * 10 + (characters[i + 1] - '0');
                    i++;
                }
                numbers.Push(number);
            }
            else if (c == '+' || c == '-')
            {

                while (operators.Count > 0 && (operators.Peek() == '+' || operators.Peek() == '-'))
                {
                    char op = operators.Pop();
                    int number2 = numbers.Pop();
                    int number1 = numbers.Pop();
                    if (op == '+')
                        numbers.Push(number1 + number2);
                    else
                        numbers.Push(number1 - number2);
                }
                operators.Push(c);
            }
        }


        while (operators.Count > 0)
        {
            char op = operators.Pop();
            int number2 = numbers.Pop();
            int number1 = numbers.Pop();
            if (op == '+')
                numbers.Push(number1 + number2);
            else
                numbers.Push(number1 - number2);
        }
        return numbers.Peek();
    }
}