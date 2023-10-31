public class Solution 
{
    public int[] PlusOne(int[] digits) 
    {
        int maxDigit = 9;
        int firstDigit = 0;
        int lastIndex = digits.Length - 1;

        for (int i = lastIndex; i >= 0; i--)
        {
            if (digits[i] < maxDigit)
            {
                digits[i]++;
                break;
            }
            else
            {
                digits[i] = 0;
            }            
        }

        if (digits[0] == firstDigit)
        {
            int[]newDigits = new int [ digits.Length + 1 ];
            newDigits[0] = 1;

            for (int i = 1; i < newDigits.Length; i++)
            {
                newDigits[i] = digits[i - 1];
            }
            return newDigits;
        }
        return digits;
    }
}