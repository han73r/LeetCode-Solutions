using System.Collections.Generic;

public class Solution {
    public int MaxCount(int[] banned, int n, int maxSum) {
        var bannedHS = new HashSet<int>(banned);
        int sum = 0, count = 0;
        for (int i = 1; i <= n; i++) {
            if (bannedHS.Contains(i)) continue;
            if (sum + i > maxSum) break;
            sum += i;
            count++;
        }
        return count;
    }
}