public class Solution
{
    public string FindDifferentBinaryString(string[] nums)
    {
        HashSet<string> seen = new HashSet<string>(nums);

        int n = nums[0].Length;
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            char bit = (char)('0' + ('1' - nums[0][i]));
            result.Append(bit);
        }

        string candidate = result.ToString();

        while (seen.Contains(candidate))
        {
            int randomIndex = new Random().Next(0, n);
            result[randomIndex] = (char)('0' + ('1' - result[randomIndex]));
            candidate = result.ToString();
        }

        return candidate;
    }
}