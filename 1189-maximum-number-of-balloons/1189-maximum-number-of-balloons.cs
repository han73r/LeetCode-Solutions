public class Solution {
    public int MaxNumberOfBalloons(string text) {
        var count = new int[26];
        foreach (char c in text)
            count[c - 'a']++;
        return Math.Min(
            Math.Min(count['b' - 'a'], count['a' - 'a']),
            Math.Min(
                Math.Min(count['l' - 'a'] / 2, count['o' - 'a'] / 2),
                count['n' - 'a']
            )
        );
    }
}
