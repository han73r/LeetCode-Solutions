using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public IList<IList<int>> FindMatrix(int[] nums)
    {
        List<int> container = new List<int>();
        List<int> Matrix = nums.ToList();
        IList<IList<int>> list = new List<IList<int>>();
        while (Matrix.Count > 0)
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                if (container.Count == 0 || !container.Contains(Matrix[i]))
                {
                    container.Add(Matrix[i]);
                    Matrix.Remove(Matrix[i]);
                    i--;
                }

            }
            list.Add(container.ToArray());
            container.Clear();
        }
        return list;
    }
}