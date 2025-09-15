using System.Collections.Generic;
using System.Threading.Tasks;

public class Solution {
    public int CanBeTypedWords(string text, string brokenLetters) {
        var typedWordsCounter = 0;
        var brokenTask = StringToHashSet(brokenLetters);
        var words = text.Split(' ');
        foreach (var word in words) {
            var letters = StringToHashSet(word).GetAwaiter().GetResult();
            var originalCount = letters.Count;
            var broken = brokenTask.GetAwaiter().GetResult();
            letters.ExceptWith(broken);
            if (letters.Count == originalCount)
                typedWordsCounter++;
        }
        return typedWordsCounter;
    }

    private Task<HashSet<int>> StringToHashSet(string s) {
        return Task.Run(() => {
            var result = new HashSet<int>();
            foreach (var ch in s)
                result.Add(ch);
            return result;
        });
    }
}