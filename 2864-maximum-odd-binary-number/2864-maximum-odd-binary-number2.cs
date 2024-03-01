using System.Text;

public class Solution {
    public string MaximumOddBinaryNumber(string s) {
        byte count1 = 0, count0 = 0;
        foreach (char ch in s) {
            if (ch == '1') {
                count1++;
            } else {
                count0++;
            }
        }
        StringBuilder result = new StringBuilder();
        while (count1 > 1) {
            result.Append('1');
            count1--;
        }
        while (count0 > 0) {
            result.Append('0');
            count0--;
        }
        result.Append('1');
        return result.ToString();
    }
}