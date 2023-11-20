public class Solution
{
    public int GarbageCollection(string[] garbage, int[] travel)
    {
        char[] types = { 'G', 'P', 'M' };
        var lastIndex = new int[3];
        var garbageAmount = new int[3];

        for (int i = 0; i < garbage.Length; i++)
        {
            for (int j = 0; j < types.Length; j++)
            {
                if (garbage[i].Contains(types[j]))
                {
                    lastIndex[j] = i;
                    garbageAmount[j] += garbage[i].Count(c => c == types[j]);
                }
            }
        }
        return garbageAmount.Sum() + types.Sum(type => travel.Take(lastIndex[Array.IndexOf(types, type)]).Sum());
    }
}