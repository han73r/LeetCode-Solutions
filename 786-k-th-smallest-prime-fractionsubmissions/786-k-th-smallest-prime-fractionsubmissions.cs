using System.Linq;

public class Solution {
    public int[] KthSmallestPrimeFraction(int[] arr, int k) {
        int arraySize = CalculateDigitSum(arr.Length - 1);
        int[][] fractionArray = new int[arraySize][];
        // fill fractionArray 
        int n = 0;
        for (int i = 0; i < arr.Length; i++) {
            for (int j = i + 1; j < arr.Length; j++) {
                fractionArray[n] = new int[] { arr[i], arr[j] };
                n++;
            }

        }
        // sort fracionArray
        var sortedFractionArray = fractionArray.OrderBy(item => (double)item[0] / item[1]).ToArray();
        // return k-th index
        return sortedFractionArray[k - 1];
    }

    private static int CalculateDigitSum(int number, int accumulator = 0) {
        if (number == 0) {
            return accumulator;
        } else {
            return CalculateDigitSum(number - 1, accumulator + number);
        }
    }
}