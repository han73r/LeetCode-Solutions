using System.Linq;

public class Solution {
    public int MaxCount(int[] banned, int n, int maxSum) {
        int sum = 0;
        int count = 0;
        var bannedHS = banned.ToHashSet();
        var availableInts = Enumerable.Range(1, n)
                                        .Where(x => !bannedHS.Contains(x))
                                        .OrderBy(x => x);
        foreach (var item in availableInts) {
            if (sum + item > maxSum) break;
            sum += item;
            count++;
        }
        return count;
    }
}