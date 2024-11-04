using System.Text;

public class Solution {
    public string CompressedString(string word) {
        if (string.IsNullOrEmpty(word)) return "";
        var comp = new StringBuilder();
        int i = 0;
        while (i < word.Length) {
            char currentChar = word[i];
            int count = 0;
            while (i < word.Length && word[i] == currentChar && count < 9) {
                count++;
                i++;
            }
            comp.Append(count).Append(currentChar);
        }
        return comp.ToString();
    }
}