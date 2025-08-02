using System.Collections.Generic;

public class Solution {
    public int SubarrayBitwiseORs(int[] arr) {
        HashSet<int> result = new HashSet<int>();
        HashSet<int> prev = new HashSet<int>();
        foreach (int num in arr) {
            HashSet<int> cur = new HashSet<int>();
            cur.Add(num);
            foreach (int val in prev)
                cur.Add(val | num);
            foreach (int val in cur)
                result.Add(val);
            prev = cur;
        }
        return result.Count;
    }
}