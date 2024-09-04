using System.Collections.Generic;
using System;

public class Solution {
    public int RobotSim(int[] commands, int[][] obstacles) {
        // Directions: 0 = North, 1 = East, 2 = South, 3 = West
        int[][] directions = new int[][] {
            new int[] {0, 1}, // North
            new int[] {1, 0}, // East
            new int[] {0, -1}, // South
            new int[] {-1, 0}  // West
        };
        HashSet<(int, int)> obstacleSet = new HashSet<(int, int)>();
        foreach (var obstacle in obstacles) {
            obstacleSet.Add((obstacle[0], obstacle[1]));
        }
        int x = 0, y = 0;
        int dir = 0;
        int maxDistSquared = 0;
        foreach (int command in commands) {
            if (command == -2) {
                dir = (dir + 3) % 4;
            } else if (command == -1) {
                dir = (dir + 1) % 4;
            } else if (command >= 1) {
                int dx = directions[dir][0];
                int dy = directions[dir][1];
                for (int i = 0; i < command; i++) {
                    if (obstacleSet.Contains((x + dx, y + dy))) {
                        break;
                    }
                    x += dx;
                    y += dy;
                    maxDistSquared = Math.Max(maxDistSquared, x * x + y * y);
                }
            }
        }
        return maxDistSquared;
    }
}