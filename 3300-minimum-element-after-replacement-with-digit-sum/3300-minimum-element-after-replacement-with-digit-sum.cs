public class Solution {
    public int MinElement(int[] nums) {
        int minVal = int.MaxValue;
        foreach (int numValue in nums) {
            int num = numValue;
            int currentSum = 0;
            while (num > 0) {
                currentSum += num % 10;
                num /= 10;
            }
            minVal = Math.Min(minVal, currentSum);
        }
        return minVal;
    }
}
