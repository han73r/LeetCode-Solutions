public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n <= 2)
            return n;

        int first = 1, second = 2;

        while (n > 2)
        {
            int third = first + second;
            first = second;
            second = third;
            n--;
        }

        return second;
    }
}