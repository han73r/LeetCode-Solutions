public class Solution {
    public int MinPatches(int[] nums, int n) {
        long miss = 1;
        int added = 0, i = 0;
        while (miss <= n) {
            if (i < nums.Length && nums[i] <= miss) {
                miss += nums[i];
                i++;
            } else {
                miss += miss;
                added++;
            }
        }
        return added;
    }
}