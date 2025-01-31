namespace Challenges.Kyu2.ParsingEvalOfMathExpression;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/564d9ebde30917684f000048">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/564edda7bfe8cf09a60000f1/groups/6133a8052e1c4b0001ba4049">here</see>
/// </summary>
public class Evaluate
{
    private enum Associativity
    {
        Left,
        Right
    }

    private static Dictionary<string, (Type type, int precedence, Associativity associativity)> TokenMap =
        new Dictionary<string, (Type, int, Associativity)>
        {
            { "abs", (typeof(Abs), 7, Associativity.Right) },
            { "acos", (typeof(Acos), 7, Associativity.Right) },
            { "asin", (typeof(Asin), 7, Associativity.Right) },
            { "atan", (typeof(Atan), 7, Associativity.Right) },
            { "cos", (typeof(Cos), 7, Associativity.Right) },
            { "sin", (typeof(Sin), 7, Associativity.Right) },
            { "tan", (typeof(Tan), 7, Associativity.Right) },
            { "sinh", (typeof(Sinh), 7, Associativity.Right) },
            { "cosh", (typeof(Cosh), 7, Associativity.Right) },
            { "tanh", (typeof(Tanh), 7, Associativity.Right) },
            { "sqrt", (typeof(Sqrt), 7, Associativity.Right) },

            { "&", (typeof(Exp), 6, Associativity.Right) },
            { "±", (typeof(UnaryMinus), 5, Associativity.Right) },
            { "*", (typeof(Multiply), 3, Associativity.Left) },
            { "/", (typeof(Divide), 3, Associativity.Left) },
            { "+", (typeof(Addition), 2, Associativity.Left) },
            { "-", (typeof(Subtraction), 2, Associativity.Left) }
        };

    public string eval(string expression)
    {
        string output = string.Empty;

        try
        {
            output = $"{Parse(expression)}";
        }
        catch (Exception e)
        {
            output = $"ERROR:{e.Message}";
        }

        return output;
    }

    private double Parse(string expression)
    {
        expression = expression.ToLower();

        var tokens = Scanner(expression);

        var rpnOrdered = Shunting(tokens);

        return EvaluatePolishOrder(rpnOrdered);
    }

    private LinkedList<object> Scanner(string expression)
    {
        LinkedList<object> tokens = new LinkedList<object>();
        int index = 0;
        while (index < expression.Length)
        {
            char c = expression[index];
            string cStr = c + "";

            if (c == '(' || c == ')')
            {
                tokens.AddLast(new Separator
                {
                    Value = c
                });
                index++;
            }
            else if (TryGetLiteral(expression, index, out double value, out int literalLength))
            {
                tokens.AddLast(new Literal
                {
                    Value = value
                });
                index += literalLength;
            }
            else if (TokenMap.ContainsKey(cStr)) // operators
            {
                if (c == '-' || c == '+')
                {
                    if (tokens.Last is null
                        || tokens.Last.Value is Operator
                        || tokens.Last.Value is Function
                        || (tokens.Last.Value is Separator s1 && s1.Value == '('))
                    {
                        if (c == '+')
                        {
                            throw new Exception("Unary plus (multiple) is not allowed.");
                        }

                        tokens.AddLast(new Function
                        {
                            Value = "±"
                        });
                        index++;
                        continue;
                    }
                }

                tokens.AddLast(new Operator
                {
                    Value = cStr
                });
                index++;
            }
            else if (TryGetFunction(expression, index, out string name))
            {
                tokens.AddLast(new Function
                {
                    Value = name
                });
                index += name.Length;
            }
            else if (c == ' ')
            {
                index++;
                continue;
            }
            else
            {
                throw new Exception($"Error reading {c} at index {index}.");
            }
        }

        return tokens;
    }

