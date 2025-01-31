namespace Challenges.Kyu4.StackArithmeticMachine;

using System;
using System.Collections.Generic;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/54c1bf903f0696f04600068b">Kata</see>
/// Submission link missing even after valid submission
/// </summary>
public class Machine
{
  private static readonly Dictionary<string, Action<Machine, string[]>> StackOperations = new()
  {
      { "push" , (m, args) => m.Push(args[0]) },
      { "pushr" , (m, _) => m.PushRegister() },
      { "pushrr" , (m, _) => m.PushRegister(true) },
      { "pop" , (m, args) => m.Pop(args.Length > 0 ? args[0] : null) },
      { "popr" , (m, _) => m.PopRegister() },
      { "poprr" , (m, _) => m.PopRegister(true) },
      { "mov" , (m, args) => m.Move(args[0], args[1]) }
  };
  private static readonly Dictionary<string, Func<int, int, int>> ArithmeticOperations = new()
  {
      { "add", (sum, value) => sum + value },
      { "sub", (sum, value) => sum - value },
      { "mul", (sum, value) => sum * value },
      { "div", (sum, value) => sum / value },
      { "and", (sum, value) => sum & value },
      { "or", (sum, value) => sum | value },
      { "xor", (sum, value) => sum ^ value }
  };
  
  private Cpu cpu;
  
  public Machine(Cpu? cpu = null)
  {
    this.cpu = cpu ?? throw new ArgumentNullException();
  }

  public void Exec(string op)
  {
      Console.WriteLine(op);
      string cmd = ParseOp(op, out var args);

      if (StackOperations.TryGetValue(cmd, out var stAction))
      {
          stAction(this, args);
          return;
      }

      if (ArithmeticOperations.TryGetValue(cmd, out var equation)) //base operation (ie. xor)
      {
          Evaluate(
              null,
              args,
              equation
          );
      }
      else if(ArithmeticOperations.TryGetValue(cmd[..^1], out var equation2)) //registry operation (ie. xora)
      {
          Evaluate(
              $"{cmd[^1]}",
              args,
              equation2
          );
      }
    
      Console.WriteLine($"--; Should be {cpu.ReadReg("a")}");
      cpu.PrintStack();
  }
  
  private void Evaluate(string? reg, string[] arg, Func<int , int , int > operation)
  {
      if (reg is not null)
      {
          Push(cpu.ReadReg(reg));
      }
      else
      {
          reg = "a";
      }

      var count = (IsRegistry(arg[0])) ? cpu.ReadReg(arg[0]) : int.Parse(arg[0]);

      int sum = cpu.PopStack();
      for (int i = 1; i < count; i++)
      {
          sum = operation(sum, cpu.PopStack());
      }

      string target = (arg.Length > 1) ? arg[1] : reg;

      cpu.WriteReg(target, sum);
  }

  private void Push(string arg)
  {
      var value = IsRegistry(arg) ? cpu.ReadReg(arg) : int.Parse(arg);
      Push(value);
  }
  private void Push(int value)
  {
      cpu.WriteStack(value);
  }
  private void PushRegister(bool reverse = false)
  {
      const string registers = "abcdcba";

      var offset = 0;
      if (reverse)
      {
          offset = 3;
      }

      for (var i = 0; i < 4; i++)
      {
          var reg = cpu.ReadReg($"{registers[i + offset]}");
          cpu.WriteStack(reg);
      }
  }

  private void Pop(string? arg = null)
  {
      int value = cpu.PopStack();
        
      if (arg != null && IsRegistry(arg))
      {
          cpu.WriteReg(arg, value);
      }
  }
  private void PopRegister(bool reverse = false)
  {
      const string registers = "dcbabcd";

      var offset = 0;
      if (reverse)
      {
          offset = 3;
      }

      for (int i = 0; i < 4; i++)
      {
          var value = cpu.PopStack();
          cpu.WriteReg($"{registers[i + offset]}", value);
      }
  }

  private void Move(string value, string registry)
  {
      var v = IsRegistry(value) ? cpu.ReadReg(value) : int.Parse(value);

      Move(v, registry);
  }
  private void Move(int value, string registry)
  {
      cpu.WriteReg(registry, value);
  }
  
  // Utility
  private static bool IsRegistry(string value)
  {
      if (value.Length > 1) return false;

      var t = value[0] - 'a';

      return t is >= 0 and <= 3; //only need to check if character is [a,b,c,d] anything else is assumed an error or numerical value
  }
  private static string ParseOp(string op, out string[] arguments)
  {
      string? cmd = null;
      List<string> args = new List<string>();
      int start = -1;

      int idx = 0;
      bool readArgs = false;
      while (idx < op.Length)
      {
          switch (op[idx])
          {
              case ' ':
                  if (!readArgs)
                  {
                      cmd = op.Substring(0, idx);
                  }
                  readArgs = true;
                  start = idx + 1;
                  break;
              case ',':
                  args.Add(op.Substring(start,idx - start));
                  start = -1;
                  break;
          }

          idx++;
      }

      if (start < op.Length && start > -1)
      {
          args.Add(op.Substring(start, op.Length - start));
      }

      cmd ??= op;

      arguments = args.ToArray();
      return cmd;
  }
}