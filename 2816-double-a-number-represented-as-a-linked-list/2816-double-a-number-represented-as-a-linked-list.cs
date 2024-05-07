
using System.Text;

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
    public ListNode DoubleIt(ListNode head) {
        ListNode current = head;
        StringBuilder sb = new();
        while (current != null) {
            sb.Append(current.val);
            current = current.next;
        }
        sb = DoubleSB(sb);
        int[] numbers = SBToArray(sb);
        return CreateListNode(numbers);
    }
    private StringBuilder DoubleSB(StringBuilder sb) {
        int carry = 0;
        for (int i = sb.Length - 1; i >= 0; i--) {
            int digit = sb[i] - '0';
            int prod = digit * 2 + carry;
            sb[i] = (char)('0' + (prod % 10));
            carry = prod / 10;
        }
        if (carry > 0) {
            sb.Insert(0, (char)('0' + carry));
        }
        return sb;
    }
    private int[] SBToArray(StringBuilder sb) {
        int[] result = new int[sb.Length];
        for (int i = 0; i < sb.Length; i++) {
            result[i] = sb[i] - '0';
        }
        return result;
    }
    private ListNode CreateListNode(int[] array) {
        ListNode dummy = new();
        ListNode current = dummy;
        foreach (int i in array) {
            current.next = new ListNode(i);
            current = current.next;
        }
        return dummy.next;
    }
}