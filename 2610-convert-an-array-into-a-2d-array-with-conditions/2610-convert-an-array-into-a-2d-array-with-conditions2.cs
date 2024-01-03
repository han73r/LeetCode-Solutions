public class Solution
{
    public int NumberOfBeams(string[] bank)
    {
        int result = 0;
        if (bank.Length == 1) return result;

        int currentRow = 0, lastRow = 0;

        foreach (string st in bank)
        {
            currentRow = Calc(st);
            if (currentRow == 0) continue;

            result += currentRow * lastRow;
            lastRow = currentRow;
        }
        return result;
    }

    private int Calc(string s)
    {
        int result = 0;
        foreach (char c in s)
            result += c - '0';
        return result;
    }
}