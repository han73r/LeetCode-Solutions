public class Solution {
    public int CountBinarySubstrings(string s) {
      int pre = 1, curr = 1, sum = 0;
      for (int i = 1; i < s.Length; i++) {
        if (s[i] == s[i - 1]) {
            curr++;
        } else {
          pre = curr;
          curr = 1;
        }
        if (pre >= curr) 
            sum++;
      }
      return sum;
    }
}
