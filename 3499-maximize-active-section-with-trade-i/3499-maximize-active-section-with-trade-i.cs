public class Solution {
    public int MaxActiveSectionsAfterTrade(string s) {
        var nums = s.Select(c => c == '0' ? -1 : 1).ToArray();
        var prefs = new List<int>();
        var (pref, prev) = (nums[0], nums[0]);
        foreach (var num in nums.Skip(1)) {
            if (num != prev) {
                prefs.Add(pref);
                pref = num;
            } else
                pref += num;
            prev = num;
        }
        prefs.Add(pref);
        var max = 0;
        for (var i = 0; i < prefs.Count() - 2; i++) {
            var (start, end) = (prefs[i], prefs[i + 2]);
            if (start < 0 && end < 0) {
                max = Math.Max(max, Math.Abs(start + end));
            }
        }
        return max + prefs.Where(p => p > 0).Sum();
    }
}
