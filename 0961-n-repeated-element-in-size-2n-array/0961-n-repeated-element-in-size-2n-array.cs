    public int RepeatedNTimes(int[] nums) {
        var set = new HashSet<int>();
        foreach (var num in nums)
            if (!set.Add(num)) return num;
        return -1;
    }
