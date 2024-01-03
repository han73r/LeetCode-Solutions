public class Solution
{
    public int NumberOfBeams(string[] bank)
    {
        int result = 0;
        int curLaserLineCount = 0, lastLaserLineCount = 0;

        foreach (string st in bank)
        {
            curLaserLineCount = StringToIntSum(st);
            if (lastLaserLineCount != 0 && curLaserLineCount != 0)
            {
                result += lastLaserLineCount * curLaserLineCount;
            }

            if (curLaserLineCount > 0)
            {
                lastLaserLineCount = curLaserLineCount;
            }
        }

        return result;
    }

    private int StringToIntSum(string st)
    {
        int result = 0;
        foreach (char ch in st)
        {
            result += int.Parse(ch.ToString());
        }
        return result;
    }
}