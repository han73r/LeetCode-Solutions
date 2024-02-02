using System.Collections.Generic;

public class Solution {
    public IList<int> SequentialDigits(int low, int high) {
        List<int> result = new List<int>();
        string digits = "123456789";

        int n = digits.Length;

        for (int length = 1; length <= n; length++) {
            for (int start = 0; start <= n - length; start++) {
                string subString = digits.Substring(start, length);
                int number = int.Parse(subString);

                if (number >= low && number <= high) {
                    result.Add(number);
                }
            }
        }

        return result;
    }
}