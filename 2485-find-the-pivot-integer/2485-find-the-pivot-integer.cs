public class Solution {
    public int PivotInteger(int n) {
        int leftSum = 1;
        int rightSum = n;
        int left = 1;
        int right = n;
        int currentNumber = 1;

        while (left < right) {
            if (leftSum <= rightSum) {
                left++;
                leftSum += left;
            } else {
                right--;
                rightSum += right;
            }
        }
        if (left == right && leftSum == rightSum) {
            return right;
        }
        return -1;
    }
}