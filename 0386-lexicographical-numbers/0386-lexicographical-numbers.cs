using System.Collections.Generic;

public class Solution {
    public IList<int> LexicalOrder(int n) {
        List<int> nums = new List<int>();
        for (int i = 1; i <= n; i++) {
            nums.Add(i);
        }
        var sortedNums = nums.Select(num => num.ToString())
                             .OrderBy(num => num)
                             .Select(num => int.Parse(num))
                             .ToList();
        return sortedNums;
    }
}