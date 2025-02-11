using System.Text;

public class Solution {
    public string RemoveOccurrences(string s, string part) {
        var sb = new StringBuilder(s.Length);
        for (int i = 0; i < s.Length; i++) {
            sb.Append(s[i]);
            //Console.WriteLine($"sb:{sb.ToString()}");
            if (s[i] == part[part.Length - 1] && sb.Length >= part.Length) {
                //Console.WriteLine($"DELETE!");
                if (sb.ToString().EndsWith(part))
                    sb.Remove(sb.Length - part.Length, part.Length);
            }
        }
        return sb.ToString();
    }
}