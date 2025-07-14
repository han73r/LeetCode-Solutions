public int GetDecimalValue(ListNode head) {
    int val = 0;
    while (head != null) {
        val = val * 2 + head.val;
        head = head.next;
    }
    return val;
}