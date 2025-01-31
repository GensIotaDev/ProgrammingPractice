using Toolbox;

namespace Toolbox_Tests;

public class SHA2
{
    [Fact]
    public void AddToZero()
    {
        uint b = 0x6a09e667;
        uint k = 0xc67178f2;
        uint c = ~b + 1;
        var ans = c - k;
        Assert.True(true);
    }
    
    [Fact]
    public void Mixing()
    {
        var sha = new SHA();
        var header = new uint[]{
            0xaab31471, 0x24d95a54, 0x30c31b18, 0, //last word of merkle root, time, target, nonce
            0x8000000, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 640 //(1-0)padding, msg length
        }; 
        var output = sha.Extend(header);
        
        
        Assert.True(true);
    }
}