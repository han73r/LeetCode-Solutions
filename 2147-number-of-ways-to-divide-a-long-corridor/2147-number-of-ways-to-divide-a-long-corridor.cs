public class Solution
{
    private const int Mod = 1_000_000_007;

    public int NumberOfWays(string corridor)
    {
        int a = 1, b = 0, c = 0;

        foreach (var ch in corridor)
        {
            a = (a + c) % Mod;

            if (ch == 'S')
            {
                c = b;
                b = a;
                a = 0;
            }
        }
        return c;
    }
}