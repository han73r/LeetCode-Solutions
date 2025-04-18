using System.Text;

public class Solution {
    private static string[] dict = new string[30];
    public string CountAndSay(int n) {
        dict[0] = "1";
        int startIndex = 1;
        while (startIndex < n && dict[startIndex] != null)
            startIndex++;
        for (int i = startIndex; i < n; i++)
            dict[i] = CountNext(dict[i - 1]);
        return dict[n - 1];

    }
    private string CountNext(string s) {
        StringBuilder sb = new StringBuilder();
        int count = 1;
        for (int i = 1; i < s.Length; i++) {
            if (s[i] == s[i - 1]) {
                count++;
            } else {
                sb.Append(count);
                sb.Append(s[i - 1]);
                count = 1;
            }
        }
        sb.Append(count);
        sb.Append(s[s.Length - 1]);
        return sb.ToString();
    }
}