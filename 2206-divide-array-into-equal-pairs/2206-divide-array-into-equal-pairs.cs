using System.Collections.Generic;

public class Solution {
    public bool DivideArray(int[] nums) {
        Dictionary<int, int> counter = new();
        foreach (int num in nums) {
            if (!counter.ContainsKey(num))
                counter[num] = 0;
            counter[num]++;
        }
        foreach (int count in counter.Values) {
            if (count % 2 != 0)
                return false;
        }
        return true;
    }
}