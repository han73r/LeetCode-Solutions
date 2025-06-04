using System;

public class Solution {
    public string AnswerString(string word, int numFriends) {
        int len = word.Length - (numFriends) + 1;
        if (numFriends == 1)
            return word;
        ReadOnlySpan<char> largestPossible = word.AsSpan(0, len);
        for (int i = 0; i < word.Length; i++) {
            ReadOnlySpan<char> current = word.AsSpan(i, Math.Min(word.Length - i, len));
            if (current.SequenceCompareTo(largestPossible) > 0)
                largestPossible = current;
        }
        return largestPossible.ToString();
    }
}