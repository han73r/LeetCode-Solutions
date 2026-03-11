public class Solution {
    public int BitwiseComplement(int n) {
        var binary = Convert.ToString(n, 2);
        var complementedBinary = Complement(binary);
        return Convert.ToInt32(complementedBinary, 2);
    }
    private string Complement(string s) {
        var sb = new StringBuilder();
        foreach (var ch in s) {
            if (ch == '0')
                sb.Append('1');
            else
                sb.Append('0');
        }
        return sb.ToString();
    }
}
