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
    public ListNode ReverseList(ListNode head) {
        ListNode dummy = null;
        while (head != null) {
            ListNode nextNode = head.next;
            head.next = dummy;
            dummy = head;
            head = nextNode;
        }
        return dummy;
    }
}