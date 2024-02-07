using System.Text;

public class Solution {
    public string FrequencySort(string s) {
        int[] charFrequency = new int[128];
        char maxChar = '\0';
        int maxFrequency = 0;

        foreach (char ch in s) {
            charFrequency[ch]++;
            if (charFrequency[ch] > maxFrequency) {
                maxFrequency = charFrequency[ch];
                maxChar = ch;
            }
        }
        StringBuilder sb = new StringBuilder();
        while (maxFrequency > 0) {
            for (int i = 0; i < charFrequency.Length; i++) {
                if (charFrequency[i] == maxFrequency) {
                    sb.Append((char)i, charFrequency[i]);
                }
            }
            maxFrequency--;
        }
        return sb.ToString();
    }
}