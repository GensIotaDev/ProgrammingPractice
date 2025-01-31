using System.Text;

namespace Challenges.Kyu2.AssemblerInterpreterPart2;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/58e61f3d8ff24f774400002c">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5b3b94985da8ad26e5000138/groups/64f102f9fedaec00016e1777">here</see>
/// </summary>
public class AssemblerInterpreter
{
    [Flags]
    private enum EInstruction
    {
        None = 1,
        Single = 1 << 1,
        Binary = 1 << 2,
        
        Ret = 1 << 3 | None,
        End = 1 << 4 | None,
        Msg = 1 << 5 | Single,
        Mov = 1 << 6 | Binary,
        Cmp = 1 << 7 | Binary,
        
        Inc = 1 << 8 | Single,
        Dec = 1 << 9 | Single,
        
        Add = 1 << 8 | Binary,
        Sub = 1 << 9 | Binary,
        Mul = 1 << 10 | Binary,
        Div = 1 << 11 | Binary,
        
        Jmp = 1 << 12 | Single,
        Je = 1 << 13 | Jmp,
        Jne = Je | Dec,
        Jg = 1 << 14 | Jmp,
        Jge = Jg | Dec,
        Jl = 1 << 15 | Jmp | Single,
        Jle = Jl | Dec,
        Call = 1 << 16 | Jmp
    }
    
    public static string Interpret(string input)
    {
        var rawCmd = Parse(input);
        var program = Build(rawCmd);

        return Execute(program);
    }

    private static IEnumerable<object[]> Parse(string input)
    {
        var endCaps = new[] { ' ', ',', ':', '\n' };
        var parts = new List<object>();
        
        for (var i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case ';':
                case ':':
                {
                    i = input.IndexOf('\n', i);
                } break;
                case '\'':
                {
                    i++;
                    var value = Extract(ref i, '\'');
                    TryAddPart(value);
                } break;
                case '-':
                case >= '0' and <= '9':
                {
                    var str = Extract(ref i, endCaps);
                    var value = int.Parse(str);
                    
                    TryAddPart(value);
                } break;
                case >= 'a' and <= 'z':
                {
                    var value = Extract(ref i, endCaps);

                    if(value.Length == 1) TryAddPart((char)(value[0] - 'a'));
                    else switch (parts.Count)
                    {
                        case 0 when Enum.TryParse<EInstruction>(PromoteFirstChar(value), out var cmd):
                            parts.Add(cmd);
                            break;
                        case 0:
                            parts.Add(value);
                            break;
                        default:
                            TryAddPart(value);
                            break;
                    }
                } break;
            }

            if (i == input.Length || input[i] == '\n')
            {
                if (parts.Count == 0) continue;

                yield return parts.ToArray();
                parts.Clear();
            }
        }

        yield break;

        string Extract(ref int start, params char[] anyOf)
        {
            var end = input.IndexOfAny(anyOf, start);
            var nStart = start;

            if (end == -1)
            {
                start = input.Length;
                return input[nStart..];
            }

            start = end;
            return input[nStart..end];
        }

        void TryAddPart(object part)
        {   
            var type = (EInstruction)parts[0];
            if (type != EInstruction.Msg &&
                ((type.HasFlag(EInstruction.None) && parts.Count > 1) ||
                (type.HasFlag(EInstruction.Single) && parts.Count > 2) ||
                (type.HasFlag(EInstruction.Binary) && parts.Count > 3)))
            {
                throw new ArgumentException($"{type} has too many arguments");
            }
            
            parts.Add(part);
        }

        string PromoteFirstChar(string value)
        {
            var v = value.ToCharArray();
            v[0] = char.ToUpper(v[0]);
            return new string(v);
        }
    }

    private static object[][] Build(IEnumerable<object[]> commands)
    {
        var program = new List<object[]>();
        var labelPositions = new Dictionary<string, int>();
        var linker = new Queue<int>();
        
        var lineId = 0;
        foreach (var statement in commands)
        {
            switch (statement[0])
            {
                case string label:
                    labelPositions[label] = lineId;
                    continue;
                case EInstruction type when type.HasFlag(EInstruction.Jmp):
                    linker.Enqueue(lineId);
                    break;
                case EInstruction.Msg:
                    for (var i = 1; i < statement.Length; i++)
                    {
                        program.Add(new [] {statement[0], statement[i] });
                        lineId++;
                    }
                    continue;
            }
            
            program.Add(statement);
            lineId++;
        }

        while (linker.TryDequeue(out var instructionId))
        {
            var instruction = program[instructionId];
            instruction[1] = labelPositions[(string)instruction[1]];
        }
        
        return program.ToArray();
    }

    private static string Execute(object[][] program)
    {
        var output = new StringBuilder();
        var registry = new int[27];
        var stack = new Stack<int>();

        var i = 0;
        while (i < program.Length)
        {
            var statement = program[i];
            switch (statement[0])
            {
                case EInstruction.Inc when statement[1] is char reg:
                    registry[reg]++;
                    break;
                case EInstruction.Dec when statement[1] is char reg:
                    registry[reg]--;
                    break;
                case EInstruction.Msg when statement[1] is var msg:
                    output.Append(msg is string ? msg : ResolveValue(msg));
                    break;
                case EInstruction.Mov when statement[1] is char reg && statement[2] is var value:
                    registry[reg] = ResolveValue(value);
                    break;
                case EInstruction.Add when statement[1] is char reg && statement[2] is var value:
                    registry[reg] += ResolveValue(value);
                    break;
                case EInstruction.Sub when statement[1] is char reg && statement[2] is var value:
                    registry[reg] -= ResolveValue(value);
                    break;
                case EInstruction.Mul when statement[1] is char reg && statement[2] is var value:
                    registry[reg] *= ResolveValue(value);
                    break;
                case EInstruction.Div when statement[1] is char reg && statement[2] is var value:
                    registry[reg] /= ResolveValue(value);
                    break;
                case EInstruction.Cmp when statement[1] is var left && statement[2] is var right:
                    registry[^1] = ResolveValue(left) - ResolveValue(right);
                    break;
                case EInstruction.Jmp:
                case EInstruction.Je when registry[^1] == 0:
                case EInstruction.Jne when registry[^1] != 0:
                case EInstruction.Jg when registry[^1] > 0:
                case EInstruction.Jge when registry[^1] >= 0:
                case EInstruction.Jl when registry[^1] < 0:
                case EInstruction.Jle when registry[^1] <= 0:
                    i = (int)statement[1];
                    continue;
                case EInstruction.Call:
                    stack.Push(i);
                    i = (int)statement[1];
                    continue;
                case EInstruction.Ret:
                    i = stack.Pop();
                    break;
                case EInstruction.End:
                    return output.ToString(); 
            }

            i++;
        }
        return null;

        // Determine if constant or needs to get from registry
        int ResolveValue(object obj)
        {
            return obj switch
            {
                int value => value,
                char addr => registry[addr],
                _ => throw new NotImplementedException()
            };
        }
    }
}