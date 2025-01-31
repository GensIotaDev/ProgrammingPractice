namespace Challenges.Kyu1.ThreePassCompiler;

public abstract class Ast
{
    public string Op { get; }

    protected Ast(string op)
    {
        Op = op;
    }

    public string op() => Op;
}
public class UnOp : Ast
{
    public int N { get; }
    
    public UnOp(string type, int n) : base(type)
    {
        N = n;
    }

    public int n() => N;
}
public class BinOp : Ast
{
    public Ast A { get; }
    public Ast B { get; }

    public BinOp(string type, Ast a, Ast b) : base(type)
    {
        A = a;
        B = b;
    }

    public Ast a() => A;
    public Ast b() => B;
}