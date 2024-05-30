public class Solution
{
    public int NumDecodings(string s)
    {
        if (s[0] == '0') return 0;
        if (s.Length == 1) return 1;

        int prevPrev, prev;
        prevPrev = prev = 1;

        for (int i = 1; i < s.Length; i++)
        {
            int current = 0;
            int oneDigit = s[i] - '0';
            int twoDigits = (s[i - 1] - '0') * 10 + oneDigit;

            if (oneDigit >= 1)
                current += prev;

            if (twoDigits >= 10 && twoDigits <= 26)
                current += prevPrev;

            prevPrev = prev;
            prev = current;
        }
        return prev;
    }
}