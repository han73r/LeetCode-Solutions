public class Solution {
    private const char OpenBracket = '(';
    private const char CloseBracket = ')';

    public int MinInsertions(string s) {
        var insertions = 0;
        var openCount = 0;

        foreach (var symbol in s) {
            if (symbol == OpenBracket) {
                if (openCount % 2 != 0) {
                    insertions++;
                    openCount--;
                }
                openCount += 2;
            } 
            else if (symbol == CloseBracket) {
                openCount--;
                if (openCount < 0) {
                    insertions++;
                    openCount += 2;
                }
            }
        }

        return insertions + openCount;
    }
}
