using Challenges.Kyu2.AssemblerInterpreterPart2;

namespace Tests.Kyu2.AssemblerInterpreterPart2;

public class SampleTests
{
    public static IEnumerable<object[]> BasicData = new[]
    {
        /*new object[]
        {
            "(5+1)/2 = 3",
            "\n; My first program\nmov  a, 5\ninc  a\ncall function\nmsg  '(5+1)/2 = ', a    ; output message\nend\n\nfunction:\n    div  a, 2\n    ret\n"
        },
        new object[]
        {
            "5! = 120",
            "\nmov   a, 5\nmov   b, a\nmov   c, a\ncall  proc_fact\ncall  print\nend\n\nproc_fact:\n    dec   b\n    mul   c, b\n    cmp   b, 1\n    jne   proc_fact\n    ret\n\nprint:\n    msg   a, '! = ', c ; output text\n    ret\n",
        },*/
        new object[]
        {
            "mod(11, 3) = 2",
            "\nmov   a, 11           ; value1\nmov   b, 3            ; value2\ncall  mod_func\nmsg   'mod(', a, ', ', b, ') = ', d        ; output\nend\n\n; Mod function\nmod_func:\n    mov   c, a        ; temp1\n    div   c, b\n    mul   c, b\n    mov   d, a        ; temp2\n    sub   d, c\n    ret\n",
        }
    };

    [Theory]
    [MemberData(nameof(BasicData))]
    public void Basic(string expected, string program)
    {
        var result = AssemblerInterpreter.Interpret(program);
        
        Assert.Equal(expected, result);
    }
}