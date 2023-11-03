public class Solution 
{
    public IList<string> BuildArray(int[] target, int n) 
    {
        List<string> operations = new List<string>();
        Stack<int> stack = new Stack<int>();
        int targetIndex = 0;

        for (int i = 1; i <= n; i++) 
        {
            if (i == target[targetIndex]) 
            {
                operations.Add("Push");
                targetIndex++;
            } 
            else 
            {
                operations.Add("Push");
                operations.Add("Pop");
            }
            if (targetIndex == target.Length) 
            {
                break;
            }
        }
        return operations; 
    }
}