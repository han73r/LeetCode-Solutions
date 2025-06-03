using System.Collections.Generic;

public class Solution {
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes) {
        int n = status.Length;
        bool[] hasKey = new bool[n];
        bool[] boxOwned = new bool[n];
        bool[] boxVisited = new bool[n];

        Queue<int> queue = new Queue<int>();

        foreach (int box in initialBoxes) {
            boxOwned[box] = true;
            queue.Enqueue(box);
        }

        int totalCandies = 0;
        bool progress = true;

        while (progress) {
            progress = false;
            int size = queue.Count;

            for (int i = 0; i < size; i++) {
                int box = queue.Dequeue();
                if (!boxVisited[box] && (status[box] == 1 || hasKey[box])) {
                    boxVisited[box] = true;
                    progress = true;

                    totalCandies += candies[box];

                    foreach (int key in keys[box]) {
                        hasKey[key] = true;
                        if (boxOwned[key] && !boxVisited[key]) {
                            queue.Enqueue(key);
                        }
                    }

                    foreach (int contained in containedBoxes[box]) {
                        boxOwned[contained] = true;
                        queue.Enqueue(contained);
                    }
                } else {
                    queue.Enqueue(box);
                }
            }
        }

        return totalCandies;
    }
}