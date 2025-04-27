public class Solution {
    public long CountSubarrays(int[] nums, int minK, int maxK) {
        long pair = 0;
        int lastMin = -1, lastMax = -1, lastInvaild = -1;
        for (int index = 0; index < nums.Length; index++) {
            int num = nums[index];
            if (num == minK) lastMin = index;
            if (num == maxK) lastMax = index;
            if (num < minK || num > maxK) lastInvaild = index;
            pair += int.Max(0, int.Min(lastMax, lastMin) - lastInvaild);
        }
        return pair;
    }
}