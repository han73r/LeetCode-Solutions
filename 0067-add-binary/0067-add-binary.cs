public class Solution 
{
    public string AddBinary(string a, string b) 
    {
        StringBuilder result = new StringBuilder();
        int carry = 0;
        int i = a.Length - 1;
        int j = b.Length - 1;

        while (i >= 0 || j >= 0 || carry > 0) 
        {
            int digitA = (i >= 0) ? a[i--] - '0' : 0;
            int digitB = (j >= 0) ? b[j--] - '0' : 0;
            int sum = digitA + digitB + carry;
            result.Insert(0, (sum % 2).ToString());
            carry = sum / 2;
        }

        return result.ToString();
    }
}