
using System.Collections.Generic;


using System;

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
    public int[] NodesBetweenCriticalPoints(ListNode head) {
        List<int> criticalPoints = new List<int>();
        int index = 0;
        ListNode prev = null;
        ListNode current = head;
        while (current != null && current.next != null && current.next.next != null) {
            if (IsLocalMaximum(current) || IsLocalMinimum(current)) {
                criticalPoints.Add(index);
            }
            index++;
            current = current.next;
        }
        if (criticalPoints.Count < 2) {
            return new int[] { -1, -1 };
        }
        int minDistance = int.MaxValue;
        int maxDistance = criticalPoints[criticalPoints.Count - 1] - criticalPoints[0];
        for (int i = 1; i < criticalPoints.Count; i++) {
            minDistance = Math.Min(minDistance, criticalPoints[i] - criticalPoints[i - 1]);
        }
        return new int[] { minDistance, maxDistance };
    }
    private bool IsLocalMaximum(ListNode head) {
        return (head.val < head.next.val &&
                head.next.val > head.next.next.val);
    }
    private bool IsLocalMinimum(ListNode head) {
        return (head.val > head.next.val &&
                head.next.val < head.next.next.val);
    }
}