public class Solution {
    private const int StableIdxNotFound = -1;

    public int FirstStableIndex(int[] nums, int scoreUpLim) {
        int numsTot = nums.Length;
        if (numsTot == 0) return StableIdxNotFound;
        int[] minNumSuf = new int[numsTot];
        minNumSuf[numsTot - 1] = nums[numsTot - 1];

        for (int i = numsTot - 2; i >= 0; i--) {
            minNumSuf[i] = Math.Min(minNumSuf[i + 1], nums[i]);
        }

        int prefMaxNum = int.MinValue;

        for (int idx = 0; idx < numsTot; idx++) {
            prefMaxNum = Math.Max(prefMaxNum, nums[idx]);
            if (prefMaxNum - minNumSuf[idx] <= scoreUpLim) {
                return idx;
            }
        }

        return StableIdxNotFound;
    }
}
