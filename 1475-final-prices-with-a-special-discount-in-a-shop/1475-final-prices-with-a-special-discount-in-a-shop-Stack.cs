using System.Collections.Generic;

public class Solution {
    public int[] FinalPrices(int[] prices) {
        var stack = new Stack<int>();
        for (int i = 0; i < prices.Length; i++) {
            while (stack.Count > 0 && prices[stack.Peek()] >= prices[i]) {
                int idx = stack.Pop();
                prices[idx] -= prices[i];
            }
            stack.Push(i);
        }
        return prices;
    }
}