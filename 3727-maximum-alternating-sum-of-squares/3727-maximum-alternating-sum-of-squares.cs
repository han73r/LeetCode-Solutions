public class Solution {
    public long MaxAlternatingSum(int[] nums) {
        int n = nums.Length;
        long[] squares = new long[n];
        
        for (int i = 0; i < n; i++) {
            long val = nums[i];
            squares[i] = val * val;
        }
        
        Array.Sort(squares);
        long score = 0;
        int negativeCount = n / 2;
        
        for (int i = 0; i < negativeCount; i++)
            score -= squares[i];
        
        for (int i = negativeCount; i < n; i++)
            score += squares[i];
        
        return score;
    }
}
