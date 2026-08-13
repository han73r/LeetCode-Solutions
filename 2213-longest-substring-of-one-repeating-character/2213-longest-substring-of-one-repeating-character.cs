public class Solution {
    public class Node {
        public char left_char;
        public char right_char;
        public int prefix_len;
        public int suffix_len;
        public int max_len;
        public int total_len;
    }

    public class SegmentTree {
        private int n;
        private Node[] tree;
        private char[] s;

        public SegmentTree(string str) {
            n = str.Length;
            tree = new Node[4 * n];
            for (int i = 0; i < 4 * n; i++) {
                tree[i] = new Node();
            }
            s = str.ToCharArray();
            Build(1, 0, n - 1);
        }

        private void PushUp(Node node, Node left, Node right) {
            node.left_char = left.left_char;
            node.right_char = right.right_char;
            node.total_len = left.total_len + right.total_len;

            node.prefix_len = left.prefix_len;
            node.suffix_len = right.suffix_len;
            node.max_len = Math.Max(left.max_len, right.max_len);

            if (left.right_char == right.left_char) {
                int bridge_len = left.suffix_len + right.prefix_len;
                node.max_len = Math.Max(node.max_len, bridge_len);

                if (left.prefix_len == left.total_len) {
                    node.prefix_len = left.total_len + right.prefix_len;
                }
                if (right.suffix_len == right.total_len) {
                    node.suffix_len = right.total_len + left.suffix_len;
                }
            }
        }
        
        private void Build(int u, int l, int r) {
            if (l == r) {
                Node node = tree[u];
                node.left_char = node.right_char = s[l];
                node.prefix_len = node.suffix_len = node.max_len = node.total_len = 1;
                return;
            }

            int mid = l + (r - l) / 2;
            Build(2 * u, l, mid);
            Build(2 * u + 1, mid + 1, r);
            PushUp(tree[u], tree[2 * u], tree[2 * u + 1]);
        }

        private void Update(int u, int l, int r, int idx, char c) {
            if (l == r) {
                Node node = tree[u];
                node.left_char = node.right_char = c;
                s[idx] = c;
                return;
            }

            int mid = l + (r - l) / 2;
            if (idx <= mid) {
                Update(2 * u, l, mid, idx, c);
            } else {
                Update(2 * u + 1, mid + 1, r, idx, c);
            }

            PushUp(tree[u], tree[2 * u], tree[2 * u + 1]);
        }

        public void Update(int idx, char c) {
            Update(1, 0, n - 1, idx, c);
        }

        public int QueryMax() {
            return tree[1].max_len;
        }
    }

    public int[] LongestRepeating(string s, string queryCharacters, int[] queryIndices) {
        SegmentTree tree = new SegmentTree(s);
        int k = queryCharacters.Length;
        int[] ans = new int[k];
        for (int i = 0; i < k; i++) {
            tree.Update(queryIndices[i], queryCharacters[i]);
            ans[i] = tree.QueryMax();
        }
        return ans;
    }
}
