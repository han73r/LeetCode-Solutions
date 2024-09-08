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
    public ListNode[] SplitListToParts(ListNode head, int k) {
        int length = 0;
        ListNode current = head;
        while (current != null) {
            length++;
            current = current.next;
        }
        int partSize = length / k;
        int extraNodes = length % k;
        ListNode[] result = new ListNode[k];
        current = head;
        for (int i = 0; i < k; i++) {
            result[i] = current;
            int currentPartSize = partSize + (extraNodes-- > 0 ? 1 : 0);
            for (int j = 0; j < currentPartSize - 1; j++) {
                if (current != null) current = current.next;
            }
            if (current != null) {
                ListNode nextPart = current.next;
                current.next = null;
                current = nextPart;
            }
        }
        return result;
    }
}