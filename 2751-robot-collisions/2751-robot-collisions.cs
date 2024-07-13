using System.Collections.Generic;

public class Solution {
    public int[] SurvivedRobotsHealths(int[] positions, int[] healths, string directions) {
        var robots = InitializeRobots(positions, healths, directions);
        robots.Sort((a, b) => a.pos.CompareTo(b.pos));
        var survivingRobots = ProcessCollisions(robots);
        return ExtractSurvivingHealths(survivingRobots, robots.Count);
    }
    private List<(int pos, int health, char dir, int idx)> InitializeRobots(int[] positions, int[] healths, string directions) {
        var robots = new List<(int pos, int health, char dir, int idx)>();
        for (int i = 0; i < positions.Length; i++) {
            robots.Add((positions[i], healths[i], directions[i], i));
        }
        return robots;
    }
    private List<(int pos, int health, char dir, int idx)> ProcessCollisions(List<(int pos, int health, char dir, int idx)> robots) {
        var stack = new Stack<(int pos, int health, char dir, int idx)>();
        for (int i = 0; i < robots.Count; i++) {
            var robot = robots[i];
            if (robot.dir == 'R') {
                stack.Push(robot);
            } else {
                while (stack.Count > 0 && stack.Peek().dir == 'R') {
                    var rightRobot = stack.Pop();
                    if (rightRobot.health > robot.health) {
                        rightRobot.health -= 1;
                        stack.Push(rightRobot);
                        robot.health = 0;
                        break;
                    } else if (rightRobot.health < robot.health) {
                        robot.health -= 1;
                    } else {
                        robot.health = 0;
                        break;
                    }
                }
                if (robot.health > 0) {
                    stack.Push(robot);
                }
                robots[i] = robot;
            }
        }
        return stack.ToList();
    }
    private int[] ExtractSurvivingHealths(List<(int pos, int health, char dir, int idx)> survivingRobots, int originalCount) {
        survivingRobots.Sort((a, b) => a.idx.CompareTo(b.idx));
        var result = new List<int>();
        foreach (var robot in survivingRobots) {
            result.Add(robot.health);
        }
        return result.ToArray();
    }
}
