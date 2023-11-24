public class Solution
{
    public int MaxCoins(int[] piles)
    {
        Array.Sort(piles);
        int yourcoins = 0;

        for (int i = piles.Length - 2, j = 0; j < piles.Length / 3; i -= 2, j++)
        {
            yourcoins += piles[i];
        }

        return yourcoins;
    }
}