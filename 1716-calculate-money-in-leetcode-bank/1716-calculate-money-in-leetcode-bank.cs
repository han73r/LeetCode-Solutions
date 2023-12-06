public class Solution
{
    int weekDays = 7;
    public int TotalMoney(int n)
    {
        int mod = n / weekDays;
        int first = weekDays * (weekDays + 1) / 2;
        int last = first + (mod - 1) * weekDays;
        int totalMoney = mod * (first + last) / 2;

        if (n % weekDays != 0)
        {
            int extraMoney = mod + 1;
            for (int i = 0; i < (n % weekDays); i++)
            {
                totalMoney += extraMoney;
                extraMoney++;
            }
        }
        return totalMoney;
    }
}