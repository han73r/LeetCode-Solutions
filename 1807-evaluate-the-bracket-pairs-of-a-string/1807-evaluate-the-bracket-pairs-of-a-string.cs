public class Solution {
    public string Evaluate(string s, IList<IList<string>> knowledge) {
        var dict = new Dictionary<string, string>();
        var addKey = false;
        var key = new StringBuilder();
        var res = new StringBuilder();

        foreach (IList<string> kd in knowledge) {
            dict.Add(kd[0], kd[1]);
        }

        foreach (char c in s) {
            if (c == '(') {
                addKey = true;
            } else if (c == ')') {
                if (dict.ContainsKey(key.ToString())) {
                    res.Append(dict[key.ToString()]);
                } else {
                    res.Append('?');
                }
                addKey = false;
                key.Length = 0;
            } else if (addKey) {
                key.Append(c);
            } else {
                res.Append(c);
            }
        }
        
        return res.ToString();
    }
}
