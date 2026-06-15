public class Solution {
    public ListNode DeleteMiddle(ListNode head) {
        if (head.next == null) return null;
        ListNode prev = null;
        ListNode slow = head;
        ListNode fast = head.next;
        while (slow != null && fast != null) {
            prev = slow;
            slow = slow.next;
            fast = fast.next?.next;
        }
        prev.next = slow.next;
        return head;
    }
}
