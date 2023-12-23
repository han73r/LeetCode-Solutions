using System.Collections.Generic;

public class Solution
{
    private Point position = new Point(0, 0);
    private HashSet<Point> visited = new HashSet<Point>();
    public struct Point
    {
        int x;
        int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Move(char direction)
        {
            switch (direction)
            {
                case 'N':
                    x++;
                    break;
                case 'S':
                    x--;
                    break;
                case 'E':
                    y++;
                    break;
                case 'W':
                    y--;
                    break;
            }
        }
        public override int GetHashCode() => x.GetHashCode() ^ y.GetHashCode();
    }

    public bool IsPathCrossing(string path)
    {
        visited.Add(position);
        foreach (char ch in path)
        {
            position.Move(ch);
            if (visited.Contains(position))
                return true;
            visited.Add(position);
        }
        return false;
    }
}