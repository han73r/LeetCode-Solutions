/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public int[][] SpiralMatrix(int m, int n, ListNode head) {
        int[][] matrix = new int[m][];
        for (int i = 0; i < m; i++) {
            matrix[i] = new int[n];
            for (int j = 0; j < n; j++) {
                matrix[i][j] = -1;
            }
        }
        int top = 0, bottom = m - 1, left = 0, right = n - 1;
        while (top <= bottom && left <= right) {
            for (int j = left; j <= right; j++) {
                if (head != null) {
                    matrix[top][j] = head.val;
                    head = head.next;
                }
            }
            top++;
            for (int i = top; i <= bottom; i++) {
                if (head != null) {
                    matrix[i][right] = head.val;
                    head = head.next;
                }
            }
            right--;
            if (top <= bottom) {
                for (int j = right; j >= left; j--) {
                    if (head != null) {
                        matrix[bottom][j] = head.val;
                        head = head.next;
                    }
                }
                bottom--;
            }
            if (left <= right) {
                for (int i = bottom; i >= top; i--) {
                    if (head != null) {
                        matrix[i][left] = head.val;
                        head = head.next;
                    }
                }
                left++;
            }
        }
        return matrix;
    }
}