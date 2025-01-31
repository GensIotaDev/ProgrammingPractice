namespace Challenges.Kyu4.StackArithmeticMachine;

//Note: Mock class for utility 
/// <summary>
/// Mock class for <see href="https://www.codewars.com/kata/54c1bf903f0696f04600068b">kata</see>
/// </summary>
public abstract class Cpu
{
    public abstract int ReadReg(string name);
    public abstract void WriteReg(string name, int value);

    public abstract int PopStack();
    public abstract void WriteStack(int value);
    public abstract void PrintStack();
}