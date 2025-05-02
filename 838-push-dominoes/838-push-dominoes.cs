using System.Text;

public class Solution {
    public string PushDominoes(string dominoes) {
        string result = "";
        while (!result.Equals(dominoes)) {
            result = dominoes;
            dominoes = dominoes.Replace("R.L", "-").Replace(".L", "LL").Replace("R.", "RR");
        }
        return result.Replace("-", "R.L");
    }
}

public class Solution {
    public string PushDominoes(string dominoes) {
        StringBuilder sb = new StringBuilder(dominoes);
        string result = "";
        while (!result.Equals(sb.ToString())) {
            result = sb.ToString();
            sb.Replace("R.L", "-")
              .Replace(".L", "LL")
              .Replace("R.", "RR");
        }
        return sb.ToString().Replace("-", "R.L");
    }
}
