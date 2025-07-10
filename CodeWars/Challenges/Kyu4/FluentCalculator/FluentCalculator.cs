namespace Challenges.Kyu4.FluentCalculator;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/5578a806350dae5b05000021">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5c23f43df4c86cb4ea00015e/groups/67a6f820187ec526e8ebde16">here</see>
/// </summary>
public class Operator
{
    public Value Plus => calculator.AddOperator('+');
    public Value Minus => calculator.AddOperator('-');
    public Value Times => calculator.AddOperator('*');
    public Value DividedBy => calculator.AddOperator('/');
    
    private FluentCalculator calculator;

    internal Operator(FluentCalculator calculator)
    {
        this.calculator = calculator;
    }
    
    public double Result() => calculator.Result();
    
    public static implicit operator double(Operator op) => op.calculator.Result();
}

public class Value
{
    public Operator Zero => Calculator.AddLiteral(0);
    public Operator One => Calculator.AddLiteral(1);
    public Operator Two => Calculator.AddLiteral(2);
    public Operator Three => Calculator.AddLiteral(3);
    public Operator Four => Calculator.AddLiteral(4);
    public Operator Five => Calculator.AddLiteral(5);
    public Operator Six => Calculator.AddLiteral(6);
    public Operator Seven => Calculator.AddLiteral(7);
    public Operator Eight => Calculator.AddLiteral(8);
    public Operator Nine => Calculator.AddLiteral(9);
    public Operator Ten => Calculator.AddLiteral(10);
    
    internal FluentCalculator Calculator { private get; init; }
    internal Value(){}
    
    public static implicit operator double(Value value) => value.Calculator.Result();
}

public class FluentCalculator : Value
{
    private static readonly Dictionary<char, (int precedence, Func<double, double, double> operation)> operatorMap = new()
    {
        { '+', (2, (l,r) => l+r ) },
        { '-', (2, (l,r) => l-r ) },
        { '*', (3, (l,r) => l*r ) },
        { '/', (3, (l,r) => l/r ) },
    };
    
    private Stack<char> operators = new Stack<char>();
    private Stack<object> output = new Stack<object>();
    private Operator opController;
    public FluentCalculator()
    {
        opController = new Operator(this);
        Calculator = this;
    }

    internal Operator AddLiteral(double value)
    {
        output.Push(value);
        return opController;
    }

    internal Value AddOperator(char op)
    {
        var op1 = operatorMap[op];
        while (operators.TryPeek(out char result))
        {
            var op2 = operatorMap[result];
            if (op2.precedence >= op1.precedence)
            {
                output.Push(operators.Pop());
            }
            else break;
        }
        
        operators.Push(op);
        return this;
    }

    //Resolve reverse polish notation evaluation stack  
    public double Result()
    {
        while (operators.Count > 0)
        {
            output.Push(operators.Pop());
        }

        LinkedList<object> reverseNotation = new LinkedList<object>(output.Reverse());
        output.Clear();
        
        var node = reverseNotation.First;
        while (node != null)
        {
            var nextNode = node.Next;
            if (node.Value is char op)
            {
                var leftNode = node.Previous.Previous;
                var rightNode = node.Previous;
                
                var result = operatorMap[op].operation((double)leftNode.Value, (double)rightNode.Value);
                var resultNode = reverseNotation.AddBefore(leftNode, result);
                reverseNotation.Remove(leftNode);
                reverseNotation.Remove(rightNode);
                reverseNotation.Remove(node);
            }
            
            node = nextNode;
        }
        
        return (double)reverseNotation.First.Value;
    }
}