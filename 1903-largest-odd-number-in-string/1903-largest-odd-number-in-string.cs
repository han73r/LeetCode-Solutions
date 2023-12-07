using System.Text;

public class Solution
{
    public string LargestOddNumber(string num)
    {
        var sb = CheckLastSymb(new StringBuilder(num));
        return sb.ToString();
    }

    private StringBuilder CheckLastSymb(StringBuilder sb)
    {
        byte b = (byte)(sb[sb.Length - 1] - '0');
        if (b % 2 != 0 && b != 0)
        {
            return sb;
        }
        else if (sb.Length == 1)
        {
            return sb.Clear();
        }

        return CheckLastSymb(sb.Remove(sb.Length - 1, 1));
    }
}