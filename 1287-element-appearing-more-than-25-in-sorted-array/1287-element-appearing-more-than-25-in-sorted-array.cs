public class Solution
{
    public int FindSpecialInteger(int[] arr)
    {
        if (arr.Length == 1) return arr[0];
        int count = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i - 1] == arr[i])
            {
                count++;
                if (count >= arr.Length / 4)
                {
                    return arr[i];
                }
            }
            else
            {
                count = 0;
            }
        }
        return count;
    }
}