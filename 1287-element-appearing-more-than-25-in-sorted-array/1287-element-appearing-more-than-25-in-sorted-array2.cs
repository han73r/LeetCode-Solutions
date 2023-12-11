public class Solution
{
    public int FindSpecialInteger(int[] arr)
    {
        int n = arr.Length;

        if (n == 1)
        {
            return arr[0];
        }

        int count = 1;
        int targetCount = n / 4;

        for (int i = 1; i < n; i++)
        {
            if (arr[i - 1] == arr[i])
            {
                count++;
                if (count > targetCount)
                {
                    return arr[i];
                }
            }
            else
            {
                count = 1;
            }
        }
        return arr[n - 1];
    }
}