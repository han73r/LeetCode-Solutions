using System.Collections.Generic;
using System;

public class MyCalendar {
    private List<(int start, int end)> events;
    public MyCalendar() {
        events = new List<(int, int)>();
    }
    public bool Book(int start, int end) {
        foreach (var (existingStart, existingEnd) in events) {
            if (Math.Max(start, existingStart) < Math.Min(end, existingEnd)) {
                return false;
            }
        }
        events.Add((start, end));
        return true;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */