using System.Collections.Generic;
using System.Text;

public class Solution {
    public string CountOfAtoms(string formula) {
        SortedDictionary<string, int> atomsDict = new();
        Stack<SortedDictionary<string, int>> stack = new();
        int i = 0;

        while (i < formula.Length) {
            if (formula[i] == '(') {
                stack.Push(atomsDict);
                atomsDict = new SortedDictionary<string, int>();
                i++;
            } else if (formula[i] == ')') {
                i++;
                int multiplier = GetMultiplier(ref i, formula);
                atomsDict = MergeWithStack(stack, atomsDict, multiplier);
            } else {
                (string atom, int count) = ParseAtomAndCount(ref i, formula);
                if (!atomsDict.ContainsKey(atom)) {
                    atomsDict[atom] = 0;
                }
                atomsDict[atom] += count;
            }
        }

        return FormatResult(atomsDict);
    }

    private int GetMultiplier(ref int i, string formula) {
        int start = i;
        while (i < formula.Length && char.IsDigit(formula[i])) {
            i++;
        }
        return i > start ? int.Parse(formula.Substring(start, i - start)) : 1;
    }

    private SortedDictionary<string, int> MergeWithStack(Stack<SortedDictionary<string, int>> stack, SortedDictionary<string, int> currentDict, int multiplier) {
        if (stack.Count > 0) {
            SortedDictionary<string, int> temp = currentDict;
            currentDict = stack.Pop();
            foreach (var kv in temp) {
                if (!currentDict.ContainsKey(kv.Key)) {
                    currentDict[kv.Key] = 0;
                }
                currentDict[kv.Key] += kv.Value * multiplier;
            }
        }
        return currentDict;
    }

    private (string, int) ParseAtomAndCount(ref int i, string formula) {
        int start = i;
        i++;
        while (i < formula.Length && char.IsLower(formula[i])) {
            i++;
        }
        string atom = formula.Substring(start, i - start);
        start = i;
        while (i < formula.Length && char.IsDigit(formula[i])) {
            i++;
        }
        int count = i > start ? int.Parse(formula.Substring(start, i - start)) : 1;
        return (atom, count);
    }

    private string FormatResult(SortedDictionary<string, int> atomsDict) {
        StringBuilder result = new StringBuilder();
        foreach (var kv in atomsDict) {
            result.Append(kv.Key);
            if (kv.Value > 1) {
                result.Append(kv.Value);
            }
        }
        return result.ToString();
    }
}