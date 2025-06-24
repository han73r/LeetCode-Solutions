public class Solution {
    public IList<int> FindKDistantIndices(int[] nums, int key, int k) {
        List<int> res = new List<int>();
        List<int> keys = new List<int>();
        int i = 0;
        int j = 0;
        for (i = 0; i < nums.Length; ++i) {
            if (nums[i] == key)
                keys.Add(i);
        }
        if (keys[0] - k < 0) {
            for (j = 0; j < keys[0]; ++j)
                res.Add(j);
        } else {
            for (j = keys[0] - k; j < keys[0]; ++j)
                res.Add(j);
        }

        for (i = 0; i < keys.Count - 1; ++i) {
            if (keys[i + 1] - keys[i] <= 2 * k) {
                for (j = keys[i]; j < keys[i + 1]; ++j)
                    res.Add(j);
            } else {
                for (j = keys[i]; j <= keys[i] + k; ++j)
                    res.Add(j);
                for (j = keys[i + 1] - k; j < keys[i + 1]; ++j)
                    res.Add(j);
            }
        }
        for (j = keys[i]; j <= keys[i] + k && j < nums.Length; ++j)
            res.Add(j);
        return res;
    }
}