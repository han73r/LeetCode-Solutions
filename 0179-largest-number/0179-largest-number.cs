using System.Linq;
using System;

public class Solution {
    public string LargestNumber(int[] nums) {
        string[] arr = nums.Select(num => num.ToString()).ToArray();
        Array.Sort(arr, (x, y) => (y + x).CompareTo(x + y));
        if (arr[0] == "0") return "0";
        return string.Join("", arr);
    }
}