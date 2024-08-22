using System.Text;
using System;

public class Solution {
    public int FindComplement(int num) {
        string binary = Convert.ToString(num, 2);
        string complementedBinary = Complement(binary);
        int result = Convert.ToInt32(complementedBinary, 2);
        return result;
    }
    private string Complement(string s) {
        StringBuilder sb = new StringBuilder();
        foreach (char c in s) {
            if (c == '0') {
                sb.Append('1');
            } else {
                sb.Append('0');
            }
        }
        return sb.ToString();
    }
}