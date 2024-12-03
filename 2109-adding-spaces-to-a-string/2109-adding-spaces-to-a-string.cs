public class Solution {
    public string AddSpaces(string s, int[] spaces) {
        var result = new System.Text.StringBuilder();
        int spaceIndex = 0;
        for (int i = 0; i < s.Length; i++) {
            if (spaceIndex < spaces.Length && i == spaces[spaceIndex]) {
                result.Append(' ');
                spaceIndex++;
            }
            result.Append(s[i]);
        }

        return result.ToString();
    }
}