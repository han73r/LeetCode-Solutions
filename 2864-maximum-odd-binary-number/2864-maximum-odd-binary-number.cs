public class Solution {
    public string MaximumOddBinaryNumber(string s) {
        int count1 = 0, count0 = 0, i = 0;
        foreach (char ch in s) {
            if (ch == '1') {
                count1++;
            } else {
                count0++;
            }
        }
        char[] result = new char[s.Length];
        while (i < count1 - 1) {
            result[i++] = '1';
        }
        while (i < count1 - 1 + count0) {
            result[i++] = '0';
        }
        result[i] = '1';
        return new string(result);
    }
}