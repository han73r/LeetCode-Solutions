using System;

public class Solution {
    public int MinMovesToSeat(int[] seats, int[] students) {
        int result = 0;
        Array.Sort(seats);
        Array.Sort(students);
        for (int i = 0; i < students.Length; i++) {
            result += Math.Abs(seats[i] - students[i]);
        }
        return result;
    }
}