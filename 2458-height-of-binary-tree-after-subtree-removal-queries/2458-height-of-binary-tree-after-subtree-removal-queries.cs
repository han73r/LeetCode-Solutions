
using System.Collections.Generic;


using System;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    private int[] heights;
    private int[] d;
    private int[] l;
    private int[] r;
    private int lenLeaves;
    public int[] TreeQueries(TreeNode root, int[] queries) {
        heights = new int[50000];
        d = new int[100001];
        l = new int[100001];
        r = new int[100001];
        lenLeaves = 0;
        Search(root, 0);
        int n = lenLeaves;
        int[] maxl = new int[n];
        int[] maxr = new int[n];
        for (int i = 1; i < n; i++) {
            maxl[i] = Math.Max(maxl[i - 1], heights[i - 1]);
            maxr[n - i - 1] = Math.Max(maxr[n - i], heights[n - i]);
        }
        var ret = new List<int>();
        foreach (int query in queries) {
            int maxxl = maxl[l[query]];
            int maxxr = maxr[r[query]];
            ret.Add(Math.Max(Math.Max(maxxl, maxxr), d[query] - 1));
        }
        return ret.ToArray();
    }
    private void Search(TreeNode p, int h) {
        d[p.val] = h;
        if (p.left == null && p.right == null) {
            heights[lenLeaves] = h;
            l[p.val] = r[p.val] = lenLeaves;
            lenLeaves++;
            return;
        }
        l[p.val] = lenLeaves;
        if (p.left != null) {
            Search(p.left, h + 1);
        }
        if (p.right != null) {
            Search(p.right, h + 1);
        }
        r[p.val] = lenLeaves - 1;
    }
}