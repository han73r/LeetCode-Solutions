public class Solution
{
    public int PseudoPalindromicPaths(TreeNode root)
    {
        int[] pathCount = new int[10];
        return DFS(root, pathCount);
    }

    private bool IsPalindrome(int[] arr)
    {
        int oddCount = 0;
        foreach (int count in arr)
        {
            if (count % 2 != 0)
            {
                oddCount++;
            }

            if (oddCount > 1)
            {
                return false;
            }
        }
        return true;
    }

    private int DFS(TreeNode node, int[] pathCount)
    {
        if (node == null)
        {
            return 0;
        }

        pathCount[node.val]++;
        int result = 0;

        if (node.left == null && node.right == null)
        {
            result = IsPalindrome(pathCount) ? 1 : 0;
        }
        else
        {
            result = DFS(node.left, (int[])pathCount.Clone()) + DFS(node.right, (int[])pathCount.Clone());
        }

        return result;
    }
}