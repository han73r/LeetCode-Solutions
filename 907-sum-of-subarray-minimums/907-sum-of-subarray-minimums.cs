using System.Collections.Generic;

public class Solution
{
    public int SumSubarrayMins(int[] arr)
    {
        const int MOD = 1000000007;
        int n = arr.Length;
        long result = 0;
        Stack<int> stack = new Stack<int>();
        int[] left = new int[n];
        int[] right = new int[n];

        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && arr[i] <= arr[stack.Peek()])
                stack.Pop();

            left[i] = stack.Count == 0 ? -1 : stack.Peek();
            stack.Push(i);
        }

        stack.Clear();

        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && arr[i] < arr[stack.Peek()])
                stack.Pop();

            right[i] = stack.Count == 0 ? n : stack.Peek();
            stack.Push(i);
        }

        for (int i = 0; i < n; i++)
        {
            result = (result + (long)arr[i] * (i - left[i]) * (right[i] - i) % MOD) % MOD;
        }

        return (int)result;
    }
}