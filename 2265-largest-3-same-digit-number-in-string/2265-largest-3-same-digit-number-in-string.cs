public class Solution
{
    public string LargestGoodInteger(string num)
    {
        int n = num.Length;
        string maxGoodInteger = "";

        for (int i = 0; i < n - 2; i++)
        {
            char currentDigit = num[i];
            if (currentDigit == num[i + 1] && currentDigit == num[i + 2])
            {
                string currentGoodInteger = new string(currentDigit, 3);

                if (string.Compare(currentGoodInteger, maxGoodInteger) > 0)
                {
                    maxGoodInteger = currentGoodInteger;
                }
            }
        }
        return maxGoodInteger;
    }
}