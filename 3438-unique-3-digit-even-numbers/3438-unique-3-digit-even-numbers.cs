public class Solution {
    public int TotalNumbers(int[] digits) {
        int[] cntPerDigit = new int[10];
        foreach (int digit in digits) {
            cntPerDigit[digit]++;
        }
        int uniqueDigitsCnt = 0;
        foreach (int cnt in cntPerDigit) {
            if (cnt > 0) uniqueDigitsCnt++;
        }
        int numCnt = 0;
        for (int firstDigit = 1; firstDigit < 10; firstDigit++) {
            int firstCnt = cntPerDigit[firstDigit];
            if (firstCnt == 0) continue;
            for (int thirdDigit = 0; thirdDigit < 10; thirdDigit += 2) {
                int thirdCnt = cntPerDigit[thirdDigit];
                if (thirdCnt == 0) continue;
                if (firstDigit == thirdDigit) {
                    if (firstCnt <= 1) continue;
                    numCnt += uniqueDigitsCnt - (firstCnt == 2 ? 1 : 0);
                } else {
                    numCnt += uniqueDigitsCnt - 
                              (firstCnt == 1 ? 1 : 0) - 
                              (thirdCnt == 1 ? 1 : 0);
                }
            }
        }
        return numCnt;
    }
}
