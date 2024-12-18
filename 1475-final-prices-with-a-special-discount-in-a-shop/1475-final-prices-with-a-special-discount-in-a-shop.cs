public class Solution {
    public int[] FinalPrices(int[] prices) {
        var length = prices.Length;
        var result = new int[length];
        for (int i = 0; i < length; i++) {
            int value = prices[i];
            for (int j = i + 1; j < length; j++) {
                if (j > i && prices[j] <= prices[i]) {
                    value -= prices[j];
                    break;
                }
            }
            result[i] = value;
        }
        return result;
    }
}