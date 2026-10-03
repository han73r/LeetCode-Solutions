public class Solution {
    private const char OpenBracket = '(';
    private const char CloseBracket = ')';

    public int LongestValidParentheses(string s) {
        var leftToRight = Scan(s, forward: true);
        var rightToLeft = Scan(s, forward: false);
        return Math.Max(leftToRight, rightToLeft);
    }

    private static int Scan(string s, bool forward) {
        var maxLength = 0;
        var openCount = 0;
        var closeCount = 0;
        var start = forward ? 0 : s.Length - 1;
        var step = forward ? 1 : -1;

        for (var i = start; i >= 0 && i < s.Length; i += step) {
            if (s[i] == OpenBracket)
                openCount++;
            else
                closeCount++;

            if (openCount == closeCount)
                maxLength = Math.Max(maxLength, openCount * 2);
            else if ((forward && closeCount > openCount) || (!forward && openCount > closeCount)) {
                openCount = 0;
                closeCount = 0;
            }
        }

        return maxLength;
    }
}
