public class Solution
{
    public int MaxCoins(int[] piles)
    {
        int j = 0;
        Array.Sort(piles);
        int yourcoins = 0;

        for (int i = piles.Length - 2; j < piles.Length / 3; i -= 2)
        {
            yourcoins += piles[i];
            j++;
        }

        return yourcoins;
    }
}