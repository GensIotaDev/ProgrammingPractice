namespace Toolbox;

public class SHA
{
    private readonly uint[] _w = new uint[64];
    public uint[] Extend(uint[] words)
    {
        Array.Copy(words, _w, 16);

        for (var i = 16; i < 64; i++)
        {
            var s0 = RotR(_w[i - 15], 7) ^ RotR(_w[i - 15], 18) ^ RotR(_w[i - 15], 3);
            var s1 = RotR(_w[i - 2], 17) ^ RotR(_w[i - 2], 19) ^ RotR(_w[i - 2], 10);
            _w[i] = _w[i - 16] + s0 + _w[i - 7] + s1;
        }

        return _w;
    }
    
    private static uint RotR(uint n, int shift) => (n >> shift) | (n << (32 - shift));
}