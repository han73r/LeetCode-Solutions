public class Solution 
{
    public int MaxProfit(int[] prices) 
    {
        int pricesSize = prices.Length;
        if (pricesSize == 1) { return 0; }
        if (pricesSize == 2)
        {
            return prices[1] - prices[0] > 0 ? prices[1] - prices[0] : 0;
        }

        int maxProfit = 0;
        int minPrice = int.MaxValue;

        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < minPrice)
            {
                minPrice = prices[i];
            }
            else if (prices[i] - minPrice > maxProfit)
            {
                maxProfit = prices[i] - minPrice;
            }
        }

        return maxProfit;
    }
}