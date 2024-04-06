using System.Text;

public class Solution {
    private char left = '(';
    private char right = ')';
    public string MinRemoveToMakeValid(string s) {
        StringBuilder sb = new(s);
        int count = 0;
        for (int i = 0; i < sb.Length; i++) {
            if (sb[i] == left) {
                count++;
            } else if (sb[i] == right) {
                if (count == 0) {
                    sb.Remove(i, 1);
                    i--;
                } else {
                    count--;
                }
            }
        }
        for (int i = sb.Length - 1; i >= 0 && count > 0; i--) {
            if (sb[i] == left) {
                sb.Remove(i, 1);
                count--;
            }
        }
        return sb.ToString();
    }
}