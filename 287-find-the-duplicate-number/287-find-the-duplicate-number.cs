using System.Collections.Generic;

public class Solution {
    public int FindDuplicate(int[] nums) {
        HashSet<int> hashSet = new();
        foreach (int num in nums) {
            if (hashSet.Contains(num)) {
                return num;
            } else {
                hashSet.Add(num);
            }
        }
        return 0;
    }
}