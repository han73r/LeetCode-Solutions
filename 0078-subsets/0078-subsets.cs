using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        List<int> currentSubset = new List<int>();
        Backtrack(nums, 0, currentSubset, result);
        return result;
    }
    private void Backtrack(int[] nums, int index, List<int> currentSubset, IList<IList<int>> result) {
        result.Add(new List<int>(currentSubset));
        for (int i = index; i < nums.Length; i++) {
            currentSubset.Add(nums[i]);
            Backtrack(nums, i + 1, currentSubset, result);
            currentSubset.RemoveAt(currentSubset.Count - 1);
        }
    }
}