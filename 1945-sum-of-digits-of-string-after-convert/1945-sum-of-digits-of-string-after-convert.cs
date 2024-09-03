using System.Text;

public class Solution {
    public int GetLucky(string s, int k) {
        BigInteger result = ConvertStringToInt(s);
        for (int i = 0; i < k; i++) {
            result = CountSum(result);
        }
        return (int)result;
    }
    private BigInteger ConvertStringToInt(string s) {
        StringBuilder sb = new StringBuilder();
        foreach (char ch in s) {
            sb.Append((int)ch - 'a' + 1);
        }
        return BigInteger.Parse(sb.ToString());
    }
    private BigInteger CountSum(BigInteger number) {
        BigInteger sum = 0;
        while (number > 0) {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }
}