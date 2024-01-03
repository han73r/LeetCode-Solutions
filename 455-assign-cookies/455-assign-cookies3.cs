public class Solution
{
    public int NumberOfBeams(string[] bank)
    {
        if (bank.Length < 2) return 0;

        int result = 0, currentRow = 0, lastRow = 0;

        foreach (var row in bank)
        {
            currentRow = 0;
            foreach (var ch in row.ToCharArray())
                if (ch == '1')
                    currentRow++;

            result += currentRow * lastRow;
            lastRow = currentRow == 0 ? lastRow : currentRow;
        }
        return result;
    }
}