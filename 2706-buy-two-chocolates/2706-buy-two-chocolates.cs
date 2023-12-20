using System;

public class Solution
{
    public int BuyChoco(int[] prices, int money)
    {
        Array.Sort(prices);
        int balance = money - (prices[0] + prices[1]);
        if (balance >= 0)
            return balance;
        else
            return money;
    }
}