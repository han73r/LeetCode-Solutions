public class Solution {
    private const char OpenBracket = '(';
    private const char NoChar = '\0';

    public int ScoreOfParentheses(string s) {
        int depth = 0;
        int score = 0;
        char prev = NoChar;

        foreach (char c in s) {
            bool isOpening = c == OpenBracket;
            if (isOpening) {
                depth++;
            } else {
                depth--;
                bool closesEmptyPair = prev == OpenBracket;
                if (closesEmptyPair) {
                    int pairScore = 1 << depth;
                    score += pairScore;
                }
            }
            prev = c;
        }

        return score;
    }
}
