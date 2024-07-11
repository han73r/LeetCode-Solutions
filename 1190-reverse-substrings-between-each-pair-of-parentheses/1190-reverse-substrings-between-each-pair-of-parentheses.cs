using System.Collections.Generic;
using System.Text;

public class Solution {
    private const char LEFT = '(';
    private const char RIGHT = ')';
    public string ReverseParentheses(string s) {
        Stack<StringBuilder> stack = new Stack<StringBuilder>();
        StringBuilder current = new StringBuilder();
        foreach (char c in s) {
            if (c == LEFT) {
                stack.Push(current);
                current = new StringBuilder();
            } else if (c == RIGHT) {
                ReverseStringBuilder(current);
                current = stack.Pop().Append(current);
            } else {
                current.Append(c);
            }
        }
        return current.ToString();
    }
    private void ReverseStringBuilder(StringBuilder sb) {
        int length = sb.Length;
        for (int i = 0; i < length / 2; i++) {
            char temp = sb[i];
            sb[i] = sb[length - i - 1];
            sb[length - i - 1] = temp;
        }
    }
}