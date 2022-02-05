using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class Calculator
    {
        public double Calc(string inputExpression)
        {
            var postfixRecord = GetExpression(CorrectInputExpression(inputExpression));

            return ResultExpression(postfixRecord);
        }

        private string GetExpression(string inputExpression)
        {
            var outNumbers = "";
            Stack<char> operators = new(); 

            for (var i=0; i < inputExpression.Length; i++)
            {
                if (char.IsDigit(inputExpression[i]))
                {
                    while (!IsDelimiter(inputExpression[i]) && !IsOperators(inputExpression[i]))
                    {
                        outNumbers += inputExpression[i];
                        i++; 
                        if (i == inputExpression.Length) break; 
                    }

                    outNumbers += " "; 
                    i--; 
                }

                if (!IsOperators(inputExpression[i]))
                {
                    continue;
                }

                if (inputExpression[i] == Convert.ToChar("("))
                {
                    operators.Push(inputExpression[i]);
                }
                else if (inputExpression[i] == ')') 
                {
                    var s = operators.Pop();

                    while (s != '(')
                    {
                        outNumbers += s.ToString() + ' ';
                        s = operators.Pop();
                    }
                }
                else
                {
                    if (operators.Count > 0)
                    {
                        if (GetPriority(inputExpression[i]) <= GetPriority(operators.Peek()))
                        {
                            outNumbers += operators.Pop() + " ";
                        }
                    }

                    operators.Push(char.Parse(inputExpression[i].ToString()));
                }
            }

            while (operators.Count > 0)
            {
                outNumbers += operators.Pop() + " ";
            }

            return outNumbers;
        }

        private double ResultExpression(string outExpression)
        {
            double result = 0; 
            var temp = new Stack<double>(); 

            for (var i = 0; i < outExpression.Length; i++) 
            {
                if (char.IsDigit(outExpression[i]))
                {
                    var a = "";

                    while (!IsDelimiter(outExpression[i]) && !IsOperators(outExpression[i])) 
                    {
                        a += outExpression[i]; 
                        i++;

                        if (i == outExpression.Length) break;
                    }
                    temp.Push(double.Parse(a)); 
                    i--;
                }
                else if (IsOperators(outExpression[i])) 
                {
                    var a = temp.Pop();
                    var b = temp.Pop();

                    switch (outExpression[i]) 
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/':
                            if (a == 0)
                            {
                                Errors.ErrorZero();
                                return 0;
                            }

                            result = b / a; break;
                    }
                    temp.Push(result); 
                }
            }
            return temp.Peek(); 
        }

        private static int GetPriority(char symbol)
        {
            return symbol switch
            {
                '+' => 1,
                '-' => 1,
                '/' => 2,
                '*' => 2,
                _ => 0,
            };
        }

        private static bool IsOperators(char symbol)
        {
            return "+-/*()".IndexOf(symbol) != -1;
        }

        private static bool IsDelimiter(char c)
        {
            return " ".IndexOf(c) != -1;
        }

        private string CorrectInputExpression(string inputExpression)
        {
            var i = 0;

            if ("+-".IndexOf(inputExpression[0]) != -1)
            {
                inputExpression = "(0" + inputExpression[..2] + ")" + inputExpression[2..];
            }

            while (i + 1 < inputExpression.Length)
            {
                if ("(".IndexOf(inputExpression[i]) != -1 && "+-".IndexOf(inputExpression[i + 1]) != -1)
                {
                    inputExpression = inputExpression[..(i + 1)] + "(0" + inputExpression.Substring(i + 1, 2) + ")" + inputExpression[(i + 3)..];
                }
                i += 2;
            }

            return inputExpression;
        }
    }
}
