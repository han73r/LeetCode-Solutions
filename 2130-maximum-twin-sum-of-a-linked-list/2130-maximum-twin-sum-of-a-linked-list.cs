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
    public int PairSum(ListNode head) {
        List<int> values = new();
        ListNode current = head;
        while (current != null) {
            values.Add(current.val);
            current = current.next;
        }
        (int maxPairSum, int length) = (0, values.Count);
        for (int i = 0; i < length / 2; i++) {
            maxPairSum = Math.Max(
                maxPairSum,
                values[i] + values[length - 1 - i]);
        }
        return maxPairSum;
    }
}
