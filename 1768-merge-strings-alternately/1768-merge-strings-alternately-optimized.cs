using System.Text;

public class Solution {
    public string MergeAlternately(string word1, string word2) {
        var sb = new StringBuilder(word1.Length + word2.Length);
        int firstPoint = 0, secondPoint = 0;
        int firstLength = word1.Length, secondLength = word2.Length;
        while (firstPoint < firstLength && secondPoint < secondLength) {
            sb.Append(word1[firstPoint++]);
            sb.Append(word2[secondPoint++]);
        }
        while (firstPoint < firstLength) sb.Append(word1[firstPoint++]);
        while (secondPoint < secondLength) sb.Append(word2[secondPoint++]);
        return sb.ToString();
    }
}