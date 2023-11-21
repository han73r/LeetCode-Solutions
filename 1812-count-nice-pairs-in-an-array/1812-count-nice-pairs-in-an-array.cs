public class Solution
{
    public int CountNicePairs(int[] nums)
    {
        const int Mod = 1000000007;
        int count = 0;
        Dictionary<int, int> sumCount = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            int revNum = Reverse(num);
            int currentSum = num - revNum;

            if (sumCount.ContainsKey(currentSum))
            {
                count = (count + sumCount[currentSum]) % Mod;
                sumCount[currentSum]++;
            }
            else
            {
                sumCount[currentSum] = 1;
            }
        }
        return count;
    }

    private int Reverse(int num)
    {
        int rev = 0;
        while (num > 0)
        {
            rev = rev * 10 + num % 10;
            num /= 10;
        }
        return rev;
    }
}