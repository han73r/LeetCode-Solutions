using System.Collections.Generic;
using System.Linq;

public class Solution {
    private const int Mod = 1000000007;
    private long[,] _coefficientTable;

    public int NumOfWays(int[] nums) {
        GenerateBinomialCoefficientTable(nums.Length);
        return (NumOfWays(nums.ToList()) - 1) % Mod;
    }

    public int NumOfWays(List<int> nums) {
        if (nums.Count <= 2) {
            return 1;
        }

        List<int> left = new();
        List<int> right = new();
        int root = nums[0];

        for (int i = 1; i < nums.Count; i++) {
            if (nums[i] < root) {
                left.Add(nums[i]);
            } else {
                right.Add(nums[i]);
            }
        }

        long waysLeft = NumOfWays(left);
        long waysRight = NumOfWays(right);
        long subtrees = (waysLeft * waysRight) % Mod;
        long binomialCoefficient = _coefficientTable[nums.Count - 1, left.Count];

        return (int)((binomialCoefficient * subtrees) % Mod);
    }

    public void GenerateBinomialCoefficientTable(int size) {
        _coefficientTable = new long[size, size];

        for (int i = 0; i < size; ++i) {
            _coefficientTable[i, 0] = 1;
            _coefficientTable[i, i] = 1;
        }

        for (int i = 2; i < size; i++) {
            for (int j = 1; j < i; j++) {
                _coefficientTable[i, j] = (_coefficientTable[i - 1, j - 1] + _coefficientTable[i - 1, j]) % Mod;
            }
        }
    }
}
