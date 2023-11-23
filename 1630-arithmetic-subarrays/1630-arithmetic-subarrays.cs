public class Solution
{
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
    {
        List<bool> listResult = new();

        for (int i = 0; i < l.Length; i++)
        {
            List<int> list = new();
            for (int j = l[i]; j <= r[i]; j++)
            {
                list.Add(nums[j]);
            }
            listResult.Add(CheckArithmeticSequence(list));
        }
        return listResult;
    }

    private bool CheckArithmeticSequence(List<int> list)
    {
        list.Sort();
        int d = list[1] - list[0];

        for (int i = 2; i < list.Count; i++)
        {
            if (list[i] != list[i - 1] + d)
            {
                return false;
            }
        }
        return true;
    }
}