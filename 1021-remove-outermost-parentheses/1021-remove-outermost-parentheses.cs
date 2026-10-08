public class Solution {
    private const char OpenBracket = '(';
    private const char CloseBracket = ')';

    public string RemoveOuterParentheses(string s) {
        var result = new StringBuilder(s.Length);
        var openCount = 0;

        foreach (var symbol in s) {
            if (symbol == OpenBracket) {
                if (openCount > 0)
                    result.Append(symbol);
                openCount++;
            } 
            else if (symbol == CloseBracket) {
                openCount--;
                if (openCount > 0) 
                    result.Append(symbol);
            }
        }

        return result.ToString();
    }
}
