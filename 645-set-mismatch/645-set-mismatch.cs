public class Solution
{
    public int[] FindErrorNums(int[] nums)
    {
        int[] result = new int[2];
        int n = nums.Length;
        int[] count = new int[n + 1];

        foreach (int num in nums)
        {
            count[num]++;
        }

        for (int i = 1; i <= n; i++)
        {
            if (count[i] == 2)
            {
                result[0] = i;
            }
            if (count[i] == 0)
            {
                result[1] = i;
            }
        }

        return result;
    }
}