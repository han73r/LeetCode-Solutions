public class Solution
{
    public string LargestOddNumber(string num)
    {
        int i = num.Length - 1;
        if ((byte)num[i] / 2 == 1) return num;
        while (i >= 0)
        {
            byte n = (byte)(num[i] - '0');
            if (n % 2 == 1)
            {
                return num.Substring(0, i + 1);
            }
            i--;
        }
        return "";
    }
}