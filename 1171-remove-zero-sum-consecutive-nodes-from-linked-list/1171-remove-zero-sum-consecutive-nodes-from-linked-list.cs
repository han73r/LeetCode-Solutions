
using System.Collections.Generic;

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
    public ListNode RemoveZeroSumSublists(ListNode head) {
        ListNode temp = new ListNode(0);
        temp.next = head;

        Dictionary<int, ListNode> prefixSum = new();
        int sum = 0;
        ListNode current = temp;

        while (current != null) {
            sum += current.val;
            if (prefixSum.ContainsKey(sum)) {
                current = prefixSum[sum].next;
                int tempSum = sum + current.val;
                while (tempSum != sum) {
                    prefixSum.Remove(tempSum);
                    current = current.next;
                    tempSum += current.val;
                }
                prefixSum[sum].next = current.next;
            } else {
                prefixSum[sum] = current;
            }
            current = current.next;
        }
        return temp.next;
    }
}