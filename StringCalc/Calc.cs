using System;

namespace StringCalc
{
    class Calc
    {
        public double Calculate(string input)
        {
            string output = GetExpression(input);
            double result = Counting(output);
            return result;
        }

        private string GetExpression(string input)
        {
            string output = string.Empty;

            MyStack<char> stack = new MyStack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                    throw new Exception("Ошибка. Недопустимые символы в выражении!");

                if (IsDelimiter(input[i]))
                    continue;

                if (char.IsDigit(input[i]))
                {
                    while (!IsDelimiter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];
                        i++;

                        if (i == input.Length) break;
                    }
                    output += " ";
                    i--;
                }

                if (IsOperator(input[i]))
                {
                    if (input[i] == '(')
                        stack.Push(input[i]);
                    else if (input[i] == ')')
                    {
                        char s = stack.Pop();

                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = stack.Pop();
                        }
                    }
                    else
                    {
                        if (stack.Count > 0)
                            if (GetPriority(input[i]) <= GetPriority(stack.Peek()))
                                output += stack.Pop().ToString() + " ";

                        stack.Push(char.Parse(input[i].ToString()));
                    }
                }
            }

            while (stack.Count > 0)
                output += stack.Pop() + " ";

            return output;
        }

        private double Counting(string input)
        {
            double result = 0;
            MyStack<double> temp = new MyStack<double>();

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!IsDelimiter(input[i]) && !IsOperator(input[i]))
                    {
                        a += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a));
                    i--;
                }
                else if (IsOperator(input[i]))
                {
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i])
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                        case '^':
                            result = double.Parse(Math.Pow(double.Parse(b.ToString()),
                      double.Parse(a.ToString())).ToString()); break;
                    }
                    temp.Push(result);
                }
            }
            return temp.Peek();
        }

        private bool IsDelimiter(char c)
        {
            return " =".IndexOf(c) != -1;
        }

        private bool IsOperator(char c)
        {
            return "+-/*^()".IndexOf(c) != -1;
        }

        private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }

    }
}
