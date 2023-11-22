public class Solution
{
    public int[] FindDiagonalOrder(IList<IList<int>> nums)
    {
        Dictionary<int, List<int>> groups = new Dictionary<int, List<int>>();
        // Step 1: Populate groups based on diagonal sum
        for (int row = nums.Count - 1; row >= 0; row--)
        {
            for (int col = 0; col < nums[row].Count; col++)
            {
                int diagonal = row + col;
                if (!groups.ContainsKey(diagonal))
                {
                    groups[diagonal] = new List<int>();
                }
                groups[diagonal].Add(nums[row][col]);
            }
        }
        List<int> ans = new List<int>();
        int curr = 0;

        // Step 2: Traverse through groups in order
        while (groups.ContainsKey(curr))
        {
            ans.AddRange(groups[curr]);
            curr++;
        }
        return ans.ToArray();
    }
}