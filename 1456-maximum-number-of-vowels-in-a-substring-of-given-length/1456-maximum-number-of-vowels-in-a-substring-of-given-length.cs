public class Solution {
        public int MaxVowels(string s, int k) {
            int counter = 0;
            int maxCount = 0;
            for (int i = 0; i < k; i++)
                if (IsVowel(s[i])) counter++;
            maxCount = counter;

            for (int i = k; i < s.Length; i++) {
                if (IsVowel(s[i])) counter++;
                if (IsVowel(s[i - k])) counter--;
                maxCount = Math.Max(maxCount, counter);
            }
            return maxCount++;
        }

        private bool IsVowel(char c) {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
}
