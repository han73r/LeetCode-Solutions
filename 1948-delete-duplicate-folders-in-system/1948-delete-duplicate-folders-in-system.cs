using System.Collections.Generic;
using System.Text;

public class Trie {
    public string Val;
    public SortedDictionary<string, Trie> Children = new();
    public string ChildrenHash = "";
    public Trie(string val) {
        Val = val;
    }
    public Trie() {
        Children = new SortedDictionary<string, Trie>();
    }
    public void Insert(IList<string> values) {
        Trie t = this;
        foreach (var val in values) {
            if (!t.Children.ContainsKey(val)) {
                t.Children.Add(val, new Trie(val));
            }
            t = t.Children[val];
        }
    }
    public string BuildNodesHash(Trie t, Dictionary<string, int> hashes) {
        StringBuilder st = new StringBuilder();
        foreach (var kv in t.Children) {
            string retHash = BuildNodesHash(kv.Value, hashes);
            st.Append("(");
            st.Append(retHash);
            st.Append(")");
        }
        t.ChildrenHash = st.ToString();
        if (string.IsNullOrEmpty(t.ChildrenHash)) {
            return t.Val;
        }
        //Console.WriteLine($"Built hash {t.ChildrenHash}");
        if (!hashes.ContainsKey(t.ChildrenHash)) {
            hashes.Add(t.ChildrenHash, 0);
        }
        hashes[t.ChildrenHash]++;
        st.Append("_");
        st.Append(t.Val);
        return st.ToString();
    }
}
public class Solution {
    Dictionary<string, int> hashes = new();
    public IList<IList<string>> DeleteDuplicateFolder(IList<IList<string>> paths) {
        Trie trie = new Trie("/");
        foreach (var path in paths) {
            trie.Insert(path);
        }

        trie.BuildNodesHash(trie, hashes);
        List<IList<string>> result = new List<IList<string>>();
        foreach (var childrenKV in trie.Children) {
            CollectUnique(childrenKV.Value, new List<string>(), hashes, result);
        }
        return result;
    }
    private void CollectUnique(Trie t, List<string> path, Dictionary<string, int> hashes, IList<IList<string>> result) {
        if (!string.IsNullOrEmpty(t.ChildrenHash) && hashes[t.ChildrenHash] > 1) {
            return;
        }
        path.Add(t.Val);
        //Console.WriteLine($"Adding to the path {t.Val}");
        result.Add(new List<string>(path));
        foreach (var childKV in t.Children) {
            CollectUnique(childKV.Value, path, hashes, result);
        }
        //Console.WriteLine($"Removing the value {path.Last()}");
        path.RemoveAt(path.Count - 1);
    }
}