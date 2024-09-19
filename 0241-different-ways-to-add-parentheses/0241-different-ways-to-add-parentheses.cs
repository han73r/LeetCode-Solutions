using System.Collections.Generic;

public class Solution {
    public IList<int> DiffWaysToCompute(string expression) {
        Dictionary<string, IList<int>> memo = new Dictionary<string, IList<int>>();
        return Compute(expression, memo);
    }
    private IList<int> Compute(string expression, Dictionary<string, IList<int>> memo) {
        if (memo.ContainsKey(expression)) return memo[expression];
        List<int> results = new List<int>();
        for (int i = 0; i < expression.Length; i++) {
            char ch = expression[i];
            if (ch == '+' || ch == '-' || ch == '*') {
                IList<int> leftResults = Compute(expression.Substring(0, i), memo);
                IList<int> rightResults = Compute(expression.Substring(i + 1), memo);
                foreach (int left in leftResults) {
                    foreach (int right in rightResults) {
                        int result = 0;
                        if (ch == '+') result = left + right;
                        else if (ch == '-') result = left - right;
                        else if (ch == '*') result = left * right;
                        results.Add(result);
                    }
                }
            }
        }
        if (results.Count == 0) results.Add(int.Parse(expression));
        memo[expression] = results;
        return results;
    }
}