using Challenges.Kyu1.ThreePassCompiler;

namespace Tests.Kyu1.ThreePassCompiler;

public class SimpleTests
{
    [Fact]
    public void Basic()
    {
        var compiler = new Compiler();
        var prg = "[ x y z ] ( 2*3*x + 5*y - 3*z ) / (1 + 3 + 2*2)";
        
        compiler.pass1(prg);
        
        Assert.True(true);
    }
}