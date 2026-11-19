public class Solution {
    public int MinimizeSum(int[] nums) {
        int len = nums.Length;
        if(len < 4) return 0;
        Array.Sort(nums);
        int res = nums[len-1] - nums[2];
        res = Math.Min(res, nums[len-3]-nums[0]);
        res = Math.Min(res, nums[len-2] - nums[1]);
        return res;
    }
}
