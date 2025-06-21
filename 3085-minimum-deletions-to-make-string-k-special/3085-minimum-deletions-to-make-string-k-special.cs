public class Solution {
    public int MinimumDeletions(string word, int k) {
        Dictionary<char, int> freq = new Dictionary<char, int>();
        foreach (char c in word) {
            if (!freq.ContainsKey(c))
                freq[c] = 0;
            freq[c]++;
        }
        List<int> freqList = freq.Values.ToList();
        freqList.Sort();
        int minDeletions = int.MaxValue;
        int n = freqList.Count;
        for (int i = 0; i < n; i++) {
            int baseFreq = freqList[i];
            int deletions = 0;
            for (int j = 0; j < i; j++)
                deletions += freqList[j];
            for (int j = i; j < n; j++) {
                if (freqList[j] > baseFreq + k)
                    deletions += freqList[j] - (baseFreq + k);
            }
            minDeletions = Math.Min(minDeletions, deletions);
        }
        return minDeletions;
    }
}