public class Solution {
    private const char OpenBracket = '(';
    private const char CloseBracket = ')';

    public IList<string> GenerateParenthesis(int n) {
        var result = new List<string>();

        Generate(result, current: string.Empty, openCount: 0, closeCount: 0, pairsCount: n);

        return result;
    }

    private static void Generate(
        List<string> result,
        string current,
        int openCount,
        int closeCount,
        int pairsCount)
    {
        if (current.Length == pairsCount * 2) {
            result.Add(current);
            return;
        }

        if (openCount < pairsCount)
            Generate(result, current + OpenBracket, openCount + 1, closeCount, pairsCount);

        if (closeCount < openCount)
            Generate(result, current + CloseBracket, openCount, closeCount + 1, pairsCount);
    }
}
