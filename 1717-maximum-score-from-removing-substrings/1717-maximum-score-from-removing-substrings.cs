using System.Collections.Generic;

public class Solution {
    public int MaximumGain(string s, int x, int y) {
        if (x > y) {
            return CalculateMaxPoints(s, 'a', 'b', x, y);
        } else {
            return CalculateMaxPoints(s, 'b', 'a', y, x);
        }
    }
    private int CalculateMaxPoints(string s, char first, char second, int firstPoints, int secondPoints) {
        int maxPoints = default;
        Stack<char> stack = new Stack<char>();
        maxPoints += ResultForRemovingSubstrings(s, first, second, firstPoints, stack);
        Stack<char> remaining = new Stack<char>(stack.Reverse());
        maxPoints += ResultForRemovingSubstrings(remaining, first, second, secondPoints);
        return maxPoints;
    }
    private int ResultForRemovingSubstrings(IEnumerable<char> input, char first, char second, int points, Stack<char> stack = null) {
        if (stack == null) {
            stack = new Stack<char>();
        }
        int result = default;
        foreach (char c in input) {
            if (stack.Count > 0 && stack.Peek() == first && c == second) {
                stack.Pop();
                result += points;
            } else {
                stack.Push(c);
            }
        }
        return result;
    }
}