    private LinkedList<object> Shunting(LinkedList<object> tokens)
    {
        Stack<object> outputStack = new Stack<object>();
        Stack<object> operatorStack = new Stack<object>();

        LinkedListNode<object> node = tokens.First;
        while (node != null)
        {
            object token = node.Value;
            if (token is Literal)
            {
                outputStack.Push(token);
            }
            else if (token is Function)
            {
                operatorStack.Push(token);
            }
            else if (token is Operator o1)
            {
                var oo1 = TokenMap[o1.Value];
                while (operatorStack.TryPeek(out object result) && !(result is Separator))
                {
                    string key = (result is Operator) ? ((Operator)result).Value : ((Function)result).Value;
                    var oo2 = TokenMap[key];

                    if (oo2.precedence > oo1.precedence ||
                        (oo2.precedence == oo1.precedence && oo1.associativity == Associativity.Left))
                    {
                        outputStack.Push(operatorStack.Pop());
                    }
                    else
                    {
                        break;
                    }
                }

                operatorStack.Push(token);
            }
            else if (token is Separator separator)
            {
                if (separator.Value == '(')
                {
                    operatorStack.Push(token);
                }
                else if (separator.Value == ')')
                {
                    bool foundOpposite = false;
                    while (operatorStack.TryPeek(out object result))
                    {
                        if (result is Separator s)
                        {
                            if (s.Value == '(')
                            {
                                foundOpposite = true;
                                break;
                            }
                        }
                        else
                        {
                            outputStack.Push(operatorStack.Pop());
                        }
                    }

                    if (!foundOpposite)
                    {
                        throw new Exception("Parentesis are mismatched.");
                    }

                    operatorStack.Pop();

                    if (operatorStack.TryPeek(out object result1) && result1 is Function)
                    {
                        outputStack.Push(operatorStack.Pop());
                    }
                }
            }

            node = node.Next;
        }

        while (operatorStack.Count > 0)
        {
            object token = operatorStack.Pop();
            if (token is Separator && ((Separator)token).Value == '(')
            {
                throw new Exception("Parenthesis are mismatched.");
            }

            outputStack.Push(token);
        }

        return new LinkedList<object>(outputStack.Reverse());
    }

    private double EvaluatePolishOrder(LinkedList<object> rpn)
    {
        LinkedListNode<object> node = rpn.First;
        while (node != null)
        {
            var nextNode = node.Next;

            if (node.Value is Literal)
            {
            }
            else if (node.Value is Operator op)
            {
                Literal left = node.Previous?.Previous?.Value as Literal;
                Literal right = node.Previous?.Value as Literal;

                IOperator instance = (IOperator)Activator.CreateInstance(TokenMap[op.Value].type);

                if (instance is Subtraction && left is null)
                {
                    double ans = instance.Apply(0, right.Value);

                    rpn.AddBefore(node.Previous, new Literal
                    {
                        Value = ans
                    });
                }
                else
                {
                    double ans = instance.Apply(left.Value, right.Value);

                    rpn.AddBefore(node.Previous.Previous, new Literal
                    {
                        Value = ans
                    });
                    rpn.Remove(node.Previous.Previous);
                }

                rpn.Remove(node.Previous);
                rpn.Remove(node);
            }
            else if (node.Value is Function func)
            {
                Literal right = node.Previous?.Value as Literal;

                IFunction instance = (IFunction)Activator.CreateInstance(TokenMap[func.Value].type);

                double ans = instance.Apply(right.Value);

                rpn.AddBefore(node.Previous, new Literal
                {
                    Value = ans
                });

                rpn.Remove(node.Previous);
                rpn.Remove(node);
            }

            node = nextNode;
        }

        Literal eval = rpn.First.Value as Literal;
        return eval.Value;
    }

    //Utilities
    private bool TryGetLiteral(string expression, int start, out double value, out int length)
    {
        //precheck
        char c = expression[start++];
        value = 0;
        length = 0;
        if (!('0' <= c && c <= '9')) return false;


        string sNum = new string(new char[] { c });
        bool expExists = false;
        bool decimalExists = false;

        while (start < expression.Length)
        {
            char n = expression[start++];
            if ('0' <= n && n <= '9')
            {
                sNum += n;
            }
            else if (n == '-' && (sNum.Length == 0 || sNum[sNum.Length - 1] == 'e'))
            {
                sNum += n;
            }
            else if (n == '+' && sNum[sNum.Length - 1] == 'e')
            {
                sNum += n;
            }
            else if (n == '.')
            {
                if (decimalExists)
                {
                    throw new Exception("Literal cannot have multple decimals.");
                }
                else if (expExists)
                {
                    throw new Exception("Literal cannot have a decimal after the (e) exponent.");
                }
                else
                {
                    sNum += n;
                    decimalExists = true;
                }
            }
            else if (n == 'e')
            {
                if (expExists)
                {
                    throw new Exception("Literal cannot have multiple (e) exponents.");
                }
                else
                {
                    sNum += n;
                    expExists = true;
                }
            }
            else
            {
                break;
            }
        }

        length = sNum.Length;

        string posSafe = sNum.Replace("+", string.Empty);
        return double.TryParse(posSafe, out value);
    }

    private bool TryGetFunction(string expression, int start, out string value)
    {
        string f = string.Empty;
        while (start < expression.Length)
        {
            char c = expression[start];

            if ('a' <= c && c <= 'z')
            {
                f += c;
            }
            else
            {
                break;
            }

            start++;
        }

        value = f;
        return TokenMap.ContainsKey(f);
    }

    private bool IsOperator(string value)
    {
        return TokenMap.ContainsKey(value);
    }

    private bool IsToken(string expression)
    {
        return TokenMap.ContainsKey(expression);
    }
}