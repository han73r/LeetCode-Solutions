public class Solution {
    public int SumRootToLeaf(TreeNode root, int currentSum = 0) {
        if (root == null) {
            return 0;
        }

        if (root.left == null && root.right == null) {
            currentSum = (currentSum << 1) | root.val;
            return currentSum;
        }

        currentSum = (currentSum << 1) | root.val;
        return SumRootToLeaf(root.left, currentSum) + SumRootToLeaf(root.right, currentSum);
    }
}
