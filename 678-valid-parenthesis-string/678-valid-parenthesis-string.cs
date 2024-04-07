using System.Collections.Generic;

public class Solution {
    private char left = '(';
    private char right = ')';
    private char star = '*';
    public bool CheckValidString(string s) {
        Stack<int> openStack = new Stack<int>();
        Stack<int> starStack = new Stack<int>();
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == left) {
                openStack.Push(i);
            } else if (s[i] == star) {
                starStack.Push(i);
            } else if (s[i] == right) {
                if (openStack.Count > 0) {
                    openStack.Pop();
                } else if (starStack.Count > 0) {
                    starStack.Pop();
                } else {
                    return false;
                }
            }
        }
        while (openStack.Count > 0 && starStack.Count > 0) {
            if (openStack.Pop() > starStack.Pop()) {
                return false;
            }
        }
        return openStack.Count == 0;
    }
}