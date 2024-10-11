using System.Collections.Generic;

public class Solution {
    public int SmallestChair(int[][] times, int targetFriend) {
        int n = times.Length;
        var events = new List<(int time, int friendId, bool isArrival)>();
        for (int i = 0; i < n; i++) {
            events.Add((times[i][0], i, true));
            events.Add((times[i][1], i, false));
        }
        events.Sort((a, b) => a.time != b.time ? a.time.CompareTo(b.time) : a.isArrival.CompareTo(b.isArrival));
        var availableChairs = new SortedSet<int>();
        for (int i = 0; i < n; i++) {
            availableChairs.Add(i);
        }
        var friendToChair = new int[n];
        foreach (var (time, friendId, isArrival) in events) {
            if (isArrival) {
                int assignedChair = availableChairs.Min;
                availableChairs.Remove(assignedChair);
                friendToChair[friendId] = assignedChair;
                if (friendId == targetFriend) {
                    return assignedChair;
                }
            } else {
                int leavingChair = friendToChair[friendId];
                availableChairs.Add(leavingChair);
            }
        }
        return -1;
    }
}