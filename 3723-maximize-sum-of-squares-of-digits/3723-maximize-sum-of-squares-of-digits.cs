public class Solution {
    private const int MaxDigit = 9;
    private const char ZeroChar = '0';
    private const char NineChar = '9';

    public string MaxSumOfSquares(int num, int sum) {
        if (num <= 0 || sum < 0 || (long)sum > (long)MaxDigit * num)
            return string.Empty;
        int ninesCount = sum / MaxDigit;
        int remainder = sum % MaxDigit;
        return string.Create(num, (ninesCount, remainder), (span, state) => {
            var (nines, rem) = state;
            span[..nines].Fill(NineChar);
            int index = nines;
            if (rem > 0)
                span[index++] = (char)(ZeroChar + rem);
            span[index..].Fill(ZeroChar);
        });
    }
}
