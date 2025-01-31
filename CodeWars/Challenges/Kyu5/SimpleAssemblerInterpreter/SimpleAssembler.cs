namespace Challenges.Kyu5.SimpleAssemblerInterpreter;

/// <summary>
/// For this <see href="https://www.codewars.com/kata/58e24788e24ddee28e000053">Kata</see>
/// Submission found <see href="https://www.codewars.com/kata/reviews/5e6e0b30ba49d8000163a119/groups/64e52ef83d9f3a0001e3eeea">here</see>
/// </summary>
public static class SimpleAssembler
{
    public static Dictionary<string, int> Interpret(string[] program)
    {
        var register = new Dictionary<string, int>();

        var instructionIndex = 0;
        while (instructionIndex < program.Length)
        {
            var parts = program[instructionIndex].Split(' ');
            switch (parts[0])
            {
                case "mov":
                {
                    var value = ParseFromRegister(register, parts[2]);
                    register[parts[1]] = value;
                } break;
                case "inc":
                    register[parts[1]]++;
                    break;
                case "dec":
                    register[parts[1]]--;
                    break;
                case "jnz":
                {
                    var a = ParseFromRegister(register, parts[1]);
                    var b = ParseFromRegister(register, parts[2]);

                    if (a != 0)
                    {
                        instructionIndex += b;
                        continue;
                    }
                } break;
            }

            instructionIndex++;
        }

        return register;
    }
      
    private static int ParseFromRegister(Dictionary<string, int> registers, string value)
    {
        return char.IsLetter(value[0]) ? registers[value] : int.Parse(value);
    }
}