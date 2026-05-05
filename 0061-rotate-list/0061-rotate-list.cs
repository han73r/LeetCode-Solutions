public class Solution {
    public ListNode RotateRight(ListNode head, int k) {
        if (head == null || head.next == null || k == 0)
            return head;
        int length = 1;
        ListNode curr = head;
        while (curr.next != null) {
            curr = curr.next;
            length++;
        }
        ListNode last = curr;
        last.next = head;
        int rotate = k % length;
        int stepsToNewTail = length - rotate - 1;
        curr = head;
        for (int i = 0; i < stepsToNewTail; i++) {
            curr = curr.next;
        }
        ListNode newHead = curr.next;
        curr.next = null;
        return newHead;
    }
}
