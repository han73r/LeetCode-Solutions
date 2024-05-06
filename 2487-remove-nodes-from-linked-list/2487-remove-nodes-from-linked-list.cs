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
    public ListNode RemoveNodes(ListNode head) {
        // Step 1: Reverse the linked list
        ListNode prev = null;
        ListNode curr = head;
        while (curr != null) {
            ListNode nextNode = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextNode;
        }
        ListNode reversedHead = prev;

        // Step 2: Process the reversed list and keep track of the current maximum
        ListNode dummy = new ListNode(); // Dummy node to manage the new list easily
        ListNode tail = dummy;
        int maxValue = int.MinValue;

        curr = reversedHead;
        while (curr != null) {
            // If the current value is greater or equal to the maximum seen so far
            if (curr.val >= maxValue) {
                maxValue = curr.val;
                tail.next = curr;
                tail = curr;
            }
            curr = curr.next;
        }
        // Terminate the new list
        tail.next = null;

        // Step 3: Reverse the list again to restore the original order
        prev = null;
        curr = dummy.next;
        while (curr != null) {
            ListNode nextNode = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextNode;
        }
        return prev;
    }
}