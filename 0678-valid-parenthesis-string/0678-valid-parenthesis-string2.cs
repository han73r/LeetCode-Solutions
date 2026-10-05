public class Solution {
    private const char Open = '(';
    private const char Close = ')';
    private const char Wildcard = '*';

    public bool CheckValidString(string s) {
        var openIndices = new Stack<int>();
        var wildcardIndices = new Stack<int>();

        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            bool isOpen = c == Open;
            bool isWildcard = c == Wildcard;

            if (isOpen) {
                openIndices.Push(i);
            } else if (isWildcard) {
                wildcardIndices.Push(i);
            } else {
                bool hasUnmatchedOpen = openIndices.Count > 0;
                bool hasWildcard = wildcardIndices.Count > 0;

                if (hasUnmatchedOpen) {
                    openIndices.Pop();
                } else if (hasWildcard) {
                    wildcardIndices.Pop();
                } else {
                    return false;
                }
            }
        }

        while (openIndices.Count > 0 && wildcardIndices.Count > 0) {
            int openIndex = openIndices.Pop();
            int wildcardIndex = wildcardIndices.Pop();
            bool wildcardIsBeforeOpen = wildcardIndex < openIndex;
            if (wildcardIsBeforeOpen)
                return false;
        }

        bool allOpensMatched = openIndices.Count == 0;
        return allOpensMatched;
    }
}
