using System.Collections.Generic;
using System;

public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        List<IList<int>> result = new List<IList<int>>();
        Backtrack(candidates, target, 0, new List<int>(), result);
        return result;
    }
    private void Backtrack(int[] candidates, int target, int start, List<int> current, List<IList<int>> result) {
        if (target == 0) {
            result.Add(new List<int>(current));
            return;
        }
        for (int i = start; i < candidates.Length; i++) {
            if (i > start && candidates[i] == candidates[i - 1]) continue;
            if (candidates[i] > target) break;
            current.Add(candidates[i]);
            Backtrack(candidates, target - candidates[i], i + 1, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}