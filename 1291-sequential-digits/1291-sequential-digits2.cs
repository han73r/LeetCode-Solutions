public class Solution {
    public IList<int> SequentialDigits(int low, int high) {
        List<int> result = new ();
        for (int start =1; start <= 9; start++) {
            int number = 0;
            for (int digit = start; digit <= 9; digit++) {
                number = number * 10 + digit;
                if (number >= low && number <= high)
                    result.Add(number);
                if (number > high) break;
            }
        }
        result.Sort();
        return result;
    }
}
