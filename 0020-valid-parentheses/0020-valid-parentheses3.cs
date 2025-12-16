public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        var map = new Dictionary<char, char> {
            {')', '('},
            {'}', '{'},
            {']', '['}
        };
        foreach (char ch in s) {
            if (map.ContainsValue(ch)) {
                stack.Push(ch);
            } else if (map.ContainsKey(ch)) {
                if (stack.Count == 0 || stack.Pop() != map[ch]) return false;
            }
        }
        return stack.Count == 0;
    }
}
