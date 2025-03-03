public class Solution {
    public int[] PivotArray(int[] nums, int pivot) {
        int low = 0, same = 0, high = 0;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] < pivot)
                low++;
            else if (nums[i] == pivot)
                same++;
        }
        high = low + same;
        same = low;
        low = 0;
        int[] res = new int[nums.Length];
        foreach (var item in nums) {
            if (item < pivot)
                res[low++] = item;
            else if (item == pivot)
                res[same++] = item;
            else
                res[high++] = item;
        }
        return res;
    }
}