using System.Collections.Generic;

public class Solution {
    public int MinOperations(int[] nums, int k) {
        var st = new HashSet<int>();
        foreach (int x in nums) {
            if (x < k)
                return -1;
            else if (x > k)
                st.Add(x);
        }
        return st.Count;
    }
}