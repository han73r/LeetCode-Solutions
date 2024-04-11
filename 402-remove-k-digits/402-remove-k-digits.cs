using System.Text;

public class Solution {
    public string RemoveKdigits(string num, int k) {
        int n = num.Length;
        if (k == n) return "0"; // Remove all digits

        StringBuilder sb = new StringBuilder();
        int digitsToKeep = n - k;
        char[] stack = new char[n];
        int top = 0;

        // Iterate over each digit in the number
        foreach (char c in num) {
            // Remove larger digits from the top of the stack until the stack is empty,
            // or until the current digit is smaller than the top of the stack,
            // or until we've removed enough digits to meet the required number of digits to keep
            while (top > 0 && stack[top - 1] > c && k > 0) {
                top--;
                k--;
            }

            // Push the current digit onto the stack
            stack[top++] = c;
        }

        // Skip leading zeroes
        int idx = 0;
        while (idx < digitsToKeep && stack[idx] == '0') {
            idx++;
        }

        // Build the resulting string from the digits remaining on the stack
        for (int i = idx; i < digitsToKeep; i++) {
            sb.Append(stack[i]);
        }

        // If the result is empty, return "0"
        if (sb.Length == 0) {
            return "0";
        }

        return sb.ToString();
    }
}