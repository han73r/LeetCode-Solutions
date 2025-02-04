using System.Text;

public class Solution {
    public string MergeAlternately(string word1, string word2) {
        var sb = new StringBuilder();
        int firstPoint = 0, secondPoint = 0;
        int firstLength = word1.Length, secondLength = word2.Length;
        while (firstPoint < firstLength && secondPoint < secondLength) {
            sb.Append(word1[firstPoint]);
            sb.Append(word2[secondPoint]);
            firstPoint++;
            secondPoint++;
        }
        if (firstPoint < firstLength)
            sb.Append(word1.Substring(firstPoint));
        if (secondPoint < secondLength)
            sb.Append(word2.Substring(secondPoint));
        return sb.ToString();
    }
}