public class FindElements {
    private readonly TreeNode? _root;
    public FindElements(TreeNode root) {
        _root = root;
    }
    public bool Find(int target) {
        if (target == 0)
            return _root != null;
        target++;
        var depth = int.Log2(target);
        var node = _root;
        var low = 1 << depth;
        var high = (1 << (depth + 1)) - 1;
        while (depth > 0 && node != null) {
            var mid = low + ((high - low) >> 1);
            if (mid >= target) {
                if (node.left == null)
                    return false;
                high = mid;
                node = node.left;
            } else {
                if (node.right == null)
                    return false;
                low = mid + 1;
                node = node.right;
            }
            depth--;
        }
        return true;
    }
}