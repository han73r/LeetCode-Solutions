public class Solution {
    public bool UniformArray(int[] numsIn_) {
        int minNum = int.MaxValue;
        bool areAllEven = true;
        
        foreach (int num in numsIn_) {
            if (num % 2 != 0) {
                areAllEven = false;
            }
            if (num < minNum) {
                minNum = num;
            }
        }

        return (minNum % 2 != 0) ? true : areAllEven;
    }
}
