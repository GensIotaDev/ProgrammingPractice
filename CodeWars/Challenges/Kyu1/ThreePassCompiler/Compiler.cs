using System.Text.RegularExpressions;

namespace Challenges.Kyu1.ThreePassCompiler;

public class Compiler
{
    private static readonly Dictionary<string, int> OperatorPrecedence = new()
    {
        { "*" , 3 },
        { "/" , 3 },
        { "+" , 2 },
        { "-" , 2 },
        { "(" , 1 }
    };


    public Ast pass1(string prog)
    {
        var tokens = tokenize(prog);
        var args = new Dictionary<string, int>();
        
        var values = new Queue<Ast>();
        
        var parenthesis = new Stack<(int op,int val)>();
        var operators = new List<string>();
        var operands = new List<Ast>();
        
        var captureArgs = false;
        for(var i = 0; i < tokens.Count; i++)
        {
            var token = tokens[i];
            switch (token)
            {
                case "[" or "]":
                    captureArgs = !captureArgs;
                    break;
                case var _ when captureArgs:
                    args.Add(token, args.Count);
                    break;
                case "(":
                    parenthesis.Push((operators.Count, operands.Count));
                    break;
                case ")":
                {
                    var (opStart, valStart) = parenthesis.Pop();
                    var length = operands.Count - opStart;
                    for (var offset = 0; offset < length; offset++)
                    {
                        operands[valStart] = new BinOp(operators[opStart], operands[valStart], operands[valStart + offset]);
                    }
                } break;
                case "*" or "/" or "+" or "-":
                {
                    if (operators.Count > 0 && OperatorPrecedence[operators[^1]] >= OperatorPrecedence[token])
                    {
                        operands[^2] = new BinOp(operators[^1], operands[^2], operands[^1]);
                        operators[^1] = token;
                        operands.RemoveAt(operands.Count - 1);
                    }
                    else operators.Add(token);
                } break;
                case var _ when int.TryParse(token, out var value):
                    operands.Add(new UnOp("imm", value));
                    break;
                case var _ when args.TryGetValue(token, out var value):
                    operands.Add(new UnOp("arg", value));
                    break;
            }
        }

        return operands[0];
    }
    public Ast pass11(string prog)
    {
        List<string> tokens=tokenize(prog);
        var arguments = new Dictionary<string, int>();
        var values = new Stack<Ast>();
        var ops = new Stack<string>();
        
        var isArgument = false;
        foreach (var token in tokens)
        {
            if (isArgument)
            {
                if (token == "]") isArgument = false;
                else
                {
                    arguments.Add(token, arguments.Count);
                }
                continue;
            }

            switch (token)
            {
                case "[":
                    isArgument = true;
                    break;
                case "(":
                    ops.Push(token);
                    break;
                case "*":
                case "/":
                case "+":
                case "-":
                    if (ops.Count > 0 && ops.Peek() != "(" && OperatorPrecedence[ops.Peek()] > OperatorPrecedence[token])
                    {
                        values.Push(new BinOp(ops.Pop(), b:values.Pop(), a:values.Pop()));                        
                    }
                    ops.Push(token);
                    break;
                case ")":
                    while (ops.TryPop(out var op) && op != "(")
                    {
                        values.Push(new BinOp(op, b: values.Pop(), a:values.Pop()));
                    }
                    break;
                case var cmd when arguments.TryGetValue(cmd, out var argId):
                    values.Push(new UnOp("arg", argId));
                    break;
                case var cmd when int.TryParse(cmd, out var value):
                    values.Push(new UnOp("imm", value));
                    break;
            }
        }

        while (ops.TryPop(out var op))
        {
            values.Push(new BinOp(op, b: values.Pop(), a:values.Pop()));
        }
        
        return values.Pop();
    }

    public Ast pass2(Ast ast)
    {
        if (ast is UnOp) return ast;
        var bin = (BinOp)ast;

        var a = pass2(bin.a());
        var b = pass2(bin.b());

        if (a is UnOp { Op: "imm" } a1 && b is UnOp { Op: "imm" } b2)
        {
            
        }

        throw new NotImplementedException();
    }
    public Ast pass22(Ast ast)
    {
        if (ast is UnOp) return ast;

        var op = (BinOp)ast;

        var a = pass22(op.a());
        var b = pass22(op.b());

        if (a is not UnOp aa || aa.op() is "arg" || b is not UnOp bb || bb.op() is "arg") return new BinOp(op.op(), a, b);

        var n = op.op() switch
        {
            "*" => aa.n() * bb.n(),
            "/" => aa.n() / bb.n(),
            "+" => aa.n() + bb.n(),
            "-" => aa.n() - bb.n(),
            _ => throw new NotImplementedException()
        };

        return new UnOp("imm", n);
    }

    public List<string> pass3(Ast ast, List<string> output = null)
    {
        if (output is null) return pass3(ast, new List<string>());

        switch (ast.op())
        {
            case "imm":
                output.Add($"IM ");
                break;
            case "arg":
                output.Add($"AR ");
                break;
            case "*":
                output.Add("MU");
                break;
            case "/":
                output.Add("DI");
                break;
            case "+":
                output.Add("AD");
                break;
        }

        throw new NotImplementedException();
    }
    
    private List<string> tokenize(string input)
    {
        List<string> tokens = new List<string>();
        Regex rgxMain = new Regex("\\[|\\]|[-+*/=\\(\\)]|[A-Za-z_][A-Za-z0-9_]*|[0-9]*(\\.?[0-9]+)");
        MatchCollection matches = rgxMain.Matches(input);
        foreach (Match m in matches) tokens.Add(m.Groups[0].Value);
        return tokens;
    }
}