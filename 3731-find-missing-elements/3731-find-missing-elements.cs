public class Solution {
    public IList<int> FindMissingElements(int[] nums) {
        int start = nums.Min();
        int end = nums.Max();
        int index = -1;
        List<int> result = new();
        for (; start <= end; start++) {
            index = Array.IndexOf(nums, start);
            if (index == -1) {
                result.Add(start);
            }
        }
        return result;
    }
}
