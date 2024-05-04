using System;

public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        Array.Sort(people);
        int boats = 0;
        int left = 0, right = people.Length - 1;

        while (left <= right) {
            if (people[left] + people[right] <= limit) {
                left++;
            }
            right--;
            boats++;
        }

        return boats;
    }
}