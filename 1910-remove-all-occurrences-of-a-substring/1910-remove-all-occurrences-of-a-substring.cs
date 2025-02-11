using System.Text;

public class Solution {
    public string RemoveOccurrences(string s, string part) {
        var sb = new StringBuilder(s);
        while (sb.ToString().Contains(part)) {
            int index = sb.ToString().IndexOf(part);
            sb.Remove(index, part.Length);
        }
        return sb.ToString();
    }
}