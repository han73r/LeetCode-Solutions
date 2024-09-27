using System.Collections.Generic;
using System;

public class MyCalendarTwo {
    private List<(int start, int end)> events;
    private List<(int start, int end)> overlaps;
    public MyCalendarTwo() {
        events = new List<(int, int)>();
        overlaps = new List<(int, int)>();
    }
    public bool Book(int start, int end) {
        foreach (var (overlapStart, overlapEnd) in overlaps) {
            if (Math.Max(start, overlapStart) < Math.Min(end, overlapEnd)) {
                return false;
            }
        }
        foreach (var (existingStart, existingEnd) in events) {
            int overlapStart = Math.Max(start, existingStart);
            int overlapEnd = Math.Min(end, existingEnd);
            if (overlapStart < overlapEnd) {
                overlaps.Add((overlapStart, overlapEnd));
            }
        }
        events.Add((start, end));
        return true;
    }
}

/**
 * Your MyCalendarTwo object will be instantiated and called as such:
 * MyCalendarTwo obj = new MyCalendarTwo();
 * bool param_1 = obj.Book(start,end);
 */