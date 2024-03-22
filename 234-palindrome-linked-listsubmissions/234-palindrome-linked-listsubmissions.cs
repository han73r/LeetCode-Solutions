
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
    public bool IsPalindrome(ListNode head) {
        List<int> valueList = new();
        int count = 0;
        while (head != null) {
            valueList.Add(head.val);
            head = head.next;
        }
        for (int i = 0; i < valueList.Count / 2; i++) {
            if (valueList[i] != valueList[valueList.Count - 1 - i]) {
                return false;
            }
        }
        return true;
    }
}