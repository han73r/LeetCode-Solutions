public class Solution {
    private const char OpenBracket = '(';
    private const char CloseBracket = ')';
    private readonly StringBuilder currentPath = new();
    private readonly HashSet<string> validResults = new();
    private string source = string.Empty;

    public IList<string> RemoveInvalidParentheses(string s) {
        source = s;
        currentPath.Clear();
        validResults.Clear();

        var (openToRemove, closeToRemove) = CountMisplacedBrackets(source);

        Backtrack(
            index: 0,
            openCount: 0,
            closeCount: 0,
            openToRemove: openToRemove,
            closeToRemove: closeToRemove);

        return validResults.ToList();
    }

    private static (int OpenToRemove, int CloseToRemove) CountMisplacedBrackets(string text) {
        var openToRemove = 0;
        var closeToRemove = 0;

        foreach (var symbol in text) {
            if (symbol == OpenBracket) {
                openToRemove++;
            } else if (symbol == CloseBracket) {
                if (openToRemove > 0) {
                    openToRemove--;
                } else {
                    closeToRemove++;
                }
            }
        }

        return (openToRemove, closeToRemove);
    }

    private void Backtrack(int index, int openCount, int closeCount, int openToRemove, int closeToRemove) {
        if (index == source.Length) {
            if (openToRemove == 0 && closeToRemove == 0) {
                validResults.Add(currentPath.ToString());
            }
            return;
        }

        var symbol = source[index];

        if (symbol == OpenBracket && openToRemove > 0) {
            Backtrack(index + 1, openCount, closeCount, openToRemove - 1, closeToRemove);
        } else if (symbol == CloseBracket && closeToRemove > 0) {
            Backtrack(index + 1, openCount, closeCount, openToRemove, closeToRemove - 1);
        }


        currentPath.Append(symbol);
        
        if (symbol == OpenBracket) {
            Backtrack(index + 1, openCount + 1, closeCount, openToRemove, closeToRemove);
        } else if (symbol == CloseBracket) {
            if (closeCount < openCount) {
                Backtrack(index + 1, openCount, closeCount + 1, openToRemove, closeToRemove);
            }
        } else {
            Backtrack(index + 1, openCount, closeCount, openToRemove, closeToRemove);
        }

        currentPath.Length--;
    }
}
