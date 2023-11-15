public class Solution
{
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
    {
        int main = 1;
        if (arr[0] != main)
        {
            Array.Sort(arr);
            arr[0] = main;
        }

        for (int i = 1; i < arr.Length; i++)
        {
            if (Math.Abs(arr[i] - arr[i - 1]) > main)
            {
                arr[i] = arr[i - 1] + main;
            }
        }
        return arr.Max();
    }
}