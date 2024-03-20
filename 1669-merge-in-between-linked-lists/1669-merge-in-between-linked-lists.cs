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
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2) {
        ListNode dummy = new ListNode(0);
        dummy.next = list1;
        ListNode prevA = dummy;
        for (int i = 0; i < a; i++) {
            prevA = prevA.next;
        }
        ListNode nodeA = prevA.next;
        ListNode nodeB = nodeA;
        for (int i = 0; i < b - a; i++) {
            nodeB = nodeB.next;
        }
        prevA.next = list2;
        while (list2.next != null) {
            list2 = list2.next;
        }
        list2.next = nodeB.next;
        return dummy.next;
    }
}