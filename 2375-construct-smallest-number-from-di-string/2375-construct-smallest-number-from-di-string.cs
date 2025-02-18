using System;
using System.Collections.Generic;

public class Solution {
    public string SmallestNumber(string pattern) {
        int n = pattern.Length;
        Stack<char> stack = new Stack<char>();
        List<char> result = new List<char>();
        for (int i = 1; i <= n + 1; i++) {
            stack.Push((char)(i + '0'));
            if (i == n + 1 || pattern[i - 1] == 'I')
                while (stack.Count > 0)
                    result.Add(stack.Pop());
        }
        return new string(result.ToArray());
    }
}