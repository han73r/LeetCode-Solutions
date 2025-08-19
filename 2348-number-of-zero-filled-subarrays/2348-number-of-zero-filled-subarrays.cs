public class Solution {
    public long ZeroFilledSubarray(int[] nums) {
        long cnt = 0, streak = 0;
        foreach (int num in nums) {
            if (num == 0) {
                streak++;
                cnt += streak;
            } else {
                streak = 0;
            }
        }
        return cnt;
    }
